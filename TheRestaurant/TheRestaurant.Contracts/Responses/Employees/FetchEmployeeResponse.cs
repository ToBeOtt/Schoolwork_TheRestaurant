namespace TheRestaurant.Contracts.Responses.Employees
{
    public record FetchEmployeeResponse
        (
        string Id,
        string Alias,
        string Email,
        DateTime HireDate,
        DateTime? FireDate,
        bool IsDeleted,
        bool IsOnParentalLeave,
        DateTime? ParentalLeaveStartDate
        );
}
