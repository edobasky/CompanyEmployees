﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company address is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the address is 60 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Company country is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 30 characters.")]
        public string Country { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
