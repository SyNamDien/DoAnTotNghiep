<template>
  <body>
       <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full"
           data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">
        <staff-sidebar/>
           <div class="page-wrapper">
           <div class="container-fluid">
            <div class="row">
				<div class="col-lg-4 p-2">
					<div class="card">
						<div class="card-body">
							<div class="d-flex flex-column align-items-center text-center">
								<img :src="anhUser" class="rounded-circle p-1 bg-primary" width="110">
								<div class="mt-3">
									<h4>{{fullname}}</h4>
									<p class="text-secondary mb-1">Email: {{email}}</p>
									<p class="text-muted font-size-sm">Điện thoại: {{phoneUser}}</p>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="col-lg-8">
					<div class="card">
						<div class="card-body">
                            <div class="thong-ke row mb-3 text-center text-white">
								<div class="col-sm-3 all-viec">
                                    <h4>{{tongCv}}</h4>
									<h6 class="mb-0">Số việc đã làm</h6>
								</div>
                                <div class="col-sm-3 da-ht">
                                    <h4>{{cvHoanthanh}}</h4>
									<h6 class="mb-0">Đã hoàn thành</h6>
								</div>
                                <div class="col-sm-3 dang-lam">
                                    <h4>{{cvDangLam}}</h4>
									<h6 class="mb-0">Đang làm</h6>
								</div>
							</div>

							<div class="row mb-3">
								<div class="col-sm-3">
									<h6 class="mb-0">Đang làm</h6>
								</div>
								<div class="col-sm-3 rounded text-center text-secondary dang-lam">
									<h6 class="mb-0 text-white">{{tiendanglam}} VNĐ</h6>
								</div>
							</div>
                            <div class="row mb-3">
								<div class="col-sm-3">
									<h6 class="mb-0">Khả dụng</h6>
								</div>
								<div class="col-sm-3 rounded text-secondary text-center da-ht">
									<h6 class="mb-0 text-white">{{khadung}} VNĐ</h6>
								</div>
							</div>
							<div class="row mb-3">
								<div class="col-sm-3">
									<h6 class="mb-0">Tổng thu nhập</h6>
								</div>
								<div class="col-sm-3 rounded text-center text-secondary all-viec">
									<h6 class="mb-0 text-white">{{tongTien}} VNĐ</h6>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="row">
				<div class="col-sm-12">
					<h4 class="d-flex align-items-center mb-3">Thống Kê Thu Nhập</h4>
					<div class="card">
						<div class="card-body">
							<div class="row mb-3">
                                <div class="row col-sm-6">
                                    <div class="col-lg-3">
                                        <h6 class="mt-2">Từ ngày:</h6>
                                    </div>
                                    <div class="col-lg-3">
                                        <input v-model="tungay" type="date" class="form-control"/>
                                    </div>
                                    <div class="col-lg-3">
                                        <h6 class="mt-2">đến ngày:</h6>
                                    </div>
                                    <div class="col-lg-3">
                                        <input v-model="denngay" type="date" class="form-control"/>
                                    </div>
                                </div>
								<div class="col-sm-3">
									<a v-on:click="getThongKe()" class="mb-0 btn btn-primary text-white">Xem thống kê</a> |
                                    <a v-on:click="clearFillter()" class="mb-0 btn btn-primary text-white">Xem tất cả</a>
								</div>
							</div>
						</div>
						<div v-if="all==true" class="card">
                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">Tên Công Việc</th>
                                            <th scope="col">Ngày làm</th>
                                            <th scope="col">Giá tiền</th>
                                            <th scope="col">Trạng thái</th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="item in listJobOfferStaff" :key="item.jobOfferId">
                                        <tr>
                                            <td><div v-for="job in listJob" :key="job"><div v-if="item.jobId == job.jobId">{{job.tenCv}}</div></div></td>
                                            <td>{{item.ngayBdlam}}</td>
                                            <td>{{item.gia}} VNĐ</td>
                                            <td><div v-for="t in listTrangThai" :key="t"><div v-if="item.trangThaiId == t.trangThaiId">{{t.trangThaiName}}</div></div></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        <div v-if="fillter==true" class="card">
                            <div class="table-responsive">
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">Tên Công Việc</th>
                                            <th scope="col">Ngày làm</th>
                                            <th scope="col">Giá tiền</th>
                                            <th scope="col">Trạng thái</th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="item in listJobOfferStaff2" :key="item.jobOfferId">
                                        <tr>
                                            <td><div v-for="job in listJob" :key="job"><div v-if="item.jobId == job.jobId">{{job.tenCv}}</div></div></td>
                                            <td>{{item.ngayBdlam}}</td>
                                            <td>{{item.gia}} VNĐ</td>
                                            <td><div v-for="t in listTrangThai" :key="t"><div v-if="item.trangThaiId == t.trangThaiId">{{t.trangThaiName}}</div></div></td>
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
       </div>
   </body>
</template>

<script>
import axios from 'axios';
import StaffSidebar from '@/components/StaffSidebar.vue';
export default {
name:"App",
components:{
StaffSidebar
},
data(){
    return{
    all:true,
    fillter:false,
    staffId:0,
    tongCv:0,
    cvDangLam:0,
    cvHoanthanh:0,
    tongTien:0,
    khadung:0,
    tiendanglam:0,
    fullname:sessionStorage.getItem('fullname'),
    email:sessionStorage.getItem('email'),
    anhUser:sessionStorage.getItem('anhUser'),
    phoneUser:sessionStorage.getItem('phone'),
    password:sessionStorage.getItem('password'),
    listJobOffer:[],
    staff:[],
    listJobOfferStaff:[],
    listJobOfferStaff2:[],
    listJob:[],
    listTrangThai:[],
    tungay: null,
    denngay: null
    }
},
async mounted(){
let resultJob =  await axios.get("https://localhost:44354/api/Job");
this.listJob = resultJob.data;

let resultTrangThai =  await axios.get("https://localhost:44354/api/TrangThai");
this.listTrangThai = resultTrangThai.data;

let resultStaff =  await axios.get("https://localhost:44354/api/Staff");
this.staff = resultStaff.data;
for(var j = 0; j < this.staff.length; j++){
            if(this.email==this.staff[j].email & this.password==this.staff[j].password){
                this.staffId = this.staff[j].staffId;
            }
        }
console.log("Ta có mã NV là:",this.staffId);
let resultJobOffer =  await axios.get("https://localhost:44354/api/JobOffer");
this.listJobOffer = resultJobOffer.data;
for(var i = 0; i < this.listJobOffer.length; i++){
            if(this.staffId==this.listJobOffer[i].staffId){
                this.tongCv=this.tongCv+1;
                this.tongTien=this.tongTien+parseInt(this.listJobOffer[i].gia);
                this.listJobOfferStaff.push(this.listJobOffer[i]);
                if(this.listJobOffer[i].trangThaiId==2 || this.listJobOffer[i].trangThaiId==4){
                    this.cvDangLam=this.cvDangLam+1;
                    this.tiendanglam=this.tiendanglam+parseInt(this.listJobOffer[i].gia);
                }
                if(this.listJobOffer[i].trangThaiId==5){
                    this.cvHoanthanh=this.cvHoanthanh+1;
                    this.khadung=this.khadung+parseInt(this.listJobOffer[i].gia);
                }
            }
        }
console.log("listJobOfferStaff:",this.listJobOfferStaff);
console.log("listJob:",this.listJob);
console.log("listTrangthai:",this.listTrangThai);
},

methods:{
 getThongKe(){
    this.listJobOfferStaff2 = [];
    if(this.tungay !=null || this.denngay!=null){
        if(this.tungay<this.denngay){
        this.all = false;
        this.fillter = true;
        for(var i = 0; i < this.listJobOfferStaff.length; i++){
            if(this.tungay<=this.listJobOfferStaff[i].ngayBdlam & this.listJobOfferStaff[i].ngayBdlam<= this.denngay){
                this.listJobOfferStaff2.push(this.listJobOfferStaff[i]);
            }
        }
    }
    if(this.tungay>this.denngay){
        this.all = false;
        this.fillter = true;
        for(var j = 0; j < this.listJobOfferStaff.length; j++){
            if(this.tungay>=this.listJobOfferStaff[j].ngayBdlam & this.listJobOfferStaff[j].ngayBdlam>= this.denngay){
                this.listJobOfferStaff2.push(this.listJobOfferStaff[j]);
            }
        }
    }
    if(this.tungay==this.denngay){
        this.all = false;
        this.fillter = true;
        for(var y = 0; y < this.listJobOfferStaff.length; y++){
            if(this.tungay==this.listJobOfferStaff[y].ngayBdlam){
                this.listJobOfferStaff2.push(this.listJobOfferStaff[y]);
            }
        }
    }
} else alert("Bạn chưa chọn ngày! Vui lòng chọn ngày và thử lại");
    },
    clearFillter(){
        this.fillter = false;
        this.all = true;
    }
}
}
</script>

<style>
body{
    background: #f7f7ff;
}
.card {
    position: relative;
    display: flex;
    flex-direction: column;
    min-width: 0;
    word-wrap: break-word;
    background-color: #fff;
    background-clip: border-box;
    border: 0 solid transparent;
    border-radius: .25rem;
    margin-bottom: 1.5rem;
    box-shadow: 0 2px 6px 0 rgb(218 218 253 / 65%), 0 2px 6px 0 rgb(206 206 238 / 54%);
}
.me-2 {
    margin-right: .5rem!important;
}
.all-viec{
    background-color: #7ec72f;
    padding: 10px;
}
.da-ht{
    background-color: #3366FF;
    padding: 10px;
}
.dang-lam{
    background-color: #ffa529;
    padding: 10px;
}
.thong-ke div{
    margin: 10px !important;
}
</style>