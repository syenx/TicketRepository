using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Crypt_DeCrypt;
namespace LocCongonhas.Controllers
{

    /// <summary>
    /// Classe reponsável por integrar a aplicação ao banco de dados.
    /// </summary>
    public class DAO : IDisposable
    {

        #region Atributos
        /// <summary>
        /// Variável utilizada para controlar o Dipose da Classe.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Recebe a string de conexão com uma base de dados.
        /// </summary>
        private string stringConexao;

        #endregion

        #region Métodos
        /// <summary>
        /// Através dos parâmetros do comando, dos inputs do comando e do nome da base, realiza Insert, Update, Delete ou algum comando interno no banco de dados.
        /// </summary>
        /// <param name="_sqlParameter"></param>
        /// <param name="_comando"></param>
        /// <param name="_nomeDataBase"></param>
        /// <remarks>Não retorna nenhum objeto do banco de dados para a aplicação.</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public void ExecuteNonQuery(SqlParameter[] _sqlParameter, string _comando, string _nomeDataBase)
        {
            this.stringConexao = Crypt_DeCrypt.Crypt_DeCrypt.Decrypt(ConfigurationManager.ConnectionStrings[_nomeDataBase].ConnectionString);
            try
            {
                using (SqlConnection cone = new SqlConnection(stringConexao))
                {
                    cone.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(_comando, cone))
                    {

                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        if ((_sqlParameter != null) && (_sqlParameter.Count() > 0))
                        {
                            _sqlParameter.ToList().ForEach(delegate(SqlParameter p)
                            {
                                sqlCommand.Parameters.Add(p);
                            });
                        }
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// Através do comando e do nome da base, realiza algum comando interno no banco de dados.
        /// </summary>
        /// <param name="_comando">_comando</param>
        /// <param name="_nomeDataBase">_nomeDataBase</param>
        /// <remarks>Não retorna nenhum objeto do banco de dados para a aplicação.</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public void ExecuteNonQuery(string _comando, string _nomeDataBase)
        {
            this.stringConexao = Crypt_DeCrypt.Crypt_DeCrypt.Decrypt(ConfigurationManager.ConnectionStrings[_nomeDataBase].ConnectionString);
            try
            {
                using (SqlConnection cone = new SqlConnection(stringConexao))
                {
                    cone.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(_comando, cone))
                    {
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Através dos parâmetros do comando, dos inputs do comando e do nome da base, este método realiza uma consulta na base.
        /// </summary>
        /// <param name="_sqlParameter">_sqlParameter</param>
        /// <param name="_comando">_comando</param>
        /// <param name="_nomeDataBase">_nomeDataBase</param>
        /// <returns>Retorna um objeto DataTable do comando executado no banco de dados.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataTable ExecuteDataTable(SqlParameter[] _sqlParameter, string _comando, string _nomeDataBase)
        {
            this.stringConexao = Crypt_DeCrypt.Crypt_DeCrypt.Decrypt(ConfigurationManager.ConnectionStrings[_nomeDataBase].ConnectionString);
            DataTable dtResultado = new DataTable();
            try
            {
                using (SqlConnection cone = new SqlConnection(stringConexao))
                {
                    cone.Open();
                    using (SqlCommand cmd = new SqlCommand(_comando, cone))
                    {
                        if (_comando.Contains("select"))
                            cmd.CommandType = CommandType.Text;
                        else
                            cmd.CommandType = CommandType.StoredProcedure;
                        if ((_sqlParameter != null) && (_sqlParameter.Count() > 0))
                        {
                            _sqlParameter.ToList().ForEach(delegate(SqlParameter p)
                            {
                                cmd.Parameters.Add(p);
                            });
                        }
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            using (DataTable dtResulta = new DataTable())
                            {
                                sqlDataAdapter.Fill(dtResultado);
                                return (dtResultado.Copy());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return (null);
            }
        }

        /// <summary>
        /// Através dos parâmetros do comando, dos inputs do comando e do nome da base, este método realiza uma consulta na base.
        /// </summary>
        /// <param name="_sqlParameter">_sqlParameter</param>
        /// <param name="_comando">_comando</param>
        /// <param name="_nomeDataBase">_nomeDataBase</param>
        /// <returns>Retorna um objeto DataSet do comando executado no banco de dados.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public DataSet ExecuteDataSet(SqlParameter[] _sqlParameter, string _comando, string _nomeDataBase)
        {
            this.stringConexao = Crypt_DeCrypt.Crypt_DeCrypt.Decrypt(ConfigurationManager.ConnectionStrings[_nomeDataBase].ConnectionString);
            try
            {
                using (SqlConnection cone = new SqlConnection(stringConexao))
                {
                    cone.Open();
                    using (SqlCommand cmd = new SqlCommand(_comando, cone))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if ((_sqlParameter != null) && (_sqlParameter.Count() > 0))
                        {
                            _sqlParameter.ToList().ForEach(delegate(SqlParameter p)
                            {
                                cmd.Parameters.Add(p);
                            });
                        }
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            using (DataSet dsResultado = new DataSet())
                            {
                                sqlDataAdapter.Fill(dsResultado);
                                return (dsResultado.Copy());
                            }
                        }
                    }
                }
            }
            catch
            {
                return (null);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public object ExecuteScalar(SqlParameter[] _sqlParameter, string _comando, string _nomeDataBase)
        {
            this.stringConexao = Crypt_DeCrypt.Crypt_DeCrypt.Decrypt(ConfigurationManager.ConnectionStrings[_nomeDataBase].ConnectionString);
            object result = null;
            try
            {
                using (SqlConnection cone = new SqlConnection(stringConexao))
                {
                    cone.Open();
                    using (SqlCommand cmd = new SqlCommand(_comando, cone))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if ((_sqlParameter != null) && (_sqlParameter.Count() > 0))
                        {
                            _sqlParameter.ToList().ForEach(delegate(SqlParameter p)
                            {
                                cmd.Parameters.Add(p);
                            });
                        }

                        result = cmd.ExecuteScalar();

                        return result;
                    }
                }
            }
            catch
            {
                return (null);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public object ExecuteScalarText(SqlParameter[] _sqlParameter, string _comando, string _nomeDataBase)
        {
            this.stringConexao = Crypt_DeCrypt.Crypt_DeCrypt.Decrypt(ConfigurationManager.ConnectionStrings[_nomeDataBase].ConnectionString);
            object result = null;
            try
            {
                using (SqlConnection cone = new SqlConnection(stringConexao))
                {
                    cone.Open();
                    using (SqlCommand cmd = new SqlCommand(_comando, cone))
                    {
                        cmd.CommandType = CommandType.Text;
                        if ((_sqlParameter != null) && (_sqlParameter.Count() > 0))
                        {
                            _sqlParameter.ToList().ForEach(delegate(SqlParameter p)
                            {
                                cmd.Parameters.Add(p);
                            });
                        }

                        result = cmd.ExecuteScalar();

                        return result;
                    }
                }
            }
            catch
            {
                return (null);
            }
        }


        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            catch
            { }
            finally
            { }
        }


        #endregion

    }

}
