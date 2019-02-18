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
	public dbId = '';
	public userNameParam = '';

	constructor(
		private http: HttpClient,
		private router: Router
	) {
		this.baseUrl = UtilitiesComponent.GetBaseUrl();			
	}	

	public Cancel() {
		this.router.navigate(['/main']);
	}						

	public Edit(
	    itemName: string,
		dateCreated: string,
		category: string,
		completed: string,
		latitude: string,
		longitude: string, 
		dbId: string,
		userNameParam: string
	) {
		let userName = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_USERNAME);
		let token = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_TOKEN);		   

		const url = this.baseUrl + '/BucketListItem/EditBucketListItem?'
			+ 'Name=' + itemName
			+ '&DateCreated=' + dateCreated
			+ '&BucketListItemType=' + category
			+ '&Completed=' + (completed === 'true' ? true : false).toString()
			+ '&Latitude=' + (latitude === '' ? 0 : latitude).toString()
			+ '&Longitude=' + (longitude === '' ? 0 : longitude).toString()
			+ '&DatabaseId=' + dbId
			+ '&UserName=' + userNameParam
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
