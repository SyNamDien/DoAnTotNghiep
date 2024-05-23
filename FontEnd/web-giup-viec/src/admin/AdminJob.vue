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
                                <h4 class="card-title">Danh Sách Công Việc</h4>
                                <div>
                                    <a v-on:click="dialogAdd=true" class="btn btn-green">Thêm Việc</a>
                                </div>
                            </div>
                            <div class="table-responsive">
                                
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">STT</th>
                                            <th scope="col">Tên Công Việc</th>
                                            <th scope="col">Giá gốc</th>
                                            <th scope="col">Thời gian làm</th>
                                            <th scope="col">Trạng thái</th>
                                            <th scope="col"></th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="(item,index) in listJob" :key="item.jobId">
                                        <tr>
                                            <th>{{index+1}}</th>
                                            <td>{{item.tenCv}}</td>
                                            <td>{{item.giaGoc}}</td>
                                            <td>{{item.thoiGianLam}}</td>
                                            <td><input type="checkbox" v-model="item.trangThai"/></td>
                                            <td><v-btn
                                                @click="dialogView=true"
                                                v-on:click="getJob(item.jobId)"
                                                color="primary"
                                                icon="mdi-pencil"
                                                size="small"
                                            ></v-btn></td>
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

<!-- Dialog sửa việc làm -->
 <v-dialog v-model="dialogView" width="1200">
      <v-card >
        <h2 class="text-danger m-2 text-center"> Sửa Việc Làm</h2>
        <v-form v-model="valid" lazy-validation class="m-2">
            <form>
      <div class="form-group">
        <label for="exampleInputName">Tên Công Việc</label>
        <input v-model="tenCv" type="text" class="form-control">
      </div>
      <div class="form-row">
        <div class="form-group col-md-4">
        <label for="exampleInputEmail1" required="required">Giá Gốc</label>
        <input v-model="giaGoc" type="email" class="form-control">
        </div>
        <div class="form-group col-md-4">
        <label for="example-tel-input">Giá Đã Giảm</label>
          <input v-model="giaDiscount" class="form-control" type="text">
      </div>
      </div>
      <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputZip">Thời gian làm</label>
            <input v-model="thoiGianLam" type="text" class="form-control">
        </div>
        <div class="form-group col-md-4">
          <label for="inputZip">Tên Công Ty</label>
          <input v-model="congTy" type="text" class="form-control">
        </div>
      </div>
        <div class="form-group">
        <div class="form-group col-md-6">
        <label for="inputZip">Danh Mục</label>
          <v-combobox v-model="tenDM"
            label="Chọn việc"
            :items= listCBB
            ></v-combobox>
        </div>
      </div>
      <div class="form-group">
        <label for="inputZip">Mô Tả Ngắn</label>
          <textarea v-model="moTaNgan" type="text" class="form-control" placeholder="Mô tả ngắn..."></textarea>
        </div>
        <div class="form-group">
        <label for="inputZip">Mô Tả Dài</label>
          <textarea v-model="moTaDai" type="text" class="form-control" placeholder="Mô tả dài..."></textarea>
        </div>
        <div class="form-group">
        <v-switch
    v-model="trangThai"
    hide-details
    inset
    color="success"
    label="Hiển thị việc làm"
  ></v-switch>
  <v-alert v-if="showAlert==true" type="success">Sửa thông tin thành công.</v-alert>
</div>
    </form>
        </v-form>
        <v-card-actions>
          <v-spacer></v-spacer>
          <input v-on:click="updateJob()" class="btn btn-green" value="Sửa">
          <input @click="dialogView = false" class="btn text-danger" value="Close">
        </v-card-actions>
      </v-card>
    </v-dialog>

<!-- Dialog thêm việc làm -->
<v-dialog v-model="dialogAdd" width="1200">
      <v-card >
        <h2 class="text-danger m-2 text-center"> Thêm Việc Làm Mới</h2>
        <v-form v-model="valid" lazy-validation class="m-2">
            <form>
      <div class="form-group">
        <label for="exampleInputName">Tên Công Việc</label>
        <input v-model="tenCv" type="text" class="form-control">
      </div>
      <div class="form-row">
        <div class="form-group col-md-4">
        <label for="exampleInputEmail1" required="required">Giá Gốc</label>
        <input v-model="giaGoc" type="email" class="form-control">
        </div>
        <div class="form-group col-md-4">
        <label for="example-tel-input">Giá Đã Giảm</label>
          <input v-model="giaDiscount" class="form-control" type="text">
      </div>
      </div>
      <div class="form-row">
        <div class="form-group col-md-6">
            <label for="inputZip">Thời gian làm</label>
            <input v-model="thoiGianLam" type="text" class="form-control">
        </div>
        <div class="form-group col-md-4">
          <label for="inputZip">Tên Công Ty</label>
          <input v-model="congTy" type="text" class="form-control">
        </div>
      </div>
        <div class="form-group">
        <div class="form-group col-md-6">
        <label for="inputZip">Danh Mục</label>
          <v-combobox v-model="tenDM"
            label="Chọn việc"
            :items= listCBB
            ></v-combobox>
        </div>
      </div>
      <div class="form-group">
        <label for="inputZip">Mô Tả Ngắn</label>
          <textarea v-model="moTaNgan" type="text" class="form-control" placeholder="Mô tả ngắn..."></textarea>
        </div>
        <div class="form-group">
        <label for="inputZip">Mô Tả Dài</label>
          <textarea v-model="moTaDai" type="text" class="form-control" placeholder="Mô tả dài..."></textarea>
        </div>
        <div class="form-group">
        <v-switch
    v-model="trangThai"
    hide-details
    inset
    color="success"
    label="Hiển thị việc làm"
  ></v-switch>
  <v-alert v-if="showAdd==true" type="success">Thêm việc mới thành công.</v-alert>
  <v-alert v-if="showError==true" type="warning">Thông tin không được để trống.</v-alert>
</div>
    </form>
        </v-form>
        <v-card-actions>
          <v-spacer></v-spacer>
          <input v-on:click="addJob()" class="btn btn-green" value="Thêm">
          <input @click="dialogAdd = false" class="btn text-danger" value="Close">
        </v-card-actions>
      </v-card>
    </v-dialog>
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
        showAdd:false,
        showError:false,
        listJob:[],
        dialogAdd:false,
        dialogView:false,
        jobId: 0,
        maDm: 0,
        tenCv: "",
        giaGoc: 0,
        giaDiscount: 0,
        congTy: "",
        moTaNgan: "",
        moTaDai: "",
        thoiGianLam: "",
        trangThai: true,
        list:[],
        listCBB:[],
        tenDM:"",
        showAlert:false
}
},
async mounted() {
    let resultJob = await axios.get("https://localhost:44354/api/Job");
    this.listJob = resultJob.data;
    let resultDanhMuc = await axios.get("https://localhost:44354/api/DanhMuc");
    this.list = resultDanhMuc.data;
    for(var i = 0; i < this.list.length; i++){
            this.listCBB.push(this.list[i].tenDm);
        }
},
methods:{

async getJob(id){
let resultJob = await axios.get(`https://localhost:44354/api/Job/${id}`);
this.jobId = resultJob.data.jobId;
this.maDm = resultJob.data.maDm;
this.tenCv = resultJob.data.tenCv;
this.giaGoc = resultJob.data.giaGoc;
this.giaDiscount = resultJob.data.giaDiscount;
this.congTy = resultJob.data.congTy;
this.moTaNgan = resultJob.data.moTaNgan;
this.moTaDai = resultJob.data.moTaDai;
this.thoiGianLam = resultJob.data.thoiGianLam;
this.trangThai = resultJob.data.trangThai;

for(var i = 0; i < this.list.length; i++){
            if(this.maDm==this.list[i].maDm){
                this.tenDM = this.list[i].tenDm;
            }
        }
    console.log("Tên danh mục: ",this.tenDM)
    },

async updateJob(){
for(var i = 0; i < this.list.length; i++){
            if(this.tenDM==this.list[i].tenDm){
                this.maDm = this.list[i].maDm;
            }
        }
console.log("Mã danh mục new: ",this.maDm)
let updateJob = await axios.put(`https://localhost:44354/api/Job/${this.jobId}`,{
    jobId: this.jobId,
    maDm: this.maDm,
    tenCv: this.tenCv,
    giaGoc: this.giaGoc,
    giaDiscount: this.giaDiscount,
    congTy: this.congTy,
    moTaNgan: this.moTaNgan,
    moTaDai: this.moTaDai,
    thoiGianLam: this.thoiGianLam,
    trangThai: this.trangThai
    });
if(updateJob.status == 204){
    this.showAlert = true;
    setTimeout(()=>{
      this.showAlert=false
      this.dialogView=false
      location.reload()
    },2000)
} else alert("Sửa không thành công!")
},

async addJob(){
for(var i = 0; i < this.list.length; i++){
            if(this.tenDM==this.list[i].tenDm){
                this.maDm = this.list[i].maDm;
            }
        }
console.log("Mã danh mục new: ",this.maDm)
if(this.tenCv!="" & this.tenDM!="" & this.maDm!=""& this.giaGoc!=""& this.giaDiscount!=""& this.congTy!=""
& this.moTaNgan!=""& this.moTaDai!=""& this.thoiGianLam!=""){
    let addJob = await axios.post("https://localhost:44354/api/Job",{
    maDm: this.maDm,
    tenCv: this.tenCv,
    giaGoc: this.giaGoc,
    giaDiscount: this.giaDiscount,
    congTy: this.congTy,
    moTaNgan: this.moTaNgan,
    moTaDai: this.moTaDai,
    thoiGianLam: this.thoiGianLam,
    trangThai: this.trangThai
    });
if(addJob.status == 201){
    this.showAdd = true;
    setTimeout(()=>{
      this.showAdd=false
      this.dialogAdd=false
      location.reload()
    },2000)
} else alert("Thêm không thành công!")
} else {
    this.showError = true
    setTimeout(()=>{
      this.showError=false
    },2000)
}
}
//End methods
}
}
</script>

<style>

</style>