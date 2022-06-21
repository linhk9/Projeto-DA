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
    public partial class GestRest : Form
    {
        public static RestauranteAPPContainer restauranteAPP;
        public static Restaurante restaurante;

        public GestRest(Restaurante restauranteselected)
        {
            InitializeComponent();
            restaurante = restauranteselected;
        }

        private void GestRest_Load(object sender, EventArgs e)
        {
            restauranteAPP = new RestauranteAPPContainer();
            LerDadosTrabalhadores();
        }

        private void LerDadosTrabalhadores()
        {
            listBox_Trabalhadores.DataSource = restaurante.Pessoa_Trabalhador.OfType<Pessoa_Trabalhador>().ToList();
            listBox_Trabalhadores.Refresh();
        }
        private void LerDadosPedidos()
        {
            listBoxPedidos.DataSource = restaurante.PedidoSet.OfType<PedidoSet>().ToList();
            listBoxPedidos.Refresh();
        }

        private void LerDadosMenus()
        {
            listboxMenusIndividual.DataSource = restaurante.ItemMenuSet.OfType<ItemMenuSet>().ToList();
            listboxMenusIndividual.Refresh();
        }
        private void LerDadosMenustodos()
        {
            comboBoxMenus.DataSource = restauranteAPP.ItemMenuSet.OfType<ItemMenuSet>().ToList();
            comboBoxMenus.Refresh();
        }

        private bool VerificarTexto(string texto)
        {
            return String.IsNullOrEmpty(texto);
        }

        private void Btn_RegistarTrabalhador_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAdd_Nome.Text) && VerificarTexto(textBoxAdd_Rua.Text) && VerificarTexto(textBoxAdd_CodPostal.Text) && VerificarTexto(textBoxAdd_Cidade.Text) && VerificarTexto(textBoxAdd_Pais.Text) && VerificarTexto(txtAddPosicao.Text) && VerificarTexto(txtAddPosicao.Text)))
            {
                Pessoa pessoa = new Pessoa
                {
                    Nome = textBoxAdd_Nome.Text,
                    Telemovel = Int32.Parse(txtAddTelemovel.Text)
                };

                Pessoa_Trabalhador trabalhador = new Pessoa_Trabalhador
                {
                    Pessoa = pessoa,
                    Posicao = txtAddPosicao.Text,
                    Restaurante_IdRestaurante = restaurante.IdRestaurante,
                    Salario = double.Parse(txtAddSalario.Text)
                };

                MoradaSet morada = new MoradaSet
                {
                    Pais = textBoxAdd_Pais.Text,
                    Cidade = textBoxAdd_Cidade.Text,
                    Rua = textBoxAdd_Rua.Text,
                    CodPostal = textBoxAdd_CodPostal.Text
                };

                pessoa.MoradaSet = morada;

                restauranteAPP.Pessoa_Trabalhador.Add(trabalhador);
                restauranteAPP.MoradaSet.Add(morada);
                restauranteAPP.SaveChanges();
                LerDadosTrabalhadores();

                foreach (TextBox textBox in groupBox_RegistarRestaurante.Controls.OfType<TextBox>())
                {
                    textBox.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para adicionares um cliente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ListBox_Trabalhadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pessoa_Trabalhador trabalhador = (Pessoa_Trabalhador)listBox_Trabalhadores.SelectedItem;
            textBoxAlterar_Nome.Text = trabalhador.Pessoa.Nome;
            txtAlterarTelemovel.Text = trabalhador.Pessoa.Telemovel.ToString();
            txtAlterarPosicao.Text = trabalhador.Posicao;
            txtAlterarSalario.Text =  trabalhador.Salario.ToString();
            textBoxAlterar_Rua.Text = trabalhador.Pessoa.MoradaSet.Rua;
            textBoxAlterar_CodPostal.Text = trabalhador.Pessoa.MoradaSet.CodPostal;
            textBoxAlterar_Cidade.Text = trabalhador.Pessoa.MoradaSet.Cidade;
            textBoxAlterar_Pais.Text = trabalhador.Pessoa.MoradaSet.Pais;
        }

        private void Btn_AlterarTrabalhador_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAlterar_Nome.Text) && VerificarTexto(textBoxAlterar_Rua.Text) && VerificarTexto(textBoxAlterar_CodPostal.Text) && VerificarTexto(textBoxAlterar_Cidade.Text) && VerificarTexto(textBoxAlterar_Pais.Text) && VerificarTexto(txtAlterarPosicao.Text) && VerificarTexto(txtAlterarTelemovel.Text) && VerificarTexto(txtAlterarSalario.Text)))
            {
                Pessoa_Trabalhador trabalhador = (Pessoa_Trabalhador)listBox_Trabalhadores.SelectedItem;
                trabalhador.Pessoa.Nome = textBoxAlterar_Nome.Text;
                trabalhador.Pessoa.Telemovel = Int32.Parse(txtAlterarTelemovel.Text);
                trabalhador.Posicao = txtAlterarPosicao.Text;
                trabalhador.Salario = double.Parse(txtAlterarSalario.Text);
                trabalhador.Pessoa.MoradaSet.Rua = textBoxAlterar_Rua.Text;
                trabalhador.Pessoa.MoradaSet.CodPostal = textBoxAlterar_CodPostal.Text;
                trabalhador.Pessoa.MoradaSet.Cidade = textBoxAlterar_Cidade.Text;
                trabalhador.Pessoa.MoradaSet.Pais = textBoxAlterar_Pais.Text;

                restauranteAPP.SaveChanges();
                LerDadosTrabalhadores();
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para poderes alterar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_ApagarTrabalhador_Click(object sender, EventArgs e)
        {
            Pessoa_Trabalhador trabalhador = (Pessoa_Trabalhador)listBox_Trabalhadores.SelectedItem;

            restauranteAPP.Pessoa.Remove(trabalhador.Pessoa);
            restauranteAPP.Pessoa_Trabalhador.Remove(trabalhador);
            restauranteAPP.SaveChanges();
            LerDadosTrabalhadores();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listboxMenusIndividual_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
