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
    public partial class _Default : Page
    {
        DAO banco = new DAO();

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (string.IsNullOrEmpty(Session["IDUSUARIO"] as string))
            //{
            //    Response.Redirect("~/LoginPage.aspx");
            //    Session["IDUSUARIO"] = null;
            //}
        }
    }
}