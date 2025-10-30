using System.ComponentModel.DataAnnotations;

namespace WebApi_With_SQL_Server.Application.DTOs
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Id là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Id phải là số nguyên dương")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc")]
        [Range(1000, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn 1.000 VNĐ")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Danh mục là bắt buộc")]
        [StringLength(50, ErrorMessage = "Danh mục không được vượt quá 50 ký tự")]
        public string Category { get; set; } = string.Empty;

        [Range(0, 1, ErrorMessage = "Trạng thái chỉ nhận 0 hoặc 1")]
        public int Status { get; set; } = 1;

        [Required(ErrorMessage = "Phải chọn CategoryId hợp lệ")]
        public int CategoryId { get; set; }
    }
}
