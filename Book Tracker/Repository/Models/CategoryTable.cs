using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Book_Tracker.Repository.Models
{
    [Table("category_table")]
    public partial class CategoryTable
    {
        public CategoryTable()
        {
            Books = new HashSet<Book>();
        }

        [Required]
        [Column("name_token")]
        [StringLength(50)]
        public string NameToken { get; set; }
        [Column("type")]
        public int Type { get; set; }
        [Column("description")]
        [StringLength(50)]
        public string Description { get; set; }
        [Key]
        [Column("category_id")]
        public int CategoryId { get; set; }

        [InverseProperty(nameof(Book.CategoryNavigation))]
        public virtual ICollection<Book> Books { get; set; }
    }
}
