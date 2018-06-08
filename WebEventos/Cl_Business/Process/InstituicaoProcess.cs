using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cl_Entities;
using Cl_Tools;

namespace Cl_Business.Process
{
    internal class InstituicaoProcess
    {
        Resultado resultado = new Resultado();

        public Resultado Insert(tbInstituicao pInst)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    pInst.tbInstituicao_UpdateTime = DateTime.Now;
                    dbContext.tbInstituicao.Add(pInst);
                    dbContext.SaveChanges();

                    resultado = new Resultado()
                    {
                        PageName = "Instituição",
                        ClassName = "InstituiçãoProcess",
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
                    PageName = "Instituição",
                    ClassName = "InstituiçãoProcess",
                    MethodName = "Insert",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Update(tbInstituicao pInst)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var inst = dbContext.tbInstituicao.Where(x => x.tbInstituicao_Id == pInst.tbInstituicao_Id).FirstOrDefault();

                    if (inst != null)
                    {
                        inst.tbInstituicao_Bairro = string.IsNullOrWhiteSpace(pInst.tbInstituicao_Bairro) ? inst.tbInstituicao_Bairro : pInst.tbInstituicao_Bairro;
                        inst.tbInstituicao_Cep = string.IsNullOrWhiteSpace(pInst.tbInstituicao_Cep) ? inst.tbInstituicao_Cep : pInst.tbInstituicao_Cep;
                        inst.tbInstituicao_Cidade = string.IsNullOrWhiteSpace(pInst.tbInstituicao_Cidade) ? inst.tbInstituicao_Cidade : pInst.tbInstituicao_Cidade;
                        inst.tbInstituicao_Cnpj = string.IsNullOrWhiteSpace(pInst.tbInstituicao_Cnpj) ? inst.tbInstituicao_Cnpj : pInst.tbInstituicao_Cnpj;
                        inst.tbInstituicao_Descricao = string.IsNullOrWhiteSpace(pInst.tbInstituicao_Descricao) ? inst.tbInstituicao_Descricao : pInst.tbInstituicao_Descricao;
                        inst.tbInstituicao_Estado = string.IsNullOrWhiteSpace(pInst.tbInstituicao_Estado) ? inst.tbInstituicao_Estado : pInst.tbInstituicao_Estado;
                        inst.tbInstituicao_Telefone = string.IsNullOrWhiteSpace(pInst.tbInstituicao_Telefone) ? inst.tbInstituicao_Telefone : pInst.tbInstituicao_Telefone;
                        inst.tbInstituicao_UpdateTime = DateTime.Now;

                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Instituição",
                            ClassName = "InstituiçãoProcess",
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
                    PageName = "Instituição",
                    ClassName = "InstituiçãoProcess",
                    MethodName = "Update",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Delete(tbInstituicao pInst)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var inst = dbContext.tbInstituicao.Where(x => x.tbInstituicao_Id == pInst.tbInstituicao_Id).FirstOrDefault();

                    if (inst != null)
                    {
                        dbContext.tbInstituicao.Remove(inst);
                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Instituição",
                            ClassName = "InstituiçãoProcess",
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

        public tbInstituicao GetId(int pIdData, int pIdAction)
        {
            tbInstituicao registro = new tbInstituicao();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    registro = (from x in dbContext.tbInstituicao
                                where x.tbInstituicao_Id == pIdData
                                select x).FirstOrDefault();

                    registro.idAction = pIdAction;
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Instituição",
                    ClassName = "InstituiçãoProcess",
                    MethodName = "GetId",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return registro;
        }

        public List<tbInstituicao> GetAll()
        {
            List<tbInstituicao> lista = new List<tbInstituicao>();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    lista = (from x in dbContext.tbInstituicao select x).ToList();
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Instituição",
                    ClassName = "InstituiçãoProcess",
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
