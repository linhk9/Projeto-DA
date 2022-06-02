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
        public Pedidos()
        {
            InitializeComponent();
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            Pedidos PedidosForm = new Pedidos();
            PedidosForm.Close();
        }
    }
}
