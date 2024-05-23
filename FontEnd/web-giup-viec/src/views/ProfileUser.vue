<template>
  <body>
      <header-user/>
    <div class="container">
  <div class="row">
      <div class="col-12">
        <!-- Page title -->
        <div class="my-5">
          <h3>Thông Tin Cá Nhân</h3>
          <hr>
        </div>
        <!-- Form START -->
        <form class="file-upload">
          <div class="row mb-5 gx-5">
            <!-- Contact detail -->
            <div class="col-xxl-8 mb-5 mb-xxl-0">
              <div class="bg-secondary-soft px-4 py-5 rounded">
                <div class="row g-3">
                  <h4 class="mb-4 mt-0">Chi tiết thông tin</h4>
                  <!-- First Name -->
                  <div class="col-md-6">
                    <label class="form-label">Họ và tên</label>
                    <input type="text" v-model="tenKh" class="form-control" placeholder="">
                  </div>
                  <!-- Điện thoại -->
                  <div class="col-md-6">
                    <label class="form-label">Điện thoại</label>
                    <input type="text" v-model="phoneKh" class="form-control" placeholder="" readonly>
                  </div>
                  <!-- Email -->
                  <div class="col-md-6">
                    <label class="form-label">Email</label>
                    <input type="text" v-model="emailKh" class="form-control" placeholder="" readonly>
                  </div>
                  <!-- Địa chỉ -->
                  <div class="col-md-6">
                    <label class="form-label">Địa chỉ</label>
                    <input type="text" v-model="addressKh" class="form-control" placeholder="">
                  </div>
                  <!-- Ngày sinh -->
                  <div class="col-md-4">
                    <label for="inputEmail4" class="form-label">Ngày sinh</label>
                    <input type="date" v-model="ngaysinh" class="form-control" id="inputEmail4">
                  </div>
                  <!-- Giới tính -->
                  <div class="col-md-4">
                    <label class="form-label">Giới tính</label>
                    <input type="text" v-model="gioiTinh" class="form-control" placeholder="">
                                      <div v-if="gioiTinh!='nam' && gioiTinh!='nữ' && gioiTinh!='khác'&& gioiTinh!='Nam' && gioiTinh!='Nữ' && gioiTinh!='Khác'" class="text-danger">Bạn chưa nhập đúng giới tính</div>
                  </div>
                                  <!-- Điểm TV -->
                  <div class="col-md-4">
                    <label class="form-label">Điểm thành viên</label>
                    <input type="text" v-model="diemTV" class="form-control" placeholder="" readonly>
                  </div>
                                  <div class="col-md-4">
                    <label class="btn btn-green" for="customFile" @click="dialogDoiMK=true">Đổi mật khẩu</label>
                  </div>
                </div> <!-- Row END -->
              </div>
            </div>
            <!-- Upload profile -->
            <div class="col-xxl-4">
              <div class="bg-secondary-soft px-4 py-5 rounded">
                <div class="row g-3">
                  <h4 class="mb-4 mt-0">Upload ảnh đại diện</h4>
                  <div class="text-center">
                    <!-- Image upload -->
        <v-col
                  cols="12"
                  sm="8">
      <div class="d-flex flex-column justify-space-between align-center">
      <v-slider v-model="width"
        class="align-self-stretch"
        min="200"
        max="500"
        step="1"></v-slider>
      <v-img :width="width" :src="anh" cover ></v-img>
      <input class="mt-4" accept=".jpg,.png" ref="fileInput" type="file" @input="pickFile"/>
      <input class="btn btn-green" @click="uploadImageFirebase" value="Upload"/>
      </div>
      <p class="text-muted mt-3 mb-0"><span class="me-1">*Lưu ý:</span>Kích thước tối thiểu 300px x 300px</p>
  </v-col>
                  </div>
                </div>
              </div>
            </div>
          </div> <!-- Row END -->
          <!-- button -->
          <div class="gap-3 d-md-flex justify-content-md-end text-center">
            <button type="button" v-on:click="updateProfile()" class="btn btn-primary btn-lg">Lưu thông tin</button>
          </div>
        </form> <!-- Form END -->
      </div>
    </div>
    </div>
  
      <!-- Đổi PW -->
  <v-dialog v-model="dialogDoiMK" width="1000">
      <v-card >
  <div class="row mb-5 gx-5">
            <!-- change password -->
            <div class="col-xxl-6">
              <div class="bg-secondary-soft px-4 py-5 rounded">
                <div class="row g-3">
                  <h4 class="my-4">Đổi mật khẩu</h4>
                  <!-- Old password -->
                  <div class="col-md-6">
                    <label for="exampleInputPassword1" class="form-label">Mật khẩu cũ*</label>
                    <input type="password" v-model="pwCu" class="form-control" id="exampleInputPassword1">
                  </div>
                  <!-- New password -->
                  <div class="col-md-6">
                    <label for="exampleInputPassword2" class="form-label">Mật khẩu mới*</label>
                    <input type="password" v-model="pwNew" class="form-control" id="exampleInputPassword2">
                  </div>
                  <!-- Confirm password -->
                  <div class="col-md-12">
                    <label for="exampleInputPassword3" class="form-label">Nhập lại mật khẩu mới*</label>
                    <input type="password" v-model="confirmPw" class="form-control" id="exampleInputPassword3">
                                      <div v-if="pwNew != confirmPw" class="text-danger">Mật khẩu chưa trùng nhau</div>
                  </div>
                </div>
              </div>
            </div>
          </div> <!-- Row END -->
              <v-card-actions>
            <v-spacer></v-spacer>
            <a @click="updatePassword" class="btn btn-green">Đổi mật khẩu</a>
            <a @click="dialogDoiMK = false" class="btn btn-danger">Close</a>
          </v-card-actions>
              </v-card>
  </v-dialog>
      <footer-user/>
  </body>
  </template>
  
  <script>
  import axios from 'axios';
  import HeaderUser from '@/components/HeaderUser.vue';
  import FooterUser from '@/components/FooterUser.vue';
  import { getStorage, ref, uploadBytes, deleteObject} from "firebase/storage";
  export default {
  name:'App',
  components:{
  HeaderUser,FooterUser
  },
  data(){
      return{
      width:300,
      idCus:sessionStorage.getItem('id'),
      roleId:0,
      tenKh:"",
      emailKh:"",
      addressKh:"",
      phoneKh:"",
      gioiTinh:"",
      ngaysinh:"",
      anh:"",
      diemTV:"",
      password:"",
      dialogDoiMK:false,
      pwCu:"",
      pwNew:"",
      confirmPw:"",
      list:[],
      staff:[],
      selectedFile:null,
      anhcu:''
      }
  },
  //Field data:
  async mounted(){
  let resultKH = await axios.get(`https://localhost:44354/api/Customers/${this.idCus}`);
  this.tenKh = resultKH.data.tenKh;
  this.emailKh = resultKH.data.email;
  this.addressKh = resultKH.data.diachi;
  this.phoneKh = resultKH.data.phone;
  this.gioiTinh = resultKH.data.gioiTinh;
  this.ngaysinh = resultKH.data.ngaysinh;
  this.anh = resultKH.data.avatar;
  this.anhcu = this.anh;
  this.password = resultKH.data.password;
  this.diemTV = resultKH.data.memberShip;
  this.roleId = resultKH.data.roleId;
  },
  methods:{
    //Selected file từ local
      pickFile (event) {
        this.selectedFile = event.target.files[0];
        },

//Upload ảnh lên Firebase Storage
uploadImageFirebase(){
      const storage = getStorage();
      var fileName = "user-"+this.selectedFile.name;
    const storageRef = ref(storage,fileName);
    uploadBytes(storageRef, this.selectedFile).then((snapshot) => {
      const progress = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
    console.log('Upload is ' + progress + '% done');
      alert('Upload ảnh thành công!');
      this.anh = "https://firebasestorage.googleapis.com/v0/b/vue-upload-91ec4.appspot.com/o/"+fileName+"?alt=media&token=89959e8e-5508-4e1b-b067-5d7cbeaed9c1"
      console.error("Link anh: ",this.anh)
        });
        },
  
  //Hàm xóa file cũ trong firebase:
  deletedFilebase(linkanh){
if(linkanh!=null && linkanh!="" && linkanh != this.anh){
const storage = getStorage();

const desertRef = ref(storage,linkanh);
deleteObject(desertRef).then(() => {
  console.error("File deleted successfully")
}).catch((error) => {
  console.error("Error: ",error)
});
}
},

  //Sửa thông tin người dùng nếu đây là tài khoản nhân viên sửa cả 2:
  async updateProfile(){
  this.deletedFilebase(this.anhcu);
  let resultStaff = await axios.get("https://localhost:44354/api/Staff");
  this.list = resultStaff.data;
  for(var i = 0; i < this.list.length; i++){
              if(this.emailKh==this.list[i].email & this.password==this.list[i].password){
                  this.staff =this.list[i];
              }
          }
  var idStaff = this.staff.staffId;
  console.log("Mã staff là: ",idStaff);
  console.log("staff là: ",this.staff);
  if(this.staff==""){
  let resultUpdateProfile = await axios.put(`https://localhost:44354/api/Customers/${this.idCus}`,{
    customerId: this.idCus,
    tenKh: this.tenKh,
    ngaysinh: this.ngaysinh,
    gioiTinh: this.gioiTinh,
    avatar: this.anh,
    diachi: this.addressKh,
    phone: this.phoneKh,
    email: this.emailKh,
    password: this.password,
    memberShip: this.diemTV,
    roleId: this.roleId
          });
  if(resultUpdateProfile.status==204){
      alert("Sửa thông tin thành công!");
      this.dialogThanhToan==false;
      sessionStorage.setItem('fullname',this.tenKh);
      sessionStorage.setItem('email',this.emailKh);
      sessionStorage.setItem('address',this.addressKh);
      sessionStorage.setItem('phone',this.phoneKh);
      sessionStorage.setItem('anhUser',this.list.avatar);
      location.reload();
      } else alert("Lỗi! Sửa thông tin không thành công!");
  
  } else {
  let resultUpdateProfile = await axios.put(`https://localhost:44354/api/Customers/${this.idCus}`,{
    customerId: this.idCus,
    tenKh: this.tenKh,
    ngaysinh: this.ngaysinh,
    gioiTinh: this.gioiTinh,
    avatar: this.anh,
    diachi: this.addressKh,
    phone: this.phoneKh,
    email: this.emailKh,
    password: this.password,
    memberShip: this.diemTV,
    roleId: this.roleId
          });
  let resultUpdateStaff = await axios.put(`https://localhost:44354/api/Staff/${idStaff}`,{
    staffId: this.staff.staffId,
    tenNv: this.tenKh,
    ngaysinh: this.ngaysinh,
    gioiTinh: this.gioiTinh,
    avatar: this.anh,
    diachi: this.addressKh,
    phone: this.phoneKh,
    email: this.emailKh,
    password: this.password,
    ngayVaoCty: this.staff.ngayVaoCty,
    soCvdaLam: this.staff.soCvdaLam,
    staffPoint: this.staff.staffPoint,
    danhGia:"0",
    roleId: this.staff.roleId
          });
  if(resultUpdateProfile.status==204 & resultUpdateStaff.status==204){
      alert("Sửa thông tin thành công!");
      this.dialogThanhToan==false;
      sessionStorage.setItem('fullname',this.tenKh);
      sessionStorage.setItem('email',this.emailKh);
      sessionStorage.setItem('address',this.addressKh);
      sessionStorage.setItem('phone',this.phoneKh);
      sessionStorage.setItem('anhUser',this.list.avatar);
      location.reload();
      } else alert("Lỗi! Sửa thông tin không thành công!");
  }
   },
//Check mật khẩu cũ
checkPassword(){
if(this.pwCu == this.password){
    return true
} else return false
},

//Update mật khẩu mới
async updatePassword(){
  if(this.checkPassword()==true){
  if(this.pwCu != this.pwNew){
    if(this.pwNew == this.confirmPw && this.pwNew !=""){
    this.deletedFilebase(this.anhcu);
  let resultStaff = await axios.get("https://localhost:44354/api/Staff");
  this.list = resultStaff.data;
  for(var i = 0; i < this.list.length; i++){
              if(this.emailKh==this.list[i].email & this.password==this.list[i].password){
                  this.staff =this.list[i];
              }
          }
  var idStaff = this.staff.staffId;
  console.log("Mã staff là: ",idStaff);
  console.log("staff là: ",this.staff);
  if(this.staff==""){
  let resultUpdateProfile = await axios.put(`https://localhost:44354/api/Customers/${this.idCus}`,{
    customerId: this.idCus,
    tenKh: this.tenKh,
    ngaysinh: this.ngaysinh,
    gioiTinh: this.gioiTinh,
    avatar: this.anh,
    diachi: this.addressKh,
    phone: this.phoneKh,
    email: this.emailKh,
    password: this.pwNew,
    memberShip: this.diemTV,
    roleId: this.roleId
          });
  if(resultUpdateProfile.status==204){
    alert("Đổi mật khẩu thành công!");
      this.dialogThanhToan==false;
      sessionStorage.setItem('fullname',this.tenKh);
      sessionStorage.setItem('email',this.emailKh);
      sessionStorage.setItem('address',this.addressKh);
      sessionStorage.setItem('phone',this.phoneKh);
      sessionStorage.setItem('anhUser',this.anh);
      sessionStorage.setItem('password',this.pwNew);
      location.reload();
      } else alert("Lỗi! Đổi mật khẩu không thành công!");
  
  } else {
  let resultUpdateProfile = await axios.put(`https://localhost:44354/api/Customers/${this.idCus}`,{
    customerId: this.idCus,
    tenKh: this.tenKh,
    ngaysinh: this.ngaysinh,
    gioiTinh: this.gioiTinh,
    avatar: this.anh,
    diachi: this.addressKh,
    phone: this.phoneKh,
    email: this.emailKh,
    password: this.pwNew,
    memberShip: this.diemTV,
    roleId: this.roleId
          });
  let resultUpdateStaff = await axios.put(`https://localhost:44354/api/Staff/${idStaff}`,{
    staffId: this.staff.staffId,
    tenNv: this.tenKh,
    ngaysinh: this.ngaysinh,
    gioiTinh: this.gioiTinh,
    avatar: this.anh,
    diachi: this.addressKh,
    phone: this.phoneKh,
    email: this.emailKh,
    password: this.pwNew,
    ngayVaoCty: this.staff.ngayVaoCty,
    soCvdaLam: this.staff.soCvdaLam,
    staffPoint: this.staff.staffPoint,
    danhGia:"0",
    roleId: this.staff.roleId
          });
  if(resultUpdateProfile.status==204 & resultUpdateStaff.status==204){
      alert("Đổi mật khẩu thành công!");
      this.dialogThanhToan==false;
      sessionStorage.setItem('fullname',this.tenKh);
      sessionStorage.setItem('email',this.emailKh);
      sessionStorage.setItem('address',this.addressKh);
      sessionStorage.setItem('phone',this.phoneKh);
      sessionStorage.setItem('anhUser',this.anh);
      sessionStorage.setItem('password',this.pwNew);
      location.reload();
      } else alert("Lỗi! Đổi mật khẩu không thành công!");
  }
    } else alert("Mật khẩu nhập lại chưa trùng nhau! Kiểm tra lại!")
  } else alert("Mật khẩu mới phải khác mật khẩu cũ!")
  } else alert("Mật khẩu cũ chưa đúng! Vui lòng kiểm tra lại!")
   }

   //End Methods
  }
  }
  </script>
  
  <style>
  
  </style>