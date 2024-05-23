<template>
    <body>
       <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full"
           data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">
        <staff-sidebar/>
           <div class="page-wrapper">
           <div class="container-fluid">
           <div class="row">
            <div class="col-xl-10">
                <div class="section-tittle text-center">
                            <h2>DANH SÁCH CÔNG VIỆC CỦA BẠN</h2>
                        </div>
                        <!-- single-job-content -->
                        <div class="single-job-items mb-30" v-for="item in listJobOfferNV" v-bind:key="item.jobOfferId">
                            <div class="job-items">
                                <div class="company-img">
                                    <a href=""><img src="assets/img/icon/job-list1.png" alt=""></a>
                                </div>
                                <div class="job-tittle">
                                    <a href="" v-for="i in listJob" v-bind:key="i">
                                        <h4 v-if="item.jobId == i.jobId">{{i.tenCv}}</h4>
                                    </a>
                                    <div v-for="kh in listKH" v-bind:key="kh">
                                        <span v-if="item.customerId == kh.customerId">Tên khách hàng:<h5>{{kh.tenKh}}</h5></span></div>
                                    <ul>
                                      <li><div v-for="y in listTrangThai" v-bind:key="y">
                                            <p v-if="item.trangThaiId == y.trangThaiId">{{y.trangThaiName}}</p></div></li>
                                        <li>Ngày bắt đầu: {{item.ngayBdlam}}</li>
                                        <li>Giá: {{item.gia}} VNĐ</li>
                                    </ul>
                                </div>
                            </div>
                                <div class="items-link f-right">
                                <a class="btn" @click="dialogView = true" v-on:click="getJobOffer(item.jobOfferId)">Xem</a>
                                <span>Ngày: {{item.ngayDang}}</span>
                            </div>
                        </div>
                    </div>
           </div>
           
       </div>
       </div>
       </div>
           <!-- Dialog Xem đơn tuyển nhân viên giúp việc -->
<v-dialog v-model="dialogView" width="700">
      <v-card >
        <h2 class="text-danger m-2 text-center">Thông Tin Công Việc Của Bạn</h2>
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
          <input v-model="gia" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="Click vào đây để xem giá">
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
   </body>
   </template>
   
   <script>
   import axios from 'axios';
   import StaffSidebar from '@/components/StaffSidebar.vue';
   export default {
   name:'App',
   components:{
     StaffSidebar
   },
   data(){
     return{
    dialogView:false,
    list:[],
    listJob:[],
    listKH:[],
    listJobOffer:[],
    listJobOfferNV:[],
    listTrangThai:[],
    fullname:sessionStorage.getItem('fullname'),
    email:sessionStorage.getItem('email'),
    staffId:'',
    jobId:'',
    fullnameCus:'',
    emailCus:'',
    phoneCus:'',
    addressCus:'',
    jobName:'',
    gia:'',
    ngayBDLam:'',
    note:'',
    trangThai:''
     }
   },
   async mounted(){
    let resultKH = await axios.get("https://localhost:44354/api/Customers");
   this.listKH= resultKH.data;
   let resultUserStaff = await axios.get("https://localhost:44354/api/Staff");
   this.list = resultUserStaff.data;
   for(var id = 0; id < this.list.length; id++){
            if(this.list[id].email==this.email){
                this.staffId=this.list[id].staffId;
            }
        }
   let resultJobOffer = await axios.get("https://localhost:44354/api/JobOffer");
   this.listJobOffer = resultJobOffer.data;
   for(var i = 0; i < this.listJobOffer.length; i++){
            if(this.listJobOffer[i].staffId==this.staffId){
                this.listJobOfferNV.push(this.listJobOffer[i]);
            }
        }
   
   let resultTT = await axios.get("https://localhost:44354/api/TrangThai");
   this.listTrangThai= resultTT.data;

   let resultJob = await axios.get("https://localhost:44354/api/Job");
   this.listJob= resultJob.data;
   },
   methods:{
       logout(){
       this.$router.push('/');
       sessionStorage.clear();
     },
     async getJobOffer(jobofferId){
        let resultJobOfer = await axios.get(`https://localhost:44354/api/JobOffer/${jobofferId}`);
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
   }
   }
   </script>
   
   <style>
   
   </style>