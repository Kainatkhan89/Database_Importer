# 🚀 Dynamic Access → SQL Import Tool

A flexible **WinForms-based data migration tool** that imports data from **MS Access (.mdb / .accdb)** into **SQL Server**, using **dynamic column mapping**, **runtime transformations**, and **JSON configuration** — **no code changes required** when schemas change.

---

## ✨ Features

- 🔄 Import data from **MS Access** to **SQL Server**
- 🧩 Dynamic column mapping (Access → SQL)
- 🧮 Runtime data transformations using C# expressions
- 👀 Preview transformed data before import
- ⚡ High-performance insert using `SqlBulkCopy`
- 🧾 JSON-based configuration (`mapping.json`)
- 🔐 Transaction-safe imports with rollback support
- 🗑 Optional truncate-before-insert handling
- 🖥 User-friendly WinForms UI

---

## 📌 Purpose

This tool solves a common problem:

> **Schemas change — code shouldn’t.**

Instead of rewriting migration code for every table or format change, this tool lets you:
- Define mappings in **JSON**
- Modify transformations without recompiling
- Reuse the same import engine for multiple tables

---

## 🏗 Architecture Overview

```md
MS Access (.mdb / .accdb)
        ↓
   Load into DataTable
        ↓
 Apply Mapping + Transform
        ↓
  Preview in UI (Grid)
        ↓
 SQL Transaction
   ├─ Truncate (optional)
   └─ SqlBulkCopy
        ↓
     SQL Server
```
---

## 📁 Project Structure

```md
/DynamicAccessSqlImport
│
├── MainForm.cs        # WinForms UI logic
├── MappingRow.cs      # Mapping DTO
├── mapping.json       # Column mapping configuration
└── README.md          # Documentation
```
---

## 📄 `mapping.json` Format

```json
{
  "AccessTable": "Products",
  "SqlTable": "Products",
  "ColumnMappings": [
    {
      "AccessColumn": "prod_id",
      "SqlColumn": "ProductID",
      "Transform": "(x - 901000) + 901001000"
    },
    {
      "AccessColumn": "prod_desc",
      "SqlColumn": "ProductDesc",
      "Transform": "x"
    },
    {
      "AccessColumn": "",
      "SqlColumn": "CompanyID",
      "Transform": "1"
    }
  ]
}
```
---

## 🔑 Mapping Fields Explained
#### AccessColumn

- Column name from Access table

- Leave empty (`""`) if SQL column uses a constant or default

#### SqlColumn

- Destination column in SQL Server

#### Transform

- A C# expression

- Variable `x` represents the Access value

- Evaluated at runtime using DynamicExpresso

---

## 📌 Transformation Examples

| Purpose | Expression |
|--------|------------|
| Keep value | `x` |
| Convert to int | `Convert.ToInt32(x)` |
| Convert to decimal | `Convert.ToDecimal(x)` |
| Change format | `x.ToString().PadLeft(4, '0')` |
| Add prefix | `"PRD-" + x` |
| Create new IDs | `(x - 901000) + 901001000` |
| Constant value | `1` |
| Null value | `null` |

--- 

## 🔁 How Transformations Work

This project uses DynamicExpresso to evaluate expressions at runtime.

Example:
```json
"Transform": "(x - 901000) + 901001000"
```

If the Access value is:
```text
x = 901005
```

Result:
```text
901001005
```
---

## 🧭 User Workflow
#### ✔ Step 1: Select Access Database

Choose `.mdb` or `.accdb` file.

#### ✔ Step 2: Select Access Table

Tables are auto-loaded from schema.

#### ✔ Step 3: Select SQL Table

Columns are loaded from SQL metadata.

#### ✔ Step 4: Load mapping.json

Populates the mapping grid.

#### ✔ Step 5: Preview Transformation

View transformed SQL-ready data.

#### ✔ Step 6: Import to SQL

Runs inside a transaction using `SqlBulkCopy`.

## 🔐 Transactions & Foreign Keys

- Import runs inside a SQL transaction

- Optional `TRUNCATE TABLE` before insert

- Rollback occurs automatically on failure

- FK constraints are preserved safely

---

## ⚠ Common Mistakes to Avoid

❌ Wrong Access column name (case-sensitive)

❌ Invalid C# expressions

❌ Missing quotes in string literals

❌ Data type mismatch in SQL column

---

## 🧪 Example: Constant SQL Column

SQL column exists but Access doesn’t:

```json
{
  "AccessColumn": "",
  "SqlColumn": "CompanyID",
  "Transform": "1"
}
```
Result: every row gets `CompanyID = 1`.

---

## 🔮 Future Enhancements

Planned or optional improvements:

- ✅ Supporting more databases than just Access and SQL Server

- ✅ Auto-generate mappings from schema

- ✅ Expression validation before import

- ✅ Date formatting helpers

- ✅ Multi-table batch import

- ✅ Logging & audit trail

---

## 📦 Dependencies

- .NET Framework / .NET 6+

- `System.Data.OleDb`

- `Microsoft.Data.SqlClient`

- `DynamicExpresso.Core`

---

## 🧑‍💻 Author

**Kainat Khan**  
Software Engineer  

This project was developed to demonstrate dynamic data migration, transformation,
and bulk import patterns using C#, WinForms, MS Access, and SQL Server.
