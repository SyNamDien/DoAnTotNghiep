<template>
  <header>
        <!-- Header Start -->
       <div class="header-area header-transparrent">
           <div class="headder-top header-sticky">
                <div class="container">
                    <div class="row align-items-center">
                        <div class="col-lg-3 col-md-2">
                            <!-- Logo -->
                            <div class="logo">
                                <a href="index.html"><img class="logo_header" src="assets/img/logo/logo.png" alt=""></a>
                            </div> 
                        </div>
                        <div class="col-lg-9 col-md-9">
                            <div class="menu-wrapper">
                                <!-- Main-menu -->
                                <div class="main-menu">
                                    <nav class="d-none d-lg-block">
                                        <ul id="navigation">
                                            <li><a href="index.html">Trang Chủ</a></li>
                                            <li><router-link to="/list_job_offer"><a href="">Đơn Tuyển Nhân Viên</a></router-link></li>
                                            <li><router-link to="/list_post"><a>Tin Tức</a></router-link></li>
                                            <!-- <li><a href="#">Hỗ Trợ</a>
                                                <ul class="submenu">
                                                    <li><a href="blog.html">Dịch Vụ</a></li>
                                                    <li><a href="single-blog.html">Thông Tin</a></li>
                                                    <li><a href="elements.html">Báo Lỗi</a></li>
                                                </ul>
                                            </li> -->
                                            <li><router-link to="/contact"><a>Liên Hệ</a></router-link> </li>
                                        </ul>
                                    </nav>
                                </div>          
                                <!-- Header-btn -->
                                <div class="header-btn d-none f-right d-lg-block">
<template v-if="fullname != null">
  <router-link to="/profile_user"><button class="btn head-btn1">{{fullname}}</button></router-link>
  <router-link to="/login"><button class="logout_btn" v-on:click="logout"><box-icon name='log-out' rotate='180' ></box-icon></button></router-link>
</template>
<template v-if="fullname == null">
  <router-link to="/register"><button class="btn head-btn1">Register</button></router-link>
  <router-link to="/login"><button class="btn head-btn1">Login</button></router-link>
</template>
                                    
                                </div>
                            </div>
                        </div>
                        <!-- Mobile Menu -->
                        <div class="col-12">
                            <div class="mobile_menu d-block d-lg-none"></div>
                        </div>
                    </div>
                </div>
           </div>
       </div>
        <!-- Header End -->
    </header>
</template>

<script>
export default {
    data(){
  return{
    fullname:sessionStorage.getItem('fullname')
  }
},
methods:{
    logout(){
    this.$router.push('/');
    sessionStorage.clear();
  }
}
}
</script>

<style>
.logout_btn{
  margin-top: 20px;
  width: 80px;
  height: 80px;
}
.logo_header{
    width: 50%;
}
</style>