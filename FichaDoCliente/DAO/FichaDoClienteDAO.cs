using AutoMapper;
using FichaDoCliente.DTO;
using FichaDoCliente.Model;
using System.Data;
using System.Data.SqlClient;

namespace FichaDoCliente.DAO
{
    public class FichaDoClienteDAO
    {
        String conexao = @"Server=DESKTOP-BJNTUCI\MSSQLSERVER01;Database=Cliente;Trusted_Connection=True";
        public  FichaClienteDTO retornaFichaCliente(String CPF)
        {
            FichaClienteDTO fichaClienteDTO = new FichaClienteDTO();
            Model.FichaCliente fichaDoCliente =  new Model.FichaCliente();


            string sql = "select id_ficha_aluno,CPF,CRN,CNPJ,nome_modalidade,CREF from dbo.Ficha_Cliente where CPF =" + "'" + CPF + "'";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    fichaDoCliente.idFichaAluno = Convert.ToInt32(reader["id_ficha_aluno"]);
                    fichaDoCliente.CNPJ = reader["CNPJ"].ToString();
                    fichaDoCliente.CREF = reader["CREF"].ToString();
                    fichaDoCliente.CRN = reader["CRN"].ToString();
                    fichaDoCliente.nomeDaModalidade = reader["nome_modalidade"].ToString();
                    fichaDoCliente.CPF = reader["CPF"].ToString();

                    var configuration = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<FichaCliente, FichaClienteDTO>();
                    });
                    var mapper = configuration.CreateMapper();
                    fichaClienteDTO = mapper.Map<FichaClienteDTO>(fichaDoCliente);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                con.Close();
            }

            return fichaClienteDTO;
        }

        public int deletaFichaCliente(String CPF)
        {
            String retorno = "";
            string sql = "delete from dbo.Ficha_Cliente where CPF = " + "'" + CPF + "'";

            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            int i = cmd.ExecuteNonQuery();
            return i;

        }

        public int insereFichaCliente(FichaClienteDTO fichaClienteDTO)
        {

            String retorno = "";
            string sql = "INSERT INTO dbo.Ficha_Cliente (CPF,CRN,CNPJ,nome_modalidade,CREF ) VALUES (" + "'" + fichaClienteDTO.CPF + "'" + "," + "'" + fichaClienteDTO.CRN + "'" + "," + "'" + fichaClienteDTO.CNPJ + "'" + "," + "'" + fichaClienteDTO.nomeDaModalidade + "'"+ "," + "'" + fichaClienteDTO.CREF + "'" +  ")";
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            int i = cmd.ExecuteNonQuery();

            return i;
        }


        public int alteraFichaCliente(FichaClienteDTO fichaClienteDTO)
        {

            String retorno = "";
            string sql = "UPDATE dbo.Ficha_Cliente SET  nome_modalidade=" + "'" + fichaClienteDTO.nomeDaModalidade + "'" + "," + "CRN=" + "'" + fichaClienteDTO.CRN + "'" + "," + "CREF=" + "'" + fichaClienteDTO.CREF + "'" + "," + "CNPJ=" + "'" + fichaClienteDTO.CNPJ + "'" + "   where CPF=" + "'" + fichaClienteDTO.CPF + "'";
            SqlConnection con = new SqlConnection(conexao);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            int i = cmd.ExecuteNonQuery();

            return i;
        }
    }
}
