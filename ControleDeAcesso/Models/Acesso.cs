//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ControleDeAcesso.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Acesso
    {
        public int id_login { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string ativo { get; set; }
        public string perfil { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
    }
}
