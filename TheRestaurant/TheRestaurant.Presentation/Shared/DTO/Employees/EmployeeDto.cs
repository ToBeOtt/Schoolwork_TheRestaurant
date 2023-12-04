namespace TheRestaurant.Presentation.Shared.DTO.Employees
{
    public record EmployeeDto
       (
       string Id,
       string Alias,
       string Email,
       DateTime HireDate,
       DateTime FireDate,
       bool IsDeleted,
       bool IsOnParentalLeave,
       DateTime ParentalLeaveStartDate
       );
}
