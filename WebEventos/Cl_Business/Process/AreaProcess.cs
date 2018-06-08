using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cl_Tools;
using Cl_Entities;

namespace Cl_Business.Process
{
    internal class AreaProcess
    {
        Resultado resultado = new Resultado();

        public Resultado Insert(tbArea pArea)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    pArea.tbArea_UpdateTime = DateTime.Now;
                    dbContext.tbArea.Add(pArea);
                    dbContext.SaveChanges();

                    resultado = new Resultado()
                    {
                        PageName = "Area",
                        ClassName = "AreaProcess",
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
                    PageName = "Area",
                    ClassName = "AreaProcess",
                    MethodName = "Insert",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Update(tbArea pArea)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var area = dbContext.tbArea.Where(x => x.tbArea_Id == pArea.tbArea_Id).FirstOrDefault();

                    if (area != null)
                    {
                        area.tbArea_Descricao = string.IsNullOrWhiteSpace(pArea.tbArea_Descricao) ? area.tbArea_Descricao : pArea.tbArea_Descricao;
                        area.tbArea_Ativo = pArea.tbArea_Ativo;
                        area.tbArea_UpdateTime = DateTime.Now;

                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Area",
                            ClassName = "AreaProcess",
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
                    PageName = "Area",
                    ClassName = "AreaProcess",
                    MethodName = "Update",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Delete(tbArea pArea)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var area = dbContext.tbArea.Where(x => x.tbArea_Id == pArea.tbArea_Id).FirstOrDefault();

                    if (area != null)
                    {
                        dbContext.tbArea.Remove(area);
                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Area",
                            ClassName = "AreaProcess",
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
                    PageName = "Area",
                    ClassName = "AreaProcess",
                    MethodName = "Delete",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public tbArea GetId(int pIdData, int pIdAction)
        {
            tbArea registro = new tbArea();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    registro = (from x in dbContext.tbArea
                                where x.tbArea_Id == pIdData
                                select x).FirstOrDefault();

                    registro.idAction = pIdAction;
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Area",
                    ClassName = "AreaProcess",
                    MethodName = "GetId",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return registro;
        }

        public List<tbArea> GetAll()
        {
            List<tbArea> lista = new List<tbArea>();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    lista = (from x in dbContext.tbArea orderby x.tbArea_Descricao ascending select x).ToList();
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Area",
                    ClassName = "AreaProcess",
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
