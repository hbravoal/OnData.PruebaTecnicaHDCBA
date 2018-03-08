<%@ Control Language="C#" CodeBehind="DynamicDataField1.ascx.cs" Inherits="OnData.PruebaTecnicaHDCBA.DynamicData.FieldTemplates.DynamicDataField1" %>

<asp:Literal runat="server" ID="Literal1" Text="<%# FieldValueString %>" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>

