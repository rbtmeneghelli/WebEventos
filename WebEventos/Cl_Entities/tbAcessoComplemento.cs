using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cl_Tools;

namespace Cl_Entities
{
    public partial class  tbAcesso
    {
        public int idData { get; set; }

        public int idAction { get; set; }

        public string Ativo { get; set; }

        public List<DropDownList> ListaNivelAcesso()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista = (from x in dbContext.tbAcesso orderby x.tbAcesso_Nivel select new DropDownList() { Id = x.tbAcesso_Id.ToString(), Value = x.tbAcesso_Nivel }).ToList();
            }

            return lista;
        }

        public List<DropDownList> ListaAtivo()
        {
            List<DropDownList> lista = new List<DropDownList>();

            using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            {
                lista.Add(new DropDownList() { Id = "Sim", Value = "Sim" });
                lista.Add(new DropDownList() { Id = "Não", Value = "Não" });
            }

            return lista;
        }
    }
}
