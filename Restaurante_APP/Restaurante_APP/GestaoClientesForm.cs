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
    public partial class GestaoClientesForm : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public static RestauranteAPPContainer restauranteAPP;

        public GestaoClientesForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Indigo200, MaterialSkin.TextShade.WHITE);
        }

        private void ClientGestForm_Load(object sender, EventArgs e)
        {
            restauranteAPP = new RestauranteAPPContainer();
            LerDados();
        }

        private void LerDados()
        {
            listBox_Clientes.DataSource = restauranteAPP.Pessoa_Cliente.OfType<Pessoa_Cliente>().ToList();
            listBox_Clientes.Refresh();
        }

        private bool VerificarTexto(string texto) 
        {
            return String.IsNullOrEmpty(texto);
        }

        private void BtnApagar_Click(object sender, EventArgs e)
        {
            Pessoa_Cliente cliente = (Pessoa_Cliente)listBox_Clientes.SelectedItem;

            restauranteAPP.Pessoa.Remove(cliente.Pessoa);
            restauranteAPP.Pessoa_Cliente.Remove(cliente);
            restauranteAPP.SaveChanges();
            LerDados();
        }

        private void BtnAlterar_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAlterar_Nome.Text) && VerificarTexto(textBoxAlterar_Telemovel.Text) && VerificarTexto(textBoxAlterar_NumeroContribuinte.Text) && VerificarTexto(textBoxAlterar_Rua.Text) && VerificarTexto(textBoxAlterar_CodPostal.Text) && VerificarTexto(textBoxAlterar_Cidade.Text) && VerificarTexto(textBoxAlterar_Pais.Text)))
            {
                Pessoa_Cliente cliente = (Pessoa_Cliente)listBox_Clientes.SelectedItem;
                cliente.Pessoa.Nome = textBoxAlterar_Nome.Text;
                cliente.Pessoa.Telemovel = Int32.Parse(textBoxAlterar_Telemovel.Text);
                cliente.NumContribuinte = Int32.Parse(textBoxAlterar_NumeroContribuinte.Text);
                cliente.Pessoa.MoradaSet.Rua = textBoxAlterar_Rua.Text;
                cliente.Pessoa.MoradaSet.CodPostal = textBoxAlterar_CodPostal.Text;
                cliente.Pessoa.MoradaSet.Cidade = textBoxAlterar_Cidade.Text;
                cliente.Pessoa.MoradaSet.Pais = textBoxAlterar_Pais.Text;

                restauranteAPP.SaveChanges();
                LerDados();
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para poderes alterar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnAdicionarCliente_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAdd_Nome.Text) && VerificarTexto(textBoxAdd_Telemovel.Text) && VerificarTexto(textBoxAdd_NumContribuinte.Text) && VerificarTexto(textBoxAdd_Rua.Text) && VerificarTexto(textBoxAdd_CodPostal.Text) && VerificarTexto(textBoxAdd_Cidade.Text) && VerificarTexto(textBoxAdd_Pais.Text)))
            {
                Pessoa pessoa = new Pessoa
                {
                    Nome = textBoxAdd_Nome.Text,
                    Telemovel = Int32.Parse(textBoxAdd_Telemovel.Text)
                };


                Pessoa_Cliente cliente = new Pessoa_Cliente
                {
                    Pessoa = pessoa,
                    NumContribuinte = Int32.Parse(textBoxAdd_NumContribuinte.Text)
                };

                MoradaSet morada = new MoradaSet
                {
                    Pais = textBoxAdd_Pais.Text,
                    Cidade = textBoxAdd_Cidade.Text,
                    Rua = textBoxAdd_Rua.Text,
                    CodPostal = textBoxAdd_CodPostal.Text
                };

                pessoa.MoradaSet = morada;

                restauranteAPP.Pessoa_Cliente.Add(cliente);
                restauranteAPP.MoradaSet.Add(morada);
                restauranteAPP.SaveChanges();
                LerDados();

                foreach (TextBox textBox in groupBox_RegistarCliente.Controls.OfType<TextBox>())
                {
                    textBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para adicionares um cliente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ListBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pessoa_Cliente cliente = (Pessoa_Cliente)listBox_Clientes.SelectedItem;
            textBoxAlterar_Nome.Text = cliente.Pessoa.Nome;
            textBoxAlterar_Telemovel.Text = cliente.Pessoa.Telemovel.ToString();
            textBoxAlterar_NumeroContribuinte.Text = cliente.NumContribuinte.ToString();
            textBoxAlterar_Rua.Text = cliente.Pessoa.MoradaSet.Rua;
            textBoxAlterar_CodPostal.Text = cliente.Pessoa.MoradaSet.CodPostal;
            textBoxAlterar_Cidade.Text = cliente.Pessoa.MoradaSet.Cidade;
            textBoxAlterar_Pais.Text = cliente.Pessoa.MoradaSet.Pais;
        }
    }
}
