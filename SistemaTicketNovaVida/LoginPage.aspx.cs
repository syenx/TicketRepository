using LocCongonhas.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaTicketNovaVida
{
    public partial class LoginPage : System.Web.UI.Page
    {
        DAO banco = new DAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtip.Text = Request.UserHostAddress;
           
        }
        
        protected void btnAcessar_Click(object sender, EventArgs e)
        {
            SqlParameter[] parameters =
            {    
                new SqlParameter("@LOGIN", SqlDbType.VarChar, 50) { Value = txtLogin.Text },
                new SqlParameter("@SENHA", SqlDbType.VarChar, 50) { Value = Crypt_DeCrypt.Crypt_DeCrypt.Encrypt(txtSenha.Text)},
                new SqlParameter("@CLIENTE", SqlDbType.VarChar, 150) { Value = txtCliente.Text },
                new SqlParameter("@IP", SqlDbType.VarChar, 50) { Value = Request.UserHostAddress },
                new SqlParameter("@IDPRODUTO", SqlDbType.Int) { Value = 5},
                new SqlParameter("@ERRO", SqlDbType.VarChar, 50) { Direction= ParameterDirection.Output},
                new SqlParameter("@IDUSUARIO", SqlDbType.BigInt) {  Direction = ParameterDirection.Output},
                new SqlParameter("@IDACESSO", SqlDbType.BigInt) {  Direction = ParameterDirection.Output},
                new SqlParameter("@IDCLIENTE", SqlDbType.BigInt) {  Direction = ParameterDirection.Output}
            
            };
            banco.ExecuteDataTable(parameters, "AUTORIZARLOGIN", "cone");

            if ( string.IsNullOrEmpty (parameters[5].Value.ToString()))
            {
                Session["IDUSUARIO"] = parameters[7].Value.ToString();
                Session["IPUSUARIO"] = Request.UserHostAddress;
                Response.Redirect("~/Default.aspx");
            }
            else 
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "alertMessage", @"alert('Login/Senha Incorreto')", true);
            }
         

        }

    }
}