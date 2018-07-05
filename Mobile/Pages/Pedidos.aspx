<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Pages/MasterHeader.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="myWaiter.Mobile.Pages.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <link href="../css/abaPedido.css" rel="stylesheet" />

    <div id="wrapperPedido">

        <div id="divBarraCentral">
            <asp:Label ID="lblTexto" runat="server" Text="Não há produtos no pedido!"></asp:Label>
        </div>

        <div id="divBarraNomes">
            <div id="divNomes">
                <ul id="ulNomesPedidos" runat="server">

                </ul>
            </div>

            <div id="divBotao">
                <asp:Image ID="btnEnviarPedido2" runat="server" ImageUrl="~/Mobile/images/paginaPedidos/btnEnviarPedido.fw.png" CssClass="btn"  />
            </div>
        </div>
    </div>

    <div id="msgBoxProduto">
        <asp:Image ID="imgGarcom" CssClass="garcomMsgBox" runat="server" ImageUrl="~/Mobile/images/msgBox/garcomVectorMsgBox.fw.png" />

        <div id="msgtext" class="msgText" runat="server">
            <p>Tem certeza que deseja enviar este pedido?</p>
            <p>Atenção: Após o pedido ser enviado não poderá mais ser cancelado!</p>
        </div>

        <asp:ImageButton ID="btnCancelarBox" CssClass="btnCancellBox" runat="server" ImageUrl="~/Mobile/images/msgBox/btnCancelar.fw.png" />
        <asp:ImageButton ID="btnOk" CssClass="btnOkBox" runat="server" ImageUrl="~/Mobile/images/msgBox/btnOk.fw.png" OnClick="btnEnviarPedido_Click"  />
    </div>

    <script src="../../jquery-1.11.3.js"></script>
    <script>
        $(document).ready(function () {
            $(".btn").click(function () {
                $("#msgBoxProduto").css("visibility", "visible");
                $("#wrapperPedido").css("opacity", 0.2);
                $("#wrapperPedido").css("pointer-events", "none");
                $("#header").css("opacity", 0.2);
                $("#header").css("pointer-events", "none");
            })
        })
    </script>

</asp:Content>
