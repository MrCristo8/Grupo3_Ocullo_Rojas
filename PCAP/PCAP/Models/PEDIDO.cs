//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PCAP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class PEDIDO
    {
        [Required]
        [Display(Name = "Código pedido")]
        public int CODIGOPEDIDO { get; set; }
        [Required]
        [Display(Name = "Cliente")]
        public int CODIGOCLIENTE { get; set; }
        [Required]
        [Display(Name = "Producto")]
        public int CODIGOPRODUCTO { get; set; }
        [Required]
        [Display(Name = "Fecha de pedido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime FECHAPEDIDO { get; set; }
        [Required]
        [Display(Name = "Cantidad de pedido")]
        public int CANTIDADPEDIDO { get; set; }

        public virtual CLIENTE CLIENTE { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}