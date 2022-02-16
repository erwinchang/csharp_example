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
