using LogistikWebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace LogistikWebApi.Dto;

public class ProductDto
{
    public static ProductDto FromProduct(Product product) 
    {
        var productDto = new ProductDto() 
        {
            InWarehouseSince = product.InWarehouseSince,
            Id = product.Id,
            FK_groupId = product.FK_groupId,
            Name = product.Name,
        };
        return productDto;
    }

    public DateTime InWarehouseSince { get; set; }

    [Required]
    public Guid Id { get; set; }

    [Required]
    public Guid FK_groupId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
}
