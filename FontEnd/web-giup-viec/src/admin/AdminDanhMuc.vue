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
                                    <a v-on:click="dialogView=true" class="btn btn-green">Thêm Danh Mục</a>
                                </div>
                            </div>
                            <div class="table-responsive">
                                
                                <table class="table">
                                    <thead class="thead-light">
                                        <tr>
                                            <th scope="col">STT</th>
                                            <th scope="col">Tên Danh Mục</th>
                                            <th scope="col">Mô Tả</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody v-for="(item,index) in listDM" :key="item.maDm">
                                        <tr>
                                            <th>{{index+1}}</th>
                                            <td>{{ item.tenDm }}</td>
                                            <td>{{item.mota}}</td>
                                            <td><v-btn
                                               @click="dialogViewEdit=true"
                                               v-on:click="getDM(item.maDm)"
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
   <!-- Dialog Danh Mục -->
   <v-dialog v-model="dialogView" width="1200">
      <v-card >
        <h2 class="text-danger m-2 text-center"> Thêm Danh Mục</h2>
        <v-form v-model="valid" lazy-validation class="m-2">
            <form class="form-register">

<div class="form-outline mb-4">
<label class="form-label" for="form3Example1cg">Tên Danh Mục</label>
  <input type="text" v-model="tenDm" class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
<label class="form-label" for="form3Example1cg">Mô Tả Danh Mục</label>
<textarea v-model="mota" class="form-control form-control-lg" required></textarea>
</div>
</form>
<v-alert v-if="showAlert==true" type="success">Thêm thành công.</v-alert>
<v-alert v-if="showAlertError==true" type="warning">Thông tin không được để trống.</v-alert>
        </v-form>
        <v-card-actions>
          <v-spacer></v-spacer>
          <a v-on:click="addDanhMuc" class="btn btn-green">Thêm</a>
          <a @click="dialogView = false" class="btn btn-red">Close</a>
        </v-card-actions>
      </v-card>
    </v-dialog>

 <!-- Dialog Sửa Danh Mục -->
 <v-dialog v-model="dialogViewEdit" width="1200">
      <v-card >
        <h2 class="text-danger m-2 text-center"> Sửa Danh Mục</h2>
        <v-form v-model="valid" lazy-validation class="m-2">
            <form class="form-register">

<div class="form-outline mb-4">
<label class="form-label" for="form3Example1cg">Tên Danh Mục</label>
  <input type="text" id="form3Example1cg" v-model="tenDm" class="form-control form-control-lg" required />
</div>

<div class="form-outline mb-4">
<label class="form-label" for="form3Example1cg">Mô Tả Danh Mục</label>
<textarea type="date" id="form3Example1cg" v-model="mota" class="form-control form-control-lg" required></textarea>
</div>
</form>
<v-alert v-if="showAlert==true" type="success">Sửa thành công.</v-alert>
<v-alert v-if="showAlertError==true" type="warning">Thông tin không được để trống.</v-alert>
        </v-form>
        <v-card-actions>
          <v-spacer></v-spacer>
          <a v-on:click="editDanhMuc(maDm)" class="btn btn-green">Sửa</a>
          <a @click="dialogViewEdit = false" class="btn btn-red">Close</a>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </body>
</template>

<script>
import AdminSidebar from '@/components/AdminSidebar.vue';
import axios from 'axios';
export default {
name:"App",
components:{
AdminSidebar
},
data(){
    return{
        showAlertError:false,
        dialogViewEdit:false,
        showAlert:false,
        listDM:[],
        dialogView:false,
        maDm:"",
        tenDm:"",
        mota:""
    }
},
async mounted(){
    let resultDM = await axios.get("https://localhost:44354/api/DanhMuc");
    this.listDM = resultDM.data;
},

methods:{
async getDM(id){
    let resultDM = await axios.get(`https://localhost:44354/api/DanhMuc/${id}`);
    this.maDm = id;
    this.tenDm = resultDM.data.tenDm;
    this.mota = resultDM.data.mota;
    },
//Thêm DM
async addDanhMuc(){
    if(this.tenDm!="" & this.mota!=""){
        let addDM = await axios.post("https://localhost:44354/api/DanhMuc",{
        tenDm: this.tenDm,
        mota:this.mota
    });
if(addDM.status==201){
    this.showAlert = true;
    setTimeout(()=>{
      this.showAlert=false
      location.reload();
    },2000)
      } else alert("Lỗi! Thêm không thành công!");
    } else{
    this.showAlertError = true;
    setTimeout(()=>{
      this.showAlertError=false
    },2000)
    }
    },
//Sửa DM
async editDanhMuc(id){
    if(this.tenDm!="" & this.mota!=""){
    let addDM = await axios.put(`https://localhost:44354/api/DanhMuc/${id}`,{
        maDm: id,
        tenDm: this.tenDm,
        mota:this.mota
    });
if(addDM.status==204){
    this.showAlert = true;
    setTimeout(()=>{
      this.showAlert=false
      location.reload();
    },2000)
      } else alert("Lỗi! Sửa không thành công!");
    } else {
    this.showAlertError = true;
    setTimeout(()=>{
      this.showAlertError=false
    },2000)
    }
},
}
}
</script>

<style>

</style>