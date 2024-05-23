<template>
 <body>
    <header-user/>
     <!-- Hero Area Start-->
     <div class="slider-area ">
        <div class="single-slider section-overly slider-height2 d-flex align-items-center">
            <div class="container">
                <div class="row">
                    <div class="col-xl-12">
                        <div class="hero-cap text-center">
                            <h2>Tin Tức Mới Nhất</h2>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Hero Area End -->
    <!--================Blog Area =================-->
    <section class="blog_area section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 mb-5 mb-lg-0">
                    <div class="blog_left_sidebar">
                        <article v-for="item in listPost" v-bind:key="item.postId" class="blog_item">
                            <div class="blog_item_img">
                                <img class="card-img img_post rounded-0" :src="item.anh" alt="">
                                <a class="blog_item_date">
                                    <!-- <h3>15</h3> -->
                                    <p>{{item.ngayDang}}</p>
                                </a>
                            </div>

                            <div class="blog_details">
                                <router-link :to="{name:'PostDetail',params:{id:item.postId}}" > <a class="d-inline-block" href="single-blog.html">
                                    <h2>{{item.title}}</h2>
                                </a> </router-link>
                                <p>{{item.moTaNgan}}</p>
                                <ul class="blog-info-link">
                                    <li><a><i class="fa fa-user"></i>Tác giả: {{item.tacGia}}</a></li>
                                    <li><a><i class="fa fa-comments"></i> 03 Comments</a></li>
                                </ul>
                            </div>
                        </article>

                        <nav class="blog-pagination justify-content-center d-flex">
                            <ul class="pagination">
                                <li class="page-item">
                                    <a href="#" class="page-link" aria-label="Previous">
                                        <i class="ti-angle-left"></i>
                                    </a>
                                </li>
                                <li class="page-item">
                                    <a href="#" class="page-link">1</a>
                                </li>
                                <li class="page-item active">
                                    <a href="#" class="page-link">2</a>
                                </li>
                                <li class="page-item">
                                    <a href="#" class="page-link" aria-label="Next">
                                        <i class="ti-angle-right"></i>
                                    </a>
                                </li>
                            </ul>
                        </nav>
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
    name: 'App',
  components: { HeaderUser, FooterUser },
  data(){
    return{
        list:[],
        listPost:[],
        listPostRecent:[],
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
    console.log("Danh sach post gần đay:",this.listPostRecent);
  },

}
</script>

<style>
/* .img_post{
    width: 350px;
    height: 350px;
} */
.img_recent{
    width: 50px;
    height: 50px;
}
</style>