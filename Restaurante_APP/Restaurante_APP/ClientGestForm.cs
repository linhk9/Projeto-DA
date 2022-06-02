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
    public partial class ClientGestForm : Form
    {
        public ClientGestForm()
        {
            InitializeComponent();
        }

        private void ClientGestForm_Load(object sender, EventArgs e)
        {

        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            ClientGestForm form = new ClientGestForm();
            form.Close();
        }
    }
}
