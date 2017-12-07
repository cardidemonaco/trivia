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
                
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Add a Question</h2>
            <p>
                &nbsp;<asp:TextBox ID="txtQuestion" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
            </p>
            <p>
                &nbsp;<asp:Button ID="btnQuestionAdd" runat="server" OnClick="btnQuestionAdd_Click" Text="Submit Question!" />
            </p>
        </div>
        <div class="col-md-4">
            <h2>Nothing in this column yet...</h2>
            <p>
                Eventually will add something here...</p>
        </div>
    </div>

</asp:Content>
