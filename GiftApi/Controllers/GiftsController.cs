using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GiftApi.Infrastructure;
using GiftApi.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json;

namespace GiftApi.Controllers
{
    [FormatFilter]
    [Route("[controller]")]
    [Route("[controller].{format}")]
    public class GiftsController : Controller
    {
        private readonly IGiftRepository _giftRepository;

        private readonly IDistributedCache _distributedCache;

        public GiftsController(IGiftRepository giftRepository, IDistributedCache distributedCache)
        {
            _giftRepository = giftRepository;
            _distributedCache = distributedCache;
        }

        //[HttpGet]
        //[ResponseCache(Duration = 60)]
        //public async Task<ListResponse<Gift>> GetGifts()
        //{
        //    var cachedResponse = await _distributedCache.GetAsync("giftcloud.gifts");
        //    if (cachedResponse != null)
        //    {
        //        return JsonConvert.DeserializeObject<ListResponse<Gift>>(Encoding.UTF8.GetString(cachedResponse));
        //    }

        //    var gifts = _giftRepository.Gifts;
        //    var results = gifts as Gift[] ?? gifts.ToArray();
        //    var response = new ListResponse<Gift> { Count = results.Length, Total = results.Length, Results = results };
        //    await _distributedCache.SetAsync("giftcloud.gifts",
        //        Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response)),
        //        new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60) });

        //    return response;
        //}

        [HttpGet]
        [ResponseCache(Duration = 60)]
        public ListResponse<Gift> GetGifts()
        {
            var gifts = _giftRepository.Gifts;
            var results = gifts as Gift[] ?? gifts.ToArray();
            return new ListResponse<Gift> { Count = results.Length, Total = results.Length, Results = results };
        }

        //[HttpGet]
        //public IEnumerable<GiftModel> GetGifts() => new[]
        //{
        //    new GiftModel {Id = "amazon", Name = "Amazon.co.uk Gift Card"},
        //    new GiftModel {Id = "currys-pc-world", Name = "Currys PC World Gift Card"}
        //};

        //[HttpGet]
        //public SpecialResponse GetGifts() => new SpecialResponse
        //{
        //    Results = new[]
        //    {
        //        new GiftModel {Id = "amazon", Name = "Amazon.co.uk Gift Card"},
        //        new GiftModel {Id = "currys-pc-world", Name = "Currys PC World Gift Card"}
        //    }
        //};

        //public class SpecialResponse
        //{
        //    public GiftModel[] Results { get; set; }
        //}
    }
}
