using BinhDinhFoodWeb.Intefaces;
using BinhDinhFoodWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BinhDinhFoodWeb.Views.User.Components.ChangePassComponent
{
    public class ChangePassComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
