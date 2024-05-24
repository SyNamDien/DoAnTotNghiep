<template>
  <body>
    <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full"
      data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">
      <!-- Side bar menu components -->
      <admin-sidebar />

      <div class="page-wrapper">
        <div class="container-fluid">
          <div class="row">
            <div class="col-12">
              <div class="card">
                <!-- <div class="card-body">
                  <h4 class="card-title">Danh Sách Công Việc</h4>
                  <div>
                    <a v-on:click="dialogAdd = true" class="btn btn-green">Thêm Việc</a>
                  </div>
                </div> -->
                <div class="table-responsive">

                  <table class="table">
                    <thead class="thead-light">
                      <tr>
                        <th scope="col">STT</th>
                        <th scope="col">Mã Đơn Tuyển Giúp Việc</th>
                        <th scope="col">Hình thức thanh toán</th>
                        <th scope="col">Ngày Thanh Toán</th>
                        <th scope="col">Tổng Tiền</th>
                        <th scope="col">Ghi Chú</th>
                      </tr>
                    </thead>
                    <tbody v-for="(item, index) in listJobPayment" :key="item.jobPaymentId">
                      <tr>
                        <th>{{ index + 1 }}</th>
                        <td>
                          <v-btn @click="dialogTNV = true" v-on:click="getJobOffer(item.jobOfferId)" color="primary">Xem Đơn
                            {{ item.jobOfferId }}</v-btn>
                        </td>
                        <td>
                          <div v-for="pay in listPay" v-bind:key="pay">
                            <span v-if="item.paymentId == pay.paymentId">
                              <h5>{{ pay.paymentName }}</h5>
                            </span>
                          </div>
                        </td>
                        <td>{{ item.ngayTt }}</td>
                        <td>{{ item.tongTien }} VNĐ</td>
                        <td></td>
                      </tr>
                      <v-btn @click="handlePayment(item)">Thanh toán</v-btn>
                    </tbody>
                  </table>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Dialog xem chi tiết đơn tuyển nhân viên -->
    <v-row justify="center">
      <v-dialog v-model="dialogTNV" width="1200">
        <v-card>
          <v-card-title class="text-h5">
            Chi Tiết Đơn Tuyển Nhân Viên - Mã Đơn {{ JobOffer.jobOfferId }}
          </v-card-title>
          <v-card-text>
            <v-container>
              <v-row>
                <v-col cols="12" sm="2" md="2"><img :src="Customer.avatar" class="img-thumbnail" alt="Cinque Terre"
                    width="80" height="80"></v-col>

                <v-col cols="12" sm="3" md="3">
                  <v-card-text>
                    Tên Khách Hàng: <h5>{{ Customer.tenKh }}</h5>
                  </v-card-text>
                </v-col>

                <v-col cols="12" sm="3" md="3">
                  <v-card-text>
                    Điện thoại: <h5>{{ Customer.phone }}</h5>
                  </v-card-text>
                </v-col>

                <v-col cols="12" sm="6" md="4">
                  <v-card-text>
                    Địa chỉ: <h5>{{ Customer.diachi }}</h5>
                  </v-card-text>
                </v-col>

              </v-row>
              <v-spacer></v-spacer>
              <v-row>
                <v-col cols="12" sm="2" md="2"><img :src="Staff.avatar" class="img-thumbnail" alt="Cinque Terre"
                    width="80" height="80">
                </v-col>
                <v-col cols="12" sm="3" md="3">
                  <v-card-text>
                    Nhân Viên: <h5>{{ Staff.tenNv }}</h5>
                  </v-card-text>
                </v-col>

                <v-col cols="12" sm="3" md="3">
                  <v-card-text>
                    Điện thoại: <h5>{{ Staff.phone }}</h5>
                  </v-card-text>
                </v-col>

                <v-col cols="12" sm="6" md="4">
                  <v-card-text>
                    Email: <h5>{{ Staff.email }}</h5>
                  </v-card-text>
                </v-col>

              </v-row>

              <v-row>
                <v-col cols="12" sm="6" md="4">
                  <v-card-text>
                    Công Việc: <h5>{{ Job.tenCv }}</h5>
                  </v-card-text>
                </v-col>

                <v-col cols="12" sm="6" md="4">
                  <v-card-text>
                    Giá: <h5>{{ JobOffer.gia }} VNĐ</h5>
                  </v-card-text>
                </v-col>

                <v-col cols="12" sm="6" md="4">
                  <v-card-text>
                    Ngày Bắt Đầu Làm: <h5>{{ JobOffer.ngayBdlam }}</h5>
                  </v-card-text>
                </v-col>

              </v-row>

              <v-row>
                <v-col cols="12" sm="12" md="12">
                  <v-card-text>
                    Ghi Chú: <v-textarea variant="outlined" :value="JobOffer.note"></v-textarea>
                  </v-card-text>
                </v-col>

              </v-row>

            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="green-darken-1" variant="text" @click="dialogTNV = false">
              Thoát
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
  </body>
</template>

<script>
import AdminSidebar from '@/components/AdminSidebar.vue';
import axios from 'axios';
export default {
  name: "App",
  components: {
    AdminSidebar
  },
  data() {
    return {
      dialogTNV: false,
      listJobPayment: [],
      listJob: [],
      listCustomers: [],
      listPay: [],
      Job: {
        jobId: 0,
        maDm: 0,
        tenCv: '',
        giaGoc: 0,
        giaDiscount: 0,
        congTy: '',
        moTaNgan: '',
        moTaDai: '',
        thoiGianLam: '',
        trangThai: null
      },
      Customer: {
        customerId: 0,
        tenKh: "",
        ngaysinh: "",
        gioiTinh: "",
        avatar: "",
        diachi: "",
        phone: "",
        email: "",
        password: "",
        memberShip: 0,
        roleId: 0
      },
      JobOffer: {
        jobOfferId: 0,
        jobId: 0,
        customerId: 0,
        staffId: 0,
        trangThaiId: 0,
        ngayDang: "",
        ngayBdlam: "",
        gia: "",
        note: ""
      },
      Staff: {
        staffId: 0,
        tenNv: "",
        ngaysinh: "",
        gioiTinh: "",
        avatar: "",
        diachi: "",
        phone: "",
        email: "",
        password: "",
        ngayVaoCty: "",
        soCvdaLam: 0,
        staffPoint: 0,
        danhGia: "",
        roleId: 0
      }
    }
  },
  async mounted() {
    try {
      let resultJobPayment = await axios.get("https://localhost:44354/api/JobPayment");
      this.listJobPayment = resultJobPayment.data;
      console.log("Danh sách thanh toán: ", this.listJobPayment);
    }
    catch (error) {
      console.error("Lỗi khi tải danh sách thanh toán: ", error);
    }
    let resultJob = await axios.get("https://localhost:44354/api/Job");
    this.listJob = resultJob.data;
    let resultCustomers = await axios.get("https://localhost:44354/api/Customers");
    this.listCustomers = resultCustomers.data;
    let resultPay = await axios.get("https://localhost:44354/api/Payment");
    this.listPay = resultPay.data;
  },
  methods: {
    async handlePayment(item) {
      try {
        // Gửi yêu cầu POST đến backend
        let response = await axios.post(`https://localhost:44354/api/JobPayment`, item);
        console.log("Thanh toán thành công: ", response.data);
      } catch (error) {
        console.error("Lỗi khi thực hiện thanh toán: ", error.response ? error.response.data : error.message);
      }
    },

    async fetchJobPayments() {
      let resultJobPayment = await axios.get("https://localhost:44354/api/JobPayment");
      this.listJobPayment = resultJobPayment.data;
      console.log("Danh sách thanh toán: ", this.listJobPayment);
    },

    async createJobPayment() {
      try {
        // Lấy thông tin cần thiết từ các nguồn dữ liệu khác hoặc từ người dùng
        let jobOfferId = this.JobOffer.jobOfferId; // Ví dụ: lấy từ JobOffer hiện tại
        let totalAmount = this.JobOffer.gia; // Ví dụ: lấy từ JobOffer hiện tại
        let ngayTt = new Date().toISOString().slice(0, 10); // Ngày thanh toán hiện tại

        let jobPaymentData = {
          jobOfferId: jobOfferId,
          tongTien: totalAmount,
          ngayTt: ngayTt,
          // ... (Các trường dữ liệu khác của JobPayment)
        };

        let response = await axios.post("https://localhost:44354/api/JobPayment", jobPaymentData);
        this.listJobPayment.push(response.data);
        console.log("JobPayment created:", response.data);
      } catch (error) {
        console.error("Lỗi khi tạo JobPayment:", error);
      }
    },
    async getJobOffer(id) {
      let resultJobOffer = await axios.get(`https://localhost:44354/api/JobOffer/${id}`);
      this.JobOffer = resultJobOffer.data;
      console.log("Thông tin JobOffre: ", this.JobOffer);

      let idJob = this.JobOffer.jobId;
      let idKH = this.JobOffer.customerId;
      let idStaff = this.JobOffer.staffId;

      let resultJob = await axios.get(`https://localhost:44354/api/Job/${idJob}`);
      this.Job = resultJob.data;
      console.log("Job là: ", this.Job)

      let resultCus = await axios.get(`https://localhost:44354/api/Customers/${idKH}`);
      this.Customer = resultCus.data;
      console.log("Khách hàng là: ", this.Customer)

      let resultStaff = await axios.get(`https://localhost:44354/api/Staff/${idStaff}`);
      this.Staff = resultStaff.data;
      console.log("Nhân viên là: ", this.Staff)
    }
  }
}
</script>

<style></style>