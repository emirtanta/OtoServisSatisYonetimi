<%@ Page Title="" Language="C#" MasterPageFile="~/OtoServisSablon.Master" AutoEventWireup="true" CodeBehind="KullaniciYonetimi.aspx.cs" Inherits="OtoServisSatis.WebFormUI.KullaniciYonetimi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Kullanıcı Yönetimi</h1>

    <div>
        <asp:GridView ID="gvKullaniclar" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvKullaniclar_SelectedIndexChanged">
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

        <table class="table">
            <tr>
                <th>Adı</th>
                <th>Soyadı</th>
                <th>Email</th>
                <th>Telefon</th>
                <th>Kullanıcı Adı</th>
                <th>Şifre</th>
                <th>Aktif mi?</th>
                <th>Eklenme Tarihi</th>
                <th>Kullanıcı Rolü</th>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtAdi" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtSoyadi" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtTelefon" runat="server"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="txtKullaniciAdi" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Boş olamaz" ForeColor="Red" ControlToValidate="txtKullaniciAdi"></asp:RequiredFieldValidator>
                <td>
                    <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox></td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Boş olamaz" ForeColor="Red" ControlToValidate="txtSifre"></asp:RequiredFieldValidator>
                <td>
                    <asp:CheckBox ID="cbAktifMi" runat="server" />

                </td>
                <td>
                    <asp:Label ID="lblEklenmeTarihi" runat="server" Visible="true"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlKullaniciRolu" runat="server" DataTextField="Adi" DataValueField="Id"></asp:DropDownList>

                </td>
                <td>
                    <asp:Label ID="lblId" runat="server" Text="0" Visible="false"></asp:Label>
                </td>

            </tr>
        </table>
        <asp:Button ID="btnEkle" runat="server" Text="Ekle" OnClick="btnEkle_Click" />
        <asp:Button ID="btnGucelle" runat="server" Text="Güncelle" OnClick="btnGucelle_Click" />
        <asp:Button ID="btnSil" runat="server" Text="Sil" OnClick="btnSil_Click" ValidationGroup="sil" />
    </div>
</asp:Content>
