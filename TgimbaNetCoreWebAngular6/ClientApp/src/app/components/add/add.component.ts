import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';					 
import { Session } from 'protractor';
import { ConstantsComponent } from '../common/constants.component';
import { SessionComponent } from '../common/session.component';
import { UtilitiesComponent } from '../common/utilities.component';

@Component({
	selector: 'app-root',
	templateUrl: './add.component.html',
	styleUrls: ['./add.component.css']
})

@Injectable()
export class AddComponent {		
	private baseUrl: string;
	public itemName = '';
	public dateCreated;
	public category = 'Warm';
	public completed = undefined;
	public latitude = '';
	public longitude = '';

	constructor(
		private http: HttpClient,
		private router: Router
	) {
		this.baseUrl = UtilitiesComponent.GetBaseUrl();
																						   
		var today = new Date();
		this.dateCreated = today.toLocaleDateString('en-US');
	}	

	public Cancel() {
		this.router.navigate(['/main']);
	}						

	public Add(
	    itemName: string,
		dateCreated: string,
		category: string,
		completed: string,
		latitude: string,
		longitude: string
	) {
		let userName = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_USERNAME);
		let token = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_TOKEN);		   

		const url = this.baseUrl + '/BucketListItem/AddBucketListItem?'
			+ 'Name=' + itemName
			+ '&DateCreated=' + dateCreated
			+ '&BucketListItemType=' + category
			+ '&Completed=' + (completed === 'true' ? true : false).toString()
			+ '&Latitude=' + (latitude === '' ? 0 : latitude).toString()
			+ '&Longitude=' + (longitude === '' ? 0 : longitude).toString()
			+ '&DatabaseId=' + ''
			+ '&UserName=' + userName
			+ '&encodedUser=' + btoa(userName)
			+ '&encodedToken=' + btoa(token);									  

		const headers = new HttpHeaders()
			.set('Content-Type', 'application/json')
			.set('Accept', 'application/json');

		return this.http.post(
			url,
			null,
			{ headers: headers }										  
		).subscribe(
			data => {								  
				if (data && data === true) {
					this.router.navigate(['/main']);
				} else {
					// TODO - handle error
					alert('Add failed');
				}
			},
			error => {
				alert('Error: ' + error);
			}
		);
	}
}
