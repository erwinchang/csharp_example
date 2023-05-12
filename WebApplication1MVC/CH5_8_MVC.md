# csharp_example

## CH5-7 如何指定個別View

1. 新增Views/Shared/_LayoutFriends.cshtml
2. 設定Views/Friends/Index.cshtml
```
@{
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutFriend.cshtml"; #設定個另View
}
```

設定前
<a href="https://imgur.com/zIgYm5Z"><img src="https://i.imgur.com/zIgYm5Z.png" title="source: imgur.com" /></a>

設定後

<a href="https://imgur.com/iqymAMI"><img src="https://i.imgur.com/iqymAMI.png" title="source: imgur.com" /></a>

## CH5-7 Layout

Views/Shared/_Layout.cshtml
```
<body>
    <header>
xx
    </header>
    <div class="container">
        <main role="main" class="pb-3">
            @RenderBody()                      ##採用Controller指定的View.cshtml
        </main>
    </div>

    <footer class="border-top footer text-muted">
xx
    </footer>
    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    <script src="~/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></script>
    <script src="~/js/site.js" asp-append-version="true"></script>
    @RenderSection("Scripts", required: false)
</body>
```

<a href="https://imgur.com/e1KpxCn"><img src="https://i.imgur.com/e1KpxCn.png" title="source: imgur.com" /></a>


Views/_ViewStart.cshtml
```
@{
    Layout = "_Layout";   #MVC預設的佈局檔
}
```

ViewSart.cshtml整合(RenderBody)完成合併動作，最後由Razor View引擎輸出HTML