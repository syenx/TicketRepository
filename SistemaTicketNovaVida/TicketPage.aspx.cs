using Crypt_DeCrypt;
using ICSharpCode.SharpZipLib.Zip;
using SistemaTicketNovaVida.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaTicketNovaVida
{
    public partial class TecketPage : System.Web.UI.Page
    {
        DAO banco = new DAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(Session["IDUSUARIO"] as string))
            //{
            //    //Response.Redirect("~/LoginPage.aspx");
            //    //Session["IDUSUARIO"] = null;
            //}
            //else
            //{

            //    txtQuantidade.Visible = false;
            //    lblquantidate.Visible = false;
            //    VerificaProcesso();
            //    if (!Page.IsPostBack)
            //    {
            //        preencherCliente();
            //        PreencherProcesso();
            //    }

            txtQuantidade.Visible = false;
            lblquantidate.Visible = false;
            VerificaProcesso();
            if (!Page.IsPostBack)
            {
                preencherCliente();
                PreencherProcesso();
            }


        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {


            SqlParameter[] parameters =
            {    
               new SqlParameter("@DATA_VIGENCIA", SqlDbType.DateTime, 50) { Value = txtdataVigencia.Text },
               new SqlParameter("@IDPROCESSO", SqlDbType.Int, 50) { Value = ddlProcesso.SelectedItem.Value},
               new SqlParameter("@IDCLIENTE", SqlDbType.Int, 50) { Value = ddlCliente.SelectedItem.Value},
               new SqlParameter("@QUANTIDADE", SqlDbType.VarChar, 50) { Value = txtQuantidade.Text },
               new SqlParameter("@SEGMENTACAO", SqlDbType.VarChar, 5000) { Value = txtSeguimentacao.Text },
               new SqlParameter("@VALOR_PROCESSO", SqlDbType.Decimal, 50) { Value = txtValorTotal.Text },
               new SqlParameter("@ID_USUARIO", SqlDbType.Int, 50) { Value = Session["IDUSUARIO"]},
               new SqlParameter("@IP_USUARIO", SqlDbType.VarChar, 50) { Value = Session["IPUSUARIO"]},
               new SqlParameter("@NOME_ARQUIVO", SqlDbType.VarChar, 60){Value = selectFile.FileName}
            };


            object objec = banco.ExecuteScalar(parameters, "JOBS_CONTROLE..PROC_INSERIR_TICKET", "cone");


            if (HttpContext.Current.Request.Files != null && HttpContext.Current.Request.Files.Count > 0)
            {
                for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                {
                    HttpPostedFile fl = HttpContext.Current.Request.Files[i];
                    fl.SaveAs(Server.MapPath("~/ArquivoTemporario/") + fl.FileName);

                    parameters = new SqlParameter[] {    
                        new SqlParameter("@ID_JOBCONTROLE", SqlDbType.BigInt) { Value = int.Parse(objec.ToString())},
                        new SqlParameter("@NOME_ARQUIVO", SqlDbType.VarChar) { Value = fl.FileName},
                        new SqlParameter("@TIPO", SqlDbType.VarChar) { Value = "E"}
                };

                    banco.ExecuteNonQuery(parameters, "JOBS_CONTROLE..INSERIR_ARQUIVO", "cone");
                }
            }

            var teste = int.Parse(objec.ToString());
        }

        public void preencherCliente()
        {
            var dt = banco.ExecuteDataTable(null, "VNADMIN..OBTER_CLIENTE", "cone");

            ddlCliente.DataTextField = "NOME";
            ddlCliente.DataValueField = "IDCLIENTE";

            ddlCliente.DataSource = dt;
            ddlCliente.DataBind();
        }

        public void PreencherProcesso()
        {
            var dt = banco.ExecuteDataTable(null, "JOBS_CONTROLE..PROC_OBTER_PROCESSOS", "cone");

            ddlProcesso.DataTextField = "NOME_PROCESSO";
            ddlProcesso.DataValueField = "ID_PROCESSO";

            ddlProcesso.DataSource = dt;
            ddlProcesso.DataBind();
        }

        public void VerificaProcesso()
        {
            if (ddlProcesso.SelectedValue.Equals("1") || ddlProcesso.SelectedValue.Equals("3") || ddlProcesso.SelectedValue.Equals("4"))
            {
                txtQuantidade.Visible = true;
                lblquantidate.Visible = true;
            }
        }

        public void LimparCampo()
        {
            txtdataVigencia.Text = "";
            txtQuantidade.Text = "";
            txtSeguimentacao.Text = "";
            txtValorTotal.Text = "";
        }

        private void SaveFile()
        {
            var savePath = Server.MapPath("~/ArquivoTemporario/");

            string fileName = selectFile.FileName;

            string pathToCheck = savePath + fileName;

            string tempfileName = "";

            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    tempfileName = counter.ToString() + fileName;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }

                fileName = tempfileName;
            }
            savePath += fileName;
            selectFile.SaveAs(savePath);
        }
    }
}