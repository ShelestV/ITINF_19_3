import { Component, OnInit } from '@angular/core';
import { SharedService } from '../shared.services';

@Component({
  selector: 'app-autorization',
  templateUrl: './autorization.component.html',
  styleUrls: ['./autorization.component.css']
})
export class AutorizationComponent implements OnInit {

  constructor(private service:SharedService) { }

  LoginText:string="";
  PasswordText:string="";

  ngOnInit(): void {
  }

  autorize() {
    var val = {
      Login:this.LoginText,
      Password:this.PasswordText
    }
    
    this.service.autorize(val);
    

    this.LoginText="";
    this.PasswordText="";
  }
}
