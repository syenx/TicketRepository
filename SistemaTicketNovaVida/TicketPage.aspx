<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicketPage.aspx.cs" Inherits="SistemaTicketNovaVida.TecketPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />
    <img src="logo-corp-red.png" />
    <hr />
    <div>
        <div>
            <asp:Label ID="lblUsuarioLogado" Text="Usuario" runat="server" />
        </div>
        <br />
        <div>
            <asp:Label Text="Cliente" runat="server" />

            <asp:DropDownList ID="ddlCliente" runat="server" AutoPostBack="true" EnableViewState="true" Width="314px">
                <asp:ListItem Value="" Selected="True"> - Product - </asp:ListItem>
            </asp:DropDownList>

            &nbsp;&nbsp;&nbsp;&nbsp;
            
            Valor Total:   
            <asp:TextBox runat="server" ID="txtValorTotal" onkeyup="javascript:this.value=Comma(this.value);" Style="text-align: right" Height="27px" />

        </div>
        <br />
        <div>
            <table>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <div style="margin-right: 20px">
                            Data Vigencia   :   
                            <asp:TextBox runat="server" ID="txtdataVigencia" TextMode="Date" Height="27px" />
                        </div>
                    </td>
                    <td>
                        <div style="margin-right: 30px">
                            Processo: 
                         <asp:DropDownList ID="ddlProcesso" runat="server" AutoPostBack="true" Height="27px" Width="314px">
                         </asp:DropDownList>
                        </div>
                    </td>

                    <td>
                        <div style="margin-right: 30px">
                            <asp:Label Text="Quantidade Desejada:" ID="lblquantidate" runat="server" />
                            <asp:TextBox ID="txtQuantidade" runat="server" TextMode="Number" Height="27px" />
                        </div>
                    </td>
                </tr>

            </table>
        </div>

        <br />
        Seguimentação do processo acima selecionado:
 
        <br />
        <asp:TextBox runat="server" ID="txtSeguimentacao" TextMode="MultiLine" Height="200px" Width="900px" />
        <div >
            <img src="icone-clips.png" style="width:30px; height:30px" value="ADD" id="add" />
            <div style="margin-right: 30px">
                <asp:FileUpload runat="server" ID="selectFile" Font-Names="" />
            </div>
            <div id="divfl"></div>
        </div>
        <div style="margin-right: 50%">
            <asp:Button Text="Salvar" Style="width: 157px; background: #f7852c; border: none; color: #fff; height: 52px;" ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" />
        </div>
        <br />
        <hr />
        <br />

    </div>

    <script>
        var qtdfl = 1; varqtdmax = 4;
        function Comma(Num) { //function to add commas to textboxes
            Num += '';
            Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
            Num = Num.replace(',', ''); Num = Num.replace(',', ''); Num = Num.replace(',', '');
            x = Num.split('.');
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1))
                x1 = x1.replace(rgx, '$1' + ',' + '$2');
            return x1 + x2;
        }
        $("#add").click(function () {
            if (qtdfl <= varqtdmax)
                {
                $("#divfl").append('<asp:FileUpload runat="server" ID="selectFile1" />');
                qtdfl += 1;
            }
        });
    </script>

</asp:Content>
