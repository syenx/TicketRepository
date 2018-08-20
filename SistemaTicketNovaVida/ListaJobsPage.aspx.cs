using LocCongonhas.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Zip;


namespace SistemaTicketNovaVida
{
    public partial class ListaJobsPage : System.Web.UI.Page
    {
        DAO banco = new DAO();
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(Session["IDUSUARIO"] as string))
            //{
            //    Response.Redirect("~/LoginPage.aspx");
            //}
            //else
            //{
            //    if (!Page.IsPostBack)
            //    {
            //        PreencherClienteModal();
            //        preencherCliente();
            //        PreencherProcesso();
            //        ObterTiketDispovivel();
            //        ObterTiketAfazer();
            //        ObterTiketPronto();
            //    }

            //}

             PreencherClienteModal();
                    preencherCliente();
                    PreencherProcesso();
                    ObterTiketDispovivel();
                    ObterTiketAfazer();
                    ObterTiketPronto();
        }

        public void ObterTiketDispovivel()
        {
            var dt = banco.ExecuteDataTable(null, "JOBS_CONTROLE..PROC_OBTER_TICKET", "cone");

            var dtr = dt.Rows.Cast<DataRow>().ToList().Where(x => x["STATUS"].ToString().Equals("AGUARDANDO"));

            dtr.CopyToDataTable<DataRow>(dt, LoadOption.Upsert);
            //            selectFile.Visible = false;
            if (!dtr.Count().Equals(0))
            {
                gridViewDisponivel.DataSource = dtr.CopyToDataTable();

                gridViewDisponivel.DataBind();

            }


        }

        public void ObterTiketDispovivelPorFiltro(string nome)
        {
            var dt = banco.ExecuteDataTable(null, "JOBS_CONTROLE..PROC_OBTER_TICKET", "cone");

            var dtr = dt.Rows.Cast<DataRow>().ToList().Where(x => x["CLIENTE"].ToString().Equals(nome) && x["STATUS"].ToString().Equals("AGUARDANDO"));

            dtr.CopyToDataTable<DataRow>(dt, LoadOption.Upsert);
            //            selectFile.Visible = false;
            if (!dtr.Count().Equals(0))
            {
                gridViewDisponivel.DataSource = dtr.CopyToDataTable();

                gridViewDisponivel.DataBind();

            }
            else { gridViewDisponivel.DataSource = null; gridViewDisponivel.DataBind(); }


        }

        public void ObterTiketAfazer()
        {
            var dt = banco.ExecuteDataTable(null, "JOBS_CONTROLE..PROC_OBTER_TICKET", "cone");

            var dtr = dt.Rows.Cast<DataRow>().ToList().Where(x => x["STATUS"].ToString().Equals("PROCESSANDO"));

            dtr.CopyToDataTable<DataRow>(dt, LoadOption.Upsert);

            if (!dtr.Count().Equals(0))
            {
                gridViewAfazer.DataSource = dtr.CopyToDataTable();

                gridViewAfazer.DataBind();
            }


        }

        public void ObterTiketAfazerPorFiltro(string name)
        {
            var dt = banco.ExecuteDataTable(null, "JOBS_CONTROLE..PROC_OBTER_TICKET", "cone");

            var dtr = dt.Rows.Cast<DataRow>().ToList().Where(x => x["CLIENTE"].ToString().Equals(name) && x["STATUS"].ToString().Equals("PROCESSANDO"));

            dtr.CopyToDataTable<DataRow>(dt, LoadOption.Upsert);

            if (!dtr.Count().Equals(0))
            {
                gridViewAfazer.DataSource = dtr.CopyToDataTable();

                gridViewAfazer.DataBind();
            }
            else { gridViewAfazer.DataSource = null; gridViewAfazer.DataBind(); };


        }

        public void ObterTiketPronto()
        {
            var dt = banco.ExecuteDataTable(null, "JOBS_CONTROLE..PROC_OBTER_TICKET", "cone");

            var dtr = dt.Rows.Cast<DataRow>().ToList().Where(x => x["STATUS"].ToString().Equals("PRONTO"));

            dtr.CopyToDataTable<DataRow>(dt, LoadOption.Upsert);

            if (!dtr.Count().Equals(0))
            {
                gridViewPronto.DataSource = dtr.CopyToDataTable();

                gridViewPronto.DataBind();
            }


        }

        public void ObterTiketProntoPorFiltro(string nome)
        {
            var dt = banco.ExecuteDataTable(null, "JOBS_CONTROLE..PROC_OBTER_TICKET", "cone");

            var dtr = dt.Rows.Cast<DataRow>().ToList().Where(x => x["CLIENTE"].ToString().Equals(nome) && x["STATUS"].ToString().Equals("PRONTO"));

            dtr.CopyToDataTable<DataRow>(dt, LoadOption.Upsert);

            if (!dtr.Count().Equals(0))
            {
                gridViewPronto.DataSource = dtr.CopyToDataTable();

                gridViewPronto.DataBind();
            }
            else { gridViewPronto.DataSource = null; gridViewPronto.DataBind(); }
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            myModal.Style["display"] = "none";
        }

        public void PreencherProcesso()
        {
            var dt = banco.ExecuteDataTable(null, "JOBS_CONTROLE..PROC_OBTER_PROCESSOS", "cone");

            ddlProcesso.DataTextField = "NOME_PROCESSO";
            ddlProcesso.DataValueField = "ID_PROCESSO";
            ddlProcesso.DataSource = dt;
            ddlProcesso.DataBind();
        }

        protected void gridViewDisponivel_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("Select"))
            {
                lbldiJobsControle.Text = e.CommandArgument.ToString();

                SqlParameter[] parametersObter =
            {    
                new SqlParameter("@ID_JOBCONTROLE", SqlDbType.Int, 50) { Value = lbldiJobsControle.Text },
            };
                var dt = banco.ExecuteDataTable(parametersObter, "JOBS_CONTROLE..PROC_OBTER_TICKET_ID", "cone");
                var idCliente = dt.Select()[0].ItemArray[3].ToString();
                txtValorTotal.Text = dt.Select()[0].ItemArray[13].ToString();
                txtdataVigencia.Text = dt.Select()[0].ItemArray[1].ToString();
                txtSeguimentacao.Text = dt.Select()[0].ItemArray[6].ToString();
                txtQuantidade.Text = dt.Select()[0].ItemArray[5].ToString();
                ddlProcesso.SelectedValue = dt.Select()[0].ItemArray[2].ToString();
                ddlClienteModal.SelectedValue = dt.Select()[0].ItemArray[3].ToString();

                myModal.Style["display"] = "block";

            }/******************************************************************************************************************************/
            else if (e.CommandName.Equals("Select2"))
            {
                lbldiJobsControle.Text = e.CommandArgument.ToString();

                SqlParameter[] parametersObter =
            {    
                new SqlParameter("@ID_JOBCONTROLE", SqlDbType.Int, 50) { Value = lbldiJobsControle.Text },
            };

                var dt = banco.ExecuteDataTable(parametersObter, "JOBS_CONTROLE..PROC_OBTER_TICKET_ID", "cone");

                txtValorTotal.Text = dt.Select()[0].ItemArray[13].ToString();
                txtdataVigencia.Text = dt.Select()[0].ItemArray[1].ToString();
                txtSeguimentacao.Text = dt.Select()[0].ItemArray[6].ToString();
                txtQuantidade.Text = dt.Select()[0].ItemArray[5].ToString();
                ddlStatus.SelectedValue = dt.Select()[0].ItemArray[7].ToString();
                ddlProcesso.SelectedValue = dt.Select()[0].ItemArray[2].ToString();
                ddlClienteModal.SelectedValue = dt.Select()[0].ItemArray[3].ToString();


                txtdataVigencia.Enabled = false;
                txtQuantidade.Enabled = true;
                txtSeguimentacao.Enabled = true;
                ddlClienteModal.Enabled = false;
                ddlProcesso.Enabled = true;

                myModal.Style["display"] = "block";
            }
            else if (e.CommandName.Equals("Download"))
            {

                SqlParameter[] parameterObjeto =
                {    
                    new SqlParameter("@ID_JOBCONTROLE", SqlDbType.Int, 50) { Value = e.CommandArgument.ToString() },
                };

                object item = banco.ExecuteScalar(parameterObjeto, "JOBS_CONTROLE..PROC_OBTER_TICKET_ID", "cone");

                SqlParameter[] parametersObter =
                {    
                    new SqlParameter("@ID_JOBCONTROLE", SqlDbType.Int, 50) { Value = int.Parse(item.ToString()) },
                };

                var dt = banco.ExecuteDataTable(parametersObter, "JOBS_CONTROLE..OBTER_ARQUIVO_ID_JOB", "cone");

                List<string> nomeArquivos = new List<string>();
                var downloadCaminho = Server.MapPath("~/ArquivoTemporario/");

                foreach (DataRow dtRow in dt.Rows)
                {
                    nomeArquivos.Add(downloadCaminho + dtRow[2].ToString());
                }

                var nomeArquivoZip = "NV_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".zip";
                CompactarArquivo(downloadCaminho + nomeArquivoZip, nomeArquivos);

                lbldiJobsControle.Text = e.CommandArgument.ToString();

                Response.ContentType = "image/jpeg";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + nomeArquivoZip);
                Response.TransmitFile(downloadCaminho + nomeArquivoZip);
                Response.End();

            }
        }

        public static void CompactarArquivo(string nomeArquivoZip, List<string> nomeArquivo)
        {

            using (ZipOutputStream strmZipOutputStream = new ZipOutputStream(File.Create(nomeArquivoZip)))
            {
                foreach (var item in nomeArquivo)
                {
                    FileStream fs = File.OpenRead(item);
                    ZipEntry ze = new ZipEntry(Path.GetFileName(fs.Name));
                    int len = int.Parse(fs.Length.ToString());
                    byte[] b1 = new byte[len];
                    fs.Read(b1, 0, b1.Length);

                    strmZipOutputStream.PutNextEntry(ze);
                    strmZipOutputStream.Write(b1, 0, b1.Length);
                }

            }
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            var idJobControle = lbldiJobsControle.Text;
            var dataVigencia = txtdataVigencia.Text;
            var Idprocesso = ddlProcesso.SelectedItem.Value;
            var Idcliente = ddlClienteModal.SelectedItem.Value;
            var quantidade = txtQuantidade.Text;
            var seguimentacao = txtSeguimentacao.Text;
            string status;

            if (ddlStatus.SelectedItem.Value == "PRONTO")
            {
                status = ddlStatus.SelectedItem.Value;
            }


            var nomeProcesso = "SEGUIMENTACAO";
            string nome_arquivo;



            SqlParameter[] parametersObter =
                {    
                    new SqlParameter("@ID_JOBCONTROLE", SqlDbType.Int, 50) { Value = lbldiJobsControle.Text },
                };

            var dt = banco.ExecuteDataTable(parametersObter, "JOBS_CONTROLE..PROC_OBTER_TICKET_ID", "cone");

            nome_arquivo = dt.Select()[0].ItemArray[14].ToString();


            var valorProcesso = txtValorTotal.Text;
            var ipUsuario = Session["IPUSUARIO"].ToString();
            var idUsuario = Session["IDUSUARIO"].ToString();

            SqlParameter[] parameters =
            {    
                new SqlParameter("@ID_JOBCONTROLE", SqlDbType.Int) { Value = idJobControle },
                new SqlParameter("@DATA_VIGENCIA", SqlDbType.DateTime, 50) { Value = dataVigencia},
                new SqlParameter("@IDPROCESSO", SqlDbType.Int) { Value = Idprocesso},
                new SqlParameter("@IDCLIENTE", SqlDbType.Int) { Value = Idcliente},
                new SqlParameter("@QUANTIDADE", SqlDbType.VarChar, 50) { Value = quantidade},
                new SqlParameter("@SEGMENTACAO", SqlDbType.VarChar, 5000) { Value = seguimentacao },
                new SqlParameter("@STATUS", SqlDbType.VarChar, 50) { Value = ddlStatus.SelectedItem.Value},
                new SqlParameter("@VALOR_PROCESSO", SqlDbType.Decimal, 50) { Value = valorProcesso },
                new SqlParameter("@NOME", SqlDbType.VarChar, 50) { Value = nomeProcesso},
                new SqlParameter("@ID_USUARIO", SqlDbType.Int) { Value = Session["IDUSUARIO"]},
                new SqlParameter("@IP_USUARIO", SqlDbType.VarChar, 50) { Value = Session["IPUSUARIO"]},
                new SqlParameter("@NOME_ARQUIVO", SqlDbType.VarChar, 60) { Value = ""}
            };

            //SaveFile();
            //LimparCampo();
            object obj = banco.ExecuteScalar(parameters, "JOBS_CONTROLE..PROC_UPDATE_TICKET", "cone");
            if (ddlStatus.SelectedValue == "AQUARDANDO")
            {
                if (HttpContext.Current.Request.Files != null && HttpContext.Current.Request.Files.Count > 0)
                {
                    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    {
                        HttpPostedFile fl = HttpContext.Current.Request.Files[i];
                        fl.SaveAs(Server.MapPath("~/ArquivoTemporario/") + fl.FileName);

                        parameters = new SqlParameter[] 
                            {    
                                new SqlParameter("@ID_JOBCONTROLE", SqlDbType.BigInt) { Value = parameters[0].Value},
                                new SqlParameter("@NOME_ARQUIVO", SqlDbType.VarChar) { Value = fl.FileName},
                                new SqlParameter("@TIPO", SqlDbType.VarChar) { Value = "E"}
                            };
                        banco.ExecuteNonQuery(parameters, "JOBS_CONTROLE..INSERIR_ARQUIVO", "cone");
                    }
                }
                else banco.ExecuteNonQuery(parameters, "JOBS_CONTROLE..PROC_UPDATE_TICKET", "cone");
                myModal.Style["display"] = "none";
            }
            else if (ddlStatus.SelectedValue == "PROCESSANDO")
            {
                if (HttpContext.Current.Request.Files != null && HttpContext.Current.Request.Files.Count > 0)
                {
                    for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
                    {
                        HttpPostedFile fl = HttpContext.Current.Request.Files[i];
                        fl.SaveAs(Server.MapPath("~/ArquivoTemporario/") + fl.FileName);

                        parameters = new SqlParameter[] 
                            {    
                                new SqlParameter("@ID_JOBCONTROLE", SqlDbType.BigInt) { Value = parameters[0].Value},
                                new SqlParameter("@NOME_ARQUIVO", SqlDbType.VarChar) { Value = fl.FileName},
                                new SqlParameter("@TIPO", SqlDbType.VarChar) { Value = "S"}
                            };
                        banco.ExecuteNonQuery(parameters, "JOBS_CONTROLE..INSERIR_ARQUIVO", "cone");
                    }
                }
                else banco.ExecuteNonQuery(parameters, "JOBS_CONTROLE..PROC_UPDATE_TICKET", "cone");
                myModal.Style["display"] = "none";
            }
            Response.Redirect("~/ListaJobsPage.aspx");
        }

        public void LimparCampo()
        {
            txtdataVigencia.Text = "";
            txtQuantidade.Text = "";
            txtSeguimentacao.Text = "";
            txtValorTotal.Text = "";
        }

        protected void Unnamed_Command(object sender, CommandEventArgs e)
        {
            myModal.Style["display"] = "none";
        }

        public void preencherCliente()
        {
            var dt = banco.ExecuteDataTable(null, "VNADMIN.dbo.OBTER_CLIENTE", "cone");

            dropCliente.DataTextField = "NOME";
            dropCliente.DataValueField = "IDCLIENTE";

            dropCliente.DataSource = dt;
            dropCliente.DataBind();
        }

        public void PreencherClienteModal()
        {
            var dt = banco.ExecuteDataTable(null, "VNADMIN.dbo.OBTER_CLIENTE", "cone");

            ddlClienteModal.DataTextField = "NOME";
            ddlClienteModal.DataValueField = "IDCLIENTE";

            ddlClienteModal.DataSource = dt;
            ddlClienteModal.DataBind();
        }

        protected void selectFile_Unload(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile) { }
                //SaveFile();
        }

        //private void SaveFile()
        //{
        //    var savePath = Server.MapPath("~/ArquivoTemporario/");

        //    string fileName = FileUpload1.FileName;

        //    string pathToCheck = savePath + fileName;

        //    string tempfileName = "";



        //    if (System.IO.File.Exists(pathToCheck))
        //    {
        //        int counter = 2;
        //        while (System.IO.File.Exists(pathToCheck))
        //        {
        //            tempfileName = counter.ToString() + fileName;
        //            pathToCheck = savePath + tempfileName;
        //            counter++;
        //        }

        //        fileName = tempfileName;
        //    }
        //    savePath += fileName;
        //    FileUpload1.SaveAs(savePath);
        //}

        protected void Download_Click(object sender, EventArgs e)
        {

            SqlParameter[] parameterObjeto =
                {    
                    new SqlParameter("@ID_JOBCONTROLE", SqlDbType.Int, 50) { Value = lbldiJobsControle.Text },
                };

            object item = banco.ExecuteScalar(parameterObjeto, "JOBS_CONTROLE..PROC_OBTER_TICKET_ID", "cone");
            var dtb = banco.ExecuteDataTable(parameterObjeto, "JOBS_CONTROLE..PROC_OBTER_TICKET_ID", "cone");

            SqlParameter[] parametersObter =
                {    
                    new SqlParameter("@ID_JOBCONTROLE", SqlDbType.Int, 50) { Value = int.Parse(item.ToString()) },
                };

            var dt = banco.ExecuteDataTable(parametersObter, "JOBS_CONTROLE..OBTER_ARQUIVO_ID_JOB", "cone");

            List<string> nomeArquivos = new List<string>();
            var downloadCaminho = Server.MapPath("~/ArquivoTemporario/");
            if (ddlStatus.SelectedValue == "PROCESSANDO")
            {
                foreach (DataRow dtRow in dt.Rows)
                {

                    if (dtRow[3].ToString() == "S")
                        nomeArquivos.Add(downloadCaminho + dtRow[2].ToString());

                }
                if (nomeArquivos.Count > 0)
                {
                    var nomeArquivoZip = "NV_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_Saida.zip";
                    CompactarArquivo(downloadCaminho + nomeArquivoZip, nomeArquivos);



                    Response.ContentType = "image/jpeg";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + nomeArquivoZip);
                    Response.TransmitFile(downloadCaminho + nomeArquivoZip);
                    Response.End();
                }
            }
            else if (ddlStatus.SelectedValue == "AGUARDANDO") 
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                   if (dtRow[3].ToString() == "E")
                        nomeArquivos.Add(downloadCaminho + dtRow[2].ToString());
                }

                if (nomeArquivos.Count > 0)
                {
                    var nomeArquivoZip = "NV_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_Saida.zip";
                    CompactarArquivo(downloadCaminho + nomeArquivoZip, nomeArquivos);



                    Response.ContentType = "image/jpeg";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + nomeArquivoZip);
                    Response.TransmitFile(downloadCaminho + nomeArquivoZip);
                    Response.End();
                }
            }
        }

        protected void dropCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nome = dropCliente.SelectedItem.Text;
            ObterTiketProntoPorFiltro(nome.ToUpper());
            ObterTiketAfazerPorFiltro(nome.ToUpper());
            ObterTiketDispovivelPorFiltro(nome.ToUpper());
        }

    }
}

