<template>
  <body>
    <section class="vh-100">
  <div class="container-fluid h-custom">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-md-9 col-lg-6 col-xl-5">
        <img src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.webp"
          class="img-fluid" alt="Sample image">
      </div>
      <div class="col-md-8 col-lg-6 col-xl-4 offset-xl-1">
        <form>
          <div class="d-flex flex-row align-items-center justify-content-center justify-content-lg-start">
            <p class="lead fw-normal mb-0 me-3">Đăng nhập với</p>
            <button type="button" class="btn btn-primary btn-floating mx-1">
              <i class="fab fa-facebook-f"></i>
            </button>

            <button type="button" class="btn btn-primary btn-floating mx-1">
              <i class="fab fa-twitter"></i>
            </button>

            <button type="button" class="btn btn-primary btn-floating mx-1">
              <i class="fab fa-linkedin-in"></i>
            </button>
          </div>

          <div class="divider d-flex align-items-center my-4">
            <p class="text-center fw-bold mx-3 mb-0">Or</p>
          </div>

          <!-- Email input -->
          <div class="form-outline mb-4">
            <label class="form-label" for="form3Example3">Email</label>
            <input type="email" v-model="email" id="form3Example3" class="form-control form-control-lg" required/>
          </div>

          <!-- Password input -->
          <div class="form-outline mb-3">
            <label class="form-label" for="form3Example4">Password</label>
            <input type="password" v-model="password" id="form3Example4" class="form-control form-control-lg" required/>
          </div>

          <div class="d-flex justify-content-between align-items-center">
            <!-- Checkbox -->
            <div class="form-check mb-0">
              <input class="form-check-input me-2" type="checkbox" value="" id="form2Example3" />
              <label class="form-check-label" for="form2Example3">
               Nhớ mật khẩu
              </label>
            </div>
            <a href="#!" class="text-body">Quên mật khẩu?</a>
          </div>

          <div class="text-center text-lg-start mt-4 pt-2">
            <button v-on:click="login" type="button" class="btn btn-primary btn-lg"
              style="padding-left: 2.5rem; padding-right: 2.5rem;">Login</button>
            <p class="small fw-bold mt-2 pt-1 mb-0">Bạn chưa có tài khoản? <router-link to="/register"><a class="text-body h6"><strong>Đăng ký</strong></a></router-link></p>
          </div>

        </form>
      </div>
    </div>
  </div>
</section>
  </body>
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
        email:"",
        password:""
    }
  },
  methods:{
    async login(){
        console.warn("Data: ", this.email,this.password);
        let result = await axios.get(`https://localhost:44354/api/Customers/${this.email}&${this.password}`);
        this.list = result.data;
        console.log(this.list.email,this.password);
        if(result.status ==200){
          var roleId = this.list.roleId;
            sessionStorage.setItem('id',this.list.customerId);
            sessionStorage.setItem('fullname',this.list.tenKh);
            sessionStorage.setItem('email',this.list.email);
            sessionStorage.setItem('password',this.list.password);
            sessionStorage.setItem('address',this.list.diachi);
            sessionStorage.setItem('phone',this.list.phone);
            sessionStorage.setItem('anhUser',this.list.avatar);
            if(roleId==1){
              alert('Đăng nhập thành công!');
            this.$router.push('/admin_dashboard');
            } 
            if(roleId ==2){
              alert('Đăng nhập thành công!');
            this.$router.push('/staff_home');
            } 
            if(roleId ==3) {
              alert('Đăng nhập thành công!');
            this.$router.push('/');
            }
            
        }else alert('Đăng nhập thất bại! Kiểm tra lại thông tin đăng nhập')
    },
  }
}
</script>

<style>
.divider:after,
.divider:before {
content: "";
flex: 1;
height: 1px;
background: #eee;
}
.h-custom {
height: calc(100% - 73px);
margin-top: 150px;
}
@media (max-width: 450px) {
.h-custom {
height: 100%;
}
}
</style>