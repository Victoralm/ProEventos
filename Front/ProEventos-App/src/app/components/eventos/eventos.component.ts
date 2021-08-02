import { Component, OnInit } from '@angular/core';

import { faCalendarAlt } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss'],
})
export class EventosComponent implements OnInit {

  // Fonts Awesome
  faCalendarAlt = faCalendarAlt;

  ngOnInit(): void {

  }
}
