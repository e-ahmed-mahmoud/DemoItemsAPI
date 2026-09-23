using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsAPI.Models;

public class Item
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Name { get; set; }

    public required int QunatityInStock { get; set; }

    public required decimal Price { get; set; }
}
