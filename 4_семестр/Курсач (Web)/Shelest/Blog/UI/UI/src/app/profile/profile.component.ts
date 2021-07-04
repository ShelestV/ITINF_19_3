import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from '../shared.services';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private service:SharedService, private route:ActivatedRoute) { }

  IsEdit:boolean=false;
  IsCurrentUser:boolean=false;
  IsNewPost:boolean=false;

  User:any;
  Login:string="";

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.Login = params['Login'];
      this.User=this.service.getUserByLogin(this.Login);
      this.IsCurrentUser=this.service.ActiveUser&&this.Login==this.service.getCurrentUser()["Login"];
    });
  }

  AddClick() {
    this.service.updateFriendship({Login:this.Login});
  }

  EditClick() {
    this.IsEdit=true;
  }

  AddPostClick() {
    this.IsNewPost=true;
  }

  closeClick() {
    this.IsEdit=false;
    this.IsNewPost=false;
    this.User=this.service.getUserByLogin(this.Login);
  }

  getPath():string {
    return this.service.getImageSource(this.User.Photo);
  }
}
