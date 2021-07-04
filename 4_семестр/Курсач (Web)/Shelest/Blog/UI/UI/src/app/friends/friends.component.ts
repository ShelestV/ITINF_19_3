import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-friends',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.css']
})
export class FriendsComponent implements OnInit {

  constructor() { }

  IsActive:boolean=false;
  IsApplication:boolean=false;

  ngOnInit(): void {
  }

  activeClick() {
    this.IsActive=true;
    this.IsApplication=false;
  }
  
  applicationClick() {
    this.IsActive=false;
    this.IsApplication=true;
  }
}
