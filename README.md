# csharp_example

## keyDown Event Handle

注意:可以抓到Ctrl鍵，但不能抓到數字鍵

```
_mainForm.KeyDown += MainFormVM_KeyDown;

private void MainFormVM_KeyDown(object sender, KeyEventArgs e)
{
    Console.WriteLine(e.KeyValue);
}
```