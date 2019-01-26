import { HttpClient } from 'aurelia-http-client';
import { inject } from 'aurelia-framework';
import { json } from 'aurelia-fetch-client';

@inject(HttpClient)
export class Fetchdata {
    public pokemon: any;

    constructor(http: HttpClient) {
        http.createRequest('pokemon/1/')
            .asGet()
            .withBaseUrl('https://pokeapi.co/api/v2/')
            .send()
            .then(result => { 
                let jsonData=JSON.parse(result.response);
                this.pokemon = jsonData; 
                console.log(jsonData);
            });
        // .then(data => {
        //     this.pokemon = data;
        // });
    }
}
