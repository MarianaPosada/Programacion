<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentaProducto.aspx.cs" Inherits="pSitioWEB_Programacion.ClasesBasicas.VentaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <strong>&nbsp;</strong><table align="center" style="width: 80%">
            <tr>
                <td class="text-center col-form-label" colspan="2" style="font-size: xx-large"><strong>VENTA DE PRODUCTOS</strong></td>
            </tr>
            <tr>
                <td style="width: 311px"><strong><span style="font-size: x-large">CANTIDAD:</span></strong><span style="font-size: x-large"></td>
                <td class="text-center">
                    <asp:TextBox ID="txtCantidad" class="form-control form-control-sm" placeholder="Ingrese la Cantidad" runat="server" style="margin-right: 73"></asp:TextBox>
                </td>
            </tr>
            <tr>
                
                <td style="width: 311px; font-size: x-large;"><strong>VALOR UNITARIO:</strong></td>
                <td class="text-center">
                    <asp:TextBox ID="txtValorUnitario" class="form-control form-control-sm" placeholder="Ingrese Valor Unitario" runat="server"></asp:TextBox>
             </td>
            </tr>
            <tr>
                <td style="height: 34px; " class="text-center" colspan="2">
                    <asp:Button ID="BtnCalcular" Class = "btn btn-primary" runat="server" Height="43px" style="font-size: x-large; color: #00FFFF;" Text="CALCULAR" Width="162px" OnClick="Button1_Click1" />
                </td>
            </tr>
            <tr>
                <td class="text-left" style="height: 47px; font-size: x-large;">
                    <asp:Label ID="LblError" runat="server"></asp:Label>
                </td>
                <td class="text-center" style="height: 47px; font-size: x-large;">
                    </td>
            </tr>
            <tr>
                <td style="height: 20px; width: 311px; font-size: x-large;"><strong>SUBTOTAL:</strong></td>
                <td class="text-center" style="height: 20px">
                    <asp:Label ID="LblSubtotal" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 311px; font-size: x-large;"><strong>VALOR IVA:</strong></td>
                <td class="text-center">
                    <asp:Label ID="LblValorIVA" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 311px"></span><strong><span style="font-size: x-large">TOTAL PAGAR:</span></strong></td>
                <td class="text-center">
                    <asp:Label ID="LblTotalP" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
        </table>
    </p>
</asp:Content>
