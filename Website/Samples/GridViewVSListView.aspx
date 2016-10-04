<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GridViewVSListView.aspx.cs" Inherits="Samples_GridViewVSListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="GridView POCO"></asp:Label>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="GridViewODS" runat="server"></asp:ObjectDataSource>
</asp:Content>

