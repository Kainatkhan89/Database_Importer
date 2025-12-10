namespace Database_Importer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            flowLayoutPanel1 = new FlowLayoutPanel();
            lAccessConn = new Label();
            label3 = new Label();
            tbAccessConn = new TextBox();
            lSqlConn = new Label();
            label4 = new Label();
            tbSqlConn = new TextBox();
            btnLoadTables = new Button();
            groupBox1 = new GroupBox();
            lcbAccessTable = new Label();
            cbAccessTable = new ComboBox();
            lcbSqlTable = new Label();
            cbSqlTable = new ComboBox();
            btnLoadCols = new Button();
            label5 = new Label();
            dgvMapping = new DataGridView();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnSaveMapping = new Button();
            btnTransformPreview = new Button();
            btnTransfer = new Button();
            btnLoadMapping = new Button();
            dgvPreview = new DataGridView();
            ldgvMapping = new Label();
            ldgvPreview = new Label();
            flowLayoutPanel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMapping).BeginInit();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPreview).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lAccessConn);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(tbAccessConn);
            flowLayoutPanel1.Controls.Add(lSqlConn);
            flowLayoutPanel1.Controls.Add(label4);
            flowLayoutPanel1.Controls.Add(tbSqlConn);
            flowLayoutPanel1.Controls.Add(btnLoadTables);
            flowLayoutPanel1.Location = new Point(12, 61);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1260, 177);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // lAccessConn
            // 
            lAccessConn.AutoSize = true;
            lAccessConn.Location = new Point(3, 0);
            lAccessConn.Name = "lAccessConn";
            lAccessConn.Size = new Size(93, 25);
            lAccessConn.TabIndex = 0;
            lAccessConn.Text = "Access DB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(102, 0);
            label3.Name = "label3";
            label3.Size = new Size(20, 25);
            label3.TabIndex = 4;
            label3.Text = "*";
            // 
            // tbAccessConn
            // 
            tbAccessConn.Location = new Point(3, 28);
            tbAccessConn.Name = "tbAccessConn";
            tbAccessConn.Size = new Size(1254, 31);
            tbAccessConn.TabIndex = 1;
            // 
            // lSqlConn
            // 
            lSqlConn.AutoSize = true;
            lSqlConn.Location = new Point(3, 62);
            lSqlConn.Name = "lSqlConn";
            lSqlConn.Size = new Size(98, 25);
            lSqlConn.TabIndex = 2;
            lSqlConn.Text = "SQL Server";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(107, 62);
            label4.Name = "label4";
            label4.Size = new Size(20, 25);
            label4.TabIndex = 5;
            label4.Text = "*";
            // 
            // tbSqlConn
            // 
            tbSqlConn.Location = new Point(3, 90);
            tbSqlConn.Name = "tbSqlConn";
            tbSqlConn.Size = new Size(1254, 31);
            tbSqlConn.TabIndex = 6;
            // 
            // btnLoadTables
            // 
            btnLoadTables.BackColor = SystemColors.ButtonShadow;
            btnLoadTables.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadTables.Location = new Point(3, 127);
            btnLoadTables.Name = "btnLoadTables";
            btnLoadTables.Size = new Size(1257, 42);
            btnLoadTables.TabIndex = 7;
            btnLoadTables.Text = "Load Database Tables";
            btnLoadTables.UseVisualStyleBackColor = false;
            btnLoadTables.Click += btnLoadTables_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lcbAccessTable);
            groupBox1.Controls.Add(cbAccessTable);
            groupBox1.Controls.Add(lcbSqlTable);
            groupBox1.Controls.Add(cbSqlTable);
            groupBox1.Controls.Add(btnLoadCols);
            groupBox1.Location = new Point(15, 241);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1257, 133);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // lcbAccessTable
            // 
            lcbAccessTable.AutoSize = true;
            lcbAccessTable.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lcbAccessTable.Location = new Point(137, 34);
            lcbAccessTable.Name = "lcbAccessTable";
            lcbAccessTable.Size = new Size(122, 25);
            lcbAccessTable.TabIndex = 15;
            lcbAccessTable.Text = "Access Tables";
            // 
            // cbAccessTable
            // 
            cbAccessTable.FormattingEnabled = true;
            cbAccessTable.Location = new Point(262, 30);
            cbAccessTable.Name = "cbAccessTable";
            cbAccessTable.Size = new Size(361, 33);
            cbAccessTable.TabIndex = 14;
            // 
            // lcbSqlTable
            // 
            lcbSqlTable.AutoSize = true;
            lcbSqlTable.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lcbSqlTable.Location = new Point(642, 34);
            lcbSqlTable.Name = "lcbSqlTable";
            lcbSqlTable.Size = new Size(101, 25);
            lcbSqlTable.TabIndex = 16;
            lcbSqlTable.Text = "SQL Tables";
            // 
            // cbSqlTable
            // 
            cbSqlTable.FormattingEnabled = true;
            cbSqlTable.Location = new Point(748, 31);
            cbSqlTable.Name = "cbSqlTable";
            cbSqlTable.Size = new Size(361, 33);
            cbSqlTable.TabIndex = 17;
            // 
            // btnLoadCols
            // 
            btnLoadCols.BackColor = SystemColors.ButtonShadow;
            btnLoadCols.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoadCols.Location = new Point(6, 79);
            btnLoadCols.Name = "btnLoadCols";
            btnLoadCols.Size = new Size(1248, 42);
            btnLoadCols.TabIndex = 18;
            btnLoadCols.Text = "Load Tables Columns";
            btnLoadCols.UseVisualStyleBackColor = false;
            btnLoadCols.Click += btnLoadCols_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.IndianRed;
            label5.Location = new Point(473, 7);
            label5.Name = "label5";
            label5.Size = new Size(368, 48);
            label5.TabIndex = 16;
            label5.Text = "Data Transformation";
            // 
            // dgvMapping
            // 
            dgvMapping.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMapping.Location = new Point(12, 423);
            dgvMapping.Name = "dgvMapping";
            dgvMapping.RowHeadersWidth = 62;
            dgvMapping.Size = new Size(1260, 270);
            dgvMapping.TabIndex = 17;
            dgvMapping.CellContentClick += dgvMapping_CellContentClick;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(btnSaveMapping);
            flowLayoutPanel2.Controls.Add(btnTransformPreview);
            flowLayoutPanel2.Controls.Add(btnTransfer);
            flowLayoutPanel2.Location = new Point(12, 699);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1260, 59);
            flowLayoutPanel2.TabIndex = 18;
            // 
            // btnSaveMapping
            // 
            btnSaveMapping.Location = new Point(3, 3);
            btnSaveMapping.Name = "btnSaveMapping";
            btnSaveMapping.Size = new Size(144, 43);
            btnSaveMapping.TabIndex = 1;
            btnSaveMapping.Text = "Save JSON";
            btnSaveMapping.UseVisualStyleBackColor = true;
            btnSaveMapping.Click += btnSaveMapping_Click;
            // 
            // btnTransformPreview
            // 
            btnTransformPreview.Location = new Point(153, 3);
            btnTransformPreview.Name = "btnTransformPreview";
            btnTransformPreview.Size = new Size(144, 43);
            btnTransformPreview.TabIndex = 2;
            btnTransformPreview.Text = "Preview";
            btnTransformPreview.UseVisualStyleBackColor = true;
            btnTransformPreview.Click += btnTransformPreview_Click;
            // 
            // btnTransfer
            // 
            btnTransfer.Location = new Point(303, 3);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(144, 43);
            btnTransfer.TabIndex = 3;
            btnTransfer.Text = "Transfer";
            btnTransfer.UseVisualStyleBackColor = true;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnLoadMapping
            // 
            btnLoadMapping.Location = new Point(1107, 383);
            btnLoadMapping.Name = "btnLoadMapping";
            btnLoadMapping.Size = new Size(162, 34);
            btnLoadMapping.TabIndex = 0;
            btnLoadMapping.Text = "Upload JSON";
            btnLoadMapping.UseVisualStyleBackColor = true;
            btnLoadMapping.Click += btnLoadMapping_Click;
            // 
            // dgvPreview
            // 
            dgvPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPreview.Location = new Point(9, 811);
            dgvPreview.Name = "dgvPreview";
            dgvPreview.RowHeadersWidth = 62;
            dgvPreview.Size = new Size(1260, 305);
            dgvPreview.TabIndex = 19;
            // 
            // ldgvMapping
            // 
            ldgvMapping.AutoSize = true;
            ldgvMapping.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ldgvMapping.Location = new Point(18, 389);
            ldgvMapping.Name = "ldgvMapping";
            ldgvMapping.Size = new Size(95, 28);
            ldgvMapping.TabIndex = 20;
            ldgvMapping.Text = "Columns";
            // 
            // ldgvPreview
            // 
            ldgvPreview.AutoSize = true;
            ldgvPreview.Font = new Font("Segoe UI Historic", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ldgvPreview.Location = new Point(21, 778);
            ldgvPreview.Name = "ldgvPreview";
            ldgvPreview.Size = new Size(86, 28);
            ldgvPreview.TabIndex = 21;
            ldgvPreview.Text = "Preview";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 1128);
            Controls.Add(ldgvPreview);
            Controls.Add(ldgvMapping);
            Controls.Add(dgvPreview);
            Controls.Add(btnLoadMapping);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(dgvMapping);
            Controls.Add(label5);
            Controls.Add(groupBox1);
            Controls.Add(flowLayoutPanel1);
            Name = "MainForm";
            Text = "Dynamic Importer";
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMapping).EndInit();
            flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Label lAccessConn;
        private TextBox tbAccessConn;
        private Label lSqlConn;
        private Label label3;
        private Label label4;
        private TextBox tbSqlConn;
        private Button btnLoadTables;
        private GroupBox groupBox1;
        private Label lcbAccessTable;
        private ComboBox cbAccessTable;
        private Label lcbSqlTable;
        private ComboBox cbSqlTable;
        private Button btnLoadCols;
        private Label label5;
        private DataGridView dgvMapping;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnSaveMapping;
        private Button btnTransformPreview;
        private Button btnTransfer;
        private Button btnLoadMapping;
        private DataGridView dgvPreview;
        private Label ldgvMapping;
        private Label ldgvPreview;
    }
}
