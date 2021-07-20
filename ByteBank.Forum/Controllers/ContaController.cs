using ByteBank.Forum.Models;
using ByteBank.Forum.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ByteBank.Forum.Controllers
{
    public class ContaController : Controller
    {
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(ContaRegistrarViewModel model)
        { 
            if (ModelState.IsValid)
            {
                var dbContext = new IdentityDbContext<UsuarioAplicacao>();
                UsuarioAplicacao identityUser = new UsuarioAplicacao();

                identityUser.Email = model.Email;
                identityUser.UserName = model.UserName;
                identityUser.NomeCompleto = model.NomeCompleto;

                dbContext.Users.Add(identityUser);
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}