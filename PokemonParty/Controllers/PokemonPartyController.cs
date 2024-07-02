using PokemonParty.Extension;
using PokemonParty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace PokemonParty.Controllers {
    public class PokemonPartyController : Controller {
        // GET: PokemonParty
        public ActionResult Index() {
            return View(GetPokemonDetails());
        }
        public ActionResult AddNewParty(Party item, List<int> PokemonID) {
            using (var myEntity = new PokemonPartyDBEntities()) {
                using (var tran = myEntity.Database.BeginTransaction()) {
                    try {
                        var classification = new List<string>();
                        item.DateCreated = DateTime.Now;
                        foreach (var i in PokemonID) {
                            var dItem = new PartyDetail {
                                PokemonID = i,
                            };
                            item.PartyDetails.Add(dItem);
                            classification.Add(GetPokemonType(i));
                        }
                        item.Classification = classification.GroupBy(c => c).OrderByDescending(g => g.Count()).FirstOrDefault()?.Key;
                        //
                        myEntity.Parties.Add(item);
                        myEntity.SaveChanges();
                        tran.Commit();
                        return Json(new {
                            Success = true
                        });
                    }
                    catch (Exception ex) {

                        tran.Rollback();
                        return Json(new {
                            Success = false,
                            Message = ex.Message
                        });
                    }
                }
            }
        }

        private IEnumerable<SelectListItem> GetPokemonDetails() {
            using (var myEntity = new PokemonPartyDBEntities()) {
                var item = myEntity.PokemonInfoes.ToList();
                return item.Select(c => new SelectListItem {
                    Value = c.PokemonID.ToString(),
                    Text = c.Name
                });
            }
        }
        private string GetPokemonType(int id) {
            using (var myEntity = new PokemonPartyDBEntities()) {
                return myEntity.PokemonInfoes.FirstOrDefault(c => c.PokemonID == id).Type;
            }
        }

    }
}