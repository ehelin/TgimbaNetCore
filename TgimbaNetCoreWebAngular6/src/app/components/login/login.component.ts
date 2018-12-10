import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';					 

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
