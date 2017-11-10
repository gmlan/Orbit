import { Component, OnInit,OnDestroy } from '@angular/core';
import { Issue } from '../issue/Issue';
import { User } from '../user/User';
import { ActivatedRoute, Router } from "@angular/router";
import { JsonQueryService } from '../service/json-query.service';
import { Global } from '../shared/global';
import { IKeyValuePair } from '../model/KeyValuePair';
import { JsonResponse } from '../model/JsonResponse';
@Component({
  selector: 'app-issuedetails',
  templateUrl: './issuedetails.component.html',
  styleUrls: ['./issuedetails.component.css']
})
export class IssuedetailsComponent implements OnInit {

  issue: Issue;
  users: User[];
  severities : IKeyValuePair[];
  ticketStatus : IKeyValuePair[];
  sub:any;

  constructor(private route: ActivatedRoute,
              private queryService: JsonQueryService,
              private router: Router) { }

  ngOnInit() { 
    this.sub = this.route.params.subscribe(params => {
      let id = Number.parseInt(params['id']);

      if(id == 0){
        this.issue = new Issue();
      }
      else{
        this.queryService.get(Global.BASE_ISSUE_ENDPOINT+"/"+ id)
          .subscribe((response: any)  => {
            if (response.Success) {         
              this.issue  = response.Data;
            } else {
              alert(response.Data);
            }
          });    
      } 
      
      this.queryService.get(Global.BASE_USER_ENDPOINT)
        .subscribe((response : any) =>{
          if (response.Success) {         
            this.users  = response.Data;
          } else {
            alert(response.Data);
          }
        });

       this.queryService.get(Global.BASE_ENUM_ENDPOINT + "TicketStatus")
        .subscribe((response : any) =>{
          if (response.Success) {         
            this.ticketStatus  = response.Data;
          } else {
            alert(response.Data);
          }
        });

      this.queryService.get(Global.BASE_ENUM_ENDPOINT + "SeverityLevel")
        .subscribe((response : any) =>{
          if (response.Success) {         
            this.severities  = response.Data;
          } else {
            alert(response.Data);
          }
        });


    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  updateIssue(Issue: Issue) {    
    if(Issue.Id != null){
        //update a Issue
        this.queryService.put(Global.BASE_ISSUE_ENDPOINT, Issue.Id,Issue)
            .subscribe((response: JsonResponse)  => {
              if (response.Success) {         
                this.gotoBack();
              } else {
                alert(response.Data);
              }
            });
      }
      else{
        // Create a new Issue
        this.queryService.post(Global.BASE_ISSUE_ENDPOINT,Issue)
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
    let link = ['/issue'];
    this.router.navigate([link]);
  }
}
