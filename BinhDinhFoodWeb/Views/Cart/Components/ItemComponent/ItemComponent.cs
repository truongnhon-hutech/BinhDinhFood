﻿using BinhDinhFood.Intefaces;
using BinhDinhFood.Models.Report;
using Microsoft.AspNetCore.Mvc;

namespace BinhDinhFood.Views.Cart.Components.ItemComponent;

public class ItemComponent : ViewComponent
{
    private readonly IProductRepository _productRepo;

    public ItemComponent(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }
    public IViewComponentResult Invoke(Item item)
    {
        return View(item);
    }
}
