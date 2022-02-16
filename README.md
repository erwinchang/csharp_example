# csharp_example

## [在 Windows Form DataGridView 控制項中的資料行填入模式][1]

填滿

```
dataGridView1.Dock = DockStyle.Fill;
```

### 範例如下

![image](https://github.com/erwinchang/csharp_example/blob/DataGridView_ex02/gif/datagridview-ex02.gif)

### 範例如下


```
        // Bind the DataGridView to its own Columns collection.
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.DataSource = dataGridView1.Columns;
```

```
dataGridView1_CellClick
dataGridView1_ColumnWidthChanged
dataGridView1_CurrentCellDirtyStateChanged
dataGridView1_DataError
dataGridView1_CellEndEdit 
dataGridView1_CellValueChanged
```


![image](https://github.com/erwinchang/csharp_example/blob/DataGridView_ex02/gif/DataGridView_ex02-1.gif)


[1]:https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/column-fill-mode-in-the-windows-forms-datagridview-control?view=netframeworkdesktop-4.8
