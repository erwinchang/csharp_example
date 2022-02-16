# csharp_example

## [Access Objects in a Windows Forms DataGridViewComboBoxCell Drop-Down List][1]

```
// Populate the combo box drop-down list with Employee objects.
foreach (Employee e in employees) assignedToColumn.Items.Add(e);
```

```
    // Calls the Employee.RequestStatus method.
    void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // Ignore clicks that are not on button cells.
        if (e.RowIndex < 0 || e.ColumnIndex !=
            dataGridView1.Columns["Status Request"].Index) return;

        // Retrieve the task ID.
        Int32 taskID = (Int32)dataGridView1[0, e.RowIndex].Value;
```        

### 範例如下

![image](https://github.com/erwinchang/csharp_example/blob/DataGridView_ex03/gif/DataGridView_ex03.gif)

[1]:https://docs.microsoft.com/en-us/dotnet/desktop/winforms/controls/access-objects-in-a-wf-datagridviewcomboboxcell-drop-down-list?view=netframeworkdesktop-4.8