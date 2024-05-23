<template>
      <footer>
        <!-- Footer Start-->
        <div class="footer-area footer-bg footer-padding">
            <div class="container">
                <div class="row d-flex justify-content-between">
                    <div class="col-xl-3 col-lg-3 col-md-4 col-sm-6">
                       <div class="single-footer-caption mb-50">
                         <div class="single-footer-caption mb-30">
                             <div class="footer-tittle">
                                 <h4>Về Chúng Tôi</h4>
                                 <div class="footer-pera">
                                     <p v-for="item in listContact" :key="item">
                                      {{item.mota}}</p>
                                </div>
                             </div>
                         </div>

                       </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-4 col-sm-5">
                        <div class="single-footer-caption mb-50">
                            <div class="footer-tittle">
                                <h4>Thông Tin Liên Hệ</h4>
                                <ul v-for="item in listContact" :key="item">
                                    <li>
                                    <p>Địa Chỉ :{{item.adress}}</p>
                                    </li>
                                    <li><a href="#">Phone : {{item.phone}}</a></li>
                                    <li><a href="#">Email : {{item.email}}</a></li>
                                </ul>
                            </div>

                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-4 col-sm-5">
                        <div class="single-footer-caption mb-50">
                            <div class="footer-tittle">
                                <h4>Liên Kết Nhanh</h4>
                                <ul>
                                    <li><a href="#"> Liên Hệ</a></li>
                                    <li><a href="#">Tuyển NV</a></li>
                                    <li><a href="#">Thông Tin</a></li>
                                    <li><a href="#">Chứng Nhận</a></li>
                                    <li><a href="#">Hỗ Trợ</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-3 col-md-4 col-sm-5">
                        <div class="single-footer-caption mb-50">
                            <div class="footer-tittle">
                                <h4>Nhận Thông Tin Nhanh</h4>
                                <div class="footer-pera footer-pera2">
                                 <p>Hãy nhanh tay điền email để nhận các ưu đãi sớm nhất nhé.</p>
                             </div>
                             <!-- Form -->
                             <div class="footer-form" >
                                 <div id="mc_embed_signup">
                                     <form target="_blank" action="https://spondonit.us12.list-manage.com/subscribe/post?u=1462626880ade1ac87bd9c93a&amp;id=92a4423d01"
                                     method="get" class="subscribe_form relative mail_part">
                                         <input type="email" name="email" id="newsletter-form-email" placeholder="Email Address"
                                         class="placeholder hide-on-focus" onfocus="this.placeholder = ''"
                                         onblur="this.placeholder = ' Email Address '">
                                         <div class="form-icon">
                                             <button type="submit" name="submit" id="newsletter-submit"
                                             class="email_icon newsletter-submit button-contactForm"><img src="assets/img/icon/form.png" alt=""></button>
                                         </div>
                                         <div class="mt-10 info"></div>
                                     </form>
                                 </div>
                             </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </footer>
</template>

<script>
import axios from 'axios'
export default {
    data(){
  return{
    listContact:[]
  }
},
async mounted(){
let resultContact = await axios.get("https://localhost:44354/api/Contact");
console.warn("api data", resultContact.data);
this.listContact = resultContact.data;
},
}
</script>

<style>

</style>