import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.services';

@Component({
  selector: 'app-edit-post',
  templateUrl: './edit-post.component.html',
  styleUrls: ['./edit-post.component.css']
})
export class EditPostComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() Post:any;
  PostText:string="";

  ngOnInit(): void {
  }

  edit() {
    this.service.updatePost({
      ID:this.Post.ID,
      Text:this.PostText
    });
  }
}
