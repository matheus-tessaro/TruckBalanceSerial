using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Balanca.Utils
{
    public class Conexao
    {
        #region Constructor

        public Conexao() { }

        #endregion

        #region Methods

        /// <summary>
        /// Método que cria a conexão
        /// </summary>
        /// <returns></returns>
        private SqlConnection Connection()
        {
            string serverDB = ConfigurationManager.AppSettings["serverDB"];
            string database = ConfigurationManager.AppSettings["Database"];
            string usuario = ConfigurationManager.AppSettings["UserDB"];
            string senha = ConfigurationManager.AppSettings["PassDB"];

            string conexao = $"server={serverDB}; user id={usuario}; password={senha}; initial catalog={database}; connect timeout=14400";
            SqlConnection sqlConnection = new SqlConnection(conexao);

            try
            {
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (SqlException x)
            {
                throw x;
            }
        }

        /// <summary>
        /// Método que executa uma query no banco de dados
        /// </summary>
        /// <param name="sqlAtualizar">Query a ser executada</param>
        /// <returns>String com erro se houver.</returns>
        public string Atualizar(string sqlAtualizar)
        {
            string retorno = string.Empty;

            using (SqlConnection objectConnection = Connection())
            {
                using (SqlCommand command = new SqlCommand(sqlAtualizar, objectConnection))
                {
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException x)
                    {
                        retorno = x.Message;
                    }
                    catch (Exception x)
                    {
                        retorno = x.Message;
                    }
                    finally
                    {
                        if (objectConnection.State == ConnectionState.Open)
                            objectConnection.Close();
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Método que executa uma query de pesquisa
        /// </summary>
        /// <param name="sqlPesquisa">Query a ser executada</param>
        /// <param name="opeTarefa">String passado como referência para armazenar erro</param>
        /// <param name="nometabela">String do nome da tabela no dataset</param>
        /// <returns>DataSet da pesquisa</returns>
        public DataSet Pesquisar(string sqlPesquisa, ref string retorno, string nometabela = "tabela")
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection objectConnection = Connection())
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlPesquisa, objectConnection))
                {
                    dataAdapter.SelectCommand.CommandTimeout = 600;

                    try
                    {
                        dataAdapter.Fill(dataSet, nometabela);
                    }
                    catch (SqlException x)
                    {
                        retorno = x.Message;
                    }
                    catch (Exception x)
                    {
                        retorno = x.Message;
                    }
                    finally
                    {
                        if (objectConnection.State == ConnectionState.Open)
                            objectConnection.Close();
                    }
                }
            }

            return dataSet;
        }

        #endregion
    }
}