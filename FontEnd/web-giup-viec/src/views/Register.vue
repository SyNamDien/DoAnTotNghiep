<template>
    <section class="vh-100 bg-image"
  style="background-image: url('https://mdbcdn.b-cdn.net/img/Photos/new-templates/search-box/img4.webp');">
  <div class="mask d-flex align-items-center h-100 gradient-custom-3">
    <div class="container h-100">
      <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-12 col-md-9 col-lg-7 col-xl-6">
          <div class="card" style="border-radius: 15px;">
            <div class="card-body p-5">
              <h2 class="text-uppercase text-center mb-5">Đăng ký tài khoản</h2>

              <form class="form-register">

                <div class="form-outline mb-4">
                <label class="form-label" for="form3Example1cg">Họ tên</label>
                  <input type="text" id="form3Example1cg" v-model="tenKh" class="form-control form-control-lg" required />
                  <div v-if="tenKh.length <3" class="text-danger">Bạn chưa nhập tên</div>
                </div>

                <div class="form-outline mb-4">
                    <label class="form-label" for="form3Example1cg">Ngày Sinh</label>
                  <input type="date" id="form3Example1cg" v-model="ngaysinh" class="form-control form-control-lg" required />
                  <div v-if="ngaysinh.length <3" class="text-danger">Bạn chưa chọn ngày sinh</div>
                </div>

                <div class="form-outline mb-4">
                    <label class="form-label" for="form3Example3cg"> Giới Tính</label>
                  <input type="text" id="form3Example3cg" v-model="gioiTinh" placeholder="Nam, Nữ, Khác" class="form-control form-control-lg" required />
                  <div v-if="gioiTinh!='nam' && gioiTinh!='nữ' && gioiTinh!='khác'&& gioiTinh!='Nam' && gioiTinh!='Nữ' && gioiTinh!='Khác'" class="text-danger">Bạn chưa nhập đúng giới tính</div>
                </div>

                <div class="form-outline mb-4">
                    <label class="form-label" for="form3Example3cg"> Địa Chỉ</label>
                  <input type="text" id="form3Example3cg" v-model="diachi" class="form-control form-control-lg" required />
                  <div v-if="diachi.length <3" class="text-danger">Bạn chưa nhập địa chỉ</div>
                </div>

                <div class="form-outline mb-4">
                    <label class="form-label" for="form3Example3cg">Điện Thoại</label>
                  <input type="phone" id="form3Example3cg" v-model="phone" class="form-control form-control-lg" required />
                  <div v-if="phone.length <9" class="text-danger">Nhập số điện thoại có 10 số</div>
                </div>

                <div class="form-outline mb-4">
                    <label class="form-label" for="form3Example3cg">Email</label>
                  <input type="email" id="form3Example3cg" v-model="email" class="form-control form-control-lg" required />
                  <div v-if="email.length <3" class="text-danger">Bạn chưa nhập email</div>
                </div>

                <div class="form-outline mb-4">
                    <label class="form-label" for="form3Example4cg">Password</label>
                  <input type="password" id="form3Example4cg" v-model="password" class="form-control form-control-lg" required />
                  <div v-if="password.length <6" class="text-danger">Mật khẩu phải chứa tối thiểu 6 ký tự</div>
                </div>

                <div class="form-outline mb-4">
                    <label class="form-label" for="form3Example4cdg">Nhập lại password</label>
                  <input type="password" v-model="reenterPassword" id="form3Example4cdg" class="form-control form-control-lg" required />
                  <div v-if="password != reenterPassword" class="text-danger">Mật khẩu chưa trùng nhau</div>
                </div>

                <div class="d-flex justify-content-center">
                  <button v-on:click="regisTer" type="button"
                    class="btn btn-success btn-block btn-lg gradient-custom-4 text-body">Đăng ký</button>
                </div>

                <p class="text-center text-muted mt-5 mb-0">Bạn đã có tài khoản? <router-link to="/login"><a
                    class="fw-bold text-body"><u>Đăng nhập</u></a></router-link></p>

              </form>

            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</section>
</template>

<script>
import axios from 'axios'
export default {
    name: 'App',
  components: {
    
  },
  data(){
    return{
      list:[],
    tenKh: "",
    ngaysinh: "",
    gioiTinh: "",
    avatar: null,
    diachi: "",
    phone: "",
    email: "",
    password: "",
    memberShip: 100,
    roleId: 3,
    reenterPassword:""
    }
  },
  methods:{
    async regisTer(){
        console.warn("Đã click",this.tenKh,this.ngaysinh,this.gioiTinh,this.diachi,this.phone,this.email,this.password);
        let resultCus = await axios.get("https://localhost:44354/api/Customers");
        this.list = resultCus.data;   
        var checkmail = false,checkphone=false;   
for(var i = 0; i < this.list.length; i++){
            if(this.email==this.list[i].email){
                checkmail=true;
            }
            if(this.phone==this.list[i].phone){
                checkphone=true;
            }
        }
        if(checkmail!=true){
          if(checkphone!=true){
            let result = await axios.post("https://localhost:44354/api/Customers",{
            tenKh:this.tenKh,
            ngaysinh:this.ngaysinh,
            gioiTinh:this.gioiTinh,
            avatar: null,
            diachi:this.diachi,
            phone:this.phone,
            email:this.email,
            password:this.password,
            memberShip: 100,
            roleId: 3
        });
        console.warn(result);
        if(result.status==201){
            alert("Đăng ký thành công!");
        }
        this.$router.push('/login');
          } else alert("Lỗi! Số điện thoại này đã tồn tại!")
        } else alert("Lỗi! Email này đã tồn tại!")
    }
  },
}
</script>

<style>
.form-register{
    margin-top:100px; 
}
.gradient-custom-3 {
/* fallback for old browsers */
background: #84fab0;

/* Chrome 10-25, Safari 5.1-6 */
background: -webkit-linear-gradient(to right, rgba(132, 250, 176, 0.5), rgba(143, 211, 244, 0.5));

/* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
background: linear-gradient(to right, rgba(132, 250, 176, 0.5), rgba(143, 211, 244, 0.5))
}
.gradient-custom-4 {
/* fallback for old browsers */
background: #84fab0;

/* Chrome 10-25, Safari 5.1-6 */
background: -webkit-linear-gradient(to right, rgba(132, 250, 176, 1), rgba(143, 211, 244, 1));

/* W3C, IE 10+/ Edge, Firefox 16+, Chrome 26+, Opera 12+, Safari 7+ */
background: linear-gradient(to right, rgba(132, 250, 176, 1), rgba(143, 211, 244, 1))
}
</style>