import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';					 

@Component({
	selector: 'app-root',
	templateUrl: './emptyHtml/session.component.html'
})

@Injectable()
export class SessionComponent {		
	private static sessionStorage = new Map();

	constructor() {}

	//token -------------------------------------------------------
	public static SessionSetValue(key, value) {
		sessionStorage.setItem(key, value);
	}

	public static SessionGetValue(key) {
		var val = sessionStorage.getItem(key);
		return val;
	}

	//misc --------------------------------------------------------
	public static SessionClearStorage() {
		SessionComponent.sessionStorage = new Map();
	}
}
