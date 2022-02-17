# csharp_example

## DataGridView example


```
public class TestPlanTask
{
    public int Id { get; set; }
    public String XTTFileName { get; set; }
    public double TemperatureValue { get; set; }
    public double VoltageValue { get; set; }

    public TestPlanTask(int id, String xttFileName, double temperature,double voltage)
    {
        Id = id;
        XTTFileName = xttFileName;
        TemperatureValue = temperature;
        VoltageValue = voltage;
    }
}
```

![Imgur](https://i.imgur.com/7ydkySm.png)