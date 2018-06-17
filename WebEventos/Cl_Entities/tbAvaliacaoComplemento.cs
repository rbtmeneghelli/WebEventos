using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cl_Tools;

namespace Cl_Entities
{
    public partial class tbAvaliacao
    {
        public int idData { get; set; }

        public int idAction { get; set; }

        public string tbAvaliacao_Titulo { get; set; }

        public string tbAvaliacao_UserName { get; set; }

        public List<DropDownList> ListaResponsavel()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista = (from x in dbContext.tbUsuario 
                         join z in dbContext.tbAcesso
                         on x.tbAcesso_Id equals z.tbAcesso_Id
                         where x.tbUsuario_Ativo == true && z.tbAcesso_Nivel != "Baixo"
                         select new DropDownList() { Id = x.tbUsuario_Id.ToString(), Value = x.tbUsuario_Email }).ToList();
            }

            return lista;
        }

        public List<DropDownList> ListaStatus()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista.Add(new DropDownList() { Id = "Aprovado", Value = "Aprovado" });
                lista.Add(new DropDownList() { Id = "Reprovado", Value = "Reprovado" });
            }

            return lista;
        }

        public List<DropDownList> ListaArquivo()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista = (from x in dbContext.tbArquivo
                         select new DropDownList() { Id = x.tbArquivo_Id.ToString(), Value = x.tbArquivo_Titulo }).ToList();
            }

            return lista;
        }
    }
}
