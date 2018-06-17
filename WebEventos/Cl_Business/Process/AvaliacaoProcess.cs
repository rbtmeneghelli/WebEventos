using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cl_Entities;
using Cl_Tools;

namespace Cl_Business.Process
{
    internal class AvaliacaoProcess
    {
        Resultado resultado = new Resultado();

        public Resultado Insert(tbAvaliacao pAval)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    pAval.tbAvaliacao_UpdateTime = DateTime.Now;
                    dbContext.tbAvaliacao.Add(pAval);
                    dbContext.SaveChanges();

                    resultado = new Resultado()
                    {
                        PageName = "Avaliação",
                        ClassName = "AvaliaçãoProcess",
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
                    PageName = "Avaliação",
                    ClassName = "AvaliaçãoProcess",
                    MethodName = "Insert",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Update(tbAvaliacao pAval)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var aval = dbContext.tbAvaliacao.Where(x => x.tbAvaliacao_Id == pAval.tbAvaliacao_Id).FirstOrDefault();

                    if (aval != null)
                    {
                        aval.tbAvaliacao_Responsavel = string.IsNullOrWhiteSpace(pAval.tbAvaliacao_Responsavel) ? aval.tbAvaliacao_Responsavel : pAval.tbAvaliacao_Responsavel;
                        aval.tbAvaliacao_Status = string.IsNullOrWhiteSpace(pAval.tbAvaliacao_Status) ? aval.tbAvaliacao_Status : pAval.tbAvaliacao_Status;
                        aval.tbAvaliacao_Apresentacao = pAval.tbAvaliacao_Apresentacao;
                        aval.tbAvaliacao_Clareza = pAval.tbAvaliacao_Clareza;
                        aval.tbAvaliacao_Data = pAval.tbAvaliacao_Data;
                        aval.tbAvaliacao_Dominio = pAval.tbAvaliacao_Dominio;
                        aval.tbAvaliacao_Objetivo = pAval.tbAvaliacao_Objetivo;
                        aval.tbAvaliacao_Origem = pAval.tbAvaliacao_Origem;
                        aval.tbAvaliacao_Qualidade = pAval.tbAvaliacao_Qualidade;
                        aval.tbAvaliacao_UpdateTime = DateTime.Now;

                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Avaliação",
                            ClassName = "AvaliaçãoProcess",
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
                    PageName = "Avaliação",
                    ClassName = "AvaliaçãoProcess",
                    MethodName = "Update",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Delete(tbAvaliacao pAval)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var aval = dbContext.tbAvaliacao.Where(x => x.tbAvaliacao_Id == pAval.tbAvaliacao_Id).FirstOrDefault();

                    if (aval != null)
                    {
                        dbContext.tbAvaliacao.Remove(aval);
                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Avaliação",
                            ClassName = "AvaliaçãoProcess",
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
                    PageName = "Avaliação",
                    ClassName = "AvaliaçãoProcess",
                    MethodName = "Delete",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public tbAvaliacao GetId(int pIdData, int pIdAction)
        {
            tbAvaliacao registro = new tbAvaliacao();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    registro = (from x in dbContext.tbAvaliacao
                                where x.tbAvaliacao_Id == pIdData
                                select x).FirstOrDefault();

                    registro.idAction = pIdAction;
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Avaliação",
                    ClassName = "AvaliaçãoProcess",
                    MethodName = "GetId",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return registro;
        }

        public List<tbAvaliacao> GetAll()
        {
            List<tbAvaliacao> lista = new List<tbAvaliacao>();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    lista = (from x in dbContext.tbAvaliacao 
                             select new tbAvaliacao() {
                             tbAvaliacao_Id = x.tbAvaliacao_Id,
                             tbAvaliacao_Responsavel = x.tbAvaliacao_Responsavel,
                             tbAvaliacao_Data = x.tbAvaliacao_Data,
                             tbAvaliacao_Origem = x.tbAvaliacao_Origem,
                             tbAvaliacao_Objetivo = x.tbAvaliacao_Objetivo,
                             tbAvaliacao_Clareza = x.tbAvaliacao_Clareza,
                             tbAvaliacao_Dominio = x.tbAvaliacao_Dominio,
                             tbAvaliacao_Qualidade = x.tbAvaliacao_Qualidade,
                             tbAvaliacao_Apresentacao = x.tbAvaliacao_Apresentacao,
                             tbAvaliacao_Status = x.tbAvaliacao_Status,
                             tbAvaliacao_UpdateTime = x.tbAvaliacao_UpdateTime,
                             tbArquivo_Id = x.tbArquivo_Id,
                             tbAvaliacao_Titulo = (from z in dbContext.tbArquivo where z.tbArquivo_Id == x.tbArquivo_Id select z.tbArquivo_Titulo).FirstOrDefault(),

                             }).ToList();
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Avaliação",
                    ClassName = "AvaliaçãoProcess",
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
