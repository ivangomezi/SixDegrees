import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Usuarios } from '../models/Usuarios';

@Injectable({
  providedIn: 'root'
})
export class UsuariosServiceService {

  Url = 'https://localhost:44353/';
  Api = 'api/Usuarios';

  constructor(private http: HttpClient) { }

  getUsuarios(): Observable<any> {
    return this.http.get(this.Url + this.Api);
  }
}
