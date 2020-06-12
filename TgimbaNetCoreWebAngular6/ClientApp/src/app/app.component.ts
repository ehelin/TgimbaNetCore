import { Injectable, Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionComponent } from './components/common/session.component';
import { LoginComponent } from './components/login/login.component';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css']
})

@Injectable()
export class AppComponent {
	public session: SessionComponent;

	constructor(
		private router: Router,
	) {
		this.session = new SessionComponent(); 
		if (LoginComponent.IsLoggedIn() === true) {
			this.router.navigate(['/main']);
		}
		else {
			this.router.navigate(['/login']);
		}									  
	}
}
