<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Dsms.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/loginstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <section class="w3l-mockup-form">
        <div class="container">
            <!-- /form -->
            <div class="workinghny-form-grid">
                <div class="main-mockup">
                    <div class="w3l_form align-self">
                        <div class="left_grid_info">
                            <img src="images\undraw_reminder_re_fe15.svg" alt="">
                        </div>
                    </div>
                    <div class="content-wthree">
                        <h2>User Profile</h2>
                        <br />
                        <br />
                        <label style="font-size: large;">Username :</label>
                        <asp:TextBox ID="txtuname" runat="server" CssClass="email" ReadOnly="True"></asp:TextBox>
                        <label style="font-size: large;">Email : </label>
                        <asp:TextBox ID="txtemail" runat="server" CssClass="email" ReadOnly="True"></asp:TextBox>
                        <label style="font-size: large;">Account created on: </label>
                        <asp:TextBox ID="txtdate" runat="server" CssClass="email" ReadOnly="True"></asp:TextBox>
                        <label style="font-size: large;">Change Password: </label>
                        <asp:TextBox ID="txtOldpass" runat="server" CssClass="email" placeholder="Enter Old Password" TextMode="Password"></asp:TextBox>
                        <asp:TextBox ID="txtNewpass" runat="server" CssClass="email" placeholder="Enter New Password" TextMode="Password"></asp:TextBox>
                        <asp:Button ID="Button1" runat="server" Text="Change Password" BackColor="#0043A2" Font-Bold="True" Font-Size="Large" ForeColor="White" OnClick="Button1_Click" />
                    </div>
                </div>
            </div>
            <!-- //form -->
        </div>


       <%-- <div class="container px-3 my-5 clearfix">
            <!-- Shopping cart table -->
            <div class="card">
                <div class="card-header">
                    <h2>Order History</h2>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table table-bordered m-0" style="font-size: large;">
                            <thead>
                                <tr>
                                    <!-- Set columns width -->
                                    <th class="text-center py-4 px-4" style="width: 100px;">Order id</th>
                                    <th class="text-center py-4 px-4" style="width: 100px;">Name</th>
                                    <th class="text-right py-3 px-4" style="width: 100px;">Price</th>
                                    <th class="text-center py-3 px-4" style="width: 120px;">Placed_On</th>
                                    <th class="text-right py-3 px-4" style="width: 100px;">Delivery Status</th>
                                </tr>
                            </thead>
                            <tbody>
                                        <tr>
                                            <td class="p-4">
                                                <div class="media align-items-center">
                                                    <div class="media-body">
                                                        <a href="" class="d-block text-dark"><Order ID</a>
                                                    </div>
                                                </div>
                                            </td>
                                            <td class="text-right font-weight-semibold align-middle p-4">Name</td>
                                            <td class="align-middle p-2"><input type="text" class="form-control text-center" value="₹Price" readonly></td>
                                            <td class="text-right font-weight-semibold align-middle p-4"> Date</td>
                                            <td class="text-right font-weight-semibold align-middle p-4"> Delivery Status</td>
                                        </tr>
                            </tbody>
                        </table>
                    </div>
                    <!-- / Shopping cart table -->

                </div>
            </div>
        </div>--%>
    
        <center>

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="onum" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="252px" Width="916px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="onum" HeaderText="Order Id" InsertVisible="False" ReadOnly="True" SortExpression="onum" />
                    <asp:BoundField DataField="uname" HeaderText="Name" SortExpression="uname" />
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                    <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                    <asp:BoundField DataField="contact" HeaderText="Contact" SortExpression="contact" />
                    <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
                    <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" BorderStyle="Dotted" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Size="Large" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" Font-Size="Medium" BorderColor="#4F7BCF" BorderStyle="Dotted" HorizontalAlign="Center" VerticalAlign="Middle" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbDsmsConnectionString %>" SelectCommand="SELECT * FROM [tblOrderDetails] WHERE ([uname] = @uname)">
                <SelectParameters>
                    <asp:SessionParameter Name="uname" SessionField="username" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <br />
            <br />

        </center>
   
    </section>
    <script src="js/jquery.min.js"></script>
    <script>
        $(document).ready(function(c) {
            $('.alert-close').on('click', function(c) {
                $('.main-mockup').fadeOut('slow', function(c) {
                    $('.main-mockup').remove();
                });
            });
        });
    </script>

</asp:Content>
