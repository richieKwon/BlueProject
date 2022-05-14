using Microsoft.AspNetCore.Mvc;

namespace BlueProject.Controllers.ViewComponents
{
    public class LeftMenu: ViewComponent
    {
        public LeftMenu()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}