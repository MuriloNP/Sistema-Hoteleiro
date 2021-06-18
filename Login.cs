using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaHotel
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            pnlLogin.Visible = false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point((this.Width / 2) - 166, (this.Height / 2) - 170);
            pnlLogin.Visible = true;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 114, 160);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(8, 72, 103);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            ChamarLogin();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChamarLogin();
            }
        }

        private void ChamarLogin()
        {
            if ((txtUsuario.Text.ToString().Trim() == "") && (txtSenha.Text.ToString().Trim() == ""))
            {
                MessageBox.Show("Preecha os campos...", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtSenha.Text = "";
                txtUsuario.Focus();
                return;
            }
            else if (txtUsuario.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Informe seu usuário.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }
            else if (txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Informe sua senha.", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            FrmTelaPrincipal form = new FrmTelaPrincipal();
            //this.Hide();
            LimpaCaixaDeTexto();
            form.Show();
        }

        private void LimpaCaixaDeTexto()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtUsuario.Focus();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point((this.Width / 2) - 166, (this.Height / 2) - 170);
        }
    }
}
