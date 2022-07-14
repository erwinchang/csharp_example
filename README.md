# csharp_example

此範例採用方式二: BindingList及資料物件採用INotifyPropertyChanged

##　DataGridView綁定資料自動更新方式

### 方式一: 採用List 及ResetBindings

缺點每次更新完資料都要執行及ResetBindings

```
List<Person> people = new List<Person>();
IntilalizePeopleList();

BindingSource source = new BindingSource();
source.DataSource = peopleList;
dataGridView1.DataSource = source;
source.ResetBindings(false);
```

---------

###　方式二: BindingList及資料物件採用INotifyPropertyChanged

好處，資料物件內容有只更，自動會更新DataGridView


```
private BindingSource customersBindingSource = new BindingSource();

BindingList<DemoCustomer> customerList = new BindingList<DemoCustomer>();
customersBindingSource.DataSource = customerList;
dataGridView1.DataSource = customersBindingSource;
```


資料物件使用介面INotifyPropertyChanged

```
 public class DemoCustomer : INotifyPropertyChanged
    {
        private string customerNameValue = String.Empty;
        private string phoneNumberValue = String.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string CustomerName
        {
            get
            {
                return this.customerNameValue;
            }

            set
            {
                if (value != this.customerNameValue)
                {
                    this.customerNameValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumberValue;
            }

            set
            {
                if (value != this.phoneNumberValue)
                {
                    this.phoneNumberValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
        ...
    }
```

參考來源:  
[作法：使用 BindingSource 和 INotifyPropertyChanged 介面引發變更通知][1]  

[1]:https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/raise-change-notifications--bindingsource?view=netframeworkdesktop-4.8