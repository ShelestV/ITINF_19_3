import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.services';

@Component({
  selector: 'app-application-friendship',
  templateUrl: './application-friendship.component.html',
  styleUrls: ['./application-friendship.component.css']
})
export class ApplicationFriendshipComponent implements OnInit {

  constructor(private service:SharedService) { }

  FriendList:any=[];

  ngOnInit(): void {
    this.service.getFriendApplications("text").subscribe(data=>{
      this.FriendList=data;
    });
  }

  getPath(image:number) {
    return this.service.getImageSource(image);
  }
}
