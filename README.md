# csharp_example

## 1-1 採用sqlite方式

### 1-1-1 建立sqlite database

test.db
Card資料表
<a href="https://imgur.com/YJV2bNy"><img src="https://i.imgur.com/YJV2bNy.png" title="source: imgur.com" /></a>

資料如下
<a href="https://imgur.com/0mnm276"><img src="https://i.imgur.com/0mnm276.png" title="source: imgur.com" /></a>

### 1-1-2 建立相關程式

1.Repository/CardRepository.cs 
處理sqlite

```
    public class CardRepository
    {
        private readonly string _connectString = "Data Source=D:\\gitWork\\github\\web-api\\test.db;";

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Card> GetList()
```

2.Controllers 處理web router

```
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        /// <summary>
        /// 卡片資料操作
        /// </summary>
        private readonly CardRepository _cardRepository;

        /// <summary>
        /// 建構式
        /// </summary>
        public CardController()
        {
            this._cardRepository = new CardRepository();
        }

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Card> GetList()
        {
            return this._cardRepository.GetList();
```

## 1-2 驗證

注意: 改用chrome驗證，就可以, 原本用ie測試，程式一直跳出(可能js版本不支援)
<a href="https://imgur.com/M3LtUww"><img src="https://i.imgur.com/M3LtUww.png" title="source: imgur.com" width="400px" /></a>
<a href="https://imgur.com/7FvbYwp"><img src="https://i.imgur.com/7FvbYwp.png" title="source: imgur.com" width="400px" /></a>