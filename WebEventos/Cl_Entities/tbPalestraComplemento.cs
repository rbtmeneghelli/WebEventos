using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cl_Tools;

namespace Cl_Entities
{
    public partial class tbPalestra
    {
        public int idData { get; set; }

        public int idAction { get; set; }

        public List<DropDownList> ListaArea()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista = (from x in dbContext.tbArea
                         where x.tbArea_Ativo == true
                         select new DropDownList()
                         {
                             Id = x.tbArea_Id.ToString(),
                             Value = x.tbArea_Descricao
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
