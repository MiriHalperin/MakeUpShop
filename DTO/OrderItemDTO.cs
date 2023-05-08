using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace entities;

public partial class OrderItemDTO
{
    public int OrderItemId { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public int Quantity { get; set; }
    [JsonIgnore]

    public virtual OrderDTO? Order { get;}

    [JsonIgnore]
    public virtual ProductDTO? Product { get; set; }
}
