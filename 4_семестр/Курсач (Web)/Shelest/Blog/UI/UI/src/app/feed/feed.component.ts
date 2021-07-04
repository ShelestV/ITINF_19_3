import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { SharedService } from '../shared.services';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css']
})
export class FeedComponent implements OnInit {

  constructor(private service:SharedService, private cookie:CookieService) { 
    this.CurrentUser=this.service.CurrentUser;
  }

  FeedList:any=[];
  CurrentUser:any;

  IsEditPost:boolean=false;
  IsAdmin:boolean=false;

  ngOnInit(): void {
    this.refreshFeedList();
    this.CurrentUser=this.service.getCurrentUser();
    this.IsAdmin=this.cookie.get("CurrentUserRole")=="ADMIN";
  }

  refreshFeedList() {
    alert("refresh data");
    this.service.getAllPost().subscribe(data=>{
      this.FeedList=data;
    });
  }
  
  getPhotoPath(fileName:string):string {
    return this.service.PhotoUrl+fileName;
  }

  like(post:string, reaction:string) {
    var like=true;

    if (reaction=="1") {
      this.service.deletePostReaction(post);
    } else if (reaction=="0") {
      this.service.deletePostReaction(post);
      this.service.addPostReaction({
        Post:post,
        Reaction:like
      });
    }
    else {
      this.service.addPostReaction({
        Post:post,
        Reaction:like
      });
    }
    
    this.refreshFeedList();
  }

  dislike(post:string, reaction:string) {
    var dislike=false;

    if (reaction=="0") {
      this.service.deletePostReaction(post);
    } else if (reaction=="1") {
      this.service.deletePostReaction(post);
      this.service.addPostReaction({
        Post:post,
        Reaction:dislike
      });
    }
    else {
      this.service.addPostReaction({
        Post:post,
        Reaction:dislike
      });
    }

    this.refreshFeedList();
  }

  getPath(PhotoFileName:number):string {
    return this.service.getImageSource(PhotoFileName);
  }

  closeClick() {
    this.IsEditPost=false;
  }

  editPost() {
    this.IsEditPost=true;
  }

  deletePost(id:string) {
    this.service.deletePost(id);
    this.refreshFeedList();
  }
}
