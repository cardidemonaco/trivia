<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAnswers.aspx.cs" Inherits="trivia.ManageAnswers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    &nbsp;</p>
<p>
    <strong>Pick a Question</strong></p>
<p>
    <asp:DropDownList ID="ddlQuestions" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlQuestions_SelectedIndexChanged">
    </asp:DropDownList>
</p>
<p>
    <strong>Create Potential Answers</strong></p>
<p>
    <asp:TextBox ID="txtAnswer1" runat="server"></asp:TextBox>
&nbsp;<asp:CheckBox ID="cbAnswer1" runat="server" Text="This is a correct answer" /><br />
    <asp:FileUpload ID="fuAnswer1" runat="server" />
    
</p>
    <p>
        &nbsp;</p>
<p>
    <asp:TextBox ID="txtAnswer2" runat="server"></asp:TextBox>
&nbsp;<asp:CheckBox ID="cbAnswer2" runat="server" Text="This is a correct answer" />
</p>
    <p>
        &nbsp;</p>
<p>
    <asp:TextBox ID="txtAnswer3" runat="server"></asp:TextBox>
&nbsp;<asp:CheckBox ID="cbAnswer3" runat="server" Text="This is a correct answer" />
</p>
<p>
    <asp:Button ID="btnAnswersAdd" runat="server" OnClick="btnAnswersAdd_Click" Text="Submit Answers!" />
</p>
    <p>
        &nbsp;</p>
    <p>
        <strong>Current Answers</strong></p>
    <p>
        <asp:GridView ID="gvCurrentAnswers" runat="server">
        </asp:GridView>
</p>
    <p>
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
</p>
<p>
    &nbsp;</p>
</asp:Content>
