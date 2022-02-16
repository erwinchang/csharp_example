# csharp_example

## DataGridView

[C# WinForm 動態產生 DataGridView，動態新增資料][1]  

要顯示資料很簡單，先把資料儲存在DataTable中，之後再讓DataGridView直接顯示DataTable的所有資料即可  

```
DataTable dataTable = new DataTable();
dataTable.Columns.Add("id", typeof(int));
dataTable.Columns.Add("name", typeof(string));
dataGridView.DataSource = dataTable;
```

[1]:https://www.ruyut.com/2021/12/c-winform-datagridview.html