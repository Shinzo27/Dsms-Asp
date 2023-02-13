<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="Dsms.admin.UpdateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Patel's Dryfruit and Masala</title>

    <!-- font awesome cdn link  -->

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor" crossorigin="anonymous"/>

    <link rel="stylesheet" href="css/addproduct.css" type="text/css" media="all" />



    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"/>

    <link rel="stylesheet" href="https://unpkg.com/swiper@7/swiper-bundle.min.css" />

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/lightgallery-js/1.4.0/css/lightgallery.min.css"/>

    <!-- custom css file link  -->
    <link rel="stylesheet" href="..\css\style.css"/>

    <link rel="shortcut icon" type="x-icon" href="images\icon.ico"/>

    <link href="//fonts.googleapis.com/css2?family=Poppins:wght@300;400;500;600&display=swap" rel="stylesheet"/>

    <!--/Style-CSS -->

    <!--//Style-CSS -->
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <script src="https://kit.fontawesome.com/af562a2a63.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
            <section class="w3l-mockup-form">
        <div class="container">
            <!-- /form -->
            <div class="workinghny-form-grid">
                <div class="main-mockup">
                    <div class="w3l_form align-self">
                        <div class="left_grid_info">
                            <img src="images\undraw_experience_design_re_ca7l.svg" alt=""/>
                        </div>
                    </div>
                    <div class="content-wthree">
                        <h2>Update Product</h2>
                        <p>Fill all the details properly!</p>
                        <br />
                        <asp:TextBox ID="txtPname" runat="server" CssClass="content-wthree" placeholder="Enter Product Name"></asp:TextBox>
                        <br />
                        <asp:DropDownList ID="ddCategory" runat="server" style="width: 90px; height: 30px; text-align: center; background-color: #4169e1; color: white; font-size: 14px; border-radius: 5px 5px 5px 5px;">
                            <asp:ListItem Value="dryfruit">Dryfruit</asp:ListItem>
                            <asp:ListItem Value="driedfruit">Dried Fruit</asp:ListItem>
                            <asp:ListItem Value="masala">Masala</asp:ListItem>
                            <asp:ListItem Value="namkeen">Namkeen</asp:ListItem>
                            <asp:ListItem Value="colddrink">Cold Drink</asp:ListItem>
                        </asp:DropDownList>
                        
                        <asp:Label ID="Label1" runat="server" Text="Select Category" style="color: #666; padding-left: 10px; font-size: 15px;"></asp:Label>
                        
                        <br />
                        <br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <asp:TextBox ID="txtPrice" runat="server" CssClass="name" placeholder="Enter Product Price" TextMode="Number"></asp:TextBox>
                        
                        <br />
                        <asp:Button ID="btnSubmit" runat="server" BackColor="RoyalBlue" CssClass="btn" ForeColor="White" Text="Submit" Width="99px" OnClick="btnSubmit_Click" />
                        
                    </div>
                </div>
            </div>
            <!-- //form -->
        </div>
    </section>
    <!-- //form section start -->

    <script src="js/jquery.min.js"></script>
    <script>
        $(document).ready(function (c) {
            $('.alert-close').on('click', function (c) {
                $('.main-mockup').fadeOut('slow', function (c) {
                    $('.main-mockup').remove();
                });
            });
        });
    </script>
        </div>
        </div>
    </form>
</body>
</html>

