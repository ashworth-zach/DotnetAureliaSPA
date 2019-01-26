import { HttpClient } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';

@inject(HttpClient)
export class Fetchdata {
    public pokemon: any;

    constructor(http: HttpClient) {
        http.fetch('api/SampleData/GetAsync')
            .then(result => result.json() as Promise<any>)
            .then(data => {
                this.pokemon = data;
            });
    }
}
