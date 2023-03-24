<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Dsms.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <center>
    <div style="padding-top:100px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="2" DataKeyNames="cid" DataMember="DefaultView" DataSourceID="SqlDataSource1" EmptyDataText="No Item In the Cart" Font-Bold="False" Font-Size="Large" ForeColor="#333333" GridLines="None" Height="100px" RowHeaderColumn="cid" Width="1000px" ShowHeaderWhenEmpty="True" ShowFooter="True">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. No">
                            <ItemTemplate> 
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="pname" HeaderText="pname" SortExpression="pname" />
                        <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                        <asp:BoundField DataField="quantity" HeaderText="quantity" SortExpression="quantity" />
                        <asp:BoundField DataField="total" HeaderText="total" SortExpression="total" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Height="50px" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" BorderColor="#507CD1" BorderStyle="Dotted" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbDsmsConnectionString %>" SelectCommand="SELECT * FROM [tblCart] WHERE ([uid] = @uid)" DeleteCommand="DELETE FROM [tblCart] WHERE [cid] = @cid" InsertCommand="INSERT INTO [tblCart] ([uid], [pname], [price], [quantity], [total], [date]) VALUES (@uid, @pname, @price, @quantity, @total, @date)" UpdateCommand="UPDATE [tblCart] SET [uid] = @uid, [pname] = @pname, [price] = @price, [quantity] = @quantity, [total] = @total, [date] = @date WHERE [cid] = @cid">
            <DeleteParameters>
                <asp:Parameter Name="cid" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="uid" Type="Int32" />
                <asp:Parameter Name="pname" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="quantity" Type="Int32" />
                <asp:Parameter Name="total" Type="Double" />
                <asp:Parameter Name="date" Type="DateTime" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="uid" SessionField="uid" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="uid" Type="Int32" />
                <asp:Parameter Name="pname" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="quantity" Type="Int32" />
                <asp:Parameter Name="total" Type="Double" />
                <asp:Parameter Name="date" Type="DateTime" />
                <asp:Parameter Name="cid" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </center>
</asp:Content>
