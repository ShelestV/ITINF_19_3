import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.services';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.css']
})
export class AddPostComponent implements OnInit {

  constructor(private service:SharedService) { }

  PostText:string="";

  ngOnInit(): void {

  }

  post() {
    this.service.applyNewPost({
      Text:this.PostText
    });
    alert("Your post has been post :)");
  }
}
