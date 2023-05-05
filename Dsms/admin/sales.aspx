<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sales.aspx.cs" Inherits="Dsms.admin.sales" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <link rel="stylesheet" href="css/product-bootstrap.css" />
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" />
  <link rel="stylesheet" href="css/dataTables.bootstrap5.min.css"/>
  <link rel="stylesheet" href="css/style.css"/>
  <title>Patel's Dryfruit And Masala</title>

    <style type="text/css">
        .auto-style1 {
            margin-left: 314px;
            margin-top: 26px;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
          <!-- top navigation bar -->
          <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
            <div class="container-fluid">
              <button class="navbar-toggler" type="button" data-bs-toggle="offcanvas" data-bs-target="#sidebar" aria-controls="offcanvasExample">
                <span class="navbar-toggler-icon" data-bs-target="#sidebar"></span>
              </button>
              <a class="navbar-brand me-auto ms-lg-0 ms-3 text-uppercase fw-bold" href="#">Patel's Dryfruit and Masala</a>
              <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#topNavBar" aria-controls="topNavBar" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>

                <asp:Button ID="btnLogout" runat="server" BackColor="#0D6EFD" ForeColor="White" OnClick="btnLogout_Click" Text="Log Out" CssClass="btn" />

            </div>
          </nav>
          <!-- top navigation bar -->
          <!-- offcanvas -->
          <div class="offcanvas offcanvas-start sidebar-nav bg-dark" tabindex="-1" id="sidebar">
            <div class="offcanvas-body p-0">
              <nav class="navbar-dark">
                <ul class="navbar-nav">
                  <li>
                    <!-- <div class="text-muted small fw-bold text-uppercase px-3">
                      <br>
                      CORE
                    </div> -->
                  </li>
                  <li>
                    <br/>
                    <a href="index.aspx" class="nav-link px-3 active">
                      
                      <span>Dashboard</span>
                    </a>
                    <a href="product.aspx" class="nav-link px-3 active">
                      
                      <span>Product</span>
                    </a>
                    <a href="sales.aspx" class="nav-link px-3 active">
                      
                      <span>Sales</span>
                    </a>
                    <a href="admin.aspx" class="nav-link px-3 active">
                      
                      <span>Admin</span>
                    </a>
                    <a href="stock.aspx" class="nav-link px-3 active">
                      
                      <span>Stocks</span>
                    </a>
                      <a href="image.aspx" class="nav-link px-3 active">
                      <span>Images</span>
                    </a>
                  </li>
                  <li class="my-4">
                    <hr class="dropdown-divider bg-light" />
                  </li>
                </ul>
              </nav>
            </div>
          </div>
        <div class="row">
                <div >
                    <br />
                    <br />
                    <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="Sales" Font-Bold="True" Font-Italic="False" Font-Names="Calibri" Font-Size="XX-Large"></asp:Label>&nbsp;
                </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="onum" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Width="1121px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="onum" HeaderText="Order ID" InsertVisible="False" ReadOnly="True" SortExpression="onum" />
                    <asp:BoundField DataField="uname" HeaderText="Name" SortExpression="uname" />
                    <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                    <asp:BoundField DataField="address" HeaderText="Address" SortExpression="address" />
                    <asp:BoundField DataField="contact" HeaderText="Contact" SortExpression="contact" />
                    <asp:BoundField DataField="total" HeaderText="Total" SortExpression="total" />
                    <asp:BoundField DataField="date" HeaderText="Date" SortExpression="date" />
                    <asp:HyperLinkField DataNavigateUrlFields="onum" DataNavigateUrlFormatString="vieworder.aspx?id={0}" HeaderText="View" Text="View" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-B85NU0HM\SQLEXPRESS;Initial Catalog=dbDsms;Integrated Security=True;MultipleActiveResultSets=True" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [tblOrderDetails]"></asp:SqlDataSource>
        </div>
  <script src="./js/bootstrap.bundle.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/chart.js@3.0.2/dist/chart.min.js"></script>
  <script src="./js/jquery-3.5.1.js"></script>
  <script src="./js/jquery.dataTables.min.js"></script>
  <script src="./js/dataTables.bootstrap5.min.js"></script>
  <script src="./js/script.js"></script>

          

</form>
</body>

</html>
