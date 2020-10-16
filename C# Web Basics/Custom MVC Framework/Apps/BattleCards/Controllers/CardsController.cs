﻿using BattleCards.Data;
using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Linq;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CardsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public HttpResponse Add()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {

            if (this.Request.FormData["name"].Length < 5)
            {
                return this.Error("Name should be at least 5 characters long.");
            }

            db.Cards.Add(new Card
            {
                Attack = int.Parse(this.Request.FormData["attack"]),
                Health = int.Parse(this.Request.FormData["health"]),
                Description = this.Request.FormData["description"],
                Name = this.Request.FormData["name"],
                ImageUrl = this.Request.FormData["image"],
                Keyword = this.Request.FormData["keyword"],
            });
            db.SaveChanges();

            return this.Redirect("/cards/all");
        }

        public HttpResponse All()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }
                        
            var cardsViewModel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
            }).ToList();

            //Our SUS view engine allows generic types and we can pass the list directly
            return this.View(cardsViewModel);
        }

        public HttpResponse Collection()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            return this.View();
        }
    }
}
