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
                                <h4 class="card-title">Danh Sách Tài Khoản</h4>
                            </div>
                            <div class="table-responsive">
                                <v-alert v-if="showAlert==true" type="success">Đổi quyền thành công.</v-alert>
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">STT</th>
                                            <th scope="col">Tên</th>
                                            <th scope="col">Giới Tính</th>
                                            <th scope="col">Email</th>
                                            <th scope="col">Phone</th>
                                            <th scope="col">Quyền</th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="(item,index) in listAccount" :key="item.customerId">
                                        <tr>
                                            <th>{{index+1}}</th>
                                            <td>{{item.tenKh}}</td>
                                            <td>{{item.gioiTinh}}</td>
                                            <td>{{item.email}}</td>
                                            <td>{{item.phone}}</td>
                                            <td><div v-if="item.roleId == 1"><v-switch
                                                v-on:click="offRoleAdmin(item.customerId)"
                                                :model-value="true"
                                                hide-details
                                                color="success"
                                                label="Admin"
                                            ></v-switch></div> 
                                            <span v-if="item.roleId==2"><v-switch
                                                v-on:click="onRoleAdmin(item.customerId)"
                                                :model-value="false"
                                                hide-details
                                                color="success"
                                                label="Nhân viên"
                                            ></v-switch></span>
                                            <span v-if="item.roleId==3"><v-switch
                                                v-on:click="onRoleAdmin(item.customerId)"
                                                :model-value="false"
                                                hide-details
                                                color="success"
                                                label="Người dùng"
                                            ></v-switch></span>
                                        </td>
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
import AdminSidebar from '@/components/AdminSidebar.vue';
export default {
name:"App",
components:{
    AdminSidebar
},
data(){
    return{
        listAccount:[],
        list:[],
        idStaff:"",
        showAlert:false
    }
},
async mounted(){
let resultCustomer = await axios.get("https://localhost:44354/api/Customers");
console.warn("api data", resultCustomer.data);
this.listAccount = resultCustomer.data;
},
methods:{
//Bật quyền admin cho account
async onRoleAdmin(id){
console.log("Id khách hàng là: ",id);
let resultKH = await axios.get(`https://localhost:44354/api/Customers/${id}`);
let onAdmin = await axios.put(`https://localhost:44354/api/Customers/${id}`,{
    customerId: resultKH.data.customerId,
    tenKh: resultKH.data.tenKh,
    ngaysinh: resultKH.data.ngaysinh,
    gioiTinh: resultKH.data.gioiTinh,
    avatar: resultKH.data.avatar,
    diachi: resultKH.data.diachi,
    phone: resultKH.data.phone,
    email: resultKH.data.email,
    password: resultKH.data.password,
    memberShip: resultKH.data.memberShip,
    roleId: 1
          });
if(onAdmin.status==204){
    this.showAlert = true;
    setTimeout(()=>{
      this.showAlert=false
      location.reload();
    },2000)
      } else alert("Lỗi! Đổi mật khẩu không thành công!");
},

//Tắt quyền admin
async offRoleAdmin(id){
console.log(id);
let resultKH = await axios.get(`https://localhost:44354/api/Customers/${id}`);
let resultStaff = await axios.get("https://localhost:44354/api/Staff");
  this.list = resultStaff.data;
  for(var i = 0; i < this.list.length; i++){
              if(resultKH.data.email==this.list[i].email & resultKH.data.password==this.list[i].password){
                  this.idStaff = this.list[i].staffId;
              }
          }
console.log("Id nhân viên: ", this.idStaff)
if(this.idStaff!=""){
    let offAdmin = await axios.put(`https://localhost:44354/api/Customers/${id}`,{
    customerId: resultKH.data.customerId,
    tenKh: resultKH.data.tenKh,
    ngaysinh: resultKH.data.ngaysinh,
    gioiTinh: resultKH.data.gioiTinh,
    avatar: resultKH.data.avatar,
    diachi: resultKH.data.diachi,
    phone: resultKH.data.phone,
    email: resultKH.data.email,
    password: resultKH.data.password,
    memberShip: resultKH.data.memberShip,
    roleId: 2
          });
if(offAdmin.status==204){
    this.showAlert = true;
    setTimeout(()=>{
      this.showAlert=false
      location.reload();
    },2000)
      } else alert("Lỗi! Đổi mật khẩu không thành công!");
} else {
    let offAdmin = await axios.put(`https://localhost:44354/api/Customers/${id}`,{
    customerId: resultKH.data.customerId,
    tenKh: resultKH.data.tenKh,
    ngaysinh: resultKH.data.ngaysinh,
    gioiTinh: resultKH.data.gioiTinh,
    avatar: resultKH.data.avatar,
    diachi: resultKH.data.diachi,
    phone: resultKH.data.phone,
    email: resultKH.data.email,
    password: resultKH.data.password,
    memberShip: resultKH.data.memberShip,
    roleId: 3
          });
if(offAdmin.status==204){
    this.showAlert = true;
    setTimeout(()=>{
      this.showAlert=false
      location.reload();
    },2000)
      } else alert("Lỗi! Đổi mật khẩu không thành công!");
}
}

//End methods
}
}
</script>

<style>

</style>