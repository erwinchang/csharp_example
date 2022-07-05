using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
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
        }
    }
}
