namespace TheRestaurant.Application.Employees.DTOs
{
    public record FetchEmployeeDto
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
