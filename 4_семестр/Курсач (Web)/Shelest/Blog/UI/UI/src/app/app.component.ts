import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { SharedService } from './shared.services';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Uviki';

  IsActiveAutorization:boolean=false;
  IsActiveRegistration:boolean=false;

  IsActiveUser:boolean=false;

  UserLogin:string="";
  User:any;

  constructor (private http:HttpClient, private service:SharedService, private cookieService:CookieService) { }

  ngOnInit(): void { 
    this.refresh();
  }

  SignInClick() {
    this.IsActiveAutorization=true;
  }

  SignUpClick() {
    if (!this.IsActiveUser) {
      this.IsActiveRegistration=true;
    }
  }

  SignOutClick() {
    this.service.signOut();
    this.cookieService.deleteAll();
    this.IsActiveUser=false;
  }

  closeClick() {
    this.IsActiveAutorization=false;  
    this.IsActiveRegistration=false;
    this.User=this.service.CurrentUser;
    this.refresh();
  }

  refresh():void {
    this.UserLogin=this.cookieService.get("CurrentUserLogin");
    this.User=this.service.getCurrentUser();
    this.IsActiveUser=this.User!=null;
  }
}
