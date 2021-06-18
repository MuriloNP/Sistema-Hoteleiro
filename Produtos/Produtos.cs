using System;
using System.Windows.Forms;

namespace SistemaHotel.Produtos
{
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtDescricao.Enabled = true;
            txtEstoque.Enabled = true;
            cbFornecedor.Enabled = true;
            txtValor.Enabled = true;
            BtnImg.Enabled = true;
            txtNome.Focus();
        }

        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtDescricao.Enabled = false;
            txtEstoque.Enabled = false;
            cbFornecedor.Enabled = false;
            txtValor.Enabled = false;
            BtnImg.Enabled = false;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtEstoque.Text = "";
            txtValor.Text = "";
            LimparImage();
        }

        private void LimparImage()
        {
            Img.Image = Properties.Resources.sem_foto;
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            LimparImage();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text.ToString().Trim() == "") && (txtValor.Text == ""))
            {
                MessageBox.Show("Preecha os campos obrigatórios: Nome e Valor", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            else if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preecha o campo Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            else if (txtValor.Text == "")
            {
                MessageBox.Show("Preecha o campo Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }

            //CODIGO DO NOTÃO PARA SALVAR

            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            LimparCampos();
            DesabilitarCampos();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text.ToString().Trim() == "") && (txtValor.Text == ""))
            {
                MessageBox.Show("Preecha os campos obrigatórios: Nome e Valor", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            else if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preecha o campo Nome", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            else if (txtValor.Text == "")
            {
                MessageBox.Show("Preecha o campo Valor", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return;
            }

            //CODIGO DO BOTÃO PARA EDITAR

            MessageBox.Show("Registro Editado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            LimparCampos();
            DesabilitarCampos();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Excluir o Registro?", "Exclui Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Registro Excluido com Sucesso!", "Registro Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                LimparCampos();
                DesabilitarCampos();
            }
        }

        private void BtnImg_Click(object sender, EventArgs e)
        {
            //Cria/instancia uma objeto do tipo: OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Imagens(*.jpg;*.png)|*.jpg;*.png|Todos os Arquivos(*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoDaImagem = dialog.FileName.ToString();
                Img.ImageLocation = caminhoDaImagem;
            }
        }
    }
}
