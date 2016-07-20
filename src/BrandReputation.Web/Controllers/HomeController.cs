using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BrandReputation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Data.BrandReputationContext _context;

        public HomeController(Data.BrandReputationContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            //using (var context = new Data.BrandReputationContext())
            //{
                _context.Brand.Where(c => c.Id > 0).ToList();
            //}
            return View();
        }
    }
}
