import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class DojoService {

  constructor(private _http: HttpClient) { }
    // readOne(id:any)
    // {
    //   return this._http.get("/api/authors/"+id);
    // }
    // createOne(data:any)
    // {
    //   return this._http.post("/api/authors", data);
    // }
    // readAll()
    // {
    //   return this._http.get("/api/authors");
    // }
    // deleteOne(id:any)
    // {
    //   return this._http.delete("/api/authors/"+id);
    // }
    // editOne(id:any, data:any)
    // {
    //   return this._http.patch("/api/authors/"+id, data);
    // }
}