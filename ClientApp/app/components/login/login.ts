import 'whatwg-fetch';
import { HttpClient, json } from 'aurelia-fetch-client';

let client = new HttpClient();

export class register {
   email = '';
   password = '';
   error = "";
   // regex=new RegExp(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/);
   RegisterUser() {
      var myUser = { email: this.email, password: this.password }
      console.log(myUser);
      client.fetch('http://localhost:5000/api/login/LoginUser', {
         method: "POST",
         body: json(myUser)
      })
         .then(response => response.json())
         .then(data => {
            if (data.Message == "Error") {
               this.error = "Invalid login credentials";
            }
            else {
               this.error = data.Message;
            }
         });
   }
}