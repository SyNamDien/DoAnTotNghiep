<template>
 <body>
    <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full"
        data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">

        <admin-sidebar/>
        
        <div class="page-wrapper">
        <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                        <div class="card">
                            <div class="card-body">
                                <h4 class="card-title">Danh Sách Nhân Viên</h4>
                                <button class="btn btn-themnv" @click="dialogAdd = true">Thêm Nhân Viên</button>
                            </div>
                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">STT</th>
                                            <th scope="col">Tên</th>
                                            <th scope="col">Giới Tính</th>
                                            <th scope="col">Email</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="(item,index) in listStaff" :key="item.staffId">
                                        <tr>
                                            <th>{{index+1}}</th>
                                            <td>{{item.tenNv}}</td>
                                            <td>{{item.gioiTinh}}</td>
                                            <td>{{item.email}}</td>
                                            <td>
                                              <btn class="btn btn-primary" @click="dialogViewNV = true" v-on:click="getNhanVien(item.staffId)">Xem</btn> |
                                              <btn class="btn btn-danger" @click="dialogXacNhanXoa = true" v-on:click="layIDNV(item.staffId)">Xóa</btn>
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

    <!-- Dialog Thêm Nhân Viên -->
<v-dialog v-model="dialogAdd" width="1200">
      <v-card >
        <h2 class="text-danger m-2 text-center"> Thêm Nhân Viên</h2>
        <v-card-actions>
          <v-spacer></v-spacer>
          <a @click="getKhachHang = true" class="btn btn-green">Lấy thông tin từ tài khoản</a>
           <v-spacer></v-spacer>
        </v-card-actions>
        <v-form v-model="valid" lazy-validation class="m-2">
            <form class="form-register">

<div class="form-outline mb-4">
<label class="form-label" for="form3Example1cg">Họ tên</label>
  <input type="text" id="form3Example1cg" v-model="tenKh" class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" for="form3Example1cg">Ngày Sinh</label>
  <input type="date" id="form3Example1cg" v-model="ngaysinh" class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" for="form3Example3cg"> Giới Tính</label>
  <input type="text" v-model="gioiTinh" placeholder="Nam, Nữ, Khác" class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" for="form3Example3cg"> Địa Chỉ</label>
  <input type="text" v-model="diachi" class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" for="form3Example3cg">Điện Thoại</label>
  <input type="phone" v-model="phone" readonly class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" >Email</label>
  <input type="text" v-model="emailNV" readonly class="form-control form-control-lg" required />
</div>
<div class="form-outline mb-4">
    <label class="form-label" >Ngày Vào Công Ty</label>
  <input type="date" v-model="ngayVaoCT" class="form-control form-control-lg" required />
</div>
</form>
        </v-form>
        <v-card-actions>
          <v-spacer></v-spacer>
          <a v-on:click="addNhanVien" class="btn btn-green">Thêm Nhân Viên</a>
          <a @click="dialogAdd = false" class="btn btn-red">Close</a>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!-- Dialog Xem Nhân Viên -->
    <v-dialog v-model="dialogViewNV" width="1200">
      <v-card>
        <h2 class="text-danger m-2 text-center"> Xem Nhân Viên</h2>
        <v-form v-model="valid" lazy-validation class="m-2">
            <form class="form-register">
<div class="form-outline mb-4">
<label class="form-label" for="form3Example1cg">Họ tên</label>
  <input type="text" id="form3Example1cg" v-model="tenKh" readonly class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" for="form3Example1cg">Ngày Sinh</label>
  <input type="date" id="form3Example1cg" readonly v-model="ngaysinh" class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" for="form3Example3cg"> Giới Tính</label>
  <input type="text" v-model="gioiTinh" readonly class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" for="form3Example3cg"> Địa Chỉ</label>
  <input type="text" v-model="diachi" readonly class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" for="form3Example3cg">Điện Thoại</label>
  <input type="phone" v-model="phone" readonly class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
    <label class="form-label" >Email</label>
  <input type="text" v-model="emailNV" readonly class="form-control form-control-lg" required />
</div>
<div class="form-outline mb-4">
    <label class="form-label" >Ngày Vào Công Ty</label>
  <input type="date" v-model="ngayVaoCT" readonly class="form-control form-control-lg" required />
</div>
<div class="d-flex flex-column justify-space-between align-center">
    <v-slider
      v-model="width"
      class="align-self-stretch"
      min="200"
      max="500"
      step="1"
    ></v-slider>

    <v-img
      :aspect-ratio="aspectRatio"
      :width="width"
      :src="avatar"
      cover
    ></v-img>
  </div>
</form>
        </v-form>
        <v-card-actions>
          <v-spacer></v-spacer>
          <a @click="dialogViewNV = false" class="btn btn-red">Close</a>
        </v-card-actions>
      </v-card>
    </v-dialog>

        <!-- Dialog Xóa Nhân Viên -->
<v-dialog v-model="dialogXacNhanXoa" width="700">
      <v-card >
        <h2 class="m-2 text-center"> Xác Nhận Xóa</h2>
        <h4 class="text-danger text-center">Bạn có chắc muốn xóa nhân viên này?</h4>
        <v-card-actions>
          <v-spacer></v-spacer>
          <a v-on:click="xoaNhanVien()" @click="dialogXacNhanXoa = false" class="btn btn-danger">Xóa</a>
          <a @click="dialogXacNhanXoa = false" class="btn btn-green">Close</a>
        </v-card-actions>
      </v-card>
    </v-dialog>

<!-- Danh sách khách hàng Dialog -->
    <v-dialog v-model="getKhachHang" width="700">
      <v-card >
        <h2 class="text-danger m-2 text-center">Danh Sách Tài Khoản</h2>
        <v-card-actions>
        </v-card-actions>
        <v-form v-model="valid" lazy-validation class="m-2">
            <div class="row">
            <div class="col-12">
                        <div class="card">
                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">STT</th>
                                            <th scope="col">Tên</th>
                                            <th scope="col">Giới Tính</th>
                                            <th scope="col">Email</th>
                                            <th scope="col">Role ID</th>
                                            <th scope="col">Action</th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="(item,index) in listKhachHang" :key="item.customerId">
                                        <tr>
                                            <th>{{index+1}}</th>
                                            <td>{{item.tenKh}}</td>
                                            <td>{{item.gioiTinh}}</td>
                                            <td>{{item.email}}</td>
                                            <td>{{item.roleId}}</td>
                                            <td><a class="btn btn-green" v-on:click="getTTKhachHang(item.customerId)">Lấy</a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                      </div>
            </div>
        </div>
        </v-form>
        <v-card-actions>
          <v-spacer></v-spacer>
          <a @click="getKhachHang = false" class="btn btn-red">Close</a>
        </v-card-actions>
      </v-card>
    </v-dialog>
    
</body>
</template>

<script>
import axios from 'axios';
import AdminSidebar from '../components/AdminSidebar.vue';
export default {
  components: { AdminSidebar },
    name:'App',
    comments:{

    },
data(){
  return{
    width:300,
    idNV:0,
    dialogXacNhanXoa: false,
    dialogViewNV:false,
    getKhachHang:false,
    fullname:sessionStorage.getItem('fullname'),
    email:sessionStorage.getItem('email'),
    anhUser:sessionStorage.getItem('anhUser'),
    listStaff:[],
    listStaffID:[],
    listKhachHang:[],
    dialogAdd:false,
    idKH:"",
    tenKh: "",
    ngaysinh: "",
    gioiTinh: "",
    avatar: "",
    diachi: "",
    phone: "",
    emailNV: "",
    password: "",
    memberShip: "",
    ngayVaoCT:'',
    roleId: 2,
    reenterPassword:""
  }
},
async mounted(){
let resultStaff = await axios.get("https://localhost:44354/api/Staff");
this.listStaff = resultStaff.data;


var list;
let resultKH = await axios.get("https://localhost:44354/api/Customers");
list = resultKH.data;
for(var i = 0; i < list.length; i++){
            if(list[i].roleId==3){
                this.listKhachHang.push(list[i]);
            }
        }

},
methods:{
  layIDNV(id){
    this.idNV = id;
  },
  async xoaNhanVien(){
    let xoaKH = await axios.delete(`https://localhost:44354/api/Staff/${this.idNV}`);
    if(xoaKH.status ==204){
      alert("Xóa nhân viên thành công!");
    location.reload();
    } else alert("Xóa nhân viên không thành công!");
  },
  async getNhanVien(id){
    let resultStaffID = await axios.get(`https://localhost:44354/api/Staff/${id}`);
        this.tenKh = resultStaffID.data.tenNv;
        this.ngaysinh = resultStaffID.data.ngaysinh;
        this.gioiTinh = resultStaffID.data.gioiTinh;
        this.diachi = resultStaffID.data.diachi;
        this.phone = resultStaffID.data.phone;
        this.emailNV = resultStaffID.data.email;
        this.ngayVaoCT = resultStaffID.data.ngayVaoCty;
        this.avatar = resultStaffID.data.avatar;
  },
    async getTTKhachHang(id){
        let resultKH = await axios.get(`https://localhost:44354/api/Customers/${id}`);
        console.log("Data click KH: ",resultKH.data);
        this.idKH = id;
        this.tenKh = resultKH.data.tenKh;
        this.ngaysinh = resultKH.data.ngaysinh;
        this.gioiTinh = resultKH.data.gioiTinh;
        this.diachi = resultKH.data.diachi;
        this.phone = resultKH.data.phone;
        this.emailNV = resultKH.data.email;
        this.password = resultKH.data.password;
        this.memberShip = resultKH.data.memberShip;
        this.avatar = resultKH.data.avatar;
        this.getKhachHang = false;
    },
async addNhanVien(){
let result = await axios.post("https://localhost:44354/api/Staff",{
  tenNv: this.tenKh,
  ngaysinh: this.ngaysinh,
  gioiTinh: this.gioiTinh,
  avatar: this.avatar,
  diachi: this.diachi,
  phone: this.phone,
  email: this.emailNV,
  password: this.password,
  ngayVaoCty: this.ngayVaoCT,
  soCvdaLam: 0,
  staffPoint: 0,
  danhGia: "0",
  roleId: 0
        });
let resultPutKH = await axios.put(`https://localhost:44354/api/Customers/${this.idKH}`,{
  customerId: this.idKH,
  tenKh: this.tenKh,
  ngaysinh: this.ngaysinh,
  gioiTinh: this.gioiTinh,
  avatar: this.avatar,
  diachi: this.diachi,
  phone: this.phone,
  email: this.emailNV,
  password: this.password,
  memberShip: this.memberShip,
  roleId: 2,
        });
if(result.status==201 || resultPutKH.status==204){
    alert("Thêm nhân viên thành công!");
    location.reload();
    } else alert("Lỗi! Thêm nhân viên không thành công!");
    }
}

}
</script>

<style>
.btn-themnv{
    background-color: #4CAF50;
  border: none;
  color: white;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 14px;
}
</style>