import { Component } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'coter_client';
  hasCookie = false;

  constructor(public cookieService : CookieService)
  {
    this.hasCookie = this.cookieService.check("monCookie");
  }

  addCookie(){
    this.cookieService.set("monCookie", "une valeur");
  }

  removeCookie(){
    this.cookieService.delete("monCookie");
  }
}
