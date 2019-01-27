import { HttpClient } from 'aurelia-http-client';
import { inject } from 'aurelia-framework';
// import { json } from 'aurelia-fetch-client';

@inject(HttpClient)
export class Fetchdata {
    public pokemon: any;

    constructor(http: HttpClient) {
        let idx=Math.floor(Math.random() * 802) + 1;
        http.createRequest('pokemon/'+idx+'/')
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
