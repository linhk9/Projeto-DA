using MaterialSkin.Controls;
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
    public partial class RestGestForm : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public RestGestForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Indigo200, MaterialSkin.TextShade.WHITE);
        }

        private void gestaoDeClientesButton_Click(object sender, EventArgs e)
        {
            GestaoClientesForm ClientForm = new GestaoClientesForm();
            ClientForm.ShowDialog();
        }

        private void gesstãoDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestaoClientesForm ClientForm = new GestaoClientesForm();
            ClientForm.ShowDialog();
        }

        private void gestaoGlobalDeRestaurantesButton_Click(object sender, EventArgs e)
        {
            GestaoRestaurantesForm RestForm = new GestaoRestaurantesForm();
            RestForm.ShowDialog();
        }

        private void pedidosButton_Click(object sender, EventArgs e)
        {
            PedidosForm pedidosForm = new PedidosForm();
            pedidosForm.ShowDialog();
        }

        private void gestaoGlobalDeRestaurantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GestaoRestaurantesForm RestForm = new GestaoRestaurantesForm();
            RestForm.ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PedidosForm pedidosForm = new PedidosForm();
            pedidosForm.ShowDialog();
        }
    }
}
