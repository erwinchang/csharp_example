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

### CH5_3_3

```
https://localhost:44365/PassData/PetShop
```

PassDataController.cs
```
        public IActionResult PetShop()
        {
            //1.使用ViewData傳遞資料到View
            ViewData["Company"] = "汪星人寵物店";

            //2.使用ViewBag傳遞資料到View
            ViewBag.Address = "台北市信義區松山路100號";

            //宣告一個List泛型集合,代表model資料模型
            List<string> petsList = new List<string>();
            petsList.Add("狗");
            petsList.Add("猫");
            petsList.Add("魚");
            petsList.Add("鼠");
            petsList.Add("變色龍");

            //3.將petSList資料模型指派給ViewData.Model屬性, 傳遞到View
            ViewData.Model = petsList;

            return View();

            //實際上傳送model物件給View,會更常使用View(petsList)語法取代
            //return View(petsList);
        }
```

PetShop.cshtml
```
@model List<string>
@{
    ViewData["Title"] = "Index";
}

<h1>PetShop</h1>

公司名稱: @ViewData["Company"]
<br />
公司地址: @ViewBag.Address
<br />

販賣的寵物有:
<br />

<ul>
    @foreach(var pet in Model)
            {
                <li>@pet</li>
            }
</ul>
```
