import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.services';

@Component({
  selector: 'app-active-friendship',
  templateUrl: './active-friendship.component.html',
  styleUrls: ['./active-friendship.component.css']
})
export class ActiveFriendshipComponent implements OnInit {

  constructor(private service:SharedService) { }

  FriendList:any=[];

  ngOnInit(): void {
    this.service.getFriends().subscribe(data=>{
      this.FriendList=data;
    });
  }

  getPath(image:number) {
    return this.service.getImageSource(image);
  }
}
