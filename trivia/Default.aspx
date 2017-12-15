<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="trivia._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Trivia</h1>
        <p class="lead">Test your knowledge...</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Questions</h2>
            <p>
                <asp:GridView ID="gvQuestions" runat="server"></asp:GridView>
            </p>
                
        </div>
        <div class="col-md-4">
            <h2>Add a Question</h2>
            <p>
                <asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
            </p>
            <p>
                Category
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>
            </p>
            <p>
                &nbsp;<asp:Button ID="btnQuestionAdd" runat="server" OnClick="btnQuestionAdd_Click" Text="Submit Question!" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Add a Category</h2>
            <p>
                <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnCategoryAdd" runat="server" OnClick="btnCategoryAdd_Click" Text="Submit a Category!" />
            </p>
        </div>
    </div>

</asp:Content>
