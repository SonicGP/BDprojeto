using BDProjeto.Aplicacao;
using BDProjeto.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioAplicacao appUsuario;

        public UsuarioController()
        {
            appUsuario = UsuarioAplicacaoConstrutor.UsuarioApADO();
        }

        public ActionResult Index()
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var listaUsuarios = appUsuario.ListarTodos();
            return View(listaUsuarios);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioApADO();
                appUsuario.Salvar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Editar(string id)
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var usuario = appUsuario.UsuarioPorId(id);

            if(usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);

        }

        [HttpPost]
        public ActionResult Editar(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioApADO();
                appUsuario.Salvar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public ActionResult Detalhes(string id)
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var usuario = appUsuario.UsuarioPorId(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);

        }

        public ActionResult Excluir(string id)
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var usuario = appUsuario.UsuarioPorId(id);

            if (usuario == null)
            {
                return HttpNotFound();
            }

            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmar(string id)
        {
            //var appUsuario = UsuarioAplicacaoConstrutor.UsuarioApADO();
            var usuario = appUsuario.UsuarioPorId(id);
            appUsuario.Excluir(usuario);
            return RedirectToAction("Index");
        }
    }
}