using TheRestaurant.Application.Interfaces.IProduct;
using TheRestaurant.Application.Services.ProductServices.DTO;
using TheRestaurant.Contracts.Requests.Product;
using TheRestaurant.Contracts.Responses.ServiceResponse;
using TheRestaurant.Domain.Entities.Menu;

namespace TheRestaurant.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProductAsync(CreateProductRequest request)
        {
            var VAT = await _productRepository.GetVATById(request.VATId);

            var product = new Product
            {
                Name = request.Name,
                PriceBeforeVAT = request.PriceBeforeVat,
                Description = request.Description,
                MenuPhoto = request.MenuPhoto,
                IsFoodItem = request.IsFoodItem,
                IsDeleted = request.IsDeleted,
                ProductAllergies = new List<ProductAllergy>(),
                ProductCategories = new List<ProductCategory>(),
                VATId = request.VATId,
                VAT = VAT,
            };
            product.SetPriceWithVAT(product);


            if (request.SelectedAllergyIds != null)
            {
                foreach (var allergyId in request.SelectedAllergyIds)
                {
                    product.ProductAllergies.Add(new ProductAllergy { AllergyId = allergyId });
                }
            }


            foreach (var categoryId in request.SelectedCategoryIds)
            {
                product.ProductCategories.Add(new ProductCategory { CategoryId = categoryId });
            }

            await _productRepository.AddAsync(product);

            return product;
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            await _productRepository.SoftDeleteAsync(id);
        }

        public async Task<ServiceResponse<List<ClientProductDto>>> GetAllProducts()
        {
            ServiceResponse<List<ClientProductDto>> response = new();
            var ListOfDtos = new List<ClientProductDto>();

            var products = await _productRepository.GetAllEagerLoadedAsync();

            foreach(var product in products)
            {
                var listOfAllergies = new List<string>();
                if(listOfAllergies != null)
                {
                    foreach (var allergy in product.ProductAllergies)
                    {
                        listOfAllergies.Add(allergy.Allergy.Name);
                    }
                }
                
                var listOfCategories = new List<string>();
                if (listOfCategories != null)
                {
                    foreach (var category in product.ProductCategories)
                    {
                        listOfCategories.Add(category.Category.Name);
                    }
                }
                   
                ClientProductDto dto = new(
                   Id: product.Id,
                   Name: product.Name,
                   Price: product.Price,
                   IsFoodItem: product.IsFoodItem,
                   Description: product.Description,
                   MenuPhoto: Convert.ToBase64String(product.MenuPhoto),
                   Category: listOfCategories,
                   Allergen: listOfAllergies);

                ListOfDtos.Add(dto);
            }
            response.Data = ListOfDtos;
            return await response.SuccessResponse(response, response.Data);
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, EditProductRequest request)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(id);

            productToUpdate.Name = request.Name;
            productToUpdate.Description = request.Description;
            productToUpdate.MenuPhoto = request.MenuPhoto;
            productToUpdate.PriceBeforeVAT = request.PriceBeforeVat;
            productToUpdate.IsFoodItem = request.IsFoodItem;
            productToUpdate.IsDeleted = request.IsDeleted;
            productToUpdate.ProductCategories = new List<ProductCategory>();
            productToUpdate.ProductAllergies = new List<ProductAllergy>();

            foreach (var allergyId in request.SelectedAllergyIds)
            {
                productToUpdate.ProductAllergies.Add(new ProductAllergy { AllergyId = allergyId });
            }

            foreach (var categoryId in request.SelectedCategoryIds)
            {
                productToUpdate.ProductCategories.Add(new ProductCategory { CategoryId = categoryId });
            }

            // Fetch VAT information
            var VAT = await _productRepository.GetVATById(request.VatId);

            // Set the new price with VAT
            productToUpdate.VATId = VAT.Id;
            productToUpdate.VAT = VAT;
            productToUpdate.SetPriceWithVAT(productToUpdate);

            await _productRepository.UpdateAsync(productToUpdate);

            return productToUpdate;
        }

        public async Task<List<string>> FetchAllCategoryNames()
        {
            return await _productRepository.GetAllCategoryNames();
        }
    }
}
