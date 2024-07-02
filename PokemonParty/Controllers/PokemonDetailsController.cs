using PokemonParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PokemonParty.Controllers {
    public class PokemonDetailsController : Controller {
        // GET: PokemonDetails
        public ActionResult Index() {
            return View();
        }

        public ActionResult AddPokemon(PokemonInfo item) {
            try {
                using (var myEntity = new PokemonPartyDBEntities()) {
                    item.DateCreated = DateTime.Now;    
                    myEntity.PokemonInfoes.Add(item);
                    myEntity.SaveChanges();
                    return Json(new {
                        Success = true,
                        Message = "Pokemon Party Created Successfully!"
                    });
                }
            }
            catch (Exception ex) {
                return Json(new {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        public ActionResult GetData(int id) {
            try {
                using (var myEntity = new PokemonPartyDBEntities()) {
                    return View(GetById(id));

                }
            }
            catch (Exception ex) {
                return View();
            }
        }
        public ActionResult DeleteData(int id) {
            try {
                using (var myEntity = new PokemonPartyDBEntities()) {
                    myEntity.PokemonInfoes.Remove(GetById(id));
                    myEntity.SaveChanges();
                    return Json(new {

                    });
                }
            }
            catch (Exception ex) {
                return View();
            }
        }
        private PokemonInfo GetById(int id) {
            using (var myEntity = new PokemonPartyDBEntities()) {
                return myEntity.PokemonInfoes.FirstOrDefault(c => c.PokemonID == id);
            }
        }
    }
}