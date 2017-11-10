import { User } from '../user/User';

export class Issue{
    Id : number;
    Title : string;
    Description : string;
    Severity : number;
    Assignee : User;
    AssigneeId : number;
    CreatedBy : User;
    CreatedById : number;
    CreateDateTimeUtc : Date;
    DueDateUtc? : Date;
}