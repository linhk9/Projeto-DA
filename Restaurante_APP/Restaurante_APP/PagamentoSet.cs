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
    
    public partial class PagamentoSet
    {
        public int IdPagamento { get; set; }
        public double Valor { get; set; }
        public int Pedido_IdPedido { get; set; }
        public int MetodoPagamento_IdMetodo { get; set; }
    
        public virtual MetodoPagamentoSet MetodoPagamentoSet { get; set; }
        public virtual PedidoSet PedidoSet { get; set; }
    }
}