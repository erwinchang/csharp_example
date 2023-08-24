## CH6-5 Section

以Section將View自訂的css及js產生到指定位置

Views\Employees\IndexBootstrap.cshtml
```
@section topCSS{
    <style type="text/css">
        th {
            color: white;
            background-color: black;
            text-align: center;
        }

        .table > tbody > tr:hover {
            background-color: antiquewhite;
        }
    </style>
}
@section endJS{ 
    <script type="text/javascript">
        function alertName(name) {
            alert("你的名字是 :" + name);
        }
    </script>
}
```

Views\Shared\_Layout.cshtml
```
    @RenderSection("topCSS",required: false)
    @RenderSection("topJS",required: false)
</head>
...
    @RenderSection("Scripts", required: false)
    @RenderSection("endCSS", required: false)
    @RenderSection("endJS", required: false)
</body>
```

<img src="https://i.imgur.com/rXr3xiB.png" title="" width="500" />

