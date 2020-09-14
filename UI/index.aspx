<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="POO3B135_34.UI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" 
        integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link type="text/css" rel="stylesheet" href="UI/css/StyleSheet1.css" runat="server" />
    <title>Livraria</title>
</head>

   
<body>
    <!-- DUPLA: Pedro Henrique Oliveira Siqueira: 34 - Pedro Henrique Rodrigues: 35 -->
    <center>
        <form id="form1" runat="server">
            <asp:Label ID="messager" runat="server" style="font-family: 'Cambria Math'; font-size: 20px;"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label" style="font-family: 'Cambria Math'; font-size: 20px;">Livraria</asp:Label>

            <div class="form-label-textbox">
                <div class="form-field">
                    <asp:Label ID="Label3" runat="server" Text="Label" style="font-family: 'Cambria Math'; font-size: 20px;" >Nome do livro</asp:Label>
                    <br />
                    <asp:TextBox ID="bookName" runat="server" BorderStyle="Double" style="font-family:Arial; text-align:center;"></asp:TextBox>
                </div>

                <div class="form-field">
                    <asp:Label ID="Label1" runat="server" Text="Label" style="font-family: 'Cambria Math'; font-size: 20px;">Autor</asp:Label>
                      <br />
                    <asp:TextBox ID="authorName" runat="server" BorderStyle="Double" style="font-family:Arial; text-align:center;"></asp:TextBox>
                </div>

                <div class="form-field">
                    <asp:Label ID="Label4" runat="server" Text="Label" style="font-family: 'Cambria Math'; font-size: 20px;">Editora</asp:Label>
                      <br />
                    <asp:TextBox ID="publishCompanyName" runat="server" BorderStyle="Double" style="font-family:Arial; text-align:center;"></asp:TextBox>
                </div>

                <div class="form-field">
                    <asp:Label ID="Label5" runat="server" Text="Label" style="font-family: 'Cambria Math'; font-size: 20px;">Número de páginas</asp:Label>
                      <br />
                    <asp:TextBox ID="bookQPages" runat="server" BorderStyle="Double" style="font-family:Arial; text-align:center;"></asp:TextBox>
                </div>

                <div class="form-field">
                    <asp:Label ID="Label6" runat="server" Text="Label" style="font-family: 'Cambria Math'; font-size: 20px;">Valor</asp:Label>
                      <br />
                    <asp:TextBox ID="bookValue" runat="server" BorderStyle="Double" style="font-family:Arial; text-align:center;"></asp:TextBox>
                </div>
            </div>

          <br />
            <div class="form-buttons">
                <asp:Button class="btn btn-success" ID="addBook" runat="server" Text="Adicionar livro" OnClick="addBook_Click"/>
                <asp:Button class="btn btn-success" ID="searchByAuthor" runat="server" Text="Pesquisar autor" OnClick="searchByAuthor_Click" />
                <asp:Button class="btn btn-success" ID="searchByPublishCompany" runat="server" Text="Pesquisar editora" OnClick="searchByPublishCompany_Click" />
                <asp:Button class="btn btn-success" ID="searchByBook" runat="server" Text="Pesquisar livro" OnClick="searchByBook_Click" />
            </div>
          <br />
                <asp:GridView ID="booksTable" Width="1000" runat="server" EnableViewState="false" OnRowDeleting="booksTable_RowDeleting" OnRowCancelingEdit="booksTable_RowCancelingEdit" OnRowEditing="booksTable_RowEditing" OnRowUpdating="booksTable_RowUpdating">
                    <Columns>
                        <asp:CommandField HeaderText="Deletar" HeaderStyle-Width="100" ShowDeleteButton="true"/>
                        <asp:CommandField HeaderText="Editar"  HeaderStyle-Width="100" ShowEditButton="true" />
                    </Columns>
                </asp:GridView>
            <br />
           </form>
     </center>
</body>
</html>
