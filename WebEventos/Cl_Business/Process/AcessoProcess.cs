using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cl_Entities;
using Cl_Tools;

namespace Cl_Business.Process
{
    internal class AcessoProcess
    {
        
        Resultado resultado = new Resultado();

        public Resultado Insert(tbAcesso pAcesso)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    pAcesso.tbAcesso_UpdateTime = DateTime.Now;
                    dbContext.tbAcesso.Add(pAcesso);
                    dbContext.SaveChanges();

                    resultado = new Resultado()
                    {
                        PageName = "Acesso",
                        ClassName = "AcessoProcess",
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
                    PageName = "Acesso",
                    ClassName = "AcessoProcess",
                    MethodName = "Insert",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Update(tbAcesso pAcesso)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var acesso = dbContext.tbAcesso.Where(x => x.tbAcesso_Id == pAcesso.tbAcesso_Id).FirstOrDefault();

                    if(acesso != null)
                    {
                        acesso.tbAcesso_Descrição = string.IsNullOrWhiteSpace(pAcesso.tbAcesso_Descrição) ? acesso.tbAcesso_Descrição : pAcesso.tbAcesso_Descrição;
                        acesso.tbAcesso_Ativo = pAcesso.tbAcesso_Ativo;
                        acesso.tbAcesso_Nivel = string.IsNullOrWhiteSpace(pAcesso.tbAcesso_Nivel) ? acesso.tbAcesso_Nivel : pAcesso.tbAcesso_Nivel;
                        acesso.tbAcesso_UpdateTime = DateTime.Now;

                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Acesso",
                            ClassName = "AcessoProcess",
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
                    PageName = "Acesso",
                    ClassName = "AcessoProcess",
                    MethodName = "Update",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Delete(tbAcesso pAcesso)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var acesso = dbContext.tbAcesso.Where(x => x.tbAcesso_Id == pAcesso.tbAcesso_Id).FirstOrDefault();

                    if(acesso != null)
                    { 
                        dbContext.tbAcesso.Remove(acesso);
                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Acesso",
                            ClassName = "AcessoProcess",
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
                    PageName = "Acesso",
                    ClassName = "AcessoProcess",
                    MethodName = "Delete",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public tbAcesso GetId(int pIdData, int pIdAction)
        {
            tbAcesso registro = new tbAcesso();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    registro = (from x in dbContext.tbAcesso
                                    where x.tbAcesso_Id == pIdData
                                    select x).FirstOrDefault();

                    registro.idAction = pIdAction;
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Acesso",
                    ClassName = "AcessoProcess",
                    MethodName = "GetId",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return registro;
        }

        public List<tbAcesso> GetAll()
        {
            List<tbAcesso> lista = new List<tbAcesso>();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                   lista = (from x in dbContext.tbAcesso select x).ToList();
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Acesso",
                    ClassName = "AcessoProcess",
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
