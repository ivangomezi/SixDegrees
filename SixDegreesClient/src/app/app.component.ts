import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsuariosServiceService } from './services/usuarios-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'SixDegreesClient';

  lista: any[] = []

  constructor(
    public api: UsuariosServiceService,
    private router:Router) {
    this.api.getUsuarios().subscribe(data => {
      this.lista = data

      console.log(this.lista)
    })
  }
}
