using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cl_Tools;

namespace Cl_Entities
{
    public partial class tbInstituicao
    {
        public int idData { get; set; }

        public int idAction { get; set; }

        public List<DropDownList> ListaEstado()
        {
            List<DropDownList> lista = new List<DropDownList>();

            //Criar tabela das siglas de estados
            //using (dbWebEventoEntities dbContext = new dbWebEventoEntities())
            //{
            //    lista.Add(new DropDownList() { Id = "SP", Value = "SP" });
            //    lista.Add(new DropDownList() { Id = "RS", Value = "RS" });
            //    lista.Add(new DropDownList() { Id = "MG", Value = "MG" });
            //    lista.Add(new DropDownList() { Id = "RJ", Value = "RJ" });
            //}

            return lista;
        }
    }
}
