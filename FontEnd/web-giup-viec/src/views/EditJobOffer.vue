<template>
    <body>
        <header-user/>
  <div class="col-md-6 offset-md-3 mt-5">
    <br>
    <h1>SỬA THÔNG TIN</h1>
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
          <input v-model="maNV" type="text" name="zip" class="form-control" id="inputZip" readonly placeholder="(Nếu có)">
        </div>
      </div>
      <div class="form-group">
          <label for="inputZip">Ghi chú</label>
          <textarea v-model="note" type="text" name="zip" class="form-control" id="inputZip" placeholder="Ghi chú"></textarea>
        </div>
      <a v-on:click="submitJobOffer" class="btn btn-primary">Sửa Ngay</a>
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
created(){
let jobofferId = this.$route.params.id;
if(jobofferId){
    this.getJobOffer(jobofferId);
}
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
    listCBB:[],
    list:[],
    listJob:[],
    jobId:'',
    email:sessionStorage.getItem('email'),
    address:sessionStorage.getItem('address'),
  }
},
async mounted(){
let resultJob = await axios.get("https://localhost:44354/api/Job");
console.warn("api data Job:", resultJob.data);
this.list = resultJob.data;
for(var i = 0; i < this.list.length; i++){
            if(this.list[i].trangThai == true){
                this.listJob.push(this.list[i]);
                this.listCBB.push(this.list[i].tenCv);
            }
        }
},
methods:{
    async getJobOffer(jobofferId){
        let resultJobOfer = await axios.get(`https://localhost:44354/api/JobOffer/${jobofferId}`);
        this.gia = resultJobOfer.data.gia;
        this.ngayBDLam = resultJobOfer.data.ngayBdlam;
        this.jobId = resultJobOfer.data.jobId;
        this.note = resultJobOfer.data.note;
        this.maNV = resultJobOfer.data.staffId;
        let resultJobID = await axios.get(`https://localhost:44354/api/Job/${this.jobId}`);
        this.jobName = resultJobID.data.tenCv;
    },
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
        var ngayDangTNV = this.ngayDang.getDate()+"-"+this.ngayDang.getMonth()+"-"+this.ngayDang.getFullYear();
        let resultOffer = await axios.put(`https://localhost:44354/api/JobOffer/${this.$route.params.id}`,{
    jobOfferId:this.$route.params.id,
    jobId: this.jobId,
  customerId: this.customerID,
  staffId: this.maNV,
  trangThaiId: 1,
  ngayDang: ngayDangTNV,
  ngayBdlam: this.ngayBDLam,
  gia: String(this.gia),
  note: this.note
        });
        console.warn(resultOffer);
        try {
            if(resultOffer.status==204){
            alert("Sửa Thành Công");
        }
        this.$router.push('/list_job_offer');
        } catch (error) {
            alert("Sửa Không Thành Công");
        }

    }
}
}
</script>

<style>

</style>