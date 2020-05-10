﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Data.Model
{
    public class Category
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public HashSet<WebSite> WebSites { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
