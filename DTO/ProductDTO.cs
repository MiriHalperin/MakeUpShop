using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities;

public partial class ProductDTO
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public double Price { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public string ImagePath { get; set; } = null!;

    public virtual CategoryDTO? Category { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<OrderItemDTO> OrderItems { get; } = new List<OrderItemDTO>();
}
