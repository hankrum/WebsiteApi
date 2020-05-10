using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Api.Data.Model
{
    public class WebSite
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [Url]
        public string SnapshotUrl { get; set; }

        [Required]
        [EmailAddress]
        public string LoginEmail { get; set; }

        [Required]
        public string LoginPassword { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
