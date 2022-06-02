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
    public partial class RestGestForm : Form
    {
        public RestGestForm()
        {
            InitializeComponent();
        }

        private void gestaoDeClientesButton_Click(object sender, EventArgs e)
        {
            ClientGestForm ClientForm = new ClientGestForm();
            ClientForm.ShowDialog();
        }

        private void gesstãoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientGestForm ClientForm = new ClientGestForm();
            ClientForm.ShowDialog();
        }

        private void gestaoGlobalDeRestaurantesButton_Click(object sender, EventArgs e)
        {
            GestRest RestForm = new GestRest();
            RestForm.ShowDialog();
        }

        private void pedidosButton_Click(object sender, EventArgs e)
        {
            Pedidos PedidosForm = new Pedidos();
            PedidosForm.ShowDialog();
        }

        private void gestaoGlobalDeRestaurantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestRest RestForm = new GestRest();
            RestForm.ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pedidos PedidosForm = new Pedidos();
            PedidosForm.ShowDialog();
        }
    }
}
