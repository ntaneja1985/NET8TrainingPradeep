using Microsoft.AspNetCore.Mvc;

namespace WebApp.Custom;

public class DiscountOfferViewComponent: ViewComponent
{
    public IViewComponentResult Invoke(decimal productPrice)
    {
        //fetch value from db
        if (productPrice > 1000)
        {
            decimal discount = productPrice * 10/100;
            decimal finalPrice = productPrice - discount;
            return View("_DiscountOffer", finalPrice);
        }
        return View("_NoOffer");
    }
}