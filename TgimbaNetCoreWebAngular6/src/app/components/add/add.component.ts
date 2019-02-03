import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';					 
import { Session } from 'protractor';
import { ConstantsComponent } from '../common/constants.component';
//import { SessionComponent } from '../common/session.component';
import { UtilitiesComponent } from '../common/utilities.component';

@Component({
	selector: 'app-root',
	templateUrl: './add.component.html',
	styleUrls: ['./add.component.css']
})

@Injectable()
export class AddComponent {		
	private baseUrl: string;
	public itemName;
	public dateCreated;
	public category;
	public completed;
	public latitude;
	public longitude;

	constructor(
		private http: HttpClient,
		private router: Router
	) {
		this.baseUrl = UtilitiesComponent.GetBaseUrl();
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
		alert('add');
		//let encodedItemName = btoa(itemName);
		//let encodedDateCreated = btoa(dateCreated);
		//let encodedCategory = btoa(category);
		//let encodedCompleted = btoa(completed);
		//let encodedLatitude = btoa(latitude);
		//let encodedLongitude = btoa(longitude);
									
		//const url = this.baseUrl + '/BucketListItem/AddBucketListItem?'
		//	+ 'encodedItemName=' + encodedItemName
		//	+ '&encodedDateCreated=' + encodedDateCreated
		//	+ '&encodedCategory=' + encodedCategory
		//	+ '&encodedCompleted=' + encodedCompleted
		//	+ '&encodedLatitude=' + encodedLatitude
		//	+ '&encodedLongitude=' + encodedLongitude;

		//const headers = new HttpHeaders()
		//	.set('Content-Type', 'application/json')
		//	.set('Accept', 'application/json');

		//return this.http.post(
		//	url,
		//	null,
		//	{ headers: headers }										  
		//).subscribe(
		//	data => {
		//		// TODO - convert response to boolean
		//		if (data && data === "true") {
		//			alert('Add succeeded');
		//		} else {
		//			// TODO - handle error
		//			alert('Add failed');
		//		}
		//	},
		//	error => {
		//		alert('Error: ' + error);
		//	}
		//);
	}
}
