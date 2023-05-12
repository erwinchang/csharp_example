# mvc example 1


## Ch5

### CH5-3 ViewData

1. 新增PassDataController.cs  
2. 在PassDataController.cs/ Index點右鍵，新增檢視 (將會產生Views/PassData/Index.cshtml)  

### CH5-3-1 

通過ViewData傳送資料  

1. 新增PassViewData分頁

```
https://localhost:44365/PassData/PassViewData
```

PassDataController.cs
```
        public IActionResult PassViewData()
        {
            ViewData["Name"] = "Erwin";
            ViewData["Age"] = 21;
            ViewData["Single"] = true;
            ViewData["Employees"] = empsList;
            return View();
        }
```

PassViewData.cshtml
```
@{
    ViewData["Title"] = "PassViewData";
}

<h1>PassViewData</h1>
<ul>
    <li> Name : @ViewData["Name"]</li>
    <li>Age : @((int)ViewData["Age"]+1)</li>
    <li>Single: @ViewData["Single"]</li>
</ul>
<hr />
<ul>
    @foreach (var item in ViewData)
            {
                <li>@item.Key, @item.Value</li>
            }
</ul>
```
<a href="https://imgur.com/lxEl8jl"><img src="https://i.imgur.com/lxEl8jl.png" title="source: imgur.com" /></a>

### CH5-3-1

ViewData另一個定義方式 ViewDataAttribute  

```
        [ViewData]
        public string Gender { get; set; }

        [ViewData(Key ="Edu")]
        public string Education { get; set; }
```

