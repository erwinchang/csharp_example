# mvc example 1


## Ch5_3_2 ViewBag


若ViewData與ViewBag同時使用，記得key要分開
採用ViewBag好處
1.資料不需做轉型

```
https://localhost:44365/PassData/PassViewBag
```

PassDataController.cs
```
        public IActionResult PassViewBag()
        {
            ViewBag.Nickname = "Mary";
            ViewBag.Height = 168;
            ViewBag.Weight = 52;
            ViewBag.Married = false;
            ViewBag.EmpsList = empsList;
            return View();
        }
```

PassViewBag.cshtml
```
<h1>PassViewBag</h1>
<ul>
    <li>Name: @ViewBag.Nickname</li>
    <li>Height: @ViewBag.Height</li>
    <li>Weight: @ViewBag.Weight</li>
    <li>Married: @ViewBag.Married</li>
</ul>
```