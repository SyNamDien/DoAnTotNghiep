<template>
<body>
    <header-user/>

    <section class="blog_area single-post-area section-padding">
      <div class="container">
         <div class="row">
            <div class="col-lg-8 posts-list">
               <div v-for="item in listPostId" :key="item.postId" class="single-post">
                  <div class="feature-img">
                     <img class="img-fluid " :src="item.anh" alt="">
                  </div>
                  <div class="blog_details">
                     <h2>{{item.title}}
                     </h2>
                     <ul class="blog-info-link mt-3 mb-4">
                        <li><a href="#"><i class="fa fa-user"></i>Người viết: {{item.tacGia}}</a></li>
                        <li><a href="#"><i class="fa fa-comments"></i> {{item.ngayDang}}</a></li>
                     </ul>
                     <b>{{item.moTaNgan}}</b>
                     <p class="excert">
                        {{item.moTaDai}}
                     </p>
                  </div>
               </div>
            </div>
            <div class="col-lg-4">
                    <div class="blog_right_sidebar">
                        <aside class="single_sidebar_widget popular_post_widget">
                            <h3 class="widget_title">Tin Gần Đây</h3>

                            <div v-for="item in listPost" v-bind:key="item.postId" class="media post_item">
                                <img class="img_recent" :src="item.anh" alt="post">
                                <div class="media-body">
                                    <router-link :to="{name:'PostDetail',params:{id:item.postId}}" ><a>
                                        <h3>{{item.title}}</h3>
                                    </a></router-link>
                                    <p>{{item.ngayDang}}</p>
                                </div>
                            </div>
                        </aside>
                    </div>
                </div>
         </div>
      </div>
   </section>
   <footer-user/>
</body>
</template>

<script>
import FooterUser from '../components/FooterUser.vue'
import HeaderUser from '../components/HeaderUser.vue'
import axios from 'axios';
export default {
    name:"App",
    components:{
        HeaderUser,
        FooterUser
    },
created(){
let postId = this.$route.params.id;
console.log("ID tin là: ",postId);
if(postId!=null){
    this.getPost(postId);
}
},

data(){
    return{
        postId:0,
        list:[],
        listPost:[],
        listPostId:[]
    }
},

async mounted() {
    let resultPost = await axios.get("https://localhost:44354/api/Post");
    this.list = resultPost.data;
    for(var i=0;i<this.list.length;i++){
        if(this.list[i].trangThai==true){
            this.listPost[i]=this.list[i];
        }
    }
    console.log("Danh sach post:",this.listPost);
  },
  methods:{
    async getPost(postId){
        let resultPost = await axios.get(`https://localhost:44354/api/Post/${postId}`);
        this.listPostId.push(resultPost.data);
        console.log("Tin theo ID: ",this.listPostId);
    }
  }
}
</script>

<style>
.img_post{
    width: 500px;
    height: 400px;
}
.img_recent{
    width: 50px;
    height: 50px;
}
</style>