import { HttpClient } from 'aurelia-http-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class register {
    firstname='';
    lastname='';
    email = '';
    password = '';
    confirm='';
    error="";
    // regex=new RegExp(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/);
    RegisterUser(http:HttpClient) {
       var myUser = { email: this.email, password: this.password, firstname:this.firstname,lastname:this.lastname }
       console.log(myUser);
       if(this.confirm!=this.password){
           this.error="Passwords do not match";
       }
       else
       {
        //    http.post
       }
    };
 }