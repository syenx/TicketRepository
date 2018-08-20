<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="SistemaTicketNovaVida.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .padding-top-20 {
            margin-left: 280px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        
            <br />
            <img src="logo-corp-red.png" />
            <hr />
            <div style=" padding-top:3%; padding-left: 30%; padding-right:30%">
            <div class="col-md-9 col-sm-9"  height: 372px;">
                <h1>Acesse agora</h1>
                
                    <div class="row">
                            <div class="col-md-7 col-sm-7">
                                <div class="form-group">
                                    <div class="col-lg-8">
                                        <label for="usuario" class="col-lg-4 control-label">Login <span class="require">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></label>
                                        &nbsp;<asp:TextBox ID="txtLogin" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-8" style="padding-top: 10px;">
                                        <label for="password" class="col-lg-4 control-label" style="padding-top: 10px;">Senha <span class="require">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></label>
                                        &nbsp;<asp:TextBox ID="txtSenha" runat="server" TextMode="Password" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-8" style="padding-top: 10px;">
                                        <label for="cliente" style="padding-top: 10px;">Cliente <span class="require">*&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></label>
                                        &nbsp;<asp:TextBox ID="txtCliente" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-lg-8" style="padding-top: 10px;">
                                       <label for="password" class="col-lg-4 control-label" style="padding-top: 10px;">IP <span class="require">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span></label>
                                        &nbsp;<asp:TextBox ID="txtip" runat="server" Enabled="False" />
                                     </div>  
                                    &nbsp;</div>
                                <div class="row">
                                    <div class="col-lg-8 col-md-offset-4 padding-left-0 padding-top-20">
                                        <br />
                                        <asp:Button Text="Acessar" Style="width: 157px; background: #f7852c; border: none; color: #fff; height: 52px;" ID="btnAcessar" OnClientClick="" runat="server" OnClick="btnAcessar_Click" />
                                    </div>
                                </div>
                         </div>
                            <div class="col-md-4 col-sm-4 pull-right" style="height: 193px; width: 900px;">
                                <%--   <img src="abelha.jpg" />--%>
                            </div>

                    </div>
                </div>
    
         </div>
         <hr />
        <div style="padding-top:-1%">
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Nova Vida </p>
            </footer>
        </div>
    </form>
    
         
           

</body>
</html>
