<template>
   <!-- Blog Area Start -->
   <div class="home-blog-area blog-h-padding">
            <div class="container">
                <!-- Section Tittle -->
                <div class="row">
                    <div class="col-lg-12">
                        <div class="section-tittle text-center">
                            <h2>TIN TỨC</h2>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div v-for="item in listPost" v-bind:key="item.postId" class="col-xl-6 col-lg-6 col-md-6">
                        <router-link :to="{name:'PostDetail',params:{id:item.postId}}" > 
                        <div class="home-blog-single mb-30">
                            <div class="blog-img-cap">
                                <div class="blog-img">
                                    <img :src="item.anh" alt="">
                                    <!-- Blog date -->
                                    <div class="blog-date text-center">
                                        <span>{{item.ngayDang}}</span>
                                        <!-- <p>Now</p> -->
                                    </div>
                                </div>
                                <div class="blog-cap">
                                    <p>|   Tác giả: {{item.tacGia}}</p>
                                    <h3><a>{{item.title}}</a></h3>
                                    <a class="more-btn">Xem thêm »</a>
                                </div>
                            </div>
                        </div></router-link>
                    </div>
                </div>
            </div>
        </div>
        <!-- Blog Area End -->
</template>

<script>
import axios from 'axios';
export default {
data(){
  return{
    list:[],
    listPost:[]
  }
},
async mounted(){
let resultPost = await axios.get("https://localhost:44354/api/Post");
this.list = resultPost.data;
for(var i = 0; i < 2; i++){
    this.listPost.push(this.list[i]);
        }
console.log("Danh sách post: ",this.listPost);
},
}
</script>

<style>

</style>