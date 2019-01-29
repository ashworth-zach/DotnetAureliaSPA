import 'whatwg-fetch';
import { HttpClient, json } from 'aurelia-fetch-client';

let client = new HttpClient();

export class register {
    firstname = '';
    lastname = '';
    email = '';
    password = '';
    confirm = '';
    error = "";
    // regex=new RegExp(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/);
    RegisterUser() {
        var myUser = {firstname: this.firstname, lastname: this.lastname, email: this.email, password: this.password }
        console.log(myUser);
        if (this.confirm != this.password) {
            this.error = "Passwords do not match";
        }
        else {
            client.fetch('http://localhost:5000/api/login/RegisterUser', {
                method: "POST",
                body: json(myUser)
            })
                .then(response =>response.json())
                .then(data => {
                    if(data.Message==undefined){
                        this.error="Password must be longer than 8 characters, firstname and lastname must be over 3, and email must be valid format";
                    }
                    else{
                        if(data.Message=="Error"){
                            this.error="Email already exists in database";
                        }
                        else{
                            this.error=data.Message;
                        }
                    }
                });
        }
    }
}