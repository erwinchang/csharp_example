# csharp_example

## DataGridView 綁定資料自動更新

採用BindingSource方式  
再更新完List之後需要再設定ResetBindings一次才更新(這個比較麻煩)  


### 1.定義資料物件格式

```
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
```

### 2.建立連結

- 建立資料List<T>以供DataGridView使用  

- ResetBindings(false)  
使得繫結至 BindingSource 的控制項重新讀取清單中的所有項目，並重新整理其顯示的值  
如果資料結構描述已變更，則為 true；如果只是變更值，則為 fals  


```
List<Person> people = new List<Person>();
IntilalizePeopleList();

BindingSource source = new BindingSource();
source.DataSource = peopleList;
dataGridView1.DataSource = source;
source.ResetBindings(false);
```	

### 3.更新資料

通過ResetBindings更新資料  

```
peopleList.Add(new Person("Damion", "Dagley", 51));
source.ResetBindings(false);
```


參考來源 :  
[On a WinForms DataGridView, how do you refresh the DataSource?]  



[1]:https://entityframework.net/knowledge-base/2015327/how-to-refresh-the-datasource-on-a-winforms-datagridview-