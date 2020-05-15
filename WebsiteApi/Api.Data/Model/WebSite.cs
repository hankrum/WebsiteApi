using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.Data.Model
{
    public class WebSite : IAuditable, IDeletable
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        public long CategoryId { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

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
