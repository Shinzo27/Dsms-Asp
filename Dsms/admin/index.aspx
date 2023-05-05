<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Dsms.admin.index" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>
<html lang="en" xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
  <meta charset="UTF-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=edge" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <link rel="stylesheet" href="css/bootstrap.min.css" />
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.4.1/font/bootstrap-icons.css" />
  <link rel="stylesheet" href="css/dataTables.bootstrap5.min.css"/>
  <link rel="stylesheet" href="css/style.css"/>
  <title>Patel's Dryfruit And Masala</title>

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
  <!-- offcanvas -->
  <main class="mt-5 pt-3">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-12">
          <h4>Dashboard</h4>
        </div>
      </div>
      <div class="row">
        <div class="col-md-3 mb-3">
          <div class="card bg-primary text-white h-100">
            <div class="card-body py-5" style="font-size: 20px;">
              <center>
                  <asp:Label ID="lblSale" runat="server" Text="Label"></asp:Label>
                </center>
            </div>
            <div class="card-footer d-flex">
              Total Sale
              <span class="ms-auto">
                <i class="bi bi-chevron-right"></i>
              </span>
            </div>
          </div>
        </div>
        <div class="col-md-3 mb-3">
          <div class="card bg-warning text-dark h-100">
            <div class="card-body py-5" style="font-size: 20px;">
              <center>
                  <asp:Label ID="lblProduct" runat="server" Text="Label"></asp:Label>
                </center>
            </div>
            <div class="card-footer d-flex">
              Total Products
              <span class="ms-auto">
                <i class="bi bi-chevron-right"></i>
              </span>
            </div>
          </div>
        </div>
        <div class="col-md-3 mb-3">
          <div class="card bg-success text-white h-100">
            <div class="card-body py-5" style="font-size: 20px;">
              <center>
                  <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
                </center>
            </div>
            <div class="card-footer d-flex">
              Total Users
              <span class="ms-auto">
                <i class="bi bi-chevron-right"></i>
              </span>
            </div>
          </div>
        </div>
        <div class="col-md-3 mb-3">
          <div class="card bg-danger text-white h-100">
            <div class="card-body py-5" style="font-size: 20px;">
              <center>
                  <asp:Label ID="lblLq" runat="server" Text="Label"></asp:Label>
                </center>
            </div>
            <div class="card-footer d-flex">
              Low Quantity Products
              <span class="ms-auto">
                <i class="bi bi-chevron-right"></i>
              </span>
            </div>
          </div>
        </div>
      </div>
      <!-- <div class="row">
        <div class="col-md-6 mb-3">
          <div class="card h-100">
            <div class="card-header">
              <span class="me-2"><i class="bi bi-bar-chart-fill"></i></span>
              Area Chart Example
            </div>
            <div class="card-body">
              <canvas class="chart" width="400" height="200"></canvas>
            </div>
          </div>
        </div>
        <div class="col-md-6 mb-3">
          <div class="card h-100">
            <div class="card-header">
              <span class="me-2"><i class="bi bi-bar-chart-fill"></i></span>
              Area Chart Example
            </div>
            <div class="card-body">
              <canvas class="chart" width="400" height="200"></canvas>
            </div>
          </div>
        </div>
      </div> -->
        <div class="row">
                <div class="col-md-12">
                    <h4>Products</h4>
                    <h4>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="pid" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None" Height="289px" Width="1244px">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="pid" HeaderText="pid" InsertVisible="False" ReadOnly="True" SortExpression="pid" />
                                <asp:BoundField DataField="pname" HeaderText="pname" SortExpression="pname" />
                                <asp:BoundField DataField="category" HeaderText="category" SortExpression="category" />
                                <asp:BoundField DataField="image" HeaderText="image" SortExpression="image" />
                                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                                <asp:BoundField DataField="date" HeaderText="date" SortExpression="date" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" Font-Size="Medium" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" Font-Size="Medium" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" Font-Size="Medium" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbDsmsConnectionString %>" SelectCommand="SELECT * FROM [tblProduct]"></asp:SqlDataSource>
                    </h4>
                    <br />
                </div>
                
            </div>
    </div>

  </main>
  <script src="./js/bootstrap.bundle.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/chart.js@3.0.2/dist/chart.min.js"></script>
  <script src="./js/jquery-3.5.1.js"></script>
  <script src="./js/jquery.dataTables.min.js"></script>
  <script src="./js/dataTables.bootstrap5.min.js"></script>
  <script src="./js/script.js"></script>

</form>
</body>

</html>
