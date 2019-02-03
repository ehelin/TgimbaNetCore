import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UtilitiesComponent } from '../common/utilities.component';
import { Router } from '@angular/router';
import { SessionComponent } from '../common/session.component';
import { ConstantsComponent } from '../common/constants.component';
	 
@Component({
	selector: 'app-root',
	templateUrl: './main.component.html',
	styleUrls: ['./main.component.css']
})

@Injectable()
export class MainComponent {		
	private baseUrl: string;
	public htmlTableWData: any;

	constructor(
		private http: HttpClient,
		private router: Router
	) {
		this.baseUrl = UtilitiesComponent.GetBaseUrl();	 
		this.LoadBucketListItems();
	}

	public ShowMainMenu() {
		this.router.navigate(['/menu']);
	}					

	private LoadBucketListItems() {
		let encodedUserName = btoa(SessionComponent.SessionGetValue(ConstantsComponent.SESSION_USERNAME));
		let encodedToken = btoa(SessionComponent.SessionGetValue(ConstantsComponent.SESSION_TOKEN));
		let encodedSortString = btoa(''); // TODO implement sort

		const url = this.baseUrl + '/BucketListItem/GetBucketListItems?'
			+ 'encodedUserName=' + encodedUserName
			+ '&encoderedSortString=' + encodedSortString
			+ '&encodedToken=' + encodedToken;

		const headers = new HttpHeaders()
			.set('Content-Type', 'application/json')
			.set('Accept', 'application/json');

		return this.http.get(url).subscribe(
			bucketListItems => {
				bucketListItems = this.AddNumberColumn(bucketListItems);
				this.htmlTableWData = bucketListItems;
			}  
		);	   
	}

	private AddNumberColumn(bucketListData) {		
		for (let i = 0; i < bucketListData.length; i++) {
			bucketListData[i].number = i + 1;
		}

		return bucketListData;
	}
}
