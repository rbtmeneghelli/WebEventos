using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Cl_Tools;
using Cl_Entities;

namespace Cl_Business.Process
{
    internal class ArquivoProcess
    {
        Resultado resultado = new Resultado();

        public Resultado Backup(tbBackup pBackup)
        {
            SqlConnection conn;

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    string stConnectionString = string.Format(@"Data Source={0};Initial Catalog={1};Trusted_Connection=False;User Id=teste;Password=1234", pBackup.tbBackup_Servidor, pBackup.tbBackup_Database);

                    conn = new SqlConnection(stConnectionString);
                    var nomeArquivo = string.Format("{0}_{1}.{2}","DbWebEvento_", DateTime.Now.ToString("ddMMyyyy"), ".bak");
                    var query = string.Format("Backup database {0} to disk={1}\\{2}", pBackup.tbBackup_Database, pBackup.tbBackup_Diretorio, nomeArquivo);
                    conn.Open();
                    var cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    resultado = new Resultado()
                    {
                        PageName = "Backup",
                        ClassName = "BackupProcess",
                        MethodName = "Backup",
                        ExceptionMsg = "Arquivo de backup criado com sucesso",
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
                    PageName = "Backup",
                    ClassName = "BackupProcess",
                    MethodName = "Backup",
                    ExceptionMsg = ex.Message,
                    ResultAction = false,
                    DateAction = DateTime.Now,
                    IdUserAction = 1
                };
            }

            return resultado;
        }

        public List<tbArquivo> GetAll()
        {
            List<tbArquivo> lista = new List<tbArquivo>();

            try
            {
                using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
                {
                    lista = (from x in dbContext.tbArquivo select x).ToList();
                }
            }

            catch (Exception ex)
            {
                resultado = new Resultado()
                {
                    PageName = "Arquivo",
                    ClassName = "ArquivoProcess",
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
