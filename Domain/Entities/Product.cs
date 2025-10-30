using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi_With_SQL_Server.Domain.Constants;
using WebApi_With_SQL_Server.Domain.Enums;
namespace WebApi_With_SQL_Server.Domain.Entities
{
    [Table(TableNames.Products)]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 100000)]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        public ProductStatus Status { get; set; } = ProductStatus.Active;

        // Quan hệ (1 Category - nhiều Product)
        public int CategoryId { get; set; }
        public Category? CategoryNavigation { get; set; }
    }
}
