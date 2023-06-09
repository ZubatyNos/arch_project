﻿using Microsoft.EntityFrameworkCore;

namespace ArchProject.Models;

[PrimaryKey(nameof(StoreId), nameof(FoodId))]
public class CartEntry
{
    public int StoreId { get; set; }
    public Store Store { get; set; }
    public int FoodId { get; set; }
    public Food Food { get; set; }
    public int Quantity { get; set; }
    
}