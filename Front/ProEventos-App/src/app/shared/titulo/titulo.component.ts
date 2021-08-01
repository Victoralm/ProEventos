import { Component, Input, OnInit } from '@angular/core';
import { IconProp } from '@fortawesome/fontawesome-svg-core';
import { faUser } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  @Input() titulo: string = '';

  @Input() iconClass: IconProp = faUser;
  @Input() subtitulo: string = 'Since 2021';
  @Input() botaoListar: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
