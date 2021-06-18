using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaHotel.Cadastros
{
    public partial class FrmCargo : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;

        public FrmCargo()
        {
            InitializeComponent();
        }

        //Formata o data grid 
        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "ID";
            grid.Columns[1].HeaderText = "Cargo";

            grid.Columns[0].Visible = false;
            grid.Columns[1].Width = 230;
        }

        private void Listar()
        {
            try
            {
                con.AbreConex();
                sql = "SELECT * FROM cargos order by cargo asc";
                cmd = new MySqlCommand(sql, con.execCon);
                MySqlDataAdapter da = new MySqlDataAdapter
                {
                    //E o mesmo que: da.SelectCommand = cmd
                    SelectCommand = cmd
                };
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid.DataSource = dt;
                FormatarDG();
                con.FechaConex();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            txtNome.Focus();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
        }

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preecha o Cargo", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }

            //PROGRAMANDO O BOTÃO SALVAR
            con.AbreConex();
            sql = "INSERT INTO cargos (cargo) VALUES (@cargo)";
            cmd = new MySqlCommand(sql, con.execCon);
            cmd.Parameters.AddWithValue("@cargo", txtNome.Text);
            cmd.ExecuteNonQuery();
            con.FechaConex();

            MessageBox.Show("Registro Salvo com Sucesso!", "Dados Salvos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            txtNome.Text = "";
            txtNome.Focus();
            txtNome.Enabled = false;
            Listar();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preecha o Cargo", "Campo Vazio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }

            MessageBox.Show("Registro Editado com Sucesso!", "Dados Editados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNome.Text = "";
            txtNome.Enabled = false;
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
                txtNome.Text = "";
                txtNome.Enabled = false;
            }
        }

        private void FrmCargo_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            btnNovo.Enabled = true;
            txtNome.Enabled = true;

            id = grid.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
