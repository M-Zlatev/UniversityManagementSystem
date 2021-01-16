﻿namespace UMS.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using static UMS.Data.Common.DataValidation.Faculty;

    public class Faculty
    {
        public Faculty()
        {
            this.Departments = new HashSet<Department>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}
