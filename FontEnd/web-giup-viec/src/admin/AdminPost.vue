<template>
  <body>
    <div id="main-wrapper" data-layout="vertical" data-navbarbg="skin5" data-sidebartype="full"
        data-sidebar-position="absolute" data-header-position="absolute" data-boxed-layout="full">
    <admin-sidebar/>

    <div class="page-wrapper">
        <div class="container-fluid">
        <div class="row">
            <div class="col-12 mt-4">
                <!-- Section Tittle -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="section-tittle text-center">
                            <h4>DANH SÁCH TIN TỨC</h4>
                            <button class="btn btn-themnv" @click="(dialogAddPost=true)">Thêm Tin Tức</button>
                        </div>
                    </div>
                </div>
                <div class="single-job-items mb-30 bg_post mt-6" v-for="item in listPost" :key="item.postId">
                    <div class="job-items">
                        <div class="company-img">
                        <a href="#"><img :src="item.anh" alt=""></a>
                        </div>
                    <div class="job-tittle">
                        <a href="#">
                            <h4>{{item.title}}</h4>
                        </a>
                        <ul>
                             <li>Mô tả ngắn: {{item.moTaNgan}}</li>
                             <li>Tác giả: {{item.tacGia}}</li>
                             <li>Hiển thị: <input type="checkbox" v-model="item.trangThai"></li>
                        </ul>
                    </div>
                    </div>
                    <div class="items-link items-link2 f-right">
                        <btn class="btn btn-green" @click="(dialogSuaPost=true)" v-on:click="getPost(item.postId)">Sửa</btn>|  <btn @click="(dialogXacNhanXoa=true)" v-on:click="getIdPost(item.postId)" class="btn btn-danger">Xóa</btn>
                            <span>Ngày đăng: {{item.ngayDang}}</span>
                        </div>
                    </div>
                </div>
                </div>
                </div>
                </div>

    </div>
<!-- Thêm Post -->
    <template>
  <v-row justify="center">
    <v-dialog
      v-model="dialogAddPost"
      persistent>
      <v-card>
            <v-toolbar
              color="primary"
            ><v-card-title>
          <span class="text-h5">Thêm Tin Tức</span>
        </v-card-title>
    </v-toolbar>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col
                cols="12"
                sm="6"
                md="4">
                <v-text-field
                  label="Tiêu đề"
                  v-model="title"
                  required
                ></v-text-field>
              </v-col>
              <v-col
                cols="12"
                sm="6"
                md="4">
                <v-text-field
                  label="Tác giả"
                  v-model="tacGia"
                ></v-text-field>
              </v-col>
              <v-col
                cols="12"
                sm="6"
                md="4">
                <v-text-field
                  type="date"
                  label="Ngày đăng"
                  v-model="ngayDang"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  label="Mô tả ngắn"
                  v-model="moTaNgan"
                  required
                ></v-text-field>
              </v-col>
              <v-col
                cols="12">
            <v-textarea
            solo
            label="Mô tả chi tiết"
            v-model="moTaDai"
            required
            ></v-textarea>
            </v-col>
              <v-col
                cols="12"
                sm="4">
              <v-checkbox
            v-model="trangThai"
            label="Hiển thị tin này"
            color="primary"
            hide-details
          ></v-checkbox>
              </v-col>
              <v-col
                cols="12"
                sm="8">
    <div class="d-flex flex-column justify-space-between align-center">
    <v-slider
      v-model="width"
      class="align-self-stretch"
      min="200"
      max="500"
      step="1"
    ></v-slider>
    <v-img
      :width="width"
      :src="previewImage"
      cover
    ></v-img>
    <input class="mt-4" accept=".jpg,.png" ref="fileInput" type="file" @input="pickFile"/>
    <input class="btn btn-green" @click="uploadImageFirebase" value="Upload"/>
    </div>
        </v-col>
        </v-row>
        </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="blue-darken-1"
            variant="text"
            class="btn btn-green"
            @click="addPostNew">
            Thêm
          </v-btn>
          
          <v-btn
            color="blue-darken-1"
            variant="text"
            @click="dialogAddPost = false"
            class="btn btn-primary"
          >
            Close
          </v-btn>
          
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<!-- Xem Sửa post -->
<template>
  <v-row justify="center">
    <v-dialog
      v-model="dialogSuaPost"
      persistent>
      <v-card>
            <v-toolbar
              color="primary"
            ><v-card-title>
          <span class="text-h5">Thêm Tin Tức</span>
        </v-card-title>
    </v-toolbar>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col
                cols="12"
                sm="6"
                md="4">
                <v-text-field
                  label="Tiêu đề"
                  v-model="title"
                  required
                ></v-text-field>
              </v-col>
              <v-col
                cols="12"
                sm="6"
                md="4">
                <v-text-field
                  label="Tác giả"
                  v-model="tacGia"
                ></v-text-field>
              </v-col>
              <v-col
                cols="12"
                sm="6"
                md="4">
                <v-text-field
                  type="date"
                  label="Ngày đăng"
                  v-model="ngayDang"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field
                  label="Mô tả ngắn"
                  v-model="moTaNgan"
                  required
                ></v-text-field>
              </v-col>
              <v-col
                cols="12">
            <v-textarea
            solo
            label="Mô tả chi tiết"
            v-model="moTaDai"
            required
            ></v-textarea>
            </v-col>
              <v-col
                cols="12"
                sm="4">
              <v-checkbox
            v-model="trangThai"
            label="Hiển thị tin này"
            color="primary"
            hide-details
          ></v-checkbox>
              </v-col>
              <v-col
                cols="12"
                sm="8">
    <div class="d-flex flex-column justify-space-between align-center">
    <v-slider
      v-model="width"
      class="align-self-stretch"
      min="200"
      max="500"
      step="1"
    ></v-slider>
    <v-img
      :width="width"
      :src="previewImage"
      cover
    ></v-img>
    <input class="mt-4" accept=".jpg,.png" ref="fileInput" type="file" @input="pickFile"/>
    <input class="btn btn-green" @click="uploadImageFirebase" value="Upload"/>
    </div>
        </v-col>
        </v-row>
        </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="blue-darken-1"
            variant="text"
            class="btn btn-green"
            @click="editPost"
            >
            Lưu
          </v-btn>
          
          <v-btn
            color="blue-darken-1"
            variant="text"
            @click="dialogSuaPost = false"
            class="btn btn-primary"
          >
            Close
          </v-btn>
          
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>

<!-- Xóa tin -->
<v-dialog v-model="dialogXacNhanXoa" width="700">
      <v-card >
        <h2 class="m-2 text-center"> Xác Nhận Xóa</h2>
        <h4 class="text-danger text-center">Bạn có chắc muốn xóa tin này?</h4>
        <v-card-actions>
          <v-spacer></v-spacer>
          <a v-on:click="xoaPost()" @click="dialogXacNhanXoa = false" class="btn btn-danger">Xóa</a>
          <a @click="dialogXacNhanXoa = false" class="btn btn-green">Close</a>
        </v-card-actions>
      </v-card>
    </v-dialog>

  </body>
</template>

<script>
import { getStorage, ref, uploadBytes,deleteObject} from "firebase/storage";
import AdminSidebar from '../components/AdminSidebar.vue'
import axios from 'axios';
export default {
name:"App",
components: { AdminSidebar },
data(){
    return{
        dialogXacNhanXoa:false,
        dialogSuaPost:false,
        dialogViewSP:false,
        previewImage:"",
        anhcu:"",
        width:300,
        dialogAddPost:false,
        listPost:[],
        postId: 0,
        title: "",
        moTaNgan: "",
        moTaDai: "",
        tacGia: "",
        ngayDang: "",
        trangThai: null,
        selectedFile:null
    }
    
  },
async mounted(){
let resultPost = await axios.get("https://localhost:44354/api/Post");
this.listPost = resultPost.data;
console.log("List post:",this.listPost);
  },
  methods:{
//Hàm xóa file cũ trong firebase:
deletedFilebase(linkanh){
if(linkanh!=null && linkanh!="" && linkanh != this.previewImage){
const storage = getStorage();
const desertRef = ref(storage,linkanh);
deleteObject(desertRef).then(() => {
  console.error("File deleted successfully")
}).catch((error) => {
  console.error("Error: ",error)
});
}
},

//Upload ảnh lên Firebase Storage
uploadImageFirebase(){
      const storage = getStorage();
      var fileName = this.selectedFile.name;
    const storageRef = ref(storage,"post/"+fileName);
    uploadBytes(storageRef, this.selectedFile).then((snapshot) => {
      const progress = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
    console.log('Upload is ' + progress + '% done');
      alert('Upload ảnh thành công!');
      this.previewImage = "https://firebasestorage.googleapis.com/v0/b/vue-upload-91ec4.appspot.com/o/post%2F"+fileName+"?alt=media&token=180669a3-be5e-4e62-8c5c-51e44c6f2581"
      console.error("Link anh: ",this.previewImage)
        });
        },
    pickFile (event) {
      this.selectedFile = event.target.files[0];
      },

//Lấy id post
getIdPost(id){
this.postId=id;
    },
async xoaPost(){
    try{
        let xoaKH = await axios.delete(`https://localhost:44354/api/Post/${this.postId}`);
    if(xoaKH.status ==204){
      alert("Xóa tin thành công!");
    location.reload();
    } else alert("Xóa tin không thành công!");
    }catch{
        alert("Đã có lỗi xảy ra! Xóa tin không thành công!");
    }
    
  },

async getPost(id){
        let resultPost = await axios.get(`https://localhost:44354/api/Post/${id}`);
        this.postId = id;
        this.title = resultPost.data.title;
        this.moTaNgan=resultPost.data.moTaNgan;
        this.moTaDai=resultPost.data.moTaDai;
        this.tacGia=resultPost.data.tacGia;
        this.ngayDang=resultPost.data.ngayDang;
        this.trangThai=resultPost.data.trangThai;
        this.previewImage=resultPost.data.anh;
        this.anhcu = this.previewImage;
  },
async editPost(){
    try{
      this.deletedFilebase(this.anhcu);
        let resultPost = await axios.put(`https://localhost:44354/api/Post/${this.postId}`,{
        postId:this.postId,
        title: this.title,
        moTaNgan: this.moTaNgan,
        moTaDai: this.moTaDai,
        tacGia: this.tacGia,
        ngayDang: this.ngayDang,
        trangThai: this.trangThai,
        anh: this.previewImage
        });
    if(resultPost.status==204){
        alert("Sửa tin thành công!");
        this.dialogSuaPost=false;
        location.reload();
    } else alert("Đã có lỗi xảy ra! Sửa tin không thành công!");
    } catch {
        alert("Đã có lỗi xảy ra! Sửa tin không thành công!");
    }
    
  },

async addPostNew(){
        if(this.title =="" ||this.moTaNgan== "" ||this.moTaDai== "" ||this.tacGia== ""||this.ngayDang== ""||this.trangThai==null||this.previewImage== ""){
            alert("Trống! Bạn không được để trống thông tin!");
        } else{
let result = await axios.post("https://localhost:44354/api/Post",{
        title: this.title,
        moTaNgan: this.moTaNgan,
        moTaDai: this.moTaDai,
        tacGia: this.tacGia,
        ngayDang: this.ngayDang,
        trangThai: this.trangThai,
        anh: this.previewImage
        });
if(result.status==201){
    alert("Thêm tin thành công!");
    this.dialogAddPost=false;
    location.reload();
        }
      }
    },
  },
}
</script>

<style>
.btn-themnv{
    background-color: #4CAF50;
  border: none;
  color: white;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 14px;
}
.company-img img{
    width: 150px;
    height: 150px;
}
.bg_post{
    border-radius: 15px;
    background: linear-gradient(90deg, rgba(12,108,230,0.37608546836703427) 0%, rgba(0,255,89,0.2976540958180147) 100%);
}
</style>