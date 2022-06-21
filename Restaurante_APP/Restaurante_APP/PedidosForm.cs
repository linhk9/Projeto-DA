using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_APP
{
    public partial class Pedidos : Form
    {
        public static RestauranteAPPContainer restauranteAPP;
        public static Pedidos pedidos;
        public Pedidos(Pedidos Pedidosselected)
        {
            InitializeComponent();
            Pedidosselected = pedidos;
        }

        private void Pedidos_Load(object sender, EventArgs e)
        {

        }
    }
}
