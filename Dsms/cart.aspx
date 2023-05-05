﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="Dsms.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <center>
    <div style="padding-top:100px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="cid" ForeColor="#333333" GridLines="None" Height="342px" Width="913px"  ShowFooter="True" DataSourceID="SqlDataSource1" EmptyDataText="Your Cart Is Empty" ShowHeaderWhenEmpty="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="pname" HeaderText="Product" SortExpression="pname" />
                <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" />
                <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" />
                <asp:BoundField DataField="ptype" HeaderText="Packing" SortExpression="ptype" />
                <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
                <asp:CommandField ButtonType="Button" ShowDeleteButton="True" HeaderText="Action">
                <ControlStyle BackColor="#CC0000" Font-Size="Large" ForeColor="White" CssClass="btn" />
                </asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <EmptyDataRowStyle Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />

        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-B85NU0HM\SQLEXPRESS;Initial Catalog=dbDsms;Integrated Security=True;MultipleActiveResultSets=True" DeleteCommand="DELETE FROM [tblCart] WHERE [cid] = @cid" InsertCommand="INSERT INTO [tblCart] ([uid], [pname], [price], [quantity], [total], [ptype]) VALUES (@uid, @pname, @price, @quantity, @total, @ptype)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [uid], [pname], [price], [quantity], [total], [ptype], [cid] FROM [tblCart] WHERE ([uid] = @uid)" UpdateCommand="UPDATE [tblCart] SET [uid] = @uid, [pname] = @pname, [price] = @price, [quantity] = @quantity, [total] = @total, [ptype] = @ptype WHERE [cid] = @cid">
            <DeleteParameters>
                <asp:Parameter Name="cid" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="uid" Type="Int32" />
                <asp:Parameter Name="pname" Type="String" />
                <asp:Parameter Name="price" Type="Double" />
                <asp:Parameter Name="quantity" Type="Int32" />
                <asp:Parameter Name="total" Type="Double" />
                <asp:Parameter Name="ptype" Type="String" />
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
                <asp:Parameter Name="ptype" Type="String" />
                <asp:Parameter Name="cid" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </div>
    </center>
    <div>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" BackColor="#CC0000" CssClass="btn" Font-Size="Large" ForeColor="White" OnClick="Button2_Click" Text="Back to Shopping" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" BackColor="#4F7BCF" CssClass="btn" Font-Size="Large" ForeColor="White" OnClick="Button1_Click" Text="Checkout" />
    </div>
</asp:Content>
