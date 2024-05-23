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
                                    <a href="#" class="" id="Userdd" role="button"
                                        data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <h5 class="m-b-0 user-name font-medium">{{fullname}}</h5>
                                        <span class="op-5 user-email">{{email}}</span>
                                    </a>
                                </div>
                            </div>
                            <!-- End User Profile-->
                        </li>
                    
                        <!-- User Profile-->
                        <li class="sidebar-item"> <router-link to="/admin_dashboard"><a class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i class="mdi mdi-view-dashboard"></i><span
                                    class="hide-menu">Dashboard</span></a></router-link></li>
                        <li class="sidebar-item"> <router-link to="/admin_joboffer"><a class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i
                                    class="mdi mdi-book-open"></i><span class="hide-menu">Đơn Tuyển NV</span></a></router-link></li>
                        <li class="sidebar-item"> <router-link to="/admin_nhanvien"><a class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i class="mdi mdi-account-plus"></i><span
                                    class="hide-menu">Nhân Viên</span></a></router-link></li>
                        <router-link to="/admin_job"><li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i class="mdi mdi-briefcase"></i><span
                                    class="hide-menu">Việc Làm</span></a></li></router-link>
                        <router-link to="/admin_danh_muc"><li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i class="mdi mdi-clipboard-outline"></i><span
                                    class="hide-menu">Danh Mục</span></a></li></router-link>
                        <router-link to="/admin_role"><li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i class="mdi mdi-grease-pencil"></i><span
                                    class="hide-menu">Quyền Truy Cập</span></a></li></router-link>
                        <li class="sidebar-item"> <router-link to="/admin_post"><a class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i class="mdi mdi-newspaper"></i><span
                                    class="hide-menu">Tin Tức</span></a></router-link></li>
                        <router-link to="/admin_list_payment"><li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link"
                                 aria-expanded="false"><i class="mdi mdi-bulletin-board"></i><span
                                    class="hide-menu">Danh Sách Thanh Toán</span></a></li></router-link>
                        <router-link to="/admin_profile"><li class="sidebar-item"> <a class="sidebar-link waves-effect waves-dark sidebar-link"
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
},
methods: {
    logout(){
    this.$router.push('/');
    sessionStorage.clear();
  }
},
}
</script>

<style>

</style>