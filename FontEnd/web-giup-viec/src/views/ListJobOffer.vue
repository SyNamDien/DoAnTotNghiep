<template>
    <body>
<header-user/>
    <section class="featured-job-area feature-padding">
            <div class="container">
                <!-- Section Tittle -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="section-tittle text-center">
                            <h2>DANH SÁCH TUYỂN NHÂN VIÊN GIÚP VIỆC</h2>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-xl-10" v-for="item in listJobOffer" v-bind:key="item.jobOfferId">
                        <!-- single-job-content -->
                        <div class="single-job-items mb-30">
                            <div class="job-items">
                                <div class="company-img">
                                    <a><img src="assets/img/icon/job-list1.png" alt=""></a>
                                </div>
                                <div class="job-tittle">
                                    <a href="" v-for="i in listJob" v-bind:key="i">
                                        <h4 v-if="item.jobId == i.jobId">{{i.tenCv}}</h4>
                                    </a>
                                    <ul>
                                        <li><div v-for="y in listTrangThai" v-bind:key="y">
                                            <p v-if="item.trangThaiId == y.trangThaiId">{{y.trangThaiName}}</p></div></li>
                                        <li>Ngày làm: {{item.ngayBdlam}}</li>
                                        <li>Giá: {{item.gia}} VNĐ</li>
                                    </ul>
                                </div>
                            </div>
                            <template v-if="item.trangThaiId == 1 ||item.trangThaiId == 2 ">
                                <div class="items-link f-right">
                                <router-link :to="{name:'EditJobOffer',params:{id:item.jobOfferId}}" ><button href="">Sửa</button></router-link>
                                <a @click="dialogThanhToan=true" v-on:click="getJobOffer(item.jobOfferId)">Thanh Toán</a>
                            </div>
                            </template>
                            <template v-if="item.trangThaiId == 3 || item.trangThaiId == 4">
                                <div class="items-link f-right">
                                <a>Đã Thanh Toán</a>
                                <span>Ngày: {{item.ngayDang}}</span>
                            </div>
                            </template>
                        </div>
                    </div>
                </div>
            </div>
        </section>
<footer-user/>

<!-- Dialog Thanh Toán -->
<v-dialog v-model="dialogThanhToan" width="1000">
      <v-card>
        <div class="container">
  <div class="py-5 text-center">
    <h2>Thanh Toán</h2>
    <p class="lead">Cảm ơn bạn đã tin tưởng chúng tôi. Chỉ còn 1 bước nữa thôi là bạn đã hoàn tất đơn tyển nhân viên giúp việc rồi.</p>
  </div>

  <div class="row">
    <div class="col-md-4 order-md-2 mb-4">
      <h4 class="d-flex justify-content-between align-items-center mb-3">
        <span class="text-muted">Công việc</span>
      </h4>
      <ul class="list-group mb-3">
        <li class="list-group-item d-flex justify-content-between lh-condensed">
          <div>
            <h6 class="my-0">{{tenCVTT}}</h6>
            <small class="text-muted">{{motaCVTT}}</small>
          </div>
        </li>
        <li class="list-group-item d-flex justify-content-between lh-condensed">
          <div>
            <h6 class="my-0">Công ty giúp việc nhà DNU</h6>
            <small class="text-muted">Uy tín tạo nên niềm tin</small>
          </div>
        </li>
        <li class="list-group-item d-flex justify-content-between">
          <span>Tổng tiền phải trả</span>
          <strong>{{giaCVTT}} Vnđ</strong>
        </li>
      </ul>

      <h4 class="d-flex justify-content-between align-items-center mb-3">
        <span class="text-muted">Ghi Chú</span>
      </h4>
      <div class="col-md-12 mb-3">
            <label for="firstName">Ghi chú thông tin</label>
            <textarea v-model="ghiChu" type="text" class="form-control" placeholder="Nhập ghi chú..."></textarea>
          </div>
    </div>

    <div class="col-md-8 order-md-1">
      <h4 class="mb-3">Thông Tin</h4>
      <form class="needs-validation" style="margin-bottom:50px" novalidate>
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="firstName">Họ Tên</label>
            <input type="text" v-model="tenKh" class="form-control" id="firstName" placeholder="" required>
            <div class="invalid-feedback">
             Thông tin không được để trống.
            </div>
          </div>
          <div class="col-md-6 mb-3">
            <label for="lastName">Điện thoại</label>
            <input type="text" v-model="phoneKh" class="form-control" id="lastName" required>
            <div class="invalid-feedback">
              Thông tin không được để trống.
            </div>
          </div>
        </div>

        <div class="mb-3">
          <label for="email">Email</label>
          <input type="email" v-model="emailKh" class="form-control" id="email" placeholder="you@example.com">
          <div class="invalid-feedback">
            Vui lòng nhập địa chỉ email hợp lệ.
          </div>
        </div>

        <div class="mb-3">
          <label for="address">Địa chỉ</label>
          <input type="text" v-model="adressKh" class="form-control" id="address" required>
          <div class="invalid-feedback">
            Vui lòng nhập địa chỉ email hợp lệ.
          </div>
        </div>

        <h4 class="mb-3">Hình Thức Thanh Toán</h4>
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="name-pay">Hiện tại chỉ hỗ trợ loại hình thanh toán này</label>
          <input type="text" class="form-control" id="name-pay" readonly value="Thanh toán tại công ty">
          <div class="invalid-feedback">
            Vui lòng chọn hình thức thanh toán.
          </div>
          </div>
        </div>
        <hr class="mb-4">
        <v-card-actions>
          <v-spacer></v-spacer>
          <a class="btn btn-green btn-block" v-on:click="addPayMent()">Thanh Toán</a>
          <a @click="dialogThanhToan = false" class="btn btn-danger">Thoát</a>
        </v-card-actions>
        <!-- <button class="btn btn-primary btn-lg btn-block" type="submit">Thanh Toán</button>
        <button class="btn btn-danger" type="submit">Thoát</button> -->
      </form>
    </div>
  </div>
</div>
      </v-card>
    </v-dialog>

</body>
</template>

<script>
import axios from 'axios';
import HeaderUser from '../components/HeaderUser.vue';
import FooterUser from '../components/FooterUser.vue';
export default {
name:'App',
components:{
HeaderUser,
FooterUser
},
data(){
  return{
    idCus:sessionStorage.getItem('id'),
    tenKh:sessionStorage.getItem('fullname'),
    emailKh:sessionStorage.getItem('email'),
    adressKh:sessionStorage.getItem('address'),
    phoneKh:sessionStorage.getItem('phone'),
    dialogThanhToan:false,
    list:[],
    listTrangThai:[],
    listJob:[],
    listJobOffer:[],
    jobOfferIdTT:0,
    tenCVTT:"",
    giaCVTT:"",
    motaCVTT:"",
    ghiChu:""
  }
},
async mounted(){
let resultJob = await axios.get("https://localhost:44354/api/Job");
this.listJob = resultJob.data;

let resultTrangThai = await axios.get("https://localhost:44354/api/TrangThai");
this.listTrangThai = resultTrangThai.data;

let resultListOffer = await axios.get("https://localhost:44354/api/JobOffer");
console.warn("api data", resultListOffer.data);
this.list = resultListOffer.data;

for(var i = 0; i < this.list.length; i++){
            if(this.idCus==this.list[i].customerId){
                this.listJobOffer.push(this.list[i]);
            }
        }

},
methods:{
async getJobOffer(id){
  this.jobOfferIdTT = id;
    let resultJobOffer = await axios.get(`https://localhost:44354/api/JobOffer/${id}`);
    let resultJob = await axios.get(`https://localhost:44354/api/Job/${resultJobOffer.data.jobId}`);
    this.tenCVTT = resultJob.data.tenCv;
    this.giaCVTT = resultJob.data.giaDiscount;
    this.motaCVTT = resultJob.data.moTaNgan;
    console.log("Mã công việc: ",resultJob.data);
  },
  logout(){
    this.$router.push('/');
    sessionStorage.clear();
  },
async addPayMent(){
  
  var ngayDang = new Date();
  var ngayTT = (ngayDang.getMonth() + 1)+"-"+ngayDang.getDate()+"-"+ngayDang.getFullYear();
  console.log("Đã click",this.jobOfferIdTT,ngayTT,this.giaCVTT,this.ghiChu);
  let resultThanhToan = await axios.post("https://localhost:44354/api/JobPayment",{
  jobOfferId: this.jobOfferIdTT,
  paymentId: 1,
  trangThai: true,
  ngayTt:ngayTT,
  tongTien: String(this.giaCVTT),
  note: this.ghiChu
        });

let getJobOffer = await axios.get(`https://localhost:44354/api/JobOffer/${this.jobOfferIdTT}`);
var trangThai=0;
if(getJobOffer.data.staffId==2){
trangThai = 3;
} else trangThai = 4;
let resultUpdateOffer = await axios.put(`https://localhost:44354/api/JobOffer/${this.jobOfferIdTT}`,{
  jobOfferId:this.jobOfferIdTT,
  jobId: getJobOffer.data.jobId,
  customerId: getJobOffer.data.customerId,
  staffId: getJobOffer.data.staffId,
  trangThaiId: trangThai,
  ngayDang: getJobOffer.data.ngayDang,
  ngayBdlam: getJobOffer.data.ngayBdlam,
  gia: String(getJobOffer.data.gia),
  note: getJobOffer.data.note
        });

if(resultThanhToan.status==201 & resultUpdateOffer.status==204){
    alert("Thanh toán thành công!");
    this.dialogThanhToan==false;
    location.reload();
    } else alert("Lỗi! Thanh toán không thành công!");
  }
}
}
</script>

<style>
.company-img img{
    width: 100px !important;
    height: 100px !important;
}
</style>