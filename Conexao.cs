using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaHotel
{
    class Conexao
    {
        //CONEXÃO COM O BANCO DE DADOS LOCAL
        readonly string conecta = "SERVER=localhost; DATABASE=hotel; UID=root; PWD=; PORT=;";
        public MySqlConnection execCon = null;

        public void AbreConex()
        {
            try
            {
                execCon = new MySqlConnection(conecta);
                execCon.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void FechaConex()
        {
            try
            {
                execCon = new MySqlConnection(conecta);
                execCon.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //DECLARAÇÃO DE OUTRAS VARIAVEIS
    }
}
