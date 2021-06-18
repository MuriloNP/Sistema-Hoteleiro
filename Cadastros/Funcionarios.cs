using System;
using System.Windows.Forms;

namespace SistemaHotel.Cadastros
{
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        private void HabilitarCampos()
        {
            txtNome.Enabled = true;
            txtCPF.Enabled = true;
            txtEndereco.Enabled = true;
            txtTelefone.Enabled = true;
            cbCargo.Enabled = true;
            txtNome.Focus();
        }

        private void DesabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCPF.Enabled = false;
            txtEndereco.Enabled = false;
            txtTelefone.Enabled = false;
            cbCargo.Enabled = false;
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtEndereco.Text = "";
            txtTelefone.Text = "";
        }

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            rbNome.Checked = true;
        }

        private void RbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarNome.Visible = true;
            txtBuscarCPF.Visible = false;
            txtBuscarNome.Text = "";
        }

        private void RbCPF_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarCPF.Visible = true;
            txtBuscarNome.Visible = false;
            txtBuscarCPF.Text = "";
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
            if ((txtNome.Text.ToString().Trim() == "") && (txtCPF.Text == "   .   .   -"))
            {
                MessageBox.Show("Preecha os campos obrigatórios: Nome e CPF", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else if (txtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preecha o campo CPF", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Grid_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = false;
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if ((txtNome.Text.ToString().Trim() == "") && (txtCPF.Text == "   .   .   -"))
            {
                MessageBox.Show("Preecha os campos obrigatórios: Nome e CPF", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            else if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preecha o campo Nome!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            else if (txtCPF.Text == "   .   .   -")
            {
                MessageBox.Show("Preecha o campo CPF!", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
