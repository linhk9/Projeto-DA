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
    public partial class GestaoRestaurantesForm : Form
    {
        public static RestauranteAPPContainer restauranteAPP;

        public GestaoRestaurantesForm()
        {
            InitializeComponent();
        }

        private void GestaoRestaurantesForm_Load(object sender, EventArgs e)
        {
            restauranteAPP = new RestauranteAPPContainer();
            LerDadosRestaurantes();
            LerDadosCategorias();
            LerDadosMetodosPagamento();
        }

        private void LerDadosRestaurantes()
        {
            listBox_Restaurantes.DataSource = restauranteAPP.Restaurante.OfType<Restaurante>().ToList();
            listBox_Restaurantes.Refresh();
        }

        private void LerDadosCategorias()
        {
            listBox_Categorias.DataSource = restauranteAPP.CategoriaSet.OfType<CategoriaSet>().ToList();
            listBox_Categorias.Refresh();
        }

        private void LerDadosMetodosPagamento()
        {
            listBox_MetodosPagamentos.DataSource = restauranteAPP.MetodoPagamentoSet.OfType<MetodoPagamentoSet>().ToList();
            listBox_MetodosPagamentos.Refresh();
        }

        private bool VerificarTexto(string texto)
        {
            return String.IsNullOrEmpty(texto);
        }

        private void ListBox_Restaurantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Restaurante restaurante = (Restaurante)listBox_Restaurantes.SelectedItem;
            textBoxAlterar_Nome.Text = restaurante.Nome;
            textBoxAlterar_Rua.Text = restaurante.MoradaSet.Rua;
            textBoxAlterar_CodPostal.Text = restaurante.MoradaSet.CodPostal;
            textBoxAlterar_Cidade.Text = restaurante.MoradaSet.Cidade;
            textBoxAlterar_Pais.Text = restaurante.MoradaSet.Pais;
        }

        private void Btn_ApagarRestaurante_Click(object sender, EventArgs e)
        {
            Restaurante restaurante = (Restaurante)listBox_Restaurantes.SelectedItem;

            restauranteAPP.Restaurante.Remove(restaurante);
            restauranteAPP.SaveChanges();
            LerDadosRestaurantes();
        }

        private void Btn_AlterarRestaurante_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAlterar_Nome.Text) && VerificarTexto(textBoxAlterar_Rua.Text) && VerificarTexto(textBoxAlterar_CodPostal.Text) && VerificarTexto(textBoxAlterar_Cidade.Text) && VerificarTexto(textBoxAlterar_Pais.Text)))
            {
                Restaurante restaurante = (Restaurante)listBox_Restaurantes.SelectedItem;
                restaurante.Nome = textBoxAlterar_Nome.Text;
                restaurante.MoradaSet.Rua = textBoxAlterar_Rua.Text;
                restaurante.MoradaSet.CodPostal = textBoxAlterar_CodPostal.Text;
                restaurante.MoradaSet.Cidade = textBoxAlterar_Cidade.Text;
                restaurante.MoradaSet.Pais = textBoxAlterar_Pais.Text;

                restauranteAPP.SaveChanges();
                LerDadosRestaurantes();
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para poderes alterar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_RegistarRestaurante_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAdd_Nome.Text) && VerificarTexto(textBoxAdd_Rua.Text) && VerificarTexto(textBoxAdd_CodPostal.Text) && VerificarTexto(textBoxAdd_Cidade.Text) && VerificarTexto(textBoxAdd_Pais.Text)))
            {
                Restaurante restaurante = new Restaurante
                {
                    Nome = textBoxAdd_Nome.Text
                };

                MoradaSet morada = new MoradaSet
                {
                    Pais = textBoxAdd_Pais.Text,
                    Cidade = textBoxAdd_Cidade.Text,
                    Rua = textBoxAdd_Rua.Text,
                    CodPostal = textBoxAdd_CodPostal.Text
                };

                restaurante.MoradaSet = morada;

                restauranteAPP.Restaurante.Add(restaurante);
                restauranteAPP.MoradaSet.Add(morada);
                restauranteAPP.SaveChanges();
                LerDadosRestaurantes();

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

        private void ListBox_Categorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoriaSet categoria = (CategoriaSet)listBox_Categorias.SelectedItem;
            textBoxAlterarCategoria_Nome.Text = categoria.Nome;
            checkBoxAlterarCategoria_Ativo.Checked = categoria.Ativo;
        }

        private void BtnCategoria_Apagar_Click(object sender, EventArgs e)
        {
            CategoriaSet categoria = (CategoriaSet)listBox_Categorias.SelectedItem;

            restauranteAPP.CategoriaSet.Remove(categoria);
            restauranteAPP.SaveChanges();
            LerDadosCategorias();
        }

        private void BtnCategoria_Alterar_Click(object sender, EventArgs e)
        {
            if (!VerificarTexto(textBoxAlterarCategoria_Nome.Text))
            {
                CategoriaSet categoria = (CategoriaSet)listBox_Categorias.SelectedItem;
                categoria.Nome = textBoxAlterarCategoria_Nome.Text;
                categoria.Ativo = checkBoxAlterarCategoria_Ativo.Checked;

                restauranteAPP.SaveChanges();
                LerDadosCategorias();
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para poderes alterar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnCategoria_Add_Click(object sender, EventArgs e)
        {
            if (!VerificarTexto(textBoxAddCategoria_Nome.Text))
            {
                CategoriaSet categoria = new CategoriaSet
                {
                    Nome = textBoxAddCategoria_Nome.Text,
                    Ativo = checkBoxAddCategoria_Ativo.Checked
                };

                restauranteAPP.CategoriaSet.Add(categoria);
                restauranteAPP.SaveChanges();
                LerDadosCategorias();


                textBoxAddCategoria_Nome.Text = "";
                checkBoxAddCategoria_Ativo.Checked = false;
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para adicionares um cliente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ListBox_MetodosPagamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetodoPagamentoSet metodoPagamento = (MetodoPagamentoSet)listBox_MetodosPagamentos.SelectedItem;
            textBoxAlterarMP_Metodo.Text = metodoPagamento.MetododePagamento;
            checkBoxAlterarMP_Ativo.Checked = metodoPagamento.Ativo;
        }

        private void BtnMP_Apagar_Click(object sender, EventArgs e)
        {
            MetodoPagamentoSet metodoPagamento = (MetodoPagamentoSet)listBox_MetodosPagamentos.SelectedItem;

            restauranteAPP.MetodoPagamentoSet.Remove(metodoPagamento);
            restauranteAPP.SaveChanges();
            LerDadosMetodosPagamento();
        }

        private void BtnMP_Aterar_Click(object sender, EventArgs e)
        {
            if (!VerificarTexto(textBoxAlterarMP_Metodo.Text))
            {
                MetodoPagamentoSet metodoPagamento = (MetodoPagamentoSet)listBox_MetodosPagamentos.SelectedItem;
                metodoPagamento.MetododePagamento = textBoxAlterarMP_Metodo.Text;
                metodoPagamento.Ativo = checkBoxAlterarMP_Ativo.Checked;

                restauranteAPP.SaveChanges();
                LerDadosMetodosPagamento();
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para poderes alterar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnMetodoPagamento_Add_Click(object sender, EventArgs e)
        {
            if (!VerificarTexto(textBoxAddMP_Metodo.Text))
            {
                MetodoPagamentoSet metodoPagamento = new MetodoPagamentoSet
                {
                    MetododePagamento = textBoxAddMP_Metodo.Text,
                    Ativo = checkBoxAddMP_Ativo.Checked
                };

                restauranteAPP.MetodoPagamentoSet.Add(metodoPagamento);
                restauranteAPP.SaveChanges();
                LerDadosMetodosPagamento();

                textBoxAddMP_Metodo.Text = "";
                checkBoxAddMP_Ativo.Checked = false;
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para adicionares um cliente!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAbrirRestaurante_Click(object sender, EventArgs e)
        {
            Restaurante restauranteselected = (Restaurante)listBox_Restaurantes.SelectedItem;
            GestRest GestaoRestauranteForm = new GestRest(restauranteselected);
            GestaoRestauranteForm.ShowDialog();
        }

    }
}
