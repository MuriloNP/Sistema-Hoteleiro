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
    public partial class FrmTelaPrincipal : Form
    {
        public FrmTelaPrincipal()
        {
            InitializeComponent();
        }

        private void FrmTelaPrincipal_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmTelaPrincipal_Load(object sender, EventArgs e)
        {
            pnlTopo.BackColor = Color.FromArgb(230, 230, 230);
            pnlRight.BackColor = Color.FromArgb(130, 130, 130);
        }

        private void FuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmFuncionarios form = new Cadastros.FrmFuncionarios();
            form.Show();
        }

        private void CargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmCargo form = new Cadastros.FrmCargo();
            form.Show();
            //cargoToolStripMenuItem.Enabled = false;
        }

        private void BtnProdutos_Click(object sender, EventArgs e)
        {
            Produtos.FrmProdutos form = new Produtos.FrmProdutos();
            form.Show();
        }

        private void NovoProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produtos.FrmProdutos form = new Produtos.FrmProdutos();
            form.Show();
        }
    }
}
