<template>
     <body>
<header-user/>
  <div class="col-md-6 offset-md-3 mt-5">
    <br>
    <h1>THÔNG TIN TUYỂN GIÚP VIỆC</h1>
    <form>
      <div class="form-group">
        <label for="exampleInputName">Tên Khách Hàng</label>
        <input v-model="fullname" type="text" name="fullname" class="form-control" id="exampleInputName" placeholder="Enter your name and surname" required="required">
      </div>
      <div class="form-row">
        <div class="form-group col-md-4">
        <label for="exampleInputEmail1" required="required">Email</label>
        <input v-model="email" type="email" name="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter your email address">
        </div>
        <div class="form-group col-md-4">
        <label for="example-tel-input">Điện thoại</label>
          <input v-model="phone" class="form-control" name="tel" type="tel" id="example-tel-input">
      </div>
      </div>
      <div class="form-group">
        <label for="inputAddress">Địa chỉ</label>
        <input v-model="address" type="text" name="address" class="form-control" id="inputAddress" placeholder="1234 Main St">
      </div>
      <div class="form-group">
        <div class="form-group col-md-6">
            <label for="inputZip">Chọn công việc</label>
          <v-combobox v-model="jobName"
            label="Chọn việc"
            :items= listCBB
            ></v-combobox>
        </div>
      </div>
      <div class="form-group">
        <div class="form-group col-md-4">
          <label for="inputZip">Giá</label>
          <input v-on:click="onClickCV" v-model="gia" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="Click vào đây để xem giá">
        </div>
      </div>
      <div class="form-row">
        <div class="form-group col-md-5">
            <label for="inputZip">Ngày Bắt Đầu Làm</label>
          <input v-model="ngayBDLam" class="form-control" name="starting_date" type="date" id="example-date-input">
        </div>
        <div class="form-group col-md-3">
          <label for="inputZip">Mã Nhân Viên</label>
          <input v-model="maNV" type="text" name="zip" class="form-control" id="inputZip" placeholder="(Nếu có)">
        </div>
      </div>
      <div class="form-group">
          <label for="inputZip">Ghi chú</label>
          <textarea v-model="note" type="text" name="zip" class="form-control" id="inputZip" placeholder="Ghi chú"></textarea>
        </div>
      <a v-on:click="submitJobOffer" class="btn btn-primary">Tuyển Ngay</a>
    </form>
  </div>
<footer-user/>
    </body>
</template>

<script>
import axios from 'axios';
import HeaderUser from '../components/HeaderUser.vue';
import FooterUser from '../components/FooterUser.vue';
export default {
name: 'App',
components:{
HeaderUser,
FooterUser
},
data(){  
return{
    phone:sessionStorage.getItem('phone'),
    maNV:"",
    note:"",
    customerID:sessionStorage.getItem('id'),
    ngayDang:new Date(),
    ngayBDLam:'',
    gia:'',
    jobName:'',
    listContact:[],
    listCBB:[],
    list:[],
    listJob:[],
    jobId:'',
    fullname:sessionStorage.getItem('fullname'),
    email:sessionStorage.getItem('email'),
    address:sessionStorage.getItem('address'),
  }
},
async mounted(){
let resultContact = await axios.get("https://localhost:44354/api/Contact");
console.warn("api data", resultContact.data);
this.listContact = resultContact.data;

let resultJob = await axios.get("https://localhost:44354/api/Job");
console.warn("api data", resultJob.data);
this.list = resultJob.data;
for(var i = 0; i < this.list.length; i++){
            if(this.list[i].trangThai == true){
                this.listJob.push(this.list[i]);
                this.listCBB.push(this.list[i].tenCv);
            }
        }
},
methods:{
    onClickCV(){
        for(var j = 0; j < this.list.length; j++){
            if(this.jobName == this.list[j].tenCv){
                this.gia= this.list[j].giaDiscount;
                this.jobId= this.list[j].jobId;
            }
        }
        console.log(this.gia,this.jobId);
    },
    async submitJobOffer(){
  console.log("Đã click",this.jobId,this.customerID,this.maNV,this.ngayBDLam,this.gia,this.note);
  var ngayDangTNV = this.ngayDang.getMonth()+"-"+this.ngayDang.getDate()+"-"+this.ngayDang.getFullYear();
  let resultOffer = await axios.post("https://localhost:44354/api/JobOffer",{
  jobId: this.jobId,
  customerId: this.customerID,
  staffId: 2,
  trangThaiId: 1,
  ngayDang: ngayDangTNV,
  ngayBdlam: this.ngayBDLam,
  gia: String(this.gia),
  note: this.note
        });
        console.warn(resultOffer);
        try {
            if(resultOffer.status==201){
            alert("Tuyển Nhân Viên Thành Công");
        }
        this.$router.push('/');
        } catch (error) {
            alert("Tuyển Nhân Viên Không Thành Công");
        }

    },
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
</style>