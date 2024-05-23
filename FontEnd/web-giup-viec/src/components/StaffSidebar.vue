<template>
  <aside class="left-sidebar" data-sidebarbg="skin6">
               <!-- Sidebar scroll-->
               <div class="scroll-sidebar">
                   <!-- Sidebar navigation-->
                   <nav class="sidebar-nav">
                       <ul id="sidebarnav">
                           <!-- User Profile-->
                           <li>
                               <!-- User Profile-->
                               <div class="user-profile d-flex no-block dropdown m-t-20">
                                   <div class="user-pic"><img :src="anhUser" alt="users"
                                           class="rounded-circle" width="40" /></div>
                                   <div class="user-content hide-menu m-l-10">
                                    <router-link to="/profile_user"><a class="" id="Userdd" role="button"
                                           data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                           <h5 class="m-b-0 user-name font-medium">{{fullname}}</h5>
                                           <span class="op-5 user-email">{{email}}</span>
                                       </a></router-link>
                                   </div>
                               </div>
                               <!-- End User Profile-->
                           </li>
                       
                           <!-- Staff Profile-->
                           <router-link to="/staff_home"><li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link"
                                    aria-expanded="false"><i class="mdi mdi-briefcase"></i><span
                                       class="hide-menu">Công Việc</span></a></li></router-link>
                            <router-link to="/staff_thu_nhap"><li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link"
                                    aria-expanded="false"><i class="mdi mdi-bulletin-board"></i><span
                                       class="hide-menu">Thu Nhập</span></a></li></router-link>
                            <router-link to="/staff_profile"><li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link"
                                    aria-expanded="false"><i class="mdi mdi-account"></i><span
                                       class="hide-menu">Thông Tin Cá Nhân</span></a></li></router-link>
                            <li class="sidebar-item"><router-link to="/login"><a v-on:click="logout" class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i class="mdi mdi-logout"></i><span
                                    class="hide-menu">Đăng Xuất</span></a></router-link></li>
                       </ul>
   
                   </nav>
                   <!-- End Sidebar navigation -->
               </div>
               <!-- End Sidebar scroll-->
           </aside>
</template>

<script>
export default {
data(){
    return{
    fullname:sessionStorage.getItem('fullname'),
    email:sessionStorage.getItem('email'),
    anhUser:sessionStorage.getItem('anhUser')
    }
}
}
</script>

<style>

</style>