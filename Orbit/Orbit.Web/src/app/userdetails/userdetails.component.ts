import { Component, OnInit,OnDestroy } from '@angular/core';
import { User } from '../user/User';
import { ActivatedRoute, Router } from "@angular/router";
import { JsonQueryService } from '../service/json-query.service';
import { Global } from '../shared/global';
import { JsonResponse } from '../model/JsonResponse';
@Component({
  selector: 'app-userdetails',
  templateUrl: './userdetails.component.html',
  styleUrls: ['./userdetails.component.css']
})
export class UserdetailsComponent implements OnInit {
  user: User;
  sub:any;

  constructor(private route: ActivatedRoute,
              private queryService: JsonQueryService,
              private router: Router) { }

  ngOnInit() { 
    this.sub = this.route.params.subscribe(params => {
      let id = Number.parseInt(params['id']);

      if(id == 0){
        this.user = new User();
      }
      else{
        this.queryService.get(Global.BASE_USER_ENDPOINT+"/"+ id)
          .subscribe((response: JsonResponse)  => {            
            if (response.Success) {         
              this.user = response.Data;
            } else {
              alert(response.Data);
            }
          });
      }       
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  updateUser(user: User) {    
    if(user.Id != null){
        //update a User
        this.queryService.put(Global.BASE_USER_ENDPOINT, user.Id,user)
            .subscribe((response: JsonResponse)  => {              
              if (response.Success) {         
                this.gotoBack();
              } else {
                alert(response.Data);
              }
            });
      }
      else{
        // Create a new User
        this.queryService.post(Global.BASE_USER_ENDPOINT,user)
          .subscribe((response: JsonResponse)  => {
            if (response.Success) {         
              this.gotoBack();
            } else {
              alert(response.Data);
            }
        });
      }
  }

  gotoBack(){
    let link = ['/user'];
    this.router.navigate(link);
  }
}
