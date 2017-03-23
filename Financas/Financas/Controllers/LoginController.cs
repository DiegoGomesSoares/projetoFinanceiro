using Financas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //pode criar uma outra view model chamada login, colocando as validações de branco e tals ..
        public ActionResult Autentica(Login usuarioLogin)
        {
            if (WebSecurity.Login(usuarioLogin.login, usuarioLogin.senha))
            {
                return RedirectToAction("Index","Movimentacao");
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login ou senha invalidos");
                return View("Index");
            }
            
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index");
        }
    }
}