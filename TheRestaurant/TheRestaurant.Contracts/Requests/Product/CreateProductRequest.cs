namespace TheRestaurant.Contracts.Requests.Product
{
    // Need to add Category once implemented
    public record CreateProductRequest(
        string Name,
        double Price,
        string Description,
        byte[] MenuPhoto,
        bool IsFoodItem,
        bool IsDeleted,
        List<int> SelectedAllergyIds,
        List<int> SelectedCategoryIds,
        string VAT);

}
