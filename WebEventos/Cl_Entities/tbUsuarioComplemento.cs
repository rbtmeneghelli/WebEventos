using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cl_Tools;

namespace Cl_Entities
{
    public partial class tbUsuario
    {
        public int idData { get; set; }

        public int idAction { get; set; }

        public string Ativo { get; set; }

        public string NovaSenha { get; set; }

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
