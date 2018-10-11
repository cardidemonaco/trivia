<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="trivia.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Trivia</h1>
        <p class="lead">Test your knowledge...</p>
    </div>

    <div class="row">
        <div class="col-md-4">

            <h2>Pick a Quiz</h2>

            <asp:GridView ID="gvQuizCategories" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="CategoryName" HeaderText="Quiz Category" />
                </Columns>
            </asp:GridView>

        </div>
        <div class="col-md-4">



        </div>
    </div>

</asp:Content>
