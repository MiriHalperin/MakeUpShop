using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities;

public partial class CategoryDTO
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<ProductDTO> Products { get; } = new List<ProductDTO>();
}
