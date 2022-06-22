using MaterialSkin.Controls;
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
    public partial class MenuForm : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public static RestauranteAPPContainer restauranteAPP;

        public MenuForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Indigo200, MaterialSkin.TextShade.WHITE);
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            restauranteAPP = new RestauranteAPPContainer();
            LerDadosMenus();
            LerCategorias();
            InitializeComponent();
        }

        private void LerDadosMenus()
        {
            listBox_Menu.DataSource = restauranteAPP.ItemMenuSet.OfType<ItemMenuSet>().ToList();
            listBox_Menu.Refresh();
        }

        public void LerCategorias()
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

        private bool VerificarTexto(string texto)
        {
            return String.IsNullOrEmpty(texto);
        }

        private void Btn_AdicionarMenu_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAdd_Nome.Text) && VerificarTexto(txtAddfotografia.Text) && VerificarTexto(txtAddIngredientes.Text) && VerificarTexto(txtAddPrecos.Text)) && checkBoxAddAtivo.Checked == true)
            {
                CategoriaSet categoria = (CategoriaSet)comboBoxAddCategoria.SelectedItem;

                ItemMenuSet itens = new ItemMenuSet
                {
                    Nome = textBoxAdd_Nome.Text,
                    Fotografia = txtAddfotografia.Text,
                    Ingredientes = txtAddIngredientes.Text,
                    CategoriaIdCategoria = categoria.IdCategoria,
                    Ativo = checkBoxAddAtivo.Checked,

                    CategoriaSet = categoria
                };

                try
                {
                    itens.Precos = float.Parse(txtAddPrecos.Text);
                    restauranteAPP.ItemMenuSet.Add(itens);
                    restauranteAPP.SaveChanges();

                    checkBoxAddAtivo.Checked = false;
                    pictureBoxAddFoto.Image = null;
                    foreach (TextBox textBox in groupBox_RegistarMenu.Controls.OfType<TextBox>())
                    {
                        textBox.Text = "";
                    }

                    LerDadosMenus();
                }
                catch
                {
                    MessageBox.Show("Preço inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Tens que preencher todos os campos para adicionares o menu!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Btn_AlterarMenu_Click(object sender, EventArgs e)
        {
            if (!(VerificarTexto(textBoxAlterar_Nome.Text) && VerificarTexto(txtAlterarfotografia.Text) && VerificarTexto(txtAlterarIngredientes.Text) && VerificarTexto(txtAlterarPrecos.Text)) && checkBoxAlterarAtivo.Checked == true)
            {
                CategoriaSet categoria = (CategoriaSet)comboBoxAddCategoria.SelectedItem;

                ItemMenuSet menu = (ItemMenuSet)listBox_Menu.SelectedItem;
                menu.Nome = textBoxAlterar_Nome.Text;
                menu.Fotografia = txtAlterarfotografia.Text;
                menu.Ingredientes = txtAlterarIngredientes.Text;
                menu.CategoriaIdCategoria = categoria.IdCategoria;
                menu.Ativo = checkBoxAlterarAtivo.Checked;

                try
                {
                    menu.Precos = float.Parse(txtAlterarPrecos.Text);
                    restauranteAPP.SaveChanges();
                    LerDadosMenus();
                }
                catch
                {
                    MessageBox.Show("Preço inválido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Preenche todos os campos para poderes alterar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Btn_ApagarMenu_Click(object sender, EventArgs e)
        {
            ItemMenuSet menu = (ItemMenuSet)listBox_Menu.SelectedItem;

            restauranteAPP.ItemMenuSet.Remove(menu);
            restauranteAPP.SaveChanges();
            LerDadosMenus();
        }

        public string ConverterImagemParaBase64(Image file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.Save(memoryStream, file.RawFormat);
                byte[] imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }

        public Image ConverterBase64ParaImagem(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                ms.Write(imageBytes, 0, imageBytes.Length);
                return Image.FromStream(ms, true);
            }
        }

        private void BtnAddUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBoxAddFoto.Image = new Bitmap(open.FileName);
                using (Image imagem = pictureBoxAddFoto.Image.Clone() as Image)
                {
                    txtAddfotografia.Text = ConverterImagemParaBase64(imagem);
                }
            }
        }

        private void BtnAltUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Image Files(*.jpg; *.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp"
            };
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBoxAlterarFoto.Image = new Bitmap(open.FileName);
                using (Image imagem = pictureBoxAlterarFoto.Image.Clone() as Image)
                {
                    txtAlterarfotografia.Text = ConverterImagemParaBase64(imagem);
                }
            }
        }

        private void ListBox_Menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemMenuSet itemMenu = (ItemMenuSet)listBox_Menu.SelectedItem;
            comboBoxAlterarCategoria.SelectedItem = itemMenu.CategoriaSet.Nome;
            textBoxAlterar_Nome.Text = itemMenu.Nome;
            txtAlterarIngredientes.Text = itemMenu.Ingredientes;
            txtAlterarPrecos.Text = itemMenu.Precos.ToString();
            txtAlterarfotografia.Text = itemMenu.Fotografia;
            pictureBoxAlterarFoto.Image = ConverterBase64ParaImagem(itemMenu.Fotografia);
            checkBoxAlterarAtivo.Checked = itemMenu.Ativo;
        }
    }
}   
