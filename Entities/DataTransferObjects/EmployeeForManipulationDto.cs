﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public abstract class EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is a required field.")]

        [Range(18, int.MaxValue, ErrorMessage = "Age is required and it cant be lower than 18")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Position is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the position is 20 characters.")]
        public string Position { get; set; }
    }
}
