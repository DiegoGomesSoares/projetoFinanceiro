using Financas.DAO;
using Financas.Entidades;
using Financas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioDAO)
        {
            this.usuarioDAO = usuarioDAO;
        }
        // GET: Usuario
        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Usuario usuario = new Usuario
                    //{
                    //    Nome = usuarioModel.Nome,
                    //    Email = usuarioModel.Email
                    //};
                    //usuarioDAO.Adiciona(usuario);
                    ////criar conta de usario atraves do membership
                    //WebSecurity.CreateAccount(usuarioModel.Nome, usuarioModel.Senha);

                    //criar tanto usuario quanto a conta isso ao mesmo tempo para caso 1 dos dois der erro ele nao grave nada
                    WebSecurity.CreateUserAndAccount(usuarioModel.Nome, usuarioModel.Senha, new { Email = usuarioModel.Email });
                    return RedirectToAction("Index");
                }
                catch (MembershipCreateUserException e)
                {

                    ModelState.AddModelError("usuario.invalido",e.Message);
                    return View("Form", usuarioModel);
                }
                
            }
            else
            {
                return View("Form", usuarioModel);
            }
        }
        public ActionResult Index()
        {
            IList<Usuario> usuarios = usuarioDAO.Lista();
            return View(usuarios);
        }
    }
}