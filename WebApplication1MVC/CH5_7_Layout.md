# csharp_example

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