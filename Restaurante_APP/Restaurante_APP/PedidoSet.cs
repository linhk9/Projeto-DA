//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurante_APP
{
    using System;
    using System.Collections.Generic;
    
    public partial class PedidoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PedidoSet()
        {
            this.PagamentoSet = new HashSet<PagamentoSet>();
            this.ItemMenuSet = new HashSet<ItemMenuSet>();
        }
    
        public int IdPedido { get; set; }
        public int EstadoPedidoIdEstado { get; set; }
        public double ValorTotal { get; set; }
        public int Trabalhador_IdPessoa { get; set; }
        public int Cliente_IdPessoa { get; set; }
        public int Restaurante_IdRestaurante { get; set; }
    
        public virtual EstadoPedidoSet EstadoPedidoSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PagamentoSet> PagamentoSet { get; set; }
        public virtual Pessoa_Cliente Pessoa_Cliente { get; set; }
        public virtual Restaurante Restaurante { get; set; }
        public virtual Pessoa_Trabalhador Pessoa_Trabalhador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemMenuSet> ItemMenuSet { get; set; }
    }
}
