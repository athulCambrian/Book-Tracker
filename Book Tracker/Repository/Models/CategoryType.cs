using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Book_Tracker.Repository.Models
{
    [Table("category_type")]
    public partial class CategoryType
    {
        [Required]
        [Column("type")]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Key]
        [Column("category_type_id")]
        public int CategoryTypeId { get; set; }
    }
}
