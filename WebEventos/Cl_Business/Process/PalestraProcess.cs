using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cl_Entities;
using Cl_Tools;

namespace Cl_Business.Process
{
    internal class PalestraProcess
    {
        Resultado resultado = new Resultado();

        public Resultado Insert(tbPalestra pPalestra)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    pPalestra.tbPalestra_UpdateTime = DateTime.Now;
                    dbContext.tbPalestra.Add(pPalestra);
                    dbContext.SaveChanges();

                    resultado = new Resultado()
                    {
                        PageName = "Palestra",
                        ClassName = "PalestraProcess",
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
                    PageName = "Palestra",
                    ClassName = "PalestraProcess",
                    MethodName = "Insert",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Update(tbPalestra pPalestra)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var palestra = dbContext.tbPalestra.Where(x => x.tbPalestra_Id == pPalestra.tbPalestra_Id).FirstOrDefault();

                    if (palestra != null)
                    {
                        palestra.tbPalestra_Titulo = string.IsNullOrWhiteSpace(pPalestra.tbPalestra_Titulo) ? palestra.tbPalestra_Titulo : pPalestra.tbPalestra_Titulo;
                        palestra.tbPalestra_DataEvento = pPalestra.tbPalestra_DataEvento;
                        palestra.tbPalestra_UpdateTime = DateTime.Now;

                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Palestra",
                            ClassName = "PalestraProcess",
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
                    PageName = "Palestra",
                    ClassName = "PalestraProcess",
                    MethodName = "Update",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Delete(tbPalestra pPalestra)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var palestra = dbContext.tbPalestra.Where(x => x.tbPalestra_Id == pPalestra.tbPalestra_Id).FirstOrDefault();

                    if (palestra != null)
                    {
                        dbContext.tbPalestra.Remove(palestra);
                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Palestra",
                            ClassName = "PalestraProcess",
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
                    PageName = "Palestra",
                    ClassName = "PalestraProcess",
                    MethodName = "Delete",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public tbPalestra GetId(int pIdData, int pIdAction)
        {
            tbPalestra registro = new tbPalestra();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    registro = (from x in dbContext.tbPalestra
                                where x.tbPalestra_Id == pIdData
                                select x).FirstOrDefault();

                    registro.idAction = pIdAction;
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Palestra",
                    ClassName = "PalestraProcess",
                    MethodName = "GetId",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return registro;
        }

        public List<tbPalestra> GetAll()
        {
            List<tbPalestra> lista = new List<tbPalestra>();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    lista = (from x in dbContext.tbPalestra select x).ToList();
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Palestra",
                    ClassName = "PalestraProcess",
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
