using System;
using System.Text.Json;
using MicroServices.Services.Basket.Dtos;

namespace MicroServices.Services.Basket.Services
{
	public class BasketService:IBasketService
	{
        private readonly RedisService redisService;

		public BasketService(RedisService _redisService)
		{
            redisService = _redisService;
		}

        public async Task<bool> Delete(string userId)
        {
            try
            {
                return await redisService.GetDb().KeyDeleteAsync(userId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BasketDto> GetBasket(string userId)
        {
            try
            {
                var existBasket = await redisService.GetDb().StringGetAsync(userId);
                if (string.IsNullOrEmpty(existBasket))
                {
                    throw new Exception("Basket Not Fount");
                }
                return JsonSerializer.Deserialize<BasketDto>(existBasket);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveOrUpdate(BasketDto basket)
        {
            try
            {
               return await redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

