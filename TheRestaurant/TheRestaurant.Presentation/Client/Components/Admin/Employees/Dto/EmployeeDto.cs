namespace TheRestaurant.Presentation.Client.Components.Admin.Employees.Dto
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
