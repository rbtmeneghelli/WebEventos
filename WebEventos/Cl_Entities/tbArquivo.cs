//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cl_Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbArquivo
    {
        public tbArquivo()
        {
            this.tbAvaliacao = new HashSet<tbAvaliacao>();
        }
    
        public long tbArquivo_Id { get; set; }
        public string tbArquivo_Titulo { get; set; }
        public string tbArquivo_Descricao { get; set; }
        public Nullable<System.DateTime> tbArquivo_DataEntrega { get; set; }
        public string tbArquivo_Documento { get; set; }
        public Nullable<System.DateTime> tbArquivo_UpdateTime { get; set; }
        public Nullable<long> tbEvento_Id { get; set; }
        public Nullable<long> tbPalestra_Id { get; set; }
        public Nullable<long> tbUsuario_Id { get; set; }
    
        public virtual tbEvento tbEvento { get; set; }
        public virtual tbPalestra tbPalestra { get; set; }
        public virtual tbUsuario tbUsuario { get; set; }
        public virtual ICollection<tbAvaliacao> tbAvaliacao { get; set; }
    }
}
