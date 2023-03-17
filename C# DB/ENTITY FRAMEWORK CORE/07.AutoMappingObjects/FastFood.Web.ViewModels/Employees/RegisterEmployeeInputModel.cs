﻿namespace FastFood.Core.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using FastFood.Common.EntityConfiguration;

    public class RegisterEmployeeInputModel
    {
        [StringLength(ViewModelsValidation.EmployeeNameMaxLength, MinimumLength = ViewModelsValidation.EmployeeNameMinLength)]
        public string Name { get; set; } = null!;

        [Range(15, 80)]
        public int Age { get; set; }

        public int PositionId { get; set; }

        public string PositionName { get; set; } = null!;

        [StringLength(ViewModelsValidation.EmployeeAddressMaxLength, MinimumLength = ViewModelsValidation.EmployeeAddressMinLength)]
        public string Address { get; set; } = null!;
    }
}
