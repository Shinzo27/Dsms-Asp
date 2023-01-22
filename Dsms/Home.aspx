<%@ Page Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Dsms.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

    <section class="home" id="home">

      <div class="swiper home-slider">

         <div class="swiper-wrapper">

            <div class="swiper-slide slide" style="background: url(images/home-slide-1.jpg) no-repeat;">
               <div class="content">
                  <span>Healthy Dryfruit</span>
                  <h3>Wealthy Life</h3>
                  <a href="Product.aspx" class="btn">get started</a>
               </div>
            </div>

            <div class="swiper-slide slide" style="background: url(images/home-slide-2.jpg) no-repeat;">
               <div class="content">
                  <span>Need Spices?</span>
                  <h3>We have it too!</h3>
                  <a href="Product.aspx" class="btn">get started</a>
               </div>
            </div>

            <div class="swiper-slide slide" style="background: url(images/home-slide-3.jpg) no-repeat;">
               <div class="content">
                  <span>Morning Breakfast?</span>
                  <h3>Have A Namkeen!</h3>
                  <a href="Product.aspx" class="btn">get started</a>
               </div>
            </div>

         </div>

         <div class="swiper-button-next"></div>
         <div class="swiper-button-prev"></div>

      </div>

   </section>

   <!-- home section ends -->

   <!-- about section starts  -->

   <section class="about" id="about">

      <div class="image">
         <img src="images/about-img.png" alt="">
      </div>

      <div class="content">
         <h3 class="title">welcome to our store</h3>
         <p>We are famous seller in adajan area! Specially known for our quality dryfruit, And we are selling Bharat
            Masala which is famous all around surat and All types of Namkeens and Chocolates.We have Imported Chocolates
            and Gift Hampers too!</p>
         <div class="icons-container">
            <div class="icons">
               <img src="images/about-icon-1.png" alt="">
               <h3>quality Dryfruit</h3>
            </div>
            <div class="icons">
               <img src="images/about-icon-2.png" alt="">
               <h3>Spices</h3>
            </div>
            <div class="icons">
               <img src="images/about-icon-3.png" alt="">
               <h3>Namkeens</h3>
            </div>
         </div>
      </div>

   </section>

   <!-- about section ends -->

   <!-- food section starts  -->

   <section class="food" id="food">

      <div class="heading">
         <span>popular dryfruits</span>
         <h3>our expertise!</h3>
      </div>

      <div class="swiper food-slider">

         <div class="swiper-wrapper">

            <div class="swiper-slide slide" data-name="food-1">
               <img src="images/food-img-1.png" alt="">
               <h3>Cashew</h3>
               <div class="price">₹650/kg</div>
            </div>

            <div class="swiper-slide slide" data-name="food-2">
               <img src="images/food-img-2.png" alt="">
               <h3>Walnuts</h3>
               <div class="price">₹670/kg</div>
            </div>

            <div class="swiper-slide slide" data-name="food-3">
               <img src="images/food-img-3.png" alt="">
               <h3>Almonds</h3>
               <div class="price">₹750/kg</div>
            </div>

         </div>

         <div class="swiper-pagination"></div>

      </div>

   </section>

   <!-- food section ends -->

   <!-- food preview section starts  -->

   <section class="food-preview-container">

      <div id="close-preview" class="fas fa-times"></div>

      <div class="food-preview" data-target="food-1">
         <img src="images/food-img-1.png" alt="">
         <h3>Cashew</h3>
         <div class="stars">
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
         </div>
         <p>Rich in protein, healthy fats, and antioxidants such as polyphenols, cashews offer a variety of noteworthy
            health benefits.</p>
         <div class="price">₹650/kg</div>
         <a href="Product.aspx" class="btn">buy now</a>
      </div>

      <div class="food-preview" data-target="food-2">
         <img src="images/food-img-2.png" alt="">
         <h3>Walnuts</h3>
         <div class="stars">
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
         </div>
         <p>Walnuts are round, single-seeded stone fruits that grow from the walnut tree. They are a good source of
            healthful fats, protein, and fiber.</p>
         <div class="price">₹670/kg</div>
         <a href="Product.aspx" class="btn">buy now</a>
      </div>

      <div class="food-preview" data-target="food-3">
         <img src="images/food-img-3.png" alt="">
         <h3>Almonds</h3>
         <div class="stars">
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
            <i class="fas fa-star"></i>
         </div>
         <p>Almonds are rich in valuable nutrients for your body, like magnesium, vitamin E, and dietary fiber</p>
         <div class="price">750/kg</div>
         <a href="Product.aspx" class="btn">buy now</a>
      </div>

   </section>

   <!-- food preview section ends -->


   <!-- blogs section starts  -->

   <section class="blogs" id="blogs">

      <div class="heading">
         <span>Review Point</span>
         <h3>Our Latest reviews!</h3>
      </div>

      <div class="swiper blogs-slider">

         <div class="swiper-wrapper">

            <div class="swiper-slide slide">
               <div class="image">
                  <img src="images/blog-img-1.jpg" alt="">
                  <span>bharat masala</span>
               </div>
               <div class="content">
                  <div class="icon">
                     <a href="#"> <i class="fas fa-calendar"></i> 15th april, 2022 </a>
                     <a href="#"> <i class="fas fa-user"></i> by Drashti Patel </a>
                  </div>
                  <a href="#" class="title">"Bharat Masala in adajan!"</a>
                  <p>It's good to have bharat masala nearby as we don't have to travel more!</p>
               </div>
            </div>

            <div class="swiper-slide slide">
               <div class="image">
                  <img src="images/blog-img-2.jpg" alt="">
                  <span>gift hampers</span>
               </div>
               <div class="content">
                  <div class="icon">
                     <a href="#"> <i class="fas fa-calendar"></i> 21st may, 2022 </a>
                     <a href="#"> <i class="fas fa-user"></i> by jay dave</a>
                  </div>
                  <a href="#" class="title">Best Gift Hampers i'd seen</a>
                  <p>I want gift hamper for rakshabandhan and i'd found the best hamper!</p>
               </div>
            </div>

            <div class="swiper-slide slide">
               <div class="image">
                  <img src="images/blog-img-3.jpeg" alt="">
                  <span>services</span>
               </div>
               <div class="content">
                  <div class="icon">
                     <a href="#"> <i class="fas fa-calendar"></i> 21st may, 2022 </a>
                     <a href="#"> <i class="fas fa-user"></i> by ayush rokad</a>
                  </div>
                  <a href="#" class="title">Very Good Services!</a>
                  <p>They were out of stock but they just arranged it by that day evening.</p>
               </div>
            </div>

            <div class="swiper-slide slide">
               <div class="image">
                  <img src="images/blog-img-6.jpg" alt="">
                  <span>quality</span>
               </div>
               <div class="content">
                  <div class="icon">
                     <a href="#"> <i class="fas fa-calendar"></i> 10th march, 2022 </a>
                     <a href="#"> <i class="fas fa-user"></i> by Ved Master</a>
                  </div>
                  <a href="#" class="title">"Best quality of dryfruit!"</a>
                  <p>I founded best quality of all dryfruits at cheap prices!</p>
               </div>
            </div>

         </div>
         <a href="feedback.aspx" class="btn">Add Feedback</a>
         <div class="swiper-pagination"></div>

      </div>

   </section>

   <!-- blogs section ends -->
</asp:Content>
