

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class BaseService {

    baseURL = 'http://localhost:58732/api';
    constructor(private http: HttpClient){

    }
    
    
    getAll(url: string){
        return this.http.get(this.baseURL + url);
    }

    getBy(url: string)
    {
        return this.http.get(this.baseURL +url);
    }

    add(url: string ,data: any){
        return this.http.post(this.baseURL + url,data);
    }

    delete(url:string){
        return this.http.delete(this.baseURL + url);
    }

    update(url: string, data: any)
    {
        return this.http.put(this.baseURL + url, data);
    }

}