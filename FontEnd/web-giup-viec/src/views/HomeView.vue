<template>
<body>
   <header-user/>
    <main>

        <!-- slider Area Start-->
        <div class="slider-area ">
            <!-- Mobile Menu -->
            <div class="slider-active">
                    <div class="container">
                        <div class="row">
                            <div class="col-xl-6 col-lg-9 col-md-10">
                                <div class="hero__caption">
                                    <h1>CHÚNG TÔI CHIA SẺ VIỆC NHÀ CÙNG BẠN</h1>
                                </div>
                            </div>
                            <template v-if="fullname != null">
                              <div class="col-xl-6 col-lg-9 col-md-10">
                                <div class="hero__caption tuyen_gv_box">
                                  <h3>Tìm Giúp Việc Của Bạn Ngay</h3>
                                  <router-link to="/job_offer"><button class="btn head-btn1">Tuyển Ngay</button></router-link>
                                </div>
                            </div>
                            </template>
                            <template v-if="fullname == null">
                              <div class="col-xl-6 col-lg-9 col-md-10">
                                <div class="hero__caption tuyen_gv_box">
                                  <h3>Tìm Giúp Việc Của Bạn Ngay</h3>
                                  <router-link to="/login"><button class="btn head-btn1">Tuyển Ngay</button></router-link>
                                </div>
                            </div>
                            </template>
                        </div>
                    </div>
            </div>
        </div>
        <!-- slider Area End-->
        <!-- Our Services Start -->
        <div class="our-services section-pad-t30">
            <div class="container">
                <!-- Section Tittle -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="section-tittle text-center">
                            <span>CÓ THỂ BẠN CẦN</span>
                            <h2>TOP DANH MỤC HÀNG ĐẦU </h2>
                        </div>
                    </div>
                </div>
                <div class="row d-flex justify-contnet-center">
                    <div v-for="item in listDanhMuc" :key="item" class="col-xl-3 col-lg-3 col-md-4 col-sm-6">
                        <div class="single-services text-center mb-30">
                            <div class="services-cap">
                               <h3><a href="job_listing.html">{{item.tenDm}}</a></h3>
                                <span>{{item.mota}}</span>
                            </div>
                        </div>
                    </div>
                    
                    <div class="col-xl-3 col-lg-3 col-md-4 col-sm-6">
                        <div class="single-services text-center mb-30">
                            <div class="services-cap">
                               <h3><a href="job_listing.html">Dịch Vụ Khác</a></h3>
                                <span>Các dịch vụ khác</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Our Services End -->
        <!-- How  Apply Process Start-->
        <div class="apply-process-area apply-bg pt-150 pb-150">
            <div class="container">
                <!-- Section Tittle -->
                <div class="row">
                    <div class="col-lg-12">
                      <div class="section-tittle text-center">
                            <h4 class="text-white">TẠI ĐÂY</h4>
                            <h2 class="text-white">CHÚNG TÔI XIN ĐẢM BẢO </h2>
                        </div>
                    </div>
                </div>
                <!-- Apply Process Caption -->
                <div class="row">
                    <div class="col-lg-4 col-md-6">
                        <div class="single-process text-center mb-30">
                            <div class="process-cap">
                               <h5>1. Uy tín trong công việc</h5>
                               <p>Uy tín trong công việc.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="single-process text-center mb-30">
                            <div class="process-cap">
                               <h5>2. Đảm bảo quyền lợi</h5>
                               <p>Đảm bảo quyền lợi.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6">
                        <div class="single-process text-center mb-30">
                            <div class="process-cap">
                               <h5>3. Chăm sóc khách hàng</h5>
                               <p>Chăm sóc khách hàng.</p>
                            </div>
                        </div>
                    </div>
                </div>
             </div>
        </div>
        <!-- How  Apply Process End-->
<post-index/>
    </main>
<footer-user/>
    </body>
</template>

<script>
import axios from 'axios'
import FooterUser from '../components/FooterUser.vue';
import PostIndex from '../components/PostIndex.vue';
import HeaderUser from '../components/HeaderUser.vue';
export default {
  components: {FooterUser,PostIndex, HeaderUser },
name:"App",
data(){
  return{
    listDanhMuc:[],
    fullname:sessionStorage.getItem('fullname')
  }
},
async mounted(){
let resultDanhMuc = await axios.get("https://localhost:44354/api/DanhMuc");
console.warn("api data", resultDanhMuc.data);
this.listDanhMuc = resultDanhMuc.data;
},
}
</script>

<style>
.logout_btn{
  margin-top: 20px;
  width: 80px;
  height: 80px;
}
.tuyen_gv_box{
  margin-top: 150px;
}
</style>
