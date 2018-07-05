<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pagina2.aspx.cs" Inherits="myWaiter.pagina2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>myWaiter</title>
    <link href="~/Mobile/css/tutorial.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="background2">
        <asp:ImageButton ID="btnAvancar" runat="server" ImageUrl="~/Mobile/images/pagina2/setDireita.fw.png" PostBackUrl="~/Mobile/Pages/pagina3.aspx"/>
        <asp:ImageButton ID="btnVoltar" runat="server" ImageUrl="~/Mobile/images/pagina2/setaEsquerda.fw.png" PostBackUrl="~/Mobile/Pages/pagina1.aspx"/>
    </div>
    </form>
</body>
</html>
