<%@ Control Language="C#" CodeBehind="DynamicContainers.ascx.cs" Inherits="OnData.PruebaTecnicaHDCBA.DynamicData.FieldTemplates.DynamicContainers" %>

<asp:Literal runat="server" ID="Literal1" Text="<%# FieldValueString %>" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbPruebaTecnicaHDCBAConnectionString %>" SelectCommand="SELECT * FROM [containers]"></asp:SqlDataSource>
<asp:DataList ID="DataList1" runat="server" DataKeyField="id" DataSourceID="SqlDataSource1">
    <ItemTemplate>
        id:
        <asp:Label ID="idLabel" runat="server" Text='<%# Eval("id") %>' />
        <br />
        name:
        <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
        <br />
        description:
        <asp:Label ID="descriptionLabel" runat="server" Text='<%# Eval("description") %>' />
        <br />
        type_container_id:
        <asp:Label ID="type_container_idLabel" runat="server" Text='<%# Eval("type_container_id") %>' />
        <br />
        content:
        <asp:Label ID="contentLabel" runat="server" Text='<%# Eval("content") %>' />
        <br />
        image:
        <asp:Label ID="imageLabel" runat="server" Text='<%# Eval("image") %>' />
        <br />
<br />
    </ItemTemplate>
</asp:DataList>

