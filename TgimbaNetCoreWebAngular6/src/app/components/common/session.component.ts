import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';					 

@Component({
	selector: 'app-root',
	templateUrl: './emptyHtml/session.component.html',
	//styleUrls: ['./session.component.css']
})

@Injectable()
export class SessionComponent {		
	private static sessionStorage = new Map();

	constructor(
		//private http: HttpClient,
		//private router: Router
	) {				
		//sessionStorage = new Map();
		//this.baseUrl = window.location.protocol + "//"
		//				+ window.location.hostname + ':' + window.location.port; 
	}

	//token -------------------------------------------------------
	public static SessionSetToken(key, value) {
		sessionStorage.setItem(key, value);
	}

	public static SessionGetToken(key) {
		var val = sessionStorage.getItem(key);
		return val;
	}

	//misc --------------------------------------------------------
	public static SessionClearStorage() {
		SessionComponent.sessionStorage = new Map();
	}
}
