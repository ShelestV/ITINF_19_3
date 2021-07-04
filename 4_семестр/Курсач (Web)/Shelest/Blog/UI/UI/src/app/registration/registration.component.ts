import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.services';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private service:SharedService) { }

  UserNameText:string="";
  EmailText:string="";
  LoginText:string="";
  PasswordText:string="";
  RepeatPasswordText:string="";

  ngOnInit(): void {
  }

  signUp() {
    if (this.PasswordText==this.RepeatPasswordText &&
        this.UserNameText!="" && this.EmailText!="" && this.LoginText!="" &&
        this.PasswordText!="" && this.RepeatPasswordText!="") {

      var newUser = {
        Login:this.LoginText,
        Password:this.PasswordText,
        Name:this.UserNameText,
        Email:this.EmailText
      }
      
      this.service.addNewUser(newUser).subscribe(result => {
        alert(result);
      });
    }
  }
}
