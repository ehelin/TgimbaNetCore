import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
	selector: 'app-root',
	templateUrl: './registration.component.html',
	styleUrls: ['./registration.component.css']
})

@Injectable()
export class RegistrationComponent {
	private baseUrl: string;
	public username;
	public email;
	public password;
	public confirmPassword;

	constructor(
		private http: HttpClient,
		private router: Router
	) {
		this.baseUrl = window.location.protocol + "//"
			+ window.location.hostname + ':' + window.location.port; 
	}				

	public Cancel() {						  
		this.router.navigate(['/login']);
	}
									
	public Register(
		username: string,
		email: string,
		password: string,
		confirmPassword: string
	) {											  
		// TODO - handle registration validation
		let encodedUserValue = btoa(username);
		let encodedPassValue = btoa(password);
		let encodedEmailValue = btoa(email);

		const url = this.baseUrl + '/Home/Registration?'
			+ 'encodedUser=' + encodedUserValue
			+ '&encodedPass=' + encodedPassValue
			+ '&encodedEmail=' + encodedEmailValue;

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
					alert('Registration succeeded!');
					this.router.navigate(['/login']);
				} else {
					alert('Registration failed');
				}
			},
			error => {
				alert('Error: ' + error);
			}
		);
	}
}
