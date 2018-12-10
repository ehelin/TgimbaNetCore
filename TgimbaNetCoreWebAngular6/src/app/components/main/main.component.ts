import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';					 

@Component({
	selector: 'app-root',
	templateUrl: './main.component.html',
	styleUrls: ['./main.component.css']
})

@Injectable()
export class MainComponent {		
	//private baseUrl: string;	 

	constructor(
		private http: HttpClient,
		private router: Router
	) {								   											   
		//this.baseUrl = window.location.protocol + "//"
		//				+ window.location.hostname + ':' + window.location.port; 
	}


}
