import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router, ActivatedRoute, Params } from '@angular/router'; 			 
import { Session } from 'protractor';
import { ConstantsComponent } from '../common/constants.component';
import { SessionComponent } from '../common/session.component';
import { UtilitiesComponent } from '../common/utilities.component';
import { EditService } from './edit.service';

@Component({
	selector: 'app-edit-component',
	templateUrl: './edit.component.html',
	styleUrls: ['./edit.component.css']
})

@Injectable()
export class EditComponent {		
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
		private router: Router, 
		private route: ActivatedRoute,
		private editService: EditService
	) {
		this.baseUrl = UtilitiesComponent.GetBaseUrl();
		let bucketListItem = this.editService.getBucketListItem();
		this.Display(bucketListItem);		
	}	
		  
	private Display(bucketListItem: any) {		
		this.itemName = bucketListItem.name;
		this.dateCreated = bucketListItem.dateCreated;
		this.completed = bucketListItem.completed;
		this.latitude = bucketListItem.latitude;
		this.longitude = bucketListItem.longitude;
		this.dbId = bucketListItem.databaseId;
		this.userNameParam = bucketListItem.userName;	

		//3 hot, 2 warm, 1 cold, 0 cool						 
		if (bucketListItem.bucketListItemType === '3') {
			this.category = 'Hot';// = 0;		//hot
		} else if (bucketListItem.bucketListItemType === '2') {
			this.category = 'Warm';//		//warm
		} else {
			this.category = 'Cool';//		//cool/cold
		}	
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
