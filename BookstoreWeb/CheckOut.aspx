<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="BookstoreWeb.CheckOut" Async="true" %>

<asp:Content ID="CheckOutContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h3>Your shopping cart</h3>
    </div>

    <div class="row">

        <div class="col-md-6">
            <h4>These books will be sent as soon as possible</h4>
            <asp:GridView ID="dgvCart" runat="server" AutoGenerateColumns="False" OnRowDataBound="dgvCart_RowDataBound" HeaderStyle-HorizontalAlign="Center"
                EmptyDataText="Your cart is empty" ShowFooter="True">
                <Columns>
                    <asp:TemplateField HeaderText="Title" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "Book.Title")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Author" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "Book.Author")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "Book.Price")%>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotal" runat="server" Text="Label"></asp:Label>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" />
                </Columns>

            </asp:GridView>
        </div>
        <div class="col-md-6">
            <h4 runat="server" id="hrError" style="color: red">These books are not in stock and cannot be sent at this point</h4>

            <asp:GridView ID="dgvNotInStock" runat="server" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center"
                EmptyDataText="Your cart is empty">
                <Columns>
                    <asp:TemplateField HeaderText="Title" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "Book.Title")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Author" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "Book.Author")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "Book.Price")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
<div class="row">
    <h1>Please fill your name and adress </h1>

</div>


</asp:Content>
