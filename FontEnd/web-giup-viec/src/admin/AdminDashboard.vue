<template>
 <body>
    <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full"
        data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">
        <!-- Side bar menu components -->
        <admin-sidebar/>

        <div class="page-wrapper">
        <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Danh Sách Nhân Viên</h4>
                            </div>
                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">STT</th>
                                            <th scope="col">Tên</th>
                                            <th scope="col">Giới Tính</th>
                                            <th scope="col">Email</th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="(item,index) in listStaff" :key="item.staffId">
                                        <tr>
                                            <th>{{index+1}}</th>
                                            <td>{{item.tenNv}}</td>
                                            <td>{{item.gioiTinh}}</td>
                                            <td>{{item.email}}</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
            </div>

            <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Danh Sách Việc</h4>
                            </div>
                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">STT</th>
                                            <th scope="col">Tên Công Việc</th>
                                            <th scope="col">Giá gốc</th>
                                            <th scope="col">Thời gian làm</th>
                                            <th scope="col">Hiển thị</th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="(item,index) in listJob" :key="item.jobId">
                                        <tr>
                                            <th scope="row">{{index +1}}</th>
                                            <td>{{item.tenCv}}</td>
                                            <td>{{item.giaGoc}}</td>
                                            <td>{{item.thoiGianLam}}</td>
                                            <td><v-checkbox v-model="item.trangThai"></v-checkbox></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
        </div>
        
    </div>
    </div>
    </div>
    
</body>
</template>

<script>
import axios from 'axios';
import AdminSidebar from '../components/AdminSidebar.vue';
export default {
name:'App',
components:{
AdminSidebar
  
},
data(){
  return{
    listStaff:[], 
    listJob:[]
  }
},
async mounted(){
let resultStaff = await axios.get("https://localhost:44354/api/Staff");
console.warn("api data", resultStaff.data);
this.listStaff = resultStaff.data;

let resultJob = await axios.get("https://localhost:44354/api/Job");
console.warn("api data", resultJob.data);
this.listJob = resultJob.data;
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

</style>