# csharp_example

## DataGridView取得Task物件資料

[How to: Access Objects in a Windows Forms DataGridViewComboBoxCell Drop-Down List][1]  

1.先設定DataSource

```
private List<Task> tasks = new List<Task>();

dataGridView1.AutoGenerateColumns = false;  //不會自動產生Id欄位
dataGridView1.DataSource = tasks;           //資料內容參考List
```

2.再設定Column內容

```
DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
idColumn.Name = "Task";
idColumn.DataPropertyName = "Id";
idColumn.ReadOnly = true;

dataGridView1.Columns.Add(idColumn);
```

### Task物件

注意一定要定義Get及Set，不然DataGridView要不到資料

```
public class Task
{
    public Task(Int32 id)
    {
        Id = id;
    }
    public int Id { get; set; }
}
```

```
public class Task
{
    public Task(Int32 id)
    {
        idValue = id;
    }

    public Int32 Id
    {
        get { return idValue; }
        set { idValue = value; }
    }
}
```

下列這樣DataGridView會要不到資料

```
public class Task
{
    public Task(Int32 id)
    {
        Id = id;
    }
    public int Id;
}
```


### dataGridView1.AutoGenerateColumns = true如下，會自動產生Id欄位

![Imgur](https://i.imgur.com/qwxc3CN.png)

### dataGridView1.AutoGenerateColumns = false如下，不會自動產生Id欄位

![Imgur](https://i.imgur.com/kcG1RUf.png)

[1]:https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/access-objects-in-a-wf-datagridviewcomboboxcell-drop-down-list?view=netframeworkdesktop-4.8