using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface ISellerService
    {
        Task<Seller> GetSellerByIdAsync(int id);

        Task<Seller> AddSellerAsync(SellerDTO sellerDTO);

        Task<Seller> UpdateSellerAsync(SellerDTO sellerDTO);

        Task<Seller> DeleteSellerAsync(int id);
    }
}