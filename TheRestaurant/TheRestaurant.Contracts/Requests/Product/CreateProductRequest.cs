namespace TheRestaurant.Contracts.Requests.Product
{
    public record CreateProductRequest(
        string Name,
        double PriceBeforeVat,
        string Description,
        byte[] MenuPhoto,
        bool IsFoodItem,
        bool IsDeleted,
        List<int>? SelectedAllergyIds,
        List<int> SelectedCategoryIds,
        int VATId);

}
