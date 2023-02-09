<%@ Page Title="" Language="C#" MasterPageFile="~/Header.Master" AutoEventWireup="true" CodeBehind="product.aspx.cs" Inherits="Dsms.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <section class="menu" id="dryfruit">

      <div class="heading">
         <span>list</span>
         <h3>Our products</h3>
      </div>
      <div class="swiper menu-slider">
         <div class="swiper-wrapper">
            <div class="swiper-slide slide">
               <h3 class="title">Dryfruits</h3>
               <div class="alert alert-warning" style="font-size: 15px;" role="alert">
                  Only 250gms packing available on dryfruits! If want more contact admin!
               </div>
               <br>
               <div class="box-container">
                    <div class="box">
                        <div class="info">
                           <h3>Cashew</h3>
                           <br>
                              <input type="text" size="8" placeholder="quantity" name="quantity" style="height: 45px; font-size: 18px;" required>
                              <select name="weight" style="width: 70px; height: 28px; font-size: 15px;" required>
                                 <option value="250gm">250gms</option>
                              </select><br><br>
                              <input class="btn" type="submit" name="addtocart" value="Add To Cart">
                           <br>
                        </div>
                        <div class="img"><img src="images/cashew.jpg" style="float: right; width: 100px; height: 100px;" >
                        </div>
                        <div class="price">₹750/1kg</div>
                    </div>
               </div>
            </div>
         </div>
      </div>
   </section>

   <section class="menu" id="driedfruit">
      <div class="swiper menu-slider">
         <div class="swiper-wrapper">
            <div class="swiper-slide slide">
               <h3 class="title">Driedfruits</h3>
               <div class="alert alert-warning" style="font-size: 15px;" role="alert">
                  Only 250gms packing available on driedfruits! If want more contact admin!
               </div>
               <br>
               <div class="box-container">
                  <?php
                  include 'partials/datacon.php';
                  $query = "select * from tblProduct where category='driedfruit'";
                  $result = mysqli_query($conn, $query);
                  while ($row = mysqli_fetch_assoc($result)) :
                  ?>
                     <div class="box">
                        <div class="info">
                           <h3><?php echo $row['pname']; ?></h3>
                           <br>
                           
                              <input type="text" size="8" name="quantity" placeholder="quantity" style="height: 45px; font-size: 18px;" required>
                              <select name="weight" style="width: 70px; height: 28px; font-size: 15px;" required>
                                 <option value="250gm">250gms</option>
                              </select><br><br>
                              <input class="btn" type="submit" name="addtocart" value="Add To Cart">

                           <br>
                        </div>
                        <div class="img"><img src="admin/<?php echo $row['pimage'] ?>" style="float: right; width: 100px; height: 100px;">
                        </div>
                        <div class="price">₹<?php echo $row['price'] / 4; ?>/250gm</div>
                     </div>
                  <?php endwhile; ?>
               </div>
            </div>
         </div>
      </div>
   </section>

   <section class="menu" id="namkeen">
      <div class="swiper menu-slider">
         <div class="swiper-wrapper">
            <div class="swiper-slide slide">
               <h3 class="title">Namkeens</h3>
               <div class="box-container">
                  <?php
                  include 'partials/datacon.php';
                  $query = "select * from tblProduct where category='namkeen'";
                  $result = mysqli_query($conn, $query);
                  while ($row = mysqli_fetch_assoc($result)) :
                  ?>
                     <div class="box">
                        <div class="info">
                           <h3><?php echo $row['pname']; ?></h3>
                           <br>
                              <input type="text" size="8" name="quantity" placeholder="quantity" style="height: 45px; font-size: 18px;" required>
                              <select name="weight" style="width: 70px; height: 28px; font-size: 15px;" required>
                                 <option value="pkt">pkt</option>
                              </select><br><br>
                              <input class="btn" type="submit" name="addtocart" value="Add To Cart">
                        </div>
                        <div class="img"><img src="admin/<?php echo $row['pimage'] ?>" style="float: right; width: 100px; height: 100px;">
                        </div>
                        <div class="price">₹<?php echo $row['price']; ?>/pkt</div>
                     </div>
                  <?php endwhile; ?>
               </div>
            </div>
         </div>
      </div>
   </section>

   <section class="menu" id="Masala">
      <div class="swiper menu-slider">
         <div class="swiper-wrapper">
            <div class="swiper-slide slide">
               <h3 class="title">Masala</h3>
               <div class="alert alert-warning" style="font-size: 15px;" role="alert">
                  We have all masala of bharat masala that is known in whole surat!
               </div>
               <br>
               <div class="box-container">
                  <?php
                  include 'partials/datacon.php';
                  $query = "select * from tblProduct where category='masala'";
                  $result = mysqli_query($conn, $query);
                  while ($row = mysqli_fetch_assoc($result)) :
                  ?>
                     <div class="box">
                        <div class="info">
                           <h3><?php echo $row['pname']; ?></h3>
                           <br>
                           
                              <input type="hidden" name="pid" value="<?php echo $row['pid']; ?>">
                              <input type="hidden" name="pname" value="<?php echo $row['pname']; ?>">
                              <input type="hidden" name="price" value="<?php echo $row['price']; ?>">
                              <input type="text" size="8" name="quantity" placeholder="quantity" style="height: 45px; font-size: 18px;" required>
                              <select name="weight" style="width: 70px; height: 28px; font-size: 15px;" required>
                                 <option value="pkt">pkt</option>
                              </select><br><br>
                              <input class="btn" type="submit" name="addtocart" value="Add To Cart">
                           
                        </div>
                        <div class="img"><img src="admin/<?php echo $row['pimage'] ?>" style="float: right; width: 80px; height: 90px;">
                        </div>
                        <div class="price">₹<?php echo $row['price']; ?>/pkt</div>
                     </div>
                  <?php endwhile; ?>

               </div>
            </div>
         </div>
      </div>
   </section>

   <section class="menu" id="colddrink">
      <div class="swiper menu-slider">
         <div class="swiper-wrapper">
            <div class="swiper-slide slide">
               <h3 class="title">Cold Drink</h3>
               <div class="box-container">
                  <?php
                  include 'partials/datacon.php';
                  $query = "select * from tblProduct where category='colddrink'";
                  $result = mysqli_query($conn, $query);
                  while ($row = mysqli_fetch_assoc($result)) :
                  ?>
                     <div class="box">
                        <div class="info">
                           <h3><?php echo $row['pname']; ?></h3>
                           <br>
                              <input type="text" size="8" name="quantity" placeholder="quantity" style="height: 45px; font-size: 18px;" required>
                              <select name="weight" style="width: 70px; height: 28px; font-size: 15px;" required>
                                 <option value="bottle">bottle</option>
                              </select><br><br>
                              <input class="btn" type="submit" name="addtocart" value="Add To Cart">

                        </div>
                        <div class="img"><img src="admin/<?php echo $row['pimage'] ?>" style="float: right; width: 100px; height: 100px;">
                        </div>
                        <div class="price">₹<?php echo $row['price']; ?>/bottle</div>
                     </div>
                  <?php endwhile; ?>

               </div>
            </div>
         </div>
      </div>
   </section>


   <!-- menu section ends -->


   <script src="https://unpkg.com/swiper@7/swiper-bundle.min.js"></script>

   <script src="https://cdnjs.cloudflare.com/ajax/libs/lightgallery-js/1.4.0/js/lightgallery.min.js"></script>

   <!-- custom js file link  -->
   <script src="js/script.js"></script>
   <!-- JavaScript Bundle with Popper -->
   <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-OERcA2EqjJCMA+/3y+gxIOqMEjwtxJY7qPCqsdltbNJuaOe923+mo//f6V8Qbsw3" crossorigin="anonymous"></script>
   <script>
      lightGallery(document.querySelector('.gallery .gallery-container'));
   </script>
</asp:Content>
