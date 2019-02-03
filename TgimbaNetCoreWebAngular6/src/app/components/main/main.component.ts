import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UtilitiesComponent } from '../common/utilities.component';
import { Router } from '@angular/router';					 

@Component({
	selector: 'app-root',
	templateUrl: './main.component.html',
	styleUrls: ['./main.component.css']
})

@Injectable()
export class MainComponent {		
	private baseUrl: string;	 

	constructor(
		private http: HttpClient,
		private router: Router
	) {
		this.baseUrl = UtilitiesComponent.GetBaseUrl();
	}

	public ShowMainMenu() {
		this.router.navigate(['/menu']);
	}							   		  			   
}
