import { Injectable, Component } from '@angular/core';
import { Router } from '@angular/router';
import { SessionComponent } from './components/common/session.component';
import { LoginComponent } from './components/login/login.component';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UtilitiesComponent } from './components/common/utilities.component';
import { ConstantsComponent } from './components/common/constants.component';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.css']
})

@Injectable()
export class AppComponent {
	public session: SessionComponent;
	private baseUrl: string;

	constructor(
		private http: HttpClient,
		private router: Router,
	) {
		this.session = new SessionComponent();
		this.baseUrl = UtilitiesComponent.GetBaseUrl();

		alert("AppComponent-constructor");

		this.Initialize();

		if (LoginComponent.IsLoggedIn() === true) {
			this.router.navigate(['/main']);
		}
		else {
			this.router.navigate(['/login']);
		}									  
	}

	public Initialize()
	{
		var sortAlgorithms = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_SORT_ALGORITHMS);
		var searchAlgorithms = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_SEARCH_ALGORITHMS);

		// do not set values if they are already set
		//if (sortAlgorithms != null && sortAlgorithms != undefined
		//	&& searchAlgorithms != null && searchAlgorithms != undefined
		//	&& sortAlgorithms.length > 0 && searchAlgorithms.length > 0) {
		//	return;
		//}

		let userAgent = window.navigator.userAgent;
		const url = this.baseUrl + '/BucketListItem/Initialize?userAgent=' + userAgent;

		const headers = new HttpHeaders()
			.set('Content-Type', 'application/json')
			.set('Accept', 'application/json');

		return this.http.get<InitializeResult>(
			url,
			{ headers: headers }
		).subscribe(
			(data) => {
				if (data !== null && data !== undefined)
				{
					SessionComponent.SessionSetValue(ConstantsComponent.SESSION_SORT_ALGORITHMS, data.availableSortingAlgorithms);
					SessionComponent.SessionSetValue(ConstantsComponent.SESSION_SEARCH_ALGORITHMS, data.availableSearchingAlgorithms);
				}
			},
			error => {
				alert('Error: ' + error);
			}
		);
	}
}
class InitializeResult {
	public isMobile: boolean;
	public availableSortingAlgorithms: string[];
	public availableSearchingAlgorithms: string[];
}