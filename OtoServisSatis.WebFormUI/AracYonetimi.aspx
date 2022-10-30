<%@ Page Title="Araç Yönetimi" Language="C#" MasterPageFile="~/OtoServisSablon.Master" AutoEventWireup="true" CodeBehind="AracYonetimi.aspx.cs" Inherits="OtoServisSatis.WebFormUI.AracYonetimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvAraclar" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvAraclar_SelectedIndexChanged">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seç" />
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>

    <hr />

    <h1>Araç Bilgileri</h1>

    <table class="auto-style1">
        <tr>
            <td>Marka</td>
            <td>
                <asp:DropDownList ID="ddlMarkalar" DataTextField="Adi" DataValueField="Id" runat="server"></asp:DropDownList>
            </td>
            
        </tr>
        <tr>
            <td>Renk</td>
            <td>
                <asp:TextBox ID="txtRenk" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td>Fiyat</td>
            <td>
                <asp:TextBox ID="txtFiyati" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fiyat Boş Olamaz" ForeColor="Red" ControlToValidate="txtFiyati" ></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Modeli</td>
            <td>
                <asp:TextBox ID="txtModeli" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Kasa Tipi</td>
            <td>
                <asp:TextBox ID="txtKasaTipi" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Model Yılı</td>
            <td>
                <asp:TextBox ID="txtModelYili" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Model Yılı Boş Olamaz" ForeColor="Red" ControlToValidate="txtModelYili" ></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>Notlar</td>
            <td>
                <asp:TextBox ID="txtNotlar" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Satışta mı?</td>
            <td>
                <asp:CheckBox ID="cbSatistaMi" runat="server" />
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="lblId" runat="server" Text="0" Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
                <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" />
                <asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" ValidationGroup="sil" />
            </td>
            
        </tr>
    </table>

    <br />


</asp:Content>
