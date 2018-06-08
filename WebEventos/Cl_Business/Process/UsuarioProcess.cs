using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Sql;

using Cl_Entities;
using Cl_Tools;

namespace Cl_Business.Process
{
    internal class UsuarioProcess
    {
        Resultado resultado = new Resultado();

        public Resultado Insert(tbUsuario pUsuario)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    pUsuario.tbUsuario_UpdateTime = DateTime.Now;
                    dbContext.tbUsuario.Add(pUsuario);
                    dbContext.SaveChanges();

                    resultado = new Resultado()
                    {
                        PageName = "Usuario",
                        ClassName = "UsuarioProcess",
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
                    PageName = "Usuario",
                    ClassName = "UsuarioProcess",
                    MethodName = "Insert",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Update(tbUsuario pUsuario)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var usuario = dbContext.tbUsuario.Where(x => x.tbUsuario_Id == pUsuario.tbUsuario_Id).FirstOrDefault();

                    if (usuario != null)
                    {
                        usuario.tbUsuario_Login = string.IsNullOrWhiteSpace(pUsuario.tbUsuario_Login) ? usuario.tbUsuario_Login : pUsuario.tbUsuario_Login;
                        usuario.tbUsuario_Senha = string.IsNullOrWhiteSpace(pUsuario.tbUsuario_Senha) ? usuario.tbUsuario_Senha : pUsuario.tbUsuario_Senha;
                        usuario.tbUsuario_Ativo = pUsuario.tbUsuario_Ativo;
                        usuario.tbUsuario_UpdateTime = DateTime.Now;

                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Usuario",
                            ClassName = "UsuarioProcess",
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
                    PageName = "Usuario",
                    ClassName = "UsuarioProcess",
                    MethodName = "Update",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public Resultado Delete(tbUsuario pUsuario)
        {
            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    var usuario = dbContext.tbUsuario.Where(x => x.tbUsuario_Id == pUsuario.tbUsuario_Id).FirstOrDefault();

                    if (usuario != null)
                    {
                        dbContext.tbUsuario.Remove(usuario);
                        dbContext.SaveChanges();

                        resultado = new Resultado()
                        {
                            PageName = "Usuario",
                            ClassName = "UsuarioProcess",
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

        public tbUsuario GetId(int pIdData, int pIdAction)
        {
            tbUsuario registro = new tbUsuario();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    registro = (from x in dbContext.tbUsuario
                                where x.tbUsuario_Id == pIdData
                                select x).FirstOrDefault();

                    registro.idAction = pIdAction;
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Usuario",
                    ClassName = "UsuarioProcess",
                    MethodName = "GetId",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return registro;
        }

        public List<tbUsuario> GetAll()
        {
            List<tbUsuario> lista = new List<tbUsuario>();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    lista = (from x in dbContext.tbUsuario select x).ToList();
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Usuario",
                    ClassName = "UsuarioProcess",
                    MethodName = "GetAll",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return lista;
        }

        internal Resultado EsqueciSenha(tbUsuario user)
        {
            Random numero = new Random();
            string emailMessage = string.Empty;
            string password = string.Empty;
            
            tbUsuario usuario = new tbUsuario();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            { 
                usuario = dbContext.tbUsuario.Where(x => x.tbUsuario_Email == user.tbUsuario_Email.ToUpper()).FirstOrDefault();
                password = Util.BuildPassword();

                if (usuario != null)
                {
                    usuario.tbUsuario_Senha = new ClsSecurity().EncryptText(password);
                    usuario.NovaSenha = password;

                    dbContext.Entry(usuario).State = EntityState.Modified;
                    dbContext.SaveChanges();

                    emailMessage = "<p> Caro Usuario, <b> " + usuario.tbUsuario_Login + " </b> </p> <br>" + "<p> Este email confirma que a sua solicitação para reset de senha foi efetuada com sucesso.</p> <br>" + "<p> Senha de acesso: <b>" + usuario.NovaSenha + " </b></p> <br>" + "<p> Caso não tenha sido você o solicitante do seu reset de senha, favor entre em contato com o administrador do sistema. </p>";

                    resultado = new Resultado()
                    {
                        PageName = "Usuario",
                        ClassName = "UsuarioProcess",
                        MethodName = "EsqueciSenha",
                        ExceptionMsg = "Solicitação de nova senha efetuada com sucesso",
                        ResultAction = true,
                        DateAction = DateTime.Now,
                        IdUserAction = 0
                    };
                    //Util.EnviarEmail("", usuario.Email.ToLower(), "Nova senha de acesso", emailMessage);
                }
                else
                {
                    resultado = new Resultado()
                    {
                        PageName = "Usuario",
                        ClassName = "UsuarioProcess",
                        MethodName = "EsqueciSenha",
                        ExceptionMsg = "Não foi possivel efetuar a solicitação da nova senha",
                        ResultAction = false,
                        DateAction = DateTime.Now,
                        IdUserAction = 0
                    };
                }
                return resultado;
            }
        }
    }
}
