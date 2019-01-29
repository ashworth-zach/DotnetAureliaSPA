// import 'fetch';
import { HttpClient, json } from 'aurelia-fetch-client';

let httpClient = new HttpClient();

export class register {
    firstname = '';
    lastname = '';
    email = '';
    password = '';
    confirm = '';
    error = "";
    // regex=new RegExp(/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/);
    RegisterUser() {
        var myUser = { email: this.email, password: this.password, firstname: this.firstname, lastname: this.lastname }
        console.log(myUser);
        if (this.confirm != this.password) {
            this.error = "Passwords do not match";
        }
        else {
            httpClient.fetch('http://localhost:5000/api/login/RegisterUser', {
                method: "POST",
                body: JSON.stringify(myUser)
            })
                .then(response => response.json())
                .then(data => {
                    console.log("this is the data console log" + data);
                });
        }
    }
}