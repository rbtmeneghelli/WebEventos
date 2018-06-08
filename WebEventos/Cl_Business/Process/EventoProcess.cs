using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cl_Entities;
using Cl_Tools;

namespace Cl_Business.Process
{
    internal class EventoProcess
    {
        Resultado resultado = new Resultado();

        public Resultado Insert(tbEvento pEvento)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    pEvento.tbEvento_UpdateTime = DateTime.Now;
                    dbContext.tbEvento.Add(pEvento);
                    dbContext.SaveChanges();

                    resultado = new Resultado()
                    {
                        PageName = "Evento",
                        ClassName = "EventoProcess",
                        MethodName = "Insert",
                        ExceptionMsg = "Cadastro efetuado com sucesso",
                        ResultAction = true,
                        DateAction = DateTime.Now,
                        IdUserAction = 1
                    };
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Evento",
                    ClassName = "EventoProcess",
                    MethodName = "Insert",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Update(tbEvento pEvento)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var evento = dbContext.tbEvento.Where(x => x.tbEvento_Id == pEvento.tbEvento_Id).FirstOrDefault();

                    if (evento != null)
                    {
                        evento.tbEvento_Titulo = string.IsNullOrWhiteSpace(pEvento.tbEvento_Titulo) ? evento.tbEvento_Titulo : pEvento.tbEvento_Titulo;
                        evento.tbEvento_DataEvento = pEvento.tbEvento_DataEvento;
                        evento.tbEvento_UpdateTime = DateTime.Now;

                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Evento",
                            ClassName = "EventoProcess",
                            MethodName = "Update",
                            ExceptionMsg = "Atualização efetuada com sucesso",
                            ResultAction = true,
                            DateAction = DateTime.Now,
                            IdUserAction = 1
                        };
                    }
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Evento",
                    ClassName = "EventoProcess",
                    MethodName = "Update",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Delete(tbEvento pEvento)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var evento = dbContext.tbEvento.Where(x => x.tbEvento_Id == pEvento.tbEvento_Id).FirstOrDefault();

                    if (evento != null)
                    {
                        dbContext.tbEvento.Remove(evento);
                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Evento",
                            ClassName = "EventoProcess",
                            MethodName = "Delete",
                            ExceptionMsg = "Exclusão efetuada com sucesso",
                            ResultAction = true,
                            DateAction = DateTime.Now,
                            IdUserAction = 1
                        };
                    }
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Evento",
                    ClassName = "EventoProcess",
                    MethodName = "Delete",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public tbEvento GetId(int pIdData, int pIdAction)
        {
            tbEvento registro = new tbEvento();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    registro = (from x in dbContext.tbEvento
                                where x.tbEvento_Id == pIdData
                                select x).FirstOrDefault();

                    registro.idAction = pIdAction;
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Evento",
                    ClassName = "EventoProcess",
                    MethodName = "GetId",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return registro;
        }

        public List<tbEvento> GetAll()
        {
            List<tbEvento> lista = new List<tbEvento>();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    lista = (from x in dbContext.tbEvento select x).ToList();
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Evento",
                    ClassName = "EventoProcess",
                    MethodName = "GetAll",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return lista;
        }
    }
}
