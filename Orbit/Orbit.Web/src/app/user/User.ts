import { AddressInfo } from './Address';
import { Issue } from '../issue/Issue';
export class User{
        FirstName : string;
        LastName : string;
        Email : string;
        Password : string;
        Phone : string;
        Address : AddressInfo;
        Id : number;
        Issues: Issue[];

        constructor(){
           this.Address = new AddressInfo();
        }
    
}