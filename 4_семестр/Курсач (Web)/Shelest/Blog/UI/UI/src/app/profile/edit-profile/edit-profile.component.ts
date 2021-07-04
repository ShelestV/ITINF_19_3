import { Component, Input, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.services';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() User:any;

  UserName:string="";
  UserLogin:string="";
  UserBirthDate:string="";
  UserEmail:string="";
  UserPhoto:number=0;

  ngOnInit(): void {
    this.UserName=this.User["Name"];
    this.UserLogin=this.User["Login"];
    this.UserBirthDate=this.User["BirthDate"];
    this.UserEmail=this.User["Email"];
    this.UserPhoto=this.User["Photo"];
  }

  edit() {
    var val = {
      Login:this.UserLogin,
      Name:this.UserName,
      BirthDate:this.UserBirthDate,
      Email:this.UserEmail,
      Photo:this.UserPhoto
    };

    this.service.updateUser(val);
    alert("User information has been updated");
  }

  getPath(image:number):string {
    return this.service.getImageSource(image);
  }

  chooseImage(image:number) {
    this.UserPhoto=image;
  }
}
