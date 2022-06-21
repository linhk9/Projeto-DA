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

        private void LerDadosTrabalhadores()
        {
            listBox_Trabalhadores.DataSource = restauranteAPP.Pessoa_Trabalhador.OfType<Pessoa_Trabalhador>().ToList();
            listBox_Trabalhadores.Refresh();
        }
        private bool VerificarTexto(string texto)
        {
            return String.IsNullOrEmpty(texto);
        }


        private void btn_RegistarTrabalhador_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAdd_Nome.Text) && VerificarTexto(textBoxAdd_Rua.Text) && VerificarTexto(textBoxAdd_CodPostal.Text) && VerificarTexto(textBoxAdd_Cidade.Text) && VerificarTexto(textBoxAdd_Pais.Text) && VerificarTexto(txtAddPosicao.Text) && VerificarTexto(txtAddPosicao.Text)))
            {
                Pessoa pessoa = new Pessoa
                {
                    Nome = textBoxAdd_Nome.Text
                };

                Pessoa_Trabalhador trabalhador = new Pessoa_Trabalhador
                {
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

                restaurante.MoradaSet = morada;

                restauranteAPP.Pessoa_Trabalhador.Add(trabalhador);
                restauranteAPP.Restaurante.Add(restaurante);
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

        private void ListBox_Restaurantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Pessoa_Trabalhador trabalhador = (Pessoa_Trabalhador)listBox_Trabalhadores.SelectedItem;
            textBoxAlterar_Nome.Text = trabalhador.Pessoa.Nome;
            txtAlterarPosicao.Text = trabalhador.Posicao;
            txtAlterarSalario.Text =  trabalhador.Salario.ToString();
            textBoxAlterar_Rua.Text = trabalhador.Pessoa.MoradaSet.Rua;
            textBoxAlterar_CodPostal.Text = trabalhador.Pessoa.MoradaSet.CodPostal;
            textBoxAlterar_Cidade.Text = trabalhador.Pessoa.MoradaSet.Cidade;
            textBoxAlterar_Pais.Text = trabalhador.Pessoa.MoradaSet.Pais;
        }

        private void btn_AlterarTrabalhador_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAdd_Nome.Text) && VerificarTexto(textBoxAdd_Rua.Text) && VerificarTexto(textBoxAdd_CodPostal.Text) && VerificarTexto(textBoxAdd_Cidade.Text) && VerificarTexto(textBoxAdd_Pais.Text) && VerificarTexto(txtAddPosicao.Text) && VerificarTexto(txtAddPosicao.Text)))
            {
                Pessoa_Trabalhador trabalhador = (Pessoa_Trabalhador)listBox_Trabalhadores.SelectedItem;
                trabalhador.Pessoa.Nome = textBoxAlterar_Nome.Text;
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

        private void btn_ApagarTrabalhador_Click(object sender, EventArgs e)
        {
            Pessoa_Trabalhador trabalhador = (Pessoa_Trabalhador)listBox_Trabalhadores.SelectedItem;

            restauranteAPP.Pessoa_Trabalhador.Remove(trabalhador);
            restauranteAPP.SaveChanges();
            LerDadosTrabalhadores();
        }
    }
}
