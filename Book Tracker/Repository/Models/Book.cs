using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Book_Tracker.Repository.Models
{
    [Table("Book")]
    public partial class Book
    {
        [Required]
        [Column("isbn")]
        [StringLength(50)]
        public string Isbn { get; set; }
        [Required]
        [Column("title")]
        [StringLength(50)]
        public string Title { get; set; }
        [Column("category")]
        public int Category { get; set; }
        [Column("author")]
        [StringLength(50)]
        public string Author { get; set; }
        [Key]
        [Column("book_id")]
        public int BookId { get; set; }

        [ForeignKey(nameof(Category))]
        [InverseProperty(nameof(CategoryTable.Books))]
        public virtual CategoryTable CategoryNavigation { get; set; }
    }
}
