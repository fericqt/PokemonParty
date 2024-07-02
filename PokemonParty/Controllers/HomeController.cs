using PokemonParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonParty.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var myEntity = new PokemonPartyDBEntities();
            return View(myEntity.Parties.ToList());

        }
    }
}