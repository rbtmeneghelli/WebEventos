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
    
    public partial class tbPalestra
    {
        public long tbPalestra_Id { get; set; }
        public string tbPalestra_Titulo { get; set; }
        public Nullable<System.DateTime> tbPalestra_DataEvento { get; set; }
        public Nullable<System.DateTime> tbPalestra_UpdateTime { get; set; }
        public Nullable<long> tbArea_Id { get; set; }
        public Nullable<long> tbUsuario_Id { get; set; }
    
        public virtual tbArea tbArea { get; set; }
        public virtual tbUsuario tbUsuario { get; set; }
    }
}
