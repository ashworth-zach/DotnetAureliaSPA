import { HttpClient } from 'aurelia-http-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Login {
    email = '';
    password = '';
 
    login(http:HttpClient) {
       var myUser = { email: this.email, password: this.password }
       console.log(myUser);
    };
 }