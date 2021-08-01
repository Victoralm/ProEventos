import { faUser } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss'],
})
export class NavComponent implements OnInit {

  faUsers = faUser;

  isCollapsed = true;

  constructor(private router: Router) { }

  ngOnInit(): void { }

  ShowMenu(): boolean {
    return this.router.url != '/user/login';
  }
}
