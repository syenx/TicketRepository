<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaJobsPage.aspx.cs" Inherits="SistemaTicketNovaVida.ListaJobsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <img src="logo-corp-red.png" />
    <hr />
    <div id="dvCli" class="dvCli" style="display: block;">
        Cliente: 
        <asp:DropDownList ID="dropCliente" OnSelectedIndexChanged="dropCliente_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>

    </div>
    <div class="accordion" id="accordion2">
        <div class="accordion-group">
            <div class="accordion-group">
                <div class="accordion-heading">
                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion3" style="background-color: #08cc5a; color: #ffffff" href="#collapseThree">PRONTO
                    </a>
                </div>
                <div id="collapseThree" class="accordion-body collapse">
                    <div class="accordion-inner">
                        <asp:GridView runat="server" ID="gridViewPronto" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="612px" OnRowCommand="gridViewDisponivel_RowCommand">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkDisponivel" runat="server" CausesValidation="False" CommandName="Download" Text="   DOWNLOAD" CommandArgument='<%#Eval("ID_JOBCONTROLE") %>'></asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField>

                                    <ItemTemplate>
                                        <img src="icone-clips.jpg" style="height: 40px; width: 40px;" />

                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="#ff6a00" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="accordion-group">
            <div class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" style="background-color: #ff6a00; color: #ffffff" href="#collapseOne">EM FILA OU AGUARDADO
                </a>
            </div>
            <div id="collapseOne" class="accordion-body collapse in">
                <div class="accordion-inner">
                    <div style="width: 100%; height: 200px; overflow: scroll">
                        <asp:GridView runat="server" ID="gridViewDisponivel" CellPadding="4" ForeColor="Black" GridLines="None" Width="612px" OnRowCommand="gridViewDisponivel_RowCommand">
                            <AlternatingRowStyle BackColor="White" />

                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkDisponivel" runat="server" CausesValidation="False" BackColor="Window" CommandName="Select" Text="SELECIONAR" CommandArgument='<%#Eval("ID_JOBCONTROLE") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                            <EditRowStyle BackColor="#2461BF" />

                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#ff6a00" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />

                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>
        <div class="accordion-group">
            <div class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" style="background-color: #ff6a00; color: #ffffff" href="#collapseTwo">PROCESSANDO
                </a>
            </div>
            <div id="collapseTwo" class="accordion-body collapse">
                <div class="accordion-inner">
                    <div style="width: 100%; height: 200px; overflow: scroll">

                        <asp:GridView runat="server" ID="gridViewAfazer" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="612px" OnRowCommand="gridViewDisponivel_RowCommand">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkProncessando" runat="server" CausesValidation="False" CommandName="Select2" Text="SELECIONAR" CommandArgument='<%#Eval("ID_JOBCONTROLE") %>'></asp:LinkButton>
                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>

    </div>
    <!-- DIV MODAL-->


    <div id="myModal" runat="server" class="modal" role="dialog" style="height: 600px" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <asp:LinkButton runat="server" type="button" class="close" OnCommand="Unnamed_Command" CommandArgument="Close" CommandName="Close" data-dismiss="modal" aria-hidden="true">×</asp:LinkButton>
            <br />
            <img src="logo-corp-red.png" />

        </div>
        <div class="modal-body">
            <asp:Label Text="Cliente" runat="server" />
            <asp:DropDownList ID="ddlClienteModal" runat="server" AutoPostBack="true" Height="25px" Width="200px"></asp:DropDownList>

            <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="true" Height="25px" Width="200px">
                <asp:ListItem Text="PROCESSANDO" Value="PROCESSANDO"></asp:ListItem>
                <asp:ListItem Text="AGUARDANDO" Value="AGUARDANDO"></asp:ListItem>
                <asp:ListItem Text="PRONTO" Value="PRONTO"></asp:ListItem>
            </asp:DropDownList>
            <br />

            Total:   
                <asp:TextBox runat="server" ID="txtValorTotal" Height="25px" Width="150px" onkeyup="javascript:this.value=Comma(this.value);" Style="text-align: right" />

            <div>
                <asp:Label Text="" ID="lbldiJobsControle" Visible="false" runat="server" />
                <table>
                    <tr>

                        <td>
                            <div>
                                Data Vigencia   :   
                                <asp:TextBox runat="server" ID="txtdataVigencia" Height="25px" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                Processo: 
                                <asp:DropDownList ID="ddlProcesso" runat="server" AutoPostBack="true" Height="25px" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <asp:Label Text="Quantidade Desejada:" ID="lblquantidate" runat="server" />
                                <asp:TextBox ID="txtQuantidade" runat="server" TextMode="Number" Height="25px" Width="200px" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            Seguimentação do processo acima selecionado:
                                                <br />
            <asp:TextBox runat="server" ID="txtSeguimentacao" TextMode="MultiLine" Height="105px" Width="450px" />
            <div>
                <asp:Button Text="Download_Arquivo" runat="server" OnClick="Download_Click" />
            </div>
            <br/>
            <div>
                <img src="icone-clips.png" style="width: 30px; height: 30px" value="ADD" id="add" />
                <div style="margin-right: 30px">
                    <asp:FileUpload runat="server" ID="FileUpload1" Font-Names="" />
                </div>
                <div id="divfl"></div>
            </div>

        </div>
        <div class="modal-footer" style="height: 50px; width: 40%;">
            <asp:Button Text="Fechar" Style="background: #f7852c; border: none; color: #fff;" ID="btnFechar" runat="server" OnClick="btnFechar_Click" class="btn btn-default" data-dismiss="modal" />
            <asp:Button Text="Atualizar" Style="background: #f7852c; border: none; color: #fff;" ID="btnAtualizar" runat="server" OnClick="btnAtualizar_Click" class="btn btn-default" data-dismiss="modal" />

        </div>
        <div class="modal-backdrop in modal"></div>
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
            if (qtdfl <= varqtdmax) {
                $("#divfl").append('<asp:FileUpload runat="server" ID="selectFile1" />').before("txtValorTotal");
                qtdfl += 1;
            }
        });
    </script>
</asp:Content>
