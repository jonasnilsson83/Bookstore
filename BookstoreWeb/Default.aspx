<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookstoreWeb._Default" Async="true" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Welcome to my simple bookstore</h2>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="page-header">
                <h1><small>Search for books</small></h1>
            </div>
            <p>Search book by title or author</p>

            <asp:TextBox runat="server" ID="txtSeachBox" />
            <asp:Button Text="Search" ID="btnSearch" runat="server" OnClick="btnSearch_Click" />
            <br />
        </div>
        <div class="col-md-8">
            <div class="row">
                <div class="page-header">
                    <h1><small>Search results:</small></h1>
                </div>
            </div>
            <div class="row">
                <asp:GridView ID="dgvSearchResult" runat="server" AutoGenerateColumns="False" HeaderStyle-HorizontalAlign="Center"
                    EmptyDataText="There are no data records to display." AllowPaging="false" OnRowCommand="dgvSearchResult_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Title" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Author" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Author")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Price")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="In stock" ItemStyle-HorizontalAlign="Right">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "InStock")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add to cart" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:ImageButton Height="16px" ImageUrl="~/Content/Add.png" ID="btnAddToCart" runat="server" CommandName="IncreaseBookInCart" CommandArgument='<%# Eval("InternalId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-md-4">
            <div class="page-header">
                <h1><small>Your shopping cart:</small></h1>
            </div>
        </div>
        <div class="col-md-8">
        </div>
    </div>
    <div class="row">
        <div class="col-md-8">
            <asp:GridView ID="dgvCart" runat="server" AutoGenerateColumns="False" OnRowDataBound="dgvCart_RowDataBound"
                EmptyDataText="Your cart is empty" ShowFooter="True" HeaderStyle-HorizontalAlign="Center" OnRowCommand="dgvCart_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Title" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "Book.Title")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Author" ItemStyle-HorizontalAlign="Left">
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
                    <asp:TemplateField HeaderText="In stock" ItemStyle-HorizontalAlign="Right">
                        <ItemTemplate>
                            <%#DataBinder.Eval(Container.DataItem, "Book.InStock")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Add to cart" ItemStyle-HorizontalAlign="Center" >
                        <ItemTemplate>
                            <asp:ImageButton Height="16px"  ImageUrl="~/Content/up.png" ID="btnIncrease" runat="server" CommandName="IncreaseBookInCart" CommandArgument='<%# Eval("IdForPresentation") %>' />
                            <asp:Label runat="server" ID="lblQuantity" />
                            <asp:ImageButton Height="16px"  ImageUrl="~/Content/down.png" ID="btnDecrease" runat="server" CommandName="DecreaseBookInCart" CommandArgument='<%# Eval("IdForPresentation") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:LinkButton Text="Submit order" runat="server" OnClientClick="if (!confirm('Are you sure?')) return false;" PostBackUrl="~/CheckOut.aspx" />
        </div>
    </div>
</asp:Content>
