﻿namespace FastFood.Services.Data
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using FastFood.Core.ViewModels.Employees;

    using FastFood.Data;
    using FastFood.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public EmployeeService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task RegisterAsync(RegisterEmployeeInputModel model)
        {
            Employee employee = this.mapper.Map<Employee>(model);

            await this.context.Employees.AddAsync(employee);
            await this.context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync()
            => await this.context.Employees
            .ProjectTo<EmployeesAllViewModel>(this.mapper.ConfigurationProvider)
            .ToArrayAsync();

        public async Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvailablePositionsAsync()
            => await this.context.Positions
                .ProjectTo<RegisterEmployeeViewModel>(this.mapper.ConfigurationProvider)
                .ToArrayAsync();

    }
}
