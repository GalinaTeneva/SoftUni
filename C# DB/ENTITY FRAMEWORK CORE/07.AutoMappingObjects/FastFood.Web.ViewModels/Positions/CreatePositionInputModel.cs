﻿namespace FastFood.Core.ViewModels.Positions
{
    using System.ComponentModel.DataAnnotations;

    using FastFood.Common.EntityConfiguration;

    public class CreatePositionInputModel
    {
        //[MinLength(ViewModelsValidation.PositionNameMinLength)]
        //[MaxLength(ViewModelsValidation.PositionNameMaxLength)]
        [StringLength(ViewModelsValidation.PositionNameMaxLength, MinimumLength = ViewModelsValidation.PositionNameMinLength)]
        public string PositionName { get; set; } = null!;
    }
}