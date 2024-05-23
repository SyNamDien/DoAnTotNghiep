<template>
  <body>
   <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full"
       data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">

       <admin-sidebar/>

       <div class="page-wrapper">
       <div class="container-fluid">
       <div class="row">
       <div class="row justify-content-center">
               <div class="row">
                   <div class="col-lg-12">
                       <div class="card-body">
                               <h4 class="card-title">Danh Sách Đơn Tuyển Giúp Việc</h4>
                           </div>
                       <div class="navbar navbar-expand">
           </div>

           <div class="table-responsive">
                               <table class="table">
                                   <thead class="thead-light">
                                       <tr>
                                           <th scope="col">STT</th>
                                           <th scope="col">Công Việc</th>
                                           <th scope="col">Tên Khách Hàng</th>
                                           <th scope="col">Trạng Thái</th>
                                           <th scope="col">Ngày Làm</th>
                                           <th scope="col">Giá</th>
                                           <th scope="col"></th>
                                       </tr>
                                   </thead>
                                   <tbody v-for="(item,index) in listJobOffer" v-bind:key="item.jobOfferId">
                                       <tr>
                                           <th>{{index+1}}</th>
                                           <td>
                                           <div v-for="cv in listJob" v-bind:key="cv">
                                           <span v-if="item.jobId == cv.jobId"><h5>{{cv.tenCv}}</h5></span></div>
                                           </td>
                                           <td>
                                           <div v-for="kh in listKH" v-bind:key="kh">
                                           <span v-if="item.customerId == kh.customerId"><h5>{{kh.tenKh}}</h5></span></div>
                                           </td>
                                           <td>
                                           <div v-for="y in listTrangThai" v-bind:key="y">
                                           <p v-if="item.trangThaiId == y.trangThaiId">{{y.trangThaiName}}</p></div>
                                           </td>
                                           <td>{{item.ngayBdlam}}</td>
                                           <td>{{item.gia}}</td>
                                           <td>
                                           <template v-if="item.trangThaiId == 1 || item.trangThaiId == 2 ">
                                                   <v-btn
                                               @click="dialogEdit=true"
                                               v-on:click="getJobOffer(item.jobOfferId)"
                                               color="primary"
                                               icon="mdi-pencil"
                                               size="small"
                                           ></v-btn>
                                           </template>

                                           <template v-if="item.trangThaiId == 3 || item.trangThaiId == 4 ">
                                               <v-btn
                                               @click="dialogEdit=true"
                                               v-on:click="getJobOffer(item.jobOfferId)"
                                               color="primary"
                                               icon="mdi-pencil"
                                               size="small"
                                           ></v-btn>
                                               
                                           </template>
                                           <template v-if="item.trangThaiId == 5">
                                           <v-btn
                                               @click="dialogView=true"
                                               v-on:click="getJobOffer(item.jobOfferId)"
                                               color="primary"
                                               icon="mdi-pencil"
                                               size="small"
                                           ></v-btn>
                                           </template>
                                           </td>
                                       </tr>
                                   </tbody>
                               </table>
               </div>
           </div>
       </div>
   </div>

<!-- Dialog Duyệt đơn tuyển nhân viên giúp việc -->
<v-dialog v-model="dialogEdit" width="700">
     <v-card >
       <h2 class="text-danger m-2 text-center"> Duyệt Đơn Tuyển Nhân Viên</h2>
       <v-form v-model="valid" lazy-validation class="m-2">
           <form>
     <div class="form-group">
       <label for="exampleInputName">Tên Khách Hàng</label>
       <input v-model="fullnameCus" type="text" readonly name="fullname" class="form-control" id="exampleInputName" placeholder="Enter your name and surname" required="required">
     </div>
     <div class="form-row">
       <div class="form-group col-md-4">
       <label for="exampleInputEmail1" required="required">Email</label>
       <input v-model="emailCus" type="email" readonly name="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter your email address">
       </div>
       <div class="form-group col-md-4">
       <label for="example-tel-input">Điện thoại</label>
         <input v-model="phoneCus" class="form-control" name="tel" type="tel" readonly id="example-tel-input">
     </div>
     </div>
     <div class="form-group">
       <label for="inputAddress">Địa chỉ</label>
       <input v-model="addressCus" type="text" name="address" class="form-control" id="inputAddress" readonly placeholder="1234 Main St">
     </div>
     <div class="form-row">
       <div class="form-group col-md-6">
           <label for="inputZip">Công việc</label>
           <input v-model="jobName" type="text" name="address" class="form-control" id="inputAddress" readonly placeholder="1234 Main St">
       </div>
       <div class="form-group col-md-4">
         <label for="inputZip">Giá</label>
         <input v-on:click="onClickCV" v-model="gia" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="Click vào đây để xem giá">
       </div>
     </div>
     <div class="form-row">
       <div class="form-group col-md-3">
           <label for="inputZip">Ngày Bắt Đầu Làm</label>
         <input v-model="ngayBDLam" class="form-control" name="starting_date" type="date" readonly id="example-date-input">
       </div>
       <div class="form-group col-md-5">
       <label for="inputZip">Ghi chú</label>
         <textarea v-model="note" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="Ghi chú"></textarea>
       </div>
     </div>
     <div class="form-row">
       <div class="form-group col-md-4">
         <label for="inputZip">Chọn mã Nhân Viên</label>
         <v-combobox v-model="maNV"
         :items=lisNV
           ></v-combobox>
       </div>
       <div class="form-group col-md-4">
         <label for="inputZip">Trạng Thái</label>
         <v-combobox v-model="trangThai"
         :items=listTrangThaiName
           ></v-combobox>
       </div>
       </div>
   </form>
    <v-alert v-if="showAlert==true" type="success">Sửa thành công.</v-alert>
       </v-form>
       <v-card-actions>
         <v-spacer></v-spacer>
         <a @click="dialogNV=true" class="btn btn-green">Xem danh sách NV</a>
         <a v-on:click="submitJobOffer" class="btn btn-green">Hoàn thành</a>
         <a @click="dialogEdit = false" class="btn btn-red">Close</a>
       </v-card-actions>
     </v-card>
   </v-dialog>

   <!-- Dialog Xem đơn tuyển nhân viên giúp việc -->
<v-dialog v-model="dialogView" width="700">
     <v-card >
       <h2 class="text-danger m-2 text-center"> Duyệt Đơn Tuyển Nhân Viên</h2>
       <v-form v-model="valid" lazy-validation class="m-2">
           <form>
     <div class="form-group">
       <label for="exampleInputName">Tên Khách Hàng</label>
       <input v-model="fullnameCus" type="text" readonly name="fullname" class="form-control" id="exampleInputName" placeholder="Enter your name and surname" required="required">
     </div>
     <div class="form-row">
       <div class="form-group col-md-4">
       <label for="exampleInputEmail1" required="required">Email</label>
       <input v-model="emailCus" type="email" readonly name="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter your email address">
       </div>
       <div class="form-group col-md-4">
       <label for="example-tel-input">Điện thoại</label>
         <input v-model="phoneCus" class="form-control" name="tel" type="tel" readonly id="example-tel-input">
     </div>
     </div>
     <div class="form-group">
       <label for="inputAddress">Địa chỉ</label>
       <input v-model="addressCus" type="text" name="address" class="form-control" id="inputAddress" readonly placeholder="1234 Main St">
     </div>
     <div class="form-row">
       <div class="form-group col-md-6">
           <label for="inputZip">Công việc</label>
           <input v-model="jobName" type="text" name="address" class="form-control" id="inputAddress" readonly placeholder="1234 Main St">
       </div>
       <div class="form-group col-md-4">
         <label for="inputZip">Giá</label>
         <input v-on:click="onClickCV" v-model="gia" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="Click vào đây để xem giá">
       </div>
     </div>
     <div class="form-row">
       <div class="form-group col-md-3">
           <label for="inputZip">Ngày Bắt Đầu Làm</label>
         <input v-model="ngayBDLam" class="form-control" name="starting_date" type="date" readonly id="example-date-input">
       </div>
       <div class="form-group col-md-5">
       <label for="inputZip">Ghi chú</label>
         <textarea v-model="note" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="Ghi chú"></textarea>
       </div>
     </div>
     <div class="form-row">
       <div class="form-group col-md-4">
         <label for="inputZip">Chọn mã Nhân Viên</label>
           <input v-model="maNV" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="Click vào đây để xem giá">
       </div>
       <div class="form-group col-md-4">
         <label for="inputZip">Trạng Thái</label>
           <input v-model="trangThai" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="Click vào đây để xem giá">
       </div>
       </div>
   </form>
       </v-form>
       <v-card-actions>
         <v-spacer></v-spacer>
         <a @click="dialogView = false" class="btn btn-red">Close</a>
       </v-card-actions>
     </v-card>
   </v-dialog>

<!-- Dialog Danh sách nhân viên -->
   <v-dialog v-model="dialogNV" width="700">
     <v-card >
       <h2 class="text-danger m-2 text-center"> Danh Sách Nhân Viên</h2>
       <v-form v-model="valid" lazy-validation class="m-2 row">
           <div class="col-12">
                       <div class="card">
                           <div class="card-body">
                               <h4 class="card-title">Danh Sách Nhân Viên</h4>
                           </div>
                           <div class="table-responsive">
                               <table class="table">
                                   <thead class="thead-light">
                                       <tr>
                                           <th scope="col">Mã NV</th>
                                           <th scope="col">Tên</th>
                                           <th scope="col">Giới Tính</th>
                                           <th scope="col">Email</th>
                                       </tr>
                                   </thead>
                                   <tbody v-for="item in list" :key="item.staffId">
                                       <tr>
                                           <th>{{item.staffId}}</th>
                                           <td>{{item.tenNv}}</td>
                                           <td>{{item.gioiTinh}}</td>
                                           <td>{{item.email}}</td>
                                       </tr>
                                   </tbody>
                               </table>
                           </div>
                       </div>
           </div>
       </v-form>
       <v-card-actions>
         <v-spacer></v-spacer>
         <a @click="dialogNV = false" class="btn btn-red">Close</a>
       </v-card-actions>
     </v-card>
   </v-dialog>

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
  showAlert:false,
   listKH:[],
   listJobOffer:[],
   listTrangThai:[],
   listTrangThaiName:[],
   listJob:[],
   lisNV:[],
   list:[],
   check:'all',
   dialogEdit:false,
   dialogView:false,
   maNV:"",
   note:"",
   customerID:'',
   jobOfId:'',
   ngayDang:new Date(),
   ngayBDLam:'',
   gia:'',
   jobName:'',
   jobId:'',
   fullnameCus:'',
   phoneCus:'',
   emailCus:'',
   addressCus:'',
   trangThai:'',
   trangThaiId:'',
   dialogNV:false,
   ngayDangTNV:'',
   cusId:''
 }
},
async mounted() {
let resultJob = await axios.get("https://localhost:44354/api/Job");
this.listJob = resultJob.data;

let resultKH = await axios.get("https://localhost:44354/api/Customers");
this.listKH= resultKH.data;

let resultNV = await axios.get("https://localhost:44354/api/Staff");
this.list = resultNV.data;
for(var j = 0; j < this.list.length; j++){
   this.lisNV.push(this.list[j].staffId);
       }

let resultTrangThai = await axios.get("https://localhost:44354/api/TrangThai");
this.listTrangThai = resultTrangThai.data;
for(var k = 0;k < this.listTrangThai.length;k++){
   this.listTrangThaiName.push(this.listTrangThai[k].trangThaiName);
}

let resultListOffer = await axios.get("https://localhost:44354/api/JobOffer");
console.warn("api data", resultListOffer.data);
this.listJobOffer = resultListOffer.data;

},
methods:{
   logout(){
   this.$router.push('/');
   sessionStorage.clear();
 },
async getJobOffer(jobofferId){
       let resultJobOfer = await axios.get(`https://localhost:44354/api/JobOffer/${jobofferId}`);
       console.log("Data click jobof: ",resultJobOfer.data);
       this.jobOfId = resultJobOfer.data.jobOfferId;
       this.cusId = resultJobOfer.data.customerId;
       this.gia = resultJobOfer.data.gia;
       this.ngayBDLam = resultJobOfer.data.ngayBdlam;
       this.jobId = resultJobOfer.data.jobId;
       this.note = resultJobOfer.data.note;
       this.maNV = resultJobOfer.data.staffId;
       this.trangThaiId = resultJobOfer.data.trangThaiId;
       this.ngayDangTNV = resultJobOfer.data.ngayDang;


       let resultJobID = await axios.get(`https://localhost:44354/api/Job/${this.jobId}`);
       this.jobName = resultJobID.data.tenCv;
       let resultTT = await axios.get(`https://localhost:44354/api/TrangThai/${this.trangThaiId}`);
       this.trangThai = resultTT.data.trangThaiName;

       let resultCus = await axios.get(`https://localhost:44354/api/Customers/${this.cusId}`);
       this.fullnameCus = resultCus.data.tenKh;
       this.emailCus = resultCus.data.email;
       this.phoneCus =  resultCus.data.phone;
       this.addressCus = resultCus.data.diachi;
   },
async submitJobOffer(){
   for(var n = 0; n < this.listTrangThai.length; n++){
           if(this.listTrangThai[n].trangThaiName==this.trangThai){
               this.trangThaiId=this.listTrangThai[n].trangThaiId;
           }
       }

   let resultOffer = await axios.put(`https://localhost:44354/api/JobOffer/${this.jobOfId}`,{
   jobOfferId:this.jobOfId,
   jobId: this.jobId,
   customerId: this.cusId,
   staffId: this.maNV,
   trangThaiId: this.trangThaiId,
   ngayDang: this.ngayDangTNV,
   ngayBdlam: this.ngayBDLam,
   gia: String(this.gia),
   note: this.note
       });
       console.warn(resultOffer);
       try {
           if(resultOffer.status==204){
            this.showAlert = true;
            setTimeout(()=>{
            this.showAlert=false
            location.reload();
          },2000)
       }
       } catch (error) {
           alert("Lỗi!Duyệt Không Thành Công");
       }
   },
   }
}
</script>

<style>
.btn-green{
   background-color: #4CAF50;
 border: none;
 color: white;
 text-align: center;
 margin: 10px;
 text-decoration: none;
 display: inline-block;
 font-size: 14px;
}
.btn-red{
   background-color: #e6250c;
 border: none;
 color: white;
 text-align: center;
 text-decoration: none;
 display: inline-block;
 font-size: 14px;
}
</style>