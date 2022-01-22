import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsuariosServiceService } from 'src/app/services/usuarios-service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  lista: any[] = []
  constructor(
    public api: UsuariosServiceService,
    private router:Router) {
    this.api.getUsuarios().subscribe(data => {
      this.lista = data

      console.log(this.lista)
    })
  }

  ngOnInit(): void {
  }

}
