namespace FastFood.Services.Data
{
    using FastFood.Core.ViewModels.Employees;

    public interface IEmployeeService
    {
        Task RegisterAsync(RegisterEmployeeInputModel model);

        Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailablePositionsAsync();

        Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();
    }
}
