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

### CH5_3_2 Model傳遞資料

```
https://localhost:44365/PassData/Model
```

PassDataController.cs
```
        public IActionResult Model()
        {
            //1.呼叫View()方法時，直接將model當成參數傳入
            return View(empsList);

            //2.將model物件指定給ViewData.Model屬性
            //ViewData.Model = empsList;
            //return View();
        }
```

Model.cshtml
```
@model IEnumerable<Employee>
@{
    ViewData["Title"] = "Model";
}

<h1>Model</h1>

<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(model => model.Id);
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Name);
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Phone);
            </th>
            <th>
                @Html.DisplayNameFor(model => model.Email);
            </th>
        </tr>
    </thead>
    <tbody>
@foreach(var item in Model)
            {
        <tr>
            <td>
                @Html.DisplayFor(modleitem => item.Id)
            </td>
            <td>
                @Html.DisplayFor(modleitem => item.Name)
            </td>
            <td>
                @Html.DisplayFor(modleitem => item.Phone)
            </td>
            <td>
                @Html.DisplayFor(modleitem => item.Email)
            </td>
        </tr>
            }
    </tbody>
</table>
```

