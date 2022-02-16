using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        //https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/column-fill-mode-in-the-windows-forms-datagridview-control?view=netframeworkdesktop-4.8https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/column-fill-mode-in-the-windows-forms-datagridview-control?view=netframeworkdesktop-4.8
        private DataGridView dataGridView1 = new DataGridView();
        public Form1()
        {
            InitializeComponent();

            dataGridView1.Dock = DockStyle.Fill;
            Controls.Add(dataGridView1);
            InitializeDataGridView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDataGridView()
        {
            AddReadOnlyColumn("HeaderText", "Column");
            AddColumn("AutoSizeMode");
            AddColumn("FillWeight");
            AddColumn("MinimumWidth");
            AddColumn("Width");

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dataGridView1.Columns;

            // Configure the DataGridView so that users can manually change
            // only the column widths, which are set to fill mode.
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersWidthSizeMode =
                DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            // Configure the top left header cell as a reset button.
            dataGridView1.TopLeftHeaderCell.Value = "reset";
            dataGridView1.TopLeftHeaderCell.Style.ForeColor =
                System.Drawing.Color.Blue;


            dataGridView1.CellClick +=
            new DataGridViewCellEventHandler(dataGridView1_CellClick);

            dataGridView1.ColumnWidthChanged += new
            DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);

            dataGridView1.CurrentCellDirtyStateChanged +=
                new EventHandler(dataGridView1_CurrentCellDirtyStateChanged);

            dataGridView1.DataError +=
                new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            dataGridView1.CellEndEdit +=
                new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            dataGridView1.CellValueChanged +=
                new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
        }

        private void dataGridView1_CellValueChanged(
    object sender, DataGridViewCellEventArgs e)
        {
            // Retrieve the property to change.
            String nameOfPropertyToChange =
                dataGridView1.Columns[e.ColumnIndex].Name;
            PropertyInfo propertyToChange =
                typeof(DataGridViewColumn).GetProperty(nameOfPropertyToChange);

            // Retrieve the column to change.
            String nameOfColumnToChange =
                (String)dataGridView1["Column", e.RowIndex].Value;
            DataGridViewColumn columnToChange =
                dataGridView1.Columns[nameOfColumnToChange];

            // Use reflection to update the value of the column property.
            propertyToChange.SetValue(columnToChange,
                dataGridView1[nameOfPropertyToChange, e.RowIndex].Value, null);

            Console.WriteLine("dataGridView1_CellValueChanged");
        }

        private void dataGridView1_DataError(
            object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception == null) return;

            // If the user-specified value is invalid, cancel the change
            // and display the error icon in the row header.
            if ((e.Context & DataGridViewDataErrorContexts.Commit) != 0 &&
                (typeof(FormatException).IsAssignableFrom(e.Exception.GetType()) ||
                typeof(ArgumentException).IsAssignableFrom(e.Exception.GetType())))
            {
                dataGridView1.Rows[e.RowIndex].ErrorText =
                    "The specified value is invalid.";
                e.Cancel = true;
            }
            else
            {
                // Rethrow any exceptions that aren't related to the user input.
                e.ThrowException = true;
            }

            Console.WriteLine("dataGridView1_DataError");
        }

        private void dataGridView1_CellEndEdit(
    object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the error icon in the row header is hidden.
            dataGridView1.Rows[e.RowIndex].ErrorText = "";
            Console.WriteLine("dataGridView1_CellEndEdit");
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(
            object sender, EventArgs e)
        {
            // For combo box and check box cells, commit any value change as soon
            // as it is made rather than waiting for the focus to leave the cell.
            if (!dataGridView1.CurrentCell.OwningColumn.GetType()
                .Equals(typeof(DataGridViewTextBoxColumn)))
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            Console.WriteLine("dataGridView1_CurrentCellDirtyStateChanged");
        }

        private void dataGridView1_ColumnWidthChanged( object sender, DataGridViewColumnEventArgs e)
        {
            // Invalidate the row corresponding to the column that changed
            // to ensure that the FillWeight and Width entries are updated.
            dataGridView1.InvalidateRow(e.Column.Index);
            Console.WriteLine("dataGridView1_ColumnWidthChanged");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 && e.RowIndex == -1)
            {
                ResetDataGridView();
            }
        }


        private void ResetDataGridView()
        {
            dataGridView1.CancelEdit();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            InitializeDataGridView();
        }

        private void AddReadOnlyColumn(String dataPropertyName, String columnName)
        {
            AddColumn(typeof(DataGridViewColumn), dataPropertyName, true,
                columnName);
        }
        private void AddColumn(String dataPropertyName)
        {
            AddColumn(typeof(DataGridViewColumn), dataPropertyName, false,
                dataPropertyName);
        }

        private void AddColumn(
            Type type,
            String dataPropertyName,
            Boolean readOnly,
            String columnName)
        {
            PropertyInfo property = type.GetProperty(dataPropertyName);
            if (property == null) throw new ArgumentException("No accessible " + dataPropertyName + " property was found in the " + type.Name + " type.");

            BrowsableAttribute[] browsables = (BrowsableAttribute[])property.GetCustomAttributes(typeof(BrowsableAttribute), false);

            if (browsables.Length > 0 && !browsables[0].Browsable)
            {
                throw new ArgumentException("The " + dataPropertyName + " property has a " +
                "Browsable(false) attribute, and therefore cannot be bound.");
            }

            DataGridViewColumn column;
            Type valueType = property.PropertyType;
            if (valueType.IsEnum)
            {
                column = new DataGridViewComboBoxColumn();
                ((DataGridViewComboBoxColumn)column).DataSource = Enum.GetValues(valueType);

            }
            else if (valueType.Equals(typeof(Boolean)))
            {
                column = new DataGridViewCheckBoxColumn();
            }
            else
            {
                column = new DataGridViewTextBoxColumn();
            }

            // Initialize and bind the column.
            column.ValueType = valueType;
            column.Name = columnName;
            column.DataPropertyName = dataPropertyName;
            column.ReadOnly = readOnly;

            // Add the column to the control.
            dataGridView1.Columns.Add(column);
        }
    }
}
