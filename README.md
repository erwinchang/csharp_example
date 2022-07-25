# csharp_example


## WPF

### 5.4.3 StackPane

會自動排列選單內容

```
<Grid>
    <GroupBox Header="multiple choice" BorderBrush="Black" Margin="5">
        <StackPanel Margin="5">
            <CheckBox Content="A ItemAA"/>
            <CheckBox Content="B ItemBB"/>
            <CheckBox Content="C ItemCC"/>
            <StackPanel Orientation="Horizontal" HorizontalAlignment="Right">
                <Button Content="Clear" Width="60" Margin="5"/>
                <Button Content="Submit" Width="60" Margin="5"/>
            </StackPanel>
        </StackPanel>
    </GroupBox>
</Grid>
```

<a href="https://imgur.com/iJyN6Vc"><img src="https://i.imgur.com/iJyN6Vc.png" title="source: imgur.com" /></a>








