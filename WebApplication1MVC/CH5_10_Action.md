# csharp_example


### CH5-11-2 ViewResult動作結果

1.Action中的View(),實際是用Controller.View()

```
Controller.View(){
	return new ViewResult()
}
```

### 寫法注意地方

```
public ViewResult Index2(){   #可用IactionReuslt替代
	return new ViewResult()   #可用View()替代
}
```


## CH5-10 Action

下例IActionResult亦可用ActionResult替代，二者效果相同
但以ASP.NET會優先使用IActionResult
```
    public class ProductsNewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult ProductDetails()
        {
            return View();
        }
    }
```

IActionResult  與 ActionResult
```
    public interface IActionResult
    {
        Task ExecuteResultAsync(ActionContext context);
    }

    public abstract class ActionResult : IActionResult
    {
        protected ActionResult();
        public virtual void ExecuteResult(ActionContext context);
        public virtual Task ExecuteResultAsync(ActionContext context);
    }    
```

IActionResult  與 ActionResult 衍生類 

| Action Result類型 | Controller內建對應的方法 | |
|:------------------|:------------------------|:---|
| ViewResult  | View(..) | 回傳VewResult物件|
| ParitalViewResult | PartialView(..) | 回傳ParitalViewResult物件 |
| ContentResult | Content(...) | 回傳文字訊息內容 |
| EmptyResult | new EmptyResult() or null | 不回傳任何值 |
| JsonResult | Json(..) | |
| FileResult | File(..) | |
| RedirectResult | Redict(..) 302, RedirectPermanent() 301 | |
| RedirectToActionReult | RedirectToAction(..) | 導向另一個Action方法 |
| RedirectToRouteResult | RedirectToRoute(..) | |
| StatusCodeResult |new StatusCodeResult(..) | |
| ObjectResult | new ObjectResult ||

