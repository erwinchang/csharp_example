using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharp_example
{
    public partial class Form1 : Form
    {
        List<Person> peopleList = new List<Person>();
        BindingSource source = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            IntilalizePeopleList();

            //https://entityframework.net/knowledge-base/2015327/how-to-refresh-the-datasource-on-a-winforms-datagridview-
            source.DataSource = peopleList;
            dataGridView1.DataSource = source;

            //https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.forms.bindingsource.resetbindings?view=windowsdesktop-6.0
            //使得繫結至 BindingSource 的控制項重新讀取清單中的所有項目，並重新整理其顯示的值
            //如果資料結構描述已變更，則為 true；如果只是變更值，則為 fals
            source.ResetBindings(false);

            //people.CollectionChanged += BindingToObservableCollection_Load;

            //dataGridView1.DataSource = people;
        }
        private void IntilalizePeopleList()
        {
            peopleList.Add(new Person("Johnathan", "Gartner", 45));
            peopleList.Add(new Person("Jeannine", "Richart", 25));
            peopleList.Add(new Person("Merry", "Sparacino", 15));
            peopleList.Add(new Person("Sandi", "Willman", 32));
            peopleList.Add(new Person("Damion", "Dagley", 51));
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            peopleList.Add(new Person("Damion", "Dagley", 51));
            source.ResetBindings(false);
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (peopleList.Count > 0)
            {
                peopleList.RemoveAt(0);
                source.ResetBindings(false);
            }
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/450233/generic-list-moving-an-item-within-the-list
            Person temp = peopleList[peopleList.Count - 1];
            peopleList.RemoveAt(peopleList.Count-1);
            peopleList.Insert(0, temp);
            source.ResetBindings(false);
        }

    }
}
