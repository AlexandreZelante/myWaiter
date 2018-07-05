<%@ Page Title="" Language="C#" MasterPageFile="~/Mobile/Pages/MasterHeader.Master" AutoEventWireup="true" CodeBehind="Conta.aspx.cs" Inherits="myWaiter.Mobile.Pages.Conta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentMain" runat="server">
    <link href="../css/abaConta.css" rel="stylesheet" />

    <div id="wrapperPedido">

        <div id="divBarraCentral">
            <asp:Label ID="lblTexto" runat="server" Text="Não há pedidos na conta!"></asp:Label>
        </div>

        <div id="divBarraNomes">
            <div id="divNomes">
                <asp:Label ID="lblComandaConta" runat="server" Text="Label"></asp:Label>
            </div>

            <div id="divBotao">
                <asp:Image ID="btnFinalizarConta2" runat="server" ImageUrl="~/Mobile/images/conta/FinalizarContaRedi.fw.png" CssClass="btn btnFinalizarConta_Click"  />
            </div>
        </div>
    </div>

    <div id="msgBoxProduto" class="msgBoxProduto" runat="server">

        <asp:Image ID="imgGarcom" CssClass="garcomMsgBox" runat="server" ImageUrl="~/Mobile/images/msgBox/garcomVectorMsgBox.fw.png" />

        <div id="msgtext" class="msgText" runat="server">
            <p>Tem certeza que deseja finalizar essa comanda?</p>
            <p>Atenção: Após finalizar a comanda nenhum pedido mais poderá ser feito com a mesma!</p>
        </div>
        
        <asp:ImageButton ID="btnCancelarBoxss" CssClass="btnCancellBox" runat="server" ImageUrl="~/Mobile/images/msgBox/btnCancelar.fw.png" PostBackUrl="~/Mobile/Pages/Conta.aspx"/>
    </div>

    <div id="msgBoxConta" class="msgBoxConta" runat="server">

        <asp:Image ID="garcomMsgBox" CssClass="garcomMsgBox" runat="server" ImageUrl="~/Mobile/images/msgBox/garcomVectorMsgBox.fw.png" />

        <div id="Div2" class="msgText" runat="server">
            <p>Tem certeza que deseja finalizar a conta?</p>
        </div>
        
        <asp:ImageButton ID="ImageButton1" CssClass="btnCancellBox" runat="server" ImageUrl="~/Mobile/images/msgBox/btnCancelar.fw.png" PostBackUrl="~/Mobile/Pages/Conta.aspx"/>
        <asp:ImageButton ID="btnOk" CssClass="btnOkBox" runat="server" ImageUrl="~/Mobile/images/msgBox/btnOk.fw.png" OnClick="btnFinalizarConta_Click"  />
    </div>

    <script src="../../jquery-1.11.3.js"></script>
    <script>
        $(document).ready(function () {
            $(".btnFinalizar_Click").click(function () {
                $(".msgBoxProduto").css("visibility", "visible");
                $("#wrapperPedido").css("opacity", 0.2);
                var idCom = this.id;
                //alert(idCom);
                $(".btn"+idCom).removeClass("hidden");
                $(".btn"+idCom).addClass("visible");
                //$("#ContentMain_").css("visibility", "visible");
                $("#wrapperPedido").css("pointer-events", "none");
                $("#header").css("opacity", 0.2);
                $("#header").css("pointer-events", "none");
            })
        })
    </script>

    <script>
        $(document).ready(function () {
            $(".btnFinalizarConta_Click").click(function () {
                $(".msgBoxConta").css("visibility", "visible");
                $("#wrapperPedido").css("opacity", 0.2);
                $("#wrapperPedido").css("pointer-events", "none");
                $("#header").css("opacity", 0.2);
                $("#header").css("pointer-events", "none");
            })
        })
    </script>

</asp:Content>
