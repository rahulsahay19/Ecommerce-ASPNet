using System.Threading.Tasks;
using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdatedBasket(ShoppingCart shoppingCart);
        Task DeleteBasket(string userName);
    }
}