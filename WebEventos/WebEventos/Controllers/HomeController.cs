﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

using Cl_Business;
using Cl_Entities;
using Cl_Tools;

namespace WebEventos.Controllers
{
    public class HomeController : Controller
    {
        //Listas
        private List<tbArea> listaArea = new List<tbArea>();
        private List<tbArquivo> listaArquivo = new List<tbArquivo>();
        private List<tbAvaliacao> listaAvaliacao = new List<tbAvaliacao>();
        private List<tbEvento> listaEvento = new List<tbEvento>();
        private List<tbInstituicao> listaInstituicao = new List<tbInstituicao>();
        private List<tbPalestra> listaPalestra = new List<tbPalestra>();

        //Objetos
        private tbArea area = new tbArea();
        private tbArquivo arquivo = new tbArquivo();
        private tbAvaliacao avaliacao = new tbAvaliacao();
        private tbEvento evento = new tbEvento();
        private tbInstituicao instituicao = new tbInstituicao();
        private tbPalestra palestra = new tbPalestra();
        private Resultado resultado = new Resultado();

        private int userId = 0;
        private string stUserName = string.Empty;
        private bool blUserAuth = false;

        public HomeController()
        {
            userId = System.Web.HttpContext.Current.Session["userId"] == null ? userId : Convert.ToInt32(System.Web.HttpContext.Current.Session["userId"].ToString());
            stUserName = System.Web.HttpContext.Current.Session["userName"] == null ? stUserName : System.Web.HttpContext.Current.Session["userName"].ToString();
            blUserAuth = System.Web.HttpContext.Current.Session["userAuth"] == null ? blUserAuth : Convert.ToBoolean(System.Web.HttpContext.Current.Session["userAuth"].ToString());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            return View();
        }

        public ActionResult ListArea()
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                    listaArea = new AreaFacade().GetAll();
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");

                return View(listaArea);
            }

            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Area(int idData, int idAction)
        {
            if (idData > 0)
                area = new AreaFacade().GetId(idData, idAction);
            else
                area.idAction = 1;

            //ViewBag.ListaGrupo = new SelectList(new tbMangas().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Grupo) ? "Selecione" : MangasData.tbMangas_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbMangas().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Emprestado) ? "Selecione" : MangasData.tbMangas_Emprestado));

            return View(area);
        }

        [HttpPost]
        public ActionResult Area(tbArea Area)
        {
            switch(Area.idAction)
            {
                case 1:
                    resultado = new AreaFacade().Insert(Area);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 1 : 0;
                break;
                
                case 2:
                    resultado = new AreaFacade().Update(Area);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 2 : 0;
                break;
                
                case 3:
                    resultado = new AreaFacade().Delete(Area);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 3 : 0;
                break;
            }

            //ViewBag.ListaGrupo = new SelectList(new tbJogos().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Grupo) ? "Selecione" : JogosData.tbJogos_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbJogos().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Emprestado) ? "Selecione" : JogosData.tbJogos_Emprestado));

            return View(Area);
        }

        public ActionResult Arquivo()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListAvaliacao()
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                    listaAvaliacao = new AvaliacaoFacade().GetAll();
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");

                return View(listaAvaliacao);
            }

            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Avaliacao(int idData, int idAction)
        {
            if (idData > 0)
                avaliacao = new AvaliacaoFacade().GetId(idData, idAction);
            else
                avaliacao.idAction = 1;

            //ViewBag.ListaGrupo = new SelectList(new tbMangas().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Grupo) ? "Selecione" : MangasData.tbMangas_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbMangas().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Emprestado) ? "Selecione" : MangasData.tbMangas_Emprestado));

            return View(avaliacao);
        }

        [HttpPost]
        public ActionResult Avaliacao(tbAvaliacao Avaliacao)
        {
            switch (Avaliacao.idAction)
            {
                case 1:
                    resultado = new AvaliacaoFacade().Insert(Avaliacao);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 1 : 0;
                    break;

                case 2:
                    resultado = new AvaliacaoFacade().Update(Avaliacao);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 2 : 0;
                    break;

                case 3:
                    resultado = new AvaliacaoFacade().Delete(Avaliacao);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 3 : 0;
                    break;
            }

            //ViewBag.ListaGrupo = new SelectList(new tbJogos().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Grupo) ? "Selecione" : JogosData.tbJogos_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbJogos().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Emprestado) ? "Selecione" : JogosData.tbJogos_Emprestado));

            return View(Avaliacao);
        }

        public ActionResult ListEvento()
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                    listaEvento = new EventoFacade().GetAll();
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");

                return View(listaEvento);
            }

            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Evento(int idData, int idAction)
        {
            if (idData > 0)
                evento = new EventoFacade().GetId(idData, idAction);
            else
                evento.idAction = 1;

            //ViewBag.ListaGrupo = new SelectList(new tbMangas().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Grupo) ? "Selecione" : MangasData.tbMangas_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbMangas().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Emprestado) ? "Selecione" : MangasData.tbMangas_Emprestado));

            return View(evento);
        }

        [HttpPost]
        public ActionResult Evento(tbEvento Evento)
        {
            switch (Evento.idAction)
            {
                case 1:
                    resultado = new EventoFacade().Insert(Evento);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 1 : 0;
                    break;

                case 2:
                    resultado = new EventoFacade().Update(Evento);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 2 : 0;
                    break;

                case 3:
                    resultado = new EventoFacade().Delete(Evento);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 3 : 0;
                    break;
            }

            //ViewBag.ListaGrupo = new SelectList(new tbJogos().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Grupo) ? "Selecione" : JogosData.tbJogos_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbJogos().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Emprestado) ? "Selecione" : JogosData.tbJogos_Emprestado));

            return View(Evento);
        }

        public ActionResult ListInstituicao()
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                    listaInstituicao = new InstituicaoFacade().GetAll();
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");

                return View(listaInstituicao);
            }

            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Instituicao(int idData, int idAction)
        {
            if (idData > 0)
                instituicao = new InstituicaoFacade().GetId(idData, idAction);
            else
                instituicao.idAction = 1;

            //ViewBag.ListaGrupo = new SelectList(new tbMangas().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Grupo) ? "Selecione" : MangasData.tbMangas_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbMangas().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Emprestado) ? "Selecione" : MangasData.tbMangas_Emprestado));

            return View(instituicao);
        }

        [HttpPost]
        public ActionResult Instituicao(tbInstituicao Instituicao)
        {
            switch (Instituicao.idAction)
            {
                case 1:
                    resultado = new InstituicaoFacade().Insert(Instituicao);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 1 : 0;
                    break;

                case 2:
                    resultado = new InstituicaoFacade().Update(Instituicao);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 2 : 0;
                    break;

                case 3:
                    resultado = new InstituicaoFacade().Delete(Instituicao);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 3 : 0;
                    break;
            }

            //ViewBag.ListaGrupo = new SelectList(new tbJogos().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Grupo) ? "Selecione" : JogosData.tbJogos_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbJogos().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Emprestado) ? "Selecione" : JogosData.tbJogos_Emprestado));

            return View(Instituicao);
        }

        public ActionResult ListPalestra()
        {
            try
            {
                if (userId > 0 && blUserAuth == true)
                    listaPalestra = new PalestraFacade().GetAll();
                else if (userId > 0 && blUserAuth == false)
                    return RedirectToAction("Denied", "Account");

                return View(listaPalestra);
            }

            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadGateway);
            }

            return View();
        }

        [HttpGet]
        public ActionResult Palestra(int idData, int idAction)
        {
            if (idData > 0)
                palestra = new PalestraFacade().GetId(idData, idAction);
            else
                palestra.idAction = 1;

            //ViewBag.ListaGrupo = new SelectList(new tbMangas().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Grupo) ? "Selecione" : MangasData.tbMangas_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbMangas().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(MangasData.tbMangas_Emprestado) ? "Selecione" : MangasData.tbMangas_Emprestado));

            return View(palestra);
        }

        [HttpPost]
        public ActionResult Palestra(tbPalestra Palestra)
        {
            switch (Palestra.idAction)
            {
                case 1:
                    resultado = new PalestraFacade().Insert(Palestra);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 1 : 0;
                    break;

                case 2:
                    resultado = new PalestraFacade().Update(Palestra);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 2 : 0;
                    break;

                case 3:
                    resultado = new PalestraFacade().Delete(Palestra);
                    ViewBag.Msgtype = resultado.ResultAction == true ? 3 : 0;
                    break;
            }

            //ViewBag.ListaGrupo = new SelectList(new tbJogos().CampoGrupo(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Grupo) ? "Selecione" : JogosData.tbJogos_Grupo));
            //ViewBag.ListaEmprestado = new SelectList(new tbJogos().CampoEmprestado(), "Id", "Desc", (string.IsNullOrWhiteSpace(JogosData.tbJogos_Emprestado) ? "Selecione" : JogosData.tbJogos_Emprestado));

            return View(Palestra);
        }    
    }
}