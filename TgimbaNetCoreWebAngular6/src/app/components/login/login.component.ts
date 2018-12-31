import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';					 
import { Session } from 'protractor';
import { ConstantsComponent } from '../common/constants.component';
import { SessionComponent } from '../common/session.component';

@Component({
	selector: 'app-root',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.css']
})

@Injectable()
export class LoginComponent {		
	private baseUrl: string;
	public loginPassword;
	public loginUsername;

	constructor(
		private http: HttpClient,
		private router: Router
	) {								   											   
		this.baseUrl = window.location.protocol + "//"
						+ window.location.hostname + ':' + window.location.port; 
	}

	public static IsLoggedIn(): boolean {
		var token = SessionComponent.SessionGetToken(ConstantsComponent.SESSION_TOKEN);

		if (token !== undefined && token !== null && token.length > 0) {
			return true;
		}
		else {
			return false;
		}			 
	}

	public Register() {
		this.router.navigate(['/registration']);	
	}						

	public Login(loginUsername: string, loginPassword: string) {
		let encodedUserValue = btoa(loginUsername);
		let encodedPassValue = btoa(loginPassword);
									
		const url = this.baseUrl + '/Home/Login?'
			+ 'encodedUser=' + encodedUserValue
			+ '&encodedPass=' + encodedPassValue;

		const headers = new HttpHeaders()
			.set('Content-Type', 'application/json')
			.set('Accept', 'application/json');

		return this.http.post(
			url,
			null,
			{ headers: headers }										  
		).subscribe(
			data => {
				if (data !== null && data !== undefined && data !== '') {
					alert('Logged In');
					let token = JSON.stringify(data);
					SessionComponent.SessionSetToken(ConstantsComponent.SESSION_TOKEN, token);
					this.router.navigate(['/main']);
				} else {
					alert('Username and/or password is not correct.  Please try again');
				}
			},
			error => {
				alert('Error: ' + error);
			}
		);
	}
}
