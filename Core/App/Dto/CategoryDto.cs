using Core.App.Dto.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.App.Dto;

public class CategoryDto
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public ICollection<ProductDto> Products { get; set; }
}
