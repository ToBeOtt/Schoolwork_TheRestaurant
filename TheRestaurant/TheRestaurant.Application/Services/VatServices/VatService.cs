using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Application.Interfaces.IVat;
using TheRestaurant.Contracts.Requests.Vat;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Services.VatServices
{
    public class VatService : IVatService
    {
        private readonly IVatRepository _vatRepository;
        public VatService(IVatRepository vatRepository)
        {
            _vatRepository = vatRepository;
        }
        public async Task<VAT> CreateVatAsync(VatRequest vatRequest)
        {
            var vat = new VAT
            {
                Name = vatRequest.Name,
                Adjustment = vatRequest.Adjustment
            };
            await _vatRepository.AddAsync(vat);
            return vat;
        }

        public async Task DeleteVatAsync(int id)
        {
            await _vatRepository.DeleteAsync(id);
        }

        public async Task<List<VAT>> GetAllVatsAsync()
        {
            return await _vatRepository.GetAllAsync();
        }

        public async Task<VAT> GetVatByIdAsync(int id)
        {
            return await _vatRepository.GetByIdAsync(id);
        }

        public async Task<VAT> UpdateVatAsync(int id, VatRequest vatRequest)
        {
            var vat = await _vatRepository.GetByIdAsync(id);
            if (vat == null)
            {
                return null;
            }

            vat.Name = vatRequest.Name;
            vat.Adjustment = vatRequest.Adjustment;
            await _vatRepository.UpdateAsync(vat);
            return vat;
        }
    }
}
