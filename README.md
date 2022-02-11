# csharp_example

## HTTP

### [Http Method][2]
HTTP/1.1 協定
定義了八種方法，以不同方式操作指定的資源：

- OPTIONS
這個方法可使伺服器傳回該資源所支援的所有 HTTP 請求方法

- HEAD
可以在不必傳輸全部內容的情況下，就可以取得其中「關於該資源的資訊」
以 html 來說，都有一塊標題或css等資訊，HEAD就是只取這一塊資料

- GET
向指定的資源發出「顯示」請求。使用 GET 方法應該只用在讀取資料

- POST
向指定資源提交資料，請求伺服器進行處理

- PUT：向指定資源位置上傳其最新內容。
- DELETE：請求伺服器刪除 Request-URI 所標識的資源。
- TRACE：回顯伺服器收到的請求，主要用於測試或診斷。
- CONNECT：HTTP/1.1 協定中預留給能夠將連線改為管道方式的代理伺服器


### [如何使用 WebRequest,HttpWebRequest 來存取][1]

1. Get
```
WebRequest request = WebRequest.Create("http://jsonplaceholder.typicode.com/posts");
request.Method = "GET";

//使用 GetResponse 方法將 request 送出，如果不是用 using 包覆，請記得手動 close WebResponse 物件，避免連線持續被佔用而無法送出新的 request
using (var httpResponse = (HttpWebResponse)request.GetResponse())

using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
{
	var result = streamReader.ReadToEnd();
    Console.WriteLine($"result:{result}");
}
```

測試結果如下
```
result:[
  {
    "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
  },
  {
    "userId": 1,
    "id": 2,
    "title": "qui est esse",
    "body": "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
  },
```


<a href="https://imgur.com/nQuxOAm"><img src="https://i.imgur.com/nQuxOAm.png" title="source: imgur.com" style="width:600px;" /></a>

```
GET http://jsonplaceholder.typicode.com/posts HTTP/1.1
Host: jsonplaceholder.typicode.com
Proxy-Connection: Keep-Alive

HTTP/1.1 200 OK
Date: Fri, 11 Feb 2022 02:39:11 GMT
Content-Type: application/json; charset=utf-8
Transfer-Encoding: chunked
x-powered-by: Express
x-ratelimit-limit: 1000
x-ratelimit-remaining: 999
x-ratelimit-reset: 1644201531
access-control-allow-credentials: true
CF-Cache-Status: HIT
Report-To: {"endpoints":[{"url":"https:\/\/a.nel.cloudflare.com\/report\/v3?s=udC5w85262aYFoHytklBaSdqTZ23kVINtheK7LJdOdmdfPaGSbVlaIagBxG5tq%2BrBE318FY4XC6xnQoMTTIcz4HlJEur4nk4ic%2FKlI7Vjj5%2FXoO2Amos2EDhTzBWjpbwl6KQSoq%2FuUAlX9bPBhWy"}],"group":"cf-nel","max_age":604800}
NEL: {"success_fraction":0,"report_to":"cf-nel","max_age":604800}
CF-RAY: 6dba348e1ce40cef-LAX
alt-svc: h3=":443"; ma=86400, h3-29=":443"; ma=86400
vary: Origin, Accept-Encoding
cache-control: max-age=43200
pragma: no-cache
expires: -1
x-content-type-options: nosniff
etag: W/"6b80-Ybsq/K6GwwqrYkAsFxqDXGC7DoM"
via: 1.1 vegur
Age: 28646
Server: cloudflare

6b80
[
  {
    "userId": 1,
    "id": 1,
    "title": "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
    "body": "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
  },
  {
    "userId": 1,
    "id": 2,
    "title": "qui est esse",
    "body": "est rerum tempore vitae\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\nqui aperiam non debitis possimus qui neque nisi nulla"
  },
```


[1]:https://blog.yowko.com/webrequest-and-httpwebrequest/
[2]:https://hackmd.io/@Not/rJoRFJa3S