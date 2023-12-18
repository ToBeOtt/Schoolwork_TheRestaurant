using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.IVat
{
    public interface IVatRepository
    {
        Task<List<VAT>> GetAllAsync();
        Task<VAT> GetByIdAsync(int id);
        Task<VAT> AddAsync(VAT vat);
        Task UpdateAsync(VAT vat);
        Task SoftDeleteAsync(int id);
    }
}
