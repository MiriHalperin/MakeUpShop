using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace entities;


public partial class UserDTO
{
    public int UserId { get; set; }
    [EmailAddress(ErrorMessage = "Email not valid")]

    public string Email { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string Password { get; set; } = null!;

    public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
}
