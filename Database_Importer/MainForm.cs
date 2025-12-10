using DynamicExpresso;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Data.OleDb;

namespace Database_Importer
{
    public partial class MainForm : Form
    {
        List<string> accessColumns = new List<string>();
        List<string> sqlColumns = new List<string>();
        public MainForm()
        {
            InitializeComponent();

            // Setup mapping grid
            dgvMapping.Columns.Clear();
            var colAccess = new DataGridViewComboBoxColumn { Name = "AccessColumn", HeaderText = "Access Column", Width = 350 };
            var colSql = new DataGridViewComboBoxColumn { Name = "SqlColumn", HeaderText = "SQL Column", Width = 350 };
            var colExpr = new DataGridViewTextBoxColumn { Name = "Transform", HeaderText = "Transform Expression (use 'x')", Width = 350 };
            var colDelete = new DataGridViewButtonColumn { Name = "Delete", HeaderText = "Delete", Text = "Delete", UseColumnTextForButtonValue = true, Width = 100 };
            colAccess.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colSql.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            dgvMapping.Columns.Add(colAccess);
            dgvMapping.Columns.Add(colSql);
            dgvMapping.Columns.Add(colExpr);
            dgvMapping.Columns.Add(colDelete);

            btnLoadMapping.Enabled = false;

            tbAccessConn.Text = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\kaina\\Downloads\\1Transfer\\1Transfer.mdb;";
            tbSqlConn.Text = "Server=localhost\\SQLEXPRESS;Database=aspnet-MCCarSystem;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

        }


        private void btnLoadTables_Click(object sender, EventArgs e)
        {
            // populate table lists on load
            LoadAccessTablesIntoCombo();
            LoadSqlTablesIntoCombo();

            MessageBox.Show("Tables loaded. Select tables and load columns.");
        }

        // Load table names for Access
        private void LoadAccessTablesIntoCombo()
        {
            try
            {
                string conn = tbAccessConn.Text.Trim();
                using (OleDbConnection con = new OleDbConnection(conn))
                {
                    con.Open();
                    var dt = con.GetSchema("Tables");
                    cbAccessTable.Items.Clear();
                    foreach (DataRow r in dt.Rows)
                    {
                        string tableType = r[3].ToString();
                        if (tableType == "TABLE" || tableType == "TABLE ")
                        {
                            cbAccessTable.Items.Add(r[2].ToString());
                        }
                    }
                    if (cbAccessTable.Items.Count > 0) cbAccessTable.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Access tables: " + ex.Message);
            }
        }

        // Load table names for SQL Server
        private void LoadSqlTablesIntoCombo()
        {
            try
            {
                string conn = tbSqlConn.Text.Trim();
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    DataTable dt = con.GetSchema("Tables");
                    cbSqlTable.Items.Clear();
                    foreach (DataRow r in dt.Rows)
                    {
                        // Table schema/table name
                        string tableName = r[2].ToString();
                        cbSqlTable.Items.Add(tableName);
                    }
                    if (cbSqlTable.Items.Count > 0) cbSqlTable.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading SQL tables: " + ex.Message);
            }
        }

        private void btnLoadCols_Click(object sender, EventArgs e)
        {
            LoadAccessCols();
            LoadSqlCols();
            btnLoadMapping.Enabled = true;
        }

        private void LoadAccessCols()
        {
            string conn = tbAccessConn.Text.Trim();
            string table = cbAccessTable.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(table)) { MessageBox.Show("Select Access table"); return; }


            try
            {
                using (OleDbConnection con = new OleDbConnection(conn))
                {
                    con.Open();
                    DataTable dt = con.GetSchema("Columns", new string[] { null, null, table, null });
                    accessColumns = dt.AsEnumerable().Select(r => r.Field<string>("COLUMN_NAME")).ToList();


                    // update combo column items
                    var accessCol = (DataGridViewComboBoxColumn)dgvMapping.Columns["AccessColumn"];
                    accessCol.Items.Clear();
                    accessCol.Items.Add(""); // empty option
                    accessCol.Items.AddRange(accessColumns.ToArray());


                    MessageBox.Show($"Loaded {accessColumns.Count} columns from Access table {table}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Access columns: " + ex.Message);
            }
        }

        private void LoadSqlCols()
        {
            string conn = tbSqlConn.Text.Trim();
            string table = cbSqlTable.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(table)) { MessageBox.Show("Select SQL table"); return; }


            try
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    con.Open();
                    DataTable dt = con.GetSchema("Columns", new string[] { null, null, table, null });
                    sqlColumns = dt.AsEnumerable().Select(r => r.Field<string>("COLUMN_NAME")).ToList();


                    var sqlCol = (DataGridViewComboBoxColumn)dgvMapping.Columns["SqlColumn"];
                    sqlCol.Items.Clear();
                    sqlCol.Items.Add(""); // empty option
                    sqlCol.Items.AddRange(sqlColumns.ToArray());


                    MessageBox.Show($"Loaded {sqlColumns.Count} columns from SQL table {table}.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading SQL columns: " + ex.Message);
            }
        }

        private void btnSaveMapping_Click(object sender, EventArgs e)
        {
            var cfg = new MappingConfig();
            cfg.AccessTable = cbAccessTable.SelectedItem?.ToString();
            cfg.SqlTable = cbSqlTable.SelectedItem?.ToString();


            foreach (DataGridViewRow row in dgvMapping.Rows)
            {
                if (row.IsNewRow) continue;
                var acc = row.Cells[0].Value?.ToString();
                var sql = row.Cells[1].Value?.ToString();
                var expr = row.Cells[2].Value?.ToString();
                if (string.IsNullOrEmpty(acc) || string.IsNullOrEmpty(sql)) continue;
                cfg.Mappings.Add(new MappingRow { AccessColumn = acc, SqlColumn = sql, TransformExpression = expr });
            }


            var sfd = new SaveFileDialog { Filter = "JSON Files|*.json", FileName = "mapping.json" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, JsonConvert.SerializeObject(cfg, Formatting.Indented));
                MessageBox.Show("Mapping saved.");
            }
        }

        private void btnLoadMapping_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog { Filter = "JSON Files|*.json" };
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var cfg = JsonConvert.DeserializeObject<MappingConfig>(File.ReadAllText(ofd.FileName));
            if (cfg == null) return;


            // Select tables if present
            if (!string.IsNullOrEmpty(cfg.AccessTable) && cbAccessTable.Items.Contains(cfg.AccessTable)) cbAccessTable.SelectedItem = cfg.AccessTable;
            if (!string.IsNullOrEmpty(cfg.SqlTable) && cbSqlTable.Items.Contains(cfg.SqlTable)) cbSqlTable.SelectedItem = cfg.SqlTable;


            // Ensure columns lists are loaded for dropdowns
            LoadAccessCols();
            LoadSqlCols();


            dgvMapping.Rows.Clear();
            foreach (var m in cfg.Mappings)
            {
                dgvMapping.Rows.Add(m.AccessColumn, m.SqlColumn, m.TransformExpression);
            }


            MessageBox.Show("Mapping loaded into grid. Verify and click Preview.");
        }

        private void btnTransformPreview_Click(object sender, EventArgs e)
        {
            try
            {
                string accessConn = tbAccessConn.Text.Trim();
                string sqlConn = tbSqlConn.Text.Trim();
                string accessTable = cbAccessTable.SelectedItem?.ToString();
                string sqlTable = cbSqlTable.SelectedItem?.ToString();


                if (string.IsNullOrEmpty(accessTable) || string.IsNullOrEmpty(sqlTable)) { MessageBox.Show("Select both tables"); return; }


                var accessDT = LoadAccessData(accessConn, accessTable);
                var sqlDT = BuildSqlSchema(sqlConn, sqlTable);


                ApplyMappingAndTransforms(accessDT, sqlDT);


                dgvPreview.DataSource = sqlDT;
                MessageBox.Show("Preview ready. Verify then Transfer.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during preview: " + ex.Message);
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                string accessConn = tbAccessConn.Text.Trim();
                string sqlConn = tbSqlConn.Text.Trim();
                string accessTable = cbAccessTable.SelectedItem?.ToString();
                string sqlTable = cbSqlTable.SelectedItem?.ToString();


                if (string.IsNullOrEmpty(accessTable) || string.IsNullOrEmpty(sqlTable)) { MessageBox.Show("Select both tables!!!"); return; }


                var accessDT = LoadAccessData(accessConn, accessTable);
                var sqlDT = BuildSqlSchema(sqlConn, sqlTable);


                ApplyMappingAndTransforms(accessDT, sqlDT);

                using (SqlConnection sqlCon = new SqlConnection(sqlConn))
                {
                    sqlCon.Open();

                    using (SqlTransaction transaction = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            string table = sqlTable; // mapped from JSON

                            // Disable constraints
                            using (SqlCommand cmd = new SqlCommand(
                                $"ALTER TABLE {table} NOCHECK CONSTRAINT ALL;", sqlCon, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Delete existing rows
                            using (SqlCommand cmd = new SqlCommand(
                                $"DELETE FROM {table};", sqlCon, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Bulk insert new data
                            using (SqlBulkCopy bulk = new SqlBulkCopy(sqlCon, SqlBulkCopyOptions.Default, transaction))
                            {
                                bulk.DestinationTableName = table;

                                // Map columns by name
                                foreach (DataColumn c in sqlDT.Columns)
                                {
                                    bulk.ColumnMappings.Add(c.ColumnName, c.ColumnName);
                                }

                                bulk.WriteToServer(sqlDT);
                            }

                            // Re-enable constraints
                            using (SqlCommand cmd = new SqlCommand(
                                $"ALTER TABLE {table} WITH CHECK CHECK CONSTRAINT ALL;", sqlCon, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }

                            // Commit
                            transaction.Commit();
                            MessageBox.Show("Data transferred successfully!");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Import failed: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during transfer: " + ex.Message);
            }
        }

        private DataTable LoadAccessData(string accessConn, string accessTable)
        {
            var dt = new DataTable();
            using (OleDbConnection con = new OleDbConnection(accessConn))
            {
                con.Open();
                string q = $"SELECT * FROM [{accessTable}]";
                using (OleDbDataAdapter da = new OleDbDataAdapter(q, con))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        // Create an empty datatable with SQL schema (column names and types)
        private DataTable BuildSqlSchema(string sqlConn, string sqlTable)
        {
            var dt = new DataTable();
            using (SqlConnection con = new SqlConnection(sqlConn))
            {
                con.Open();
                // Use zero-rows query to get schema
                using (SqlCommand cmd = new SqlCommand($"SELECT TOP 0 * FROM [{sqlTable}]", con))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }
        private void ApplyMappingAndTransforms(DataTable accessDT, DataTable sqlDT)
        {
            sqlDT.Rows.Clear();

            // Build mapping list from grid
            var maps = new List<MappingRow>();
            foreach (DataGridViewRow row in dgvMapping.Rows)
            {
                if (row.IsNewRow) continue;
                var acc = row.Cells[0].Value?.ToString();
                var sql = row.Cells[1].Value?.ToString();
                var expr = row.Cells[2].Value?.ToString();
                if (string.IsNullOrEmpty(acc) || string.IsNullOrEmpty(sql)) continue;
                maps.Add(new MappingRow { AccessColumn = acc, SqlColumn = sql, TransformExpression = expr });
            }


            // Prepare expression interpreter (DynamicExpresso)
            var interpreter = new Interpreter();
            foreach (DataRow aRow in accessDT.Rows)
            {
                var newRow = sqlDT.NewRow();


                foreach (var m in maps)
                {
                    object val = DBNull.Value;
                    if (accessDT.Columns.Contains(m.AccessColumn))
                        val = aRow[m.AccessColumn];


                    // If transform expression provided - evaluate with variable 'x'
                    if (!string.IsNullOrWhiteSpace(m.TransformExpression))
                    {
                        try
                        {
                            // pass 'x' and allow null handling
                            interpreter.SetVariable("x", val);
                            var result = interpreter.Eval(m.TransformExpression);
                            newRow[m.SqlColumn] = result ?? DBNull.Value;
                        }
                        catch (Exception ex)
                        {
                            // On evaluation failure, place original value (or DBNull)
                            newRow[m.SqlColumn] = val ?? DBNull.Value;
                        }
                    }
                    else
                    {
                        // Direct copy (with type conversion if necessary)
                        if (val == DBNull.Value) newRow[m.SqlColumn] = DBNull.Value;
                        else
                        {
                            // Try to convert to target column type
                            try
                            {
                                var targetType = sqlDT.Columns[m.SqlColumn].DataType;
                                newRow[m.SqlColumn] = Convert.ChangeType(val, targetType);
                            }
                            catch
                            {
                                newRow[m.SqlColumn] = val;
                            }
                        }
                    }
                }


                // You can set static default values here if needed
                // e.g. newRow["CompanyID"] = 1;


                sqlDT.Rows.Add(newRow);
            }
        }

        private void dgvMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMapping.Columns[e.ColumnIndex].Name == "Delete")
            {
                if(MessageBox.Show("Delete this mapping row?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    dgvMapping.Rows.RemoveAt(e.RowIndex);
            }
        }

    }

    public class MappingRow
    {
        public string AccessColumn { get; set; }
        public string SqlColumn { get; set; }
        public string TransformExpression { get; set; } // e.g. "(x - 901000) + 901001000" or "x == null ? 0 : x"
    }


    public class MappingConfig
    {
        public string AccessTable { get; set; }
        public string SqlTable { get; set; }
        public List<MappingRow> Mappings { get; set; } = new List<MappingRow>();
        public Dictionary<string, object> StaticValues { get; set; } = new Dictionary<string, object>();
    }
}
