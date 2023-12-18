using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Contracts.Requests.Vat;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Interfaces.IVat
{
    public interface IVatService
    {
        Task<List<VAT>> GetAllVatsAsync();
        Task<VAT> GetVatByIdAsync(int id);
        Task<VAT> CreateVatAsync(VatRequest vatRequest);
        Task<VAT> UpdateVatAsync(int id, VatRequest vatRequest);
        Task SoftDeleteVatAsync(int id);
    }
}
