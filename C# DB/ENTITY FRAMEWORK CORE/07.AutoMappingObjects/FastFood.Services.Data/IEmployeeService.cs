using FastFood.Core.ViewModels.Employees;

namespace FastFood.Services.Data
{
    public interface IEmployeeService
    {
        Task RegisterAsync(RegisterEmployeeInputModel model);

        Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailablePositionsAsync();

        Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();
    }
}
