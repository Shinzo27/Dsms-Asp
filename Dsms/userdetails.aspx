<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="userdetails.aspx.cs" Inherits="Dsms.WebForm9" %>
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
                            <img src="images\undraw_experience_design_re_dmqq.svg" alt=""/>
                        </div>
                    </div>
                    <div class="content-wthree">
                        <h2>Enter Details</h2>
                        <p>Please Enter All The Details To Place Order!</p>
                        <br />
                            <asp:TextBox ID="txtEmail" runat="server" class="email" CssClass="inputBox" placeholder="Enter your Email" style="margin-top: 5px;" Width="300px"></asp:TextBox>
                            <asp:TextBox ID="txtContact" runat="server" class="email" CssClass="inputBox" placeholder="Enter your Contact" style="margin-top: 5px;" Width="300px"></asp:TextBox>
                            <asp:TextBox ID="txtAddress" runat="server" class="email" CssClass="inputBox" placeholder="Enter your Address" style="margin-top: 5px;" Width="300px" Height="48px"></asp:TextBox>
                            <asp:Label ID="lbl" runat="server" class="email" CssClass="inputBox" text="Total Amount :" style="margin-top: 5px;" Width="128px" Height="48px" Font-Size="Large"></asp:Label>
                            <asp:Label ID="lblTotal" runat="server" class="email" CssClass="inputBox" Font-Size="Large" ></asp:Label>
                            <br />
                        <asp:Button ID="Button1" runat="server" Text="Save Details" BackColor="#0047AB" CssClass="btn" Font-Size="Large" ForeColor="White" OnClick="Button1_Click" />
                            <br />
                            
                           <button class="btn btn-primary" id="rzp-button1" style="width:276px;">Proceed to checkout</button>
                            <div class="social-icons">
                        </div>
                    </div>
                </div>
            </div>
            <!-- //form -->
        </div>
    </section>
    
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
        <script>

            var amount = "<%=total%>";

            var options = {
                "key": "rzp_test_csE9Ald8i7CXjw",
                "amount": amount,
                "currency": "INR",
                "name": "Patel's Dryfruit And Masala",
                "description": "Proceed to checkout",

                "image": "",
                "handler": function (response) {

                    window.location.href = "payment.aspx";
                },

                "theme": {
                    "color": "#6C63FF"
                }
            };

            var rzp1 = new Razorpay(options);

            rzp1.on('payment.failed', function (response) {
                alert("Payment failed. Please try again later.");
            });

            document.getElementById('rzp-button1').onclick = function (e) {
                rzp1.open();
                e.preventDefault();
            };
        </script>
</asp:Content>
