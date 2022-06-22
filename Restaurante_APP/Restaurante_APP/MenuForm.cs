using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurante_APP
{
    public partial class MenuForm : Form
    {
        public static Menu menu;
        public static RestauranteAPPContainer restauranteAPP;
        public MenuForm(Menu menu)
        {
            LerDadosMenus();
            Categorias();
            InitializeComponent();
        }

        private void LerDadosMenus()
        {
            listBox_Menu.DataSource = restauranteAPP.ItemMenuSet.OfType<ItemMenuSet>().ToList();
            listBox_Menu.Refresh();
        }

        public void Categorias()
        {
            List<CategoriaSet> Categorias = restauranteAPP.CategoriaSet.OfType<CategoriaSet>().ToList();

            List<CategoriaSet> CategoriasSelecionadas = new List<CategoriaSet>();

            foreach (CategoriaSet categoria in Categorias)
            {
                if (categoria.Ativo)
                {
                    CategoriasSelecionadas.Add(categoria);
                }
            }

            comboBoxAddCategoria.DataSource = CategoriasSelecionadas;
            comboBoxAlterarCategoria.DataSource = CategoriasSelecionadas;
        }

        private void btn_AdicionarMenu_Click(object sender, EventArgs e)
        {
            if (textBoxAdd_Nome.Text != "" && txtAddfotografia.Text != "" && txtAddIngredientes.Text != "" && txtAddPrecos.Text != "" && checkBoxAddAtivo.Checked == true)
            {
                CategoriaSet categoria = (CategoriaSet)comboBoxAddCategoria.SelectedItem;

                ItemMenuSet itens = new ItemMenuSet();
                itens.Nome = textBoxAdd_Nome.Text;
                itens.Fotografia = txtAddfotografia.Text;
                itens.Ingredientes = txtAddIngredientes.Text;
                itens.CategoriaIdCategoria = categoria.IdCategoria;
                itens.Ativo =

                itens.CategoriaSet = categoria;//aqui erro

                try
                {
                    itens.Precos = float.Parse(txtAddPrecos.Text);
                    restauranteAPP.ItemMenuSet.Add(itens);
                    restauranteAPP.SaveChanges();

                    textBoxAdd_Nome.Text = "";
                    txtAddfotografia.Text = "";
                    checkBoxAddAtivo.Checked = false;
                    txtAddIngredientes.Text = "";
                    txtAddPrecos.Text = "";
                    pictureBoxAddFoto.Image = null;

                    LerDadosMenus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Preço inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Tem que preencher todos os dados para adicionar o menu!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_AlterarMenu_Click(object sender, EventArgs e)
        {
            if (!(textBoxAlterar_Nome.Text != "" && txtAlterarfotografia.Text != "" && txtAlterarIngredientes.Text != "" && txtAlterarPrecos.Text != "" && checkBoxAlterarAtivo.Checked == true))
            {
                CategoriaSet categoria = (CategoriaSet)comboBoxAddCategoria.SelectedItem;

                ItemMenuSet Menu = (ItemMenuSet)listBox_Menu.SelectedItem;
                Menu.Nome = textBoxAlterar_Nome.Text;
                Menu.Fotografia = txtAlterarfotografia.Text;
                Menu.Ingredientes = txtAlterarIngredientes.Text;
                Menu.CategoriaIdCategoria = categoria.IdCategoria;
                Menu.Ativo = checkBoxAlterarAtivo.Checked;

                try
                {
                    Menu.Precos = float.Parse(txtAlterarPrecos.Text);
                    restauranteAPP.SaveChanges();
                    LerDadosMenus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Preço inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para poderes alterar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_ApagarMenu_Click(object sender, EventArgs e)
        {
            ItemMenuSet Menu = (ItemMenuSet)listBox_Menu.SelectedItem;

            restauranteAPP.ItemMenuSet.Remove(Menu);
            restauranteAPP.SaveChanges();
            LerDadosMenus();
        }
        public string ConverterImagem64(String imagem)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imagem);
            Image imagem64;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                imagem64 = Image.FromStream(ms);
            }
             return imagem64;//falta Verificar o pq de nao deixar converter
        }

        private void btnAddUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBoxAddFoto.Image = new Bitmap(open.FileName);
                using (Image imagem = pictureBoxAddFoto.Image.Clone() as Image)
                {
                    txtAddfotografia.Text = ConverterImagem64(imagem);//falta Verificar o pq de nao deixar converter
                }
            }

        }

        private void btnAltUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBoxAlterarFoto.Image = new Bitmap(open.FileName);
                using (Image imagem = pictureBoxAlterarFoto.Image.Clone() as Image)
                {
                    txtAlterarfotografia.Text = ConverterImagem64(imagem);//falta Verificar o pq de nao deixar converter
                }
            }
        }
    }
}   
