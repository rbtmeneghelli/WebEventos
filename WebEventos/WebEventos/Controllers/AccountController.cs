using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net;

using Cl_Entities;
using Cl_Business;
using Cl_Tools;

namespace WebEventos.Controllers
{
    public class AccountController : Controller
    {
        private int userId = 0;
        private string stUserName = string.Empty;
        private bool blUserAuth = false;

        private List<tbAcesso> listaAcesso = new List<tbAcesso>();
        private List<tbUsuario> listaUsuario = new List<tbUsuario>();

        private tbUsuario usuario = new tbUsuario();
        private tbAcesso acesso = new tbAcesso();
        private tbBackup backup = new tbBackup();

        private Resultado resultado = new Resultado();
        private ClsSecurity security = new ClsSecurity();

        public AccountController()
        {
            userId = System.Web.HttpContext.Current.Session["userId"] == null ? userId : Convert.ToInt32(System.Web.HttpContext.Current.Session["userId"].ToString());
            stUserName = System.Web.HttpContext.Current.Session["userName"] == null ? stUserName : System.Web.HttpContext.Current.Session["userName"].ToString();
            blUserAuth = System.Web.HttpContext.Current.Session["userAuth"] == null ? blUserAuth : Convert.ToBoolean(System.Web.HttpContext.Current.Session["userAuth"].ToString());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbUsuario Usuario)
        {
            switch (Usuario.idAction)
            {
                case 1: //Logar no sistema
                    using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                    {
                        dbContext.Configuration.LazyLoadingEnabled = true; //Impede de rastrear demais tabelas!
                        dbContext.Configuration.ProxyCreationEnabled = false;//Desabilita o proxy
                        dbContext.Configuration.UseDatabaseNullSemantics = false;
                        dbContext.Configuration.ValidateOnSaveEnabled = false;

                        //AsNoTracking() incluir isso depois da consulta entity faz que o objeto nao rastrei as demais tabelas vinculadas!

                        Usuario.tbUsuario_Senha = security.EncryptText(Usuario.tbUsuario_Senha);
                        tbUsuario usuarioLogado = (from x in dbContext.tbUsuario
                                                   where x.tbUsuario_Login.Equals(Usuario.tbUsuario_Login) && x.tbUsuario_Senha.Equals(Usuario.tbUsuario_Senha)
                                                   select x).FirstOrDefault();

                        //dbContext.tbUsuario.Where(x => x.tbUsuario_Login.Equals(Usuario.tbUsuario_Login) && x.tbUsuario_Senha.Equals(Usuario.tbUsuario_Senha)).FirstOrDefault();

                        if (usuarioLogado != null)
                        {
                            if(usuarioLogado.tbUsuario_Ativo.GetValueOrDefault(false) == true)
                            { 
                                //Armazena as informações do usuario logado aqui!
                                System.Web.HttpContext.Current.Session["userId"] = usuarioLogado.tbUsuario_Id;
                                System.Web.HttpContext.Current.Session["userName"] = usuarioLogado.tbUsuario_Login;
                                System.Web.HttpContext.Current.Session["userAuth"] = (usuarioLogado.tbAcesso.tbAcesso_Ativo == true ? "True" : "False");
                                usuarioLogado.tbUsuario_UpdateTime = DateTime.Now;

                                dbContext.SaveChanges();
                                return RedirectToAction("Index", "Home");
                            }
                            else
                                ViewBag.MessageError = "Usuario Inativo, favor entrar em contato com o Administrador.";
                        }
                        else
                        {
                            ViewBag.MessageError = "Usuario ou senha invalidos";
                        }
                    }
                    break;

                case 2: //Registrar novo usuario
                    resultado = new UsuarioFacade().Insert(Usuario);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 4 : 0;
                break;
            }

            return View(Usuario);
        }

        public ActionResult Logoff()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Usuario(int idData, int idAction)
        {
            if (idData > 0)
                usuario = new UsuarioFacade().GetId(idData, idAction);
            else
                usuario.idAction = 1;

            ViewBag.ListaAtivo = new SelectList(new tbUsuario().ListaAtivo(), "Id", "Value", usuario.tbUsuario_Ativo == true ? "Sim" : "Não");

            return View(usuario);
        }

        [HttpPost]
        public ActionResult Usuario(tbUsuario Usuario)
        {
            switch (Usuario.idAction)
            {
                case 1:
                    Usuario.tbUsuario_Ativo = Usuario.Ativo == "Sim" ? true : false;
                    resultado = new UsuarioFacade().Insert(Usuario);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 1 : 0;
                    break;
                case 2:
                    Usuario.tbUsuario_Ativo = Usuario.Ativo == "Sim" ? true : false;
                    resultado = new UsuarioFacade().Update(Usuario);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 2 : 0;
                    break;
                case 3:
                    resultado = new UsuarioFacade().Delete(Usuario);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 3 : 0;
                    break;
            }

            ViewBag.ListaAtivo = new SelectList(new tbUsuario().ListaAtivo(), "Id", "Value", acesso.tbAcesso_Ativo == true ? "Sim" : "Não");

            return View(Usuario);
        }

        public ActionResult ListAcesso()
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                    listaAcesso = new AcessoFacade().GetAll();
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");

                return View(listaAcesso);
            }

            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            return View();
        }

        public ActionResult ListUsuario()
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                    listaUsuario = new UsuarioFacade().GetAll();
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");

                return View(listaUsuario);
            }

            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Acesso(int idData, int idAction)
        {
            if (idData > 0)
                acesso = new AcessoFacade().GetId(idData, idAction);
            else
                acesso.idAction = 1;

            ViewBag.ListaNivelAcesso = new SelectList(new tbAcesso().ListaNivelAcesso(), "Id", "Value", acesso.tbAcesso_Id == 0 ? 0 : acesso.tbAcesso_Id);
            ViewBag.ListaAtivo = new SelectList(new tbAcesso().ListaAtivo(), "Id", "Value", acesso.tbAcesso_Ativo == true ? "Sim" : "Não");

            return View(acesso);
        }

        [HttpPost]
        public ActionResult Acesso(tbAcesso Acesso)
        {
            switch (Acesso.idAction)
            {
                case 1:
                    acesso.tbAcesso_Ativo = acesso.Ativo == "Sim" ? true : false;
                    resultado = new AcessoFacade().Insert(Acesso);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 1 : 0;
                    break;
                case 2:
                    acesso.tbAcesso_Ativo = acesso.Ativo == "Sim" ? true : false;
                    resultado = new AcessoFacade().Update(Acesso);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 2 : 0;
                    break;
                case 3:
                    resultado = new AcessoFacade().Delete(Acesso);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 3 : 0;
                    break;
            }

            ViewBag.ListaAtivo = new SelectList(new tbAcesso().ListaAtivo(), "Id", "Value", acesso.tbAcesso_Ativo == true ? "Sim" : "Não");

            return View(Acesso);
        }

        [HttpGet]
        public ActionResult Backup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Backup(tbBackup backup)
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                {
                    resultado = new ArquivoFacade().Backup(backup);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 10 : 0; 
                }
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");                            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }          
            return View();
        }

        [HttpGet]
        public ActionResult Trocasenha()
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                {
                    usuario = new UsuarioFacade().GetId(userId, 0);
                    ViewBag.Senha = security.DecryptText(usuario.tbUsuario_Senha);
                    usuario.tbUsuario_Senha = "**********";
                }
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");

                return View(usuario);
            }

            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Trocasenha(tbUsuario usuario)
        {
            resultado = new UsuarioFacade().Update(usuario);
            ViewBag.Msgtype = resultado.ResultAction == true ? 2 : 0;

            return View();
        }

        [HttpGet]
        public ActionResult _Esqueceusenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _Esqueceusenha(tbUsuario usuario)
        {
            resultado = new UsuarioFacade().EsqueciSenha(usuario);

            if (resultado.ResultAction)
                return RedirectToAction("Confirm", "Account");
            else
                return RedirectToAction("Denied", "Account");
        }
    }
}