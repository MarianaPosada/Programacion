<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="pSitioWEB_Programacion.ReglasNegocio.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="nav-justified">
        <tr>
            <td colspan="2" style="font-weight: bold; text-align: center; font-size: x-large; height: 69px;">
                COMUNICACION CELULAR</td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>VALOR PLAN:</b>
                <asp:TextBox ID="TextBox2" runat="server" style="font-size: x-large"></asp:TextBox>
            </td>

                <td style="height: 22px; font-size: x-large">V<b>ALOR EQUIPO:</b></td>
            <td style="height: 22px">
                <asp:TextBox ID="TextBox1" runat="server" style="font-size: x-large"></asp:TextBox>
            </td>
        </tr>
            </td>
        </tr>
       
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnRegistrar" runat="server" OnClick="btnRegistrar_Click" Text="REGISTRAR VENTA" style="font-size: x-large" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblError" runat="server" style="font-size: x-large"></asp:Label>
            </td>
            <td style="font-size: x-large">&nbsp;</td>
        </tr>
        <tr>
            <td style="font-size: x-large">T<strong>otal:</strong></td>
            <td>
                <asp:Label ID="lblTotal" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large"><b>Porcentaje Descuento:</b></td>
            <td>
                <asp:Label ID="lblPorcentaje" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large">V<b>alor Descuento:</b></td>
            <td>
                <asp:Label ID="lblValorDesc" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="font-size: x-large">V<b>alor Antes IVA:</b></td>
            <td>
                <asp:Label ID="lblVlorantIVA" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
	<tr>
            <td style="font-size: x-large">V<b>alor IVA:</b></td>
            <td>
                <asp:Label ID="lblValorIVA" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        
    </table>
</asp:Content>

