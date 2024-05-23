import { createRouter, createWebHashHistory } from 'vue-router'
//Client router
import HomeView from '../views/HomeView.vue'
import Login from '../views/Login.vue'
import Register from '../views/Register.vue'
import JobOffer from '../views/JobOffer.vue'
import EditJobOffer from '../views/EditJobOffer.vue'
import ListJobOffer from '../views/ListJobOffer.vue'
import ListPost from '../views/ListPost.vue'
import PostDetail from '../views/PostDetail.vue'
import ProfileUser from '../views/ProfileUser.vue'
import ContactView from '../views/ContactView.vue'

//Admin router
import AdminDashboard from '../admin/AdminDashboard.vue'
import Admin_JobOffer from '../admin/Admin_JobOffer.vue'
import AdminNhanVien from '../admin/AdminNhanVien.vue'
import AdminPost from '../admin/AdminPost.vue'
import AdminProfile from '../admin/AdminProfile.vue'
import AdminRole from '../admin/AdminRole.vue'
import AdminJob from '../admin/AdminJob.vue'
import AdminJobPayment from '../admin/AdminJobPayment.vue'
import AdminDanhMuc from '../admin/AdminDanhMuc.vue'

//Staff router
import StaffHome from '../staff/StaffHome.vue'
import StaffThuNhap from '../staff/StaffThuNhap.vue'
import StaffProfile from '../staff/StaffProfile.vue'
const routes = [
  {
    path: '/',
    name: 'home',
    component: HomeView
  },
  {
    path: '/profile_user',
    name: 'ProfileUser',
    component: ProfileUser
  },
  {
    path: '/login',
    name: 'login',
    component: Login
  },
  {
    path: '/register',
    name: 'Register',
    component: Register
  },
  {
    path: '/job_offer',
    name: 'JobOffer',
    component: JobOffer
  },
  {
    path: '/edit_job_offer/:id',
    name: 'EditJobOffer',
    component: EditJobOffer
  },
  {
    path: '/list_job_offer',
    name: 'ListJobOffer',
    component: ListJobOffer
  },
  {
    path: '/list_post',
    name: 'ListPost',
    component: ListPost
  },
  {
    path: '/post_detail/:id',
    name: 'PostDetail',
    component: PostDetail
  },
  {
    path: '/contact',
    name: 'ContactView',
    component: ContactView
  },

  //Router admin
  {
    path: '/admin_dashboard',
    name: 'AdminDashboard',
    component: AdminDashboard
  },
  {
    path: '/admin_joboffer',
    name: 'Admin_JobOffer',
    component: Admin_JobOffer
  },
  {
    path: '/admin_nhanvien',
    name: 'AdminNhanVien',
    component: AdminNhanVien
  },
  {
    path: '/admin_post',
    name: 'AdminPost',
    component: AdminPost
  },
  {
    path: '/admin_profile',
    name: 'AdminProfile',
    component: AdminProfile
  },
  {
    path: '/admin_role',
    name: 'AdminRole',
    component: AdminRole
  },
  {
    path: '/admin_job',
    name: 'AdminJob',
    component: AdminJob
  },
  {
    path: '/admin_list_payment',
    name: 'AdminJobPayment',
    component: AdminJobPayment
  },
  {
    path: '/admin_danh_muc',
    name: 'AdminDanhMuc',
    component: AdminDanhMuc
  },

  //Router Staff
  {
    path: '/staff_home',
    name: 'staffhome',
    component: StaffHome
  },
  {
    path: '/staff_thu_nhap',
    name: 'StaffThuNhap',
    component: StaffThuNhap
  },
  {
    path: '/staff_profile',
    name: 'StaffProfile',
    component: StaffProfile
  },

  {
    path: '/about',
    name: 'about',
    component: () => import(/* webpackChunkName: "about" */ '../views/AboutView.vue')
  }
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
