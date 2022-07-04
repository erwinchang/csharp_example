# csharp_example

### 1-1 使用card物件當database範例


```
[HttpGet]
[Route("{id}")]
public Card Get([FromRoute] int id)
{
    return _cards.FirstOrDefault(card => card.Id == id);
}
```

注意: [FromRoute] 的屬性來告訴 API 說 int id 這個參數是來自於 Route 上的


```
[HttpPost]
public IActionResult Insert([FromBody] CardParameter parameter)
{
    _cards.Add(new Card
    {
        Id = _cards.Any() 
          ? _cards.Max(card => card.Id) + 1
          : 0, // 臨時防呆，如果沒東西就從 0 開始
        Name = parameter.Name,
        Description = parameter.Description
    });

    return Ok();
}
```

Ok() 一樣是 200 的狀態
此外還有代表 400 的 BadRequest()
404 的 NotFound()

我們也不是每次都會回傳 IActionResult

### 1-2 使用 PowerShell 測試方式

1.使用 PowerShell POST 
來新增資料( /card , Insert)
```
PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card `
>>  -Method 'POST' `
>>  -Headers @{ "Content-Type" = "application/json"; } `
>>  -Body "{`"name`": `"mycard`",`"description`": `"sample card`"}"
```
2.使用 PowerShell PUT
來查訊資料(/card, Read)
```
PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card/0 `
>>  -Method 'PUT' `
>>  -Headers @{ "Content-Type" = "application/json"; } `
>>  -Body "{`"name`": `"ourcard`",`"description`": `"sample card`"}"
```

3.使用 PowerShell Delete
來刪除資料
```
PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card/0 `
>>  -Method 'DELETE'
```

### 1-3 測試如下

```
PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card `
>>  -Method 'POST' `
>>  -Headers @{ "Content-Type" = "application/json"; } `
>>  -Body "{`"name`": `"mycard`",`"description`": `"sample card`"}"

PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card | ConvertTo-Json
{
    "value":  [
                  {
                      "id":  0,
                      "name":  "mycard",
                      "description":  "sample card"
                  }
              ],
    "Count":  1
}
PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card/0 `
>>  -Method 'PUT' `
>>  -Headers @{ "Content-Type" = "application/json"; } `
>>  -Body "{`"name`": `"ourcard`",`"description`": `"sample card`"}"

PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card | ConvertTo-Json
{
    "value":  [
                  {
                      "id":  0,
                      "name":  "ourcard",
                      "description":  "sample card"
                  }
              ],
    "Count":  1
}
PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card/0 | ConvertTo-Json
{
    "id":  0,
    "name":  "ourcard",
    "description":  "sample card"
}
PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card/1 | ConvertTo-Json
""
PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card/0 `
>>  -Method 'DELETE'

PS C:\Users\tw029664> Invoke-RestMethod https://localhost:5001/card | ConvertTo-Json
{
    "value":  [

              ],
    "Count":  0
}
PS C:\Users\tw029664>
```

### 1-4 參考範例


- [認識 Api & 使用 .net Core 來建立簡單的 Web Api 服務吧][1]  

[1]:https://igouist.github.io/post/2021/05/newbie-2-webapi/