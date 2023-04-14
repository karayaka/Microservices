using MicroServices.Services.Basket.Dtos;

namespace MicroServices.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasket(string userId);

        Task<bool> SaveOrUpdate(BasketDto basket);

        Task<bool> Delete(string userId);
    }
}
