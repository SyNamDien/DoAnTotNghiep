<template>

    <body>
        <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full"
            data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">
            <!-- Side bar menu components -->
            <admin-sidebar />

            <div class="page-wrapper">
                <div class="container-fluid">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-12">
                                    <h4 class="card-title">BIỂU ĐỒ THỐNG KÊ</h4>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-3 col-3">
                                    <div class="small-box bg-success">
                                        <div class="inner">
                                            <h3>{{ totalStaff }}</h3>
                                            <div class="text-icon-container">
                                                <p>Nhân Viên</p>
                                                <i style="font-size: 30px;" class="mdi mdi-account-circle"></i>
                                            </div>
                                        </div>
                                        <div class="icon">
                                        </div>
                                        <a href="#" class="small-box-footer">More info <i
                                                class="fas fa-arrow-circle-right"></i></a>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-3">
                                    <div class="small-box bg-info">
                                        <div class="inner">
                                            <h3>{{ totalJobPerDay }}</h3>
                                            <div class="text-icon-container">
                                                <p>Đơn Tuyển Dụng Trong Ngày</p>
                                                <i style="font-size: 30px;" class="mdi mdi mdi-book-open"></i>
                                            </div>
                                        </div>
                                        <div class="icon">
                                        </div>
                                        <a href="#" class="small-box-footer">More info <i
                                                class="fas fa-arrow-circle-right"></i></a>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-3">
                                    <div class="small-box bg-info">
                                        <div class="inner">
                                            <h3>{{ jobPaymentPerDay }}</h3>
                                            <div class="text-icon-container">
                                                <p>Đơn Đã Thanh Toán Trong Ngày</p>
                                                <i style="font-size: 30px;" class="mdi mdi mdi-book-open"></i>
                                            </div>
                                        </div>
                                        <div class="icon">
                                        </div>
                                        <a href="#" class="small-box-footer">More info <i
                                                class="fas fa-arrow-circle-right"></i></a>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-3">
                                    <div class="small-box bg-warning">
                                        <div class="inner">
                                            <h3>{{ totalNews }}</h3>
                                            <div class="text-icon-container">
                                                <p>Số Tin Tức</p>
                                                <i style="font-size: 30px;" class="mdi mdi mdi-book-open"></i>
                                            </div>
                                        </div>
                                        <div class="icon">
                                        </div>
                                        <a href="#" class="small-box-footer">More info <i
                                                class="fas fa-arrow-circle-right"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                            <div class="card">
                                <div class="card-body">
                                    <h4 class="card-title">BIỂU ĐỒ THỐNG KÊ</h4>
                                </div>
                                <div>
                                    <GChart type="PieChart" :data="chartData" :options="chartOptions" />
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
import AdminSidebar from '../components/AdminSidebar.vue';
import { GChart } from 'vue-google-charts';
export default {
    name: 'App',
    components: {
        AdminSidebar,
        GChart
    },
    data() {
        return {
            listStaff: [],
            listJob: [],
            chartData: [
                ['Task', 'Hours per Day'],
                ['Số đơn chưa thanh toán', 0],
                ['Số đơn thanh toán', 0]
            ],
            totalJobPerDay: 0,
            jobPaymentPerDay: 0,
            totalNews: 0,
            totalStaff: 0,
            chartOptions: {
                title: 'Biểu Đồ',
                is3D: false,
                width: 800,
                height: 600,
            },
        }
    },
    async mounted() {
        let resultStaff = await axios.get("https://localhost:44354/api/Staff");
        console.warn("api data", resultStaff.data);
        this.listStaff = resultStaff.data;

        let resultJob = await axios.get("https://localhost:44354/api/Job");
        console.warn("api data", resultJob.data);
        this.listJob = resultJob.data;

        let resultJobOffer = await axios.get("https://localhost:44354/api/JobOffer/GetDashboard");
        if (resultJobOffer && resultJobOffer.status == 200) {
            let { data } = resultJobOffer;
            this.totalJobPerDay = data.totalJobPerDay;
            this.jobPaymentPerDay = data.jobPaymentPerDay;
            this.totalNews = data.totalNews;
            this.totalStaff = data.totalStaff;
            this.chartData = [
                ['Task', 'Hours per Day'],
                ['Số đơn chưa thanh toán', data.totalJob],
                ['Số đơn thanh toán', data.totalJobPayment]
            ]
        }
    },
    methods: {
        logout() {
            this.$router.push('/');
            sessionStorage.clear();
        }
    }
}
</script>

<style>
.bg-success,
.bg-success>a {
    color: #fff !important;
}

.bg-success {
    background-color: #28a745 !important;
}

.bg-info {
    background-color: #17a2b8 !important;
}

.bg-warning {
    background-color: #ffc107 !important;
}

.small-box {
    border-radius: .25rem;
    box-shadow: 0 0 1px rgba(0, 0, 0, .125), 0 1px 3px rgba(0, 0, 0, .2);
    display: block;
    margin-bottom: 20px;
    position: relative;
}

.small-box>.inner {
    padding: 10px;
}

.small-box .icon {
    color: rgba(0, 0, 0, .15);
    z-index: 0;
}

.small-box>.small-box-footer {
    background-color: rgba(0, 0, 0, .1);
    color: rgba(255, 255, 255, .8);
    display: block;
    padding: 3px 0;
    position: relative;
    text-align: center;
    text-decoration: none;
    z-index: 10;
}

.small-box .inner {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
}

.text-icon-container {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
}

.text-icon-container p {
    margin: 0;
    color: white;
    flex-grow: 1;
}

.text-icon-container .mdi-account {
    color: white;
    font-size: 24px;
}

.small-box .icon {
    display: none;
}
</style>