using Cl_Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cl_Entities
{
    public partial class tbArquivo
    {
        public IEnumerable<HttpPostedFileBase> Arquivos { get; set; }

        public int idData { get; set; }

        public int idAction { get; set; }

        public List<DropDownList> ListaEvento()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista = (from x in dbContext.tbEvento
                         select new DropDownList()
                         {
                             Id = x.tbEvento_Id.ToString(),
                             Value = x.tbEvento_Titulo
                         }).ToList();
            }

            return lista;
        }

        public List<DropDownList> ListaPalestra()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista = (from x in dbContext.tbPalestra
                         select new DropDownList()
                         {
                             Id = x.tbPalestra_Id.ToString(),
                             Value = x.tbPalestra_Titulo
                         }).ToList();
            }

            return lista;
        }

        public List<DropDownList> ListaResponsavel()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista = (from x in dbContext.tbUsuario
                         where x.tbUsuario_Ativo == true
                         select new DropDownList()
                         {
                             Id = x.tbUsuario_Id.ToString(),
                             Value = x.tbUsuario_Email
                         }).ToList();
            }

            return lista;
        }
    }
}
