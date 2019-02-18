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


	MainController.FormEditClick = function (itemName, dateCreated, bucketListItemType,
		completed, latitude, longitude,
		dbId, userName) {
		var editFormValues = [];

		editFormValues.push(itemName);
		editFormValues.push(dateCreated);
		editFormValues.push(bucketListItemType);
		editFormValues.push(completed);
		editFormValues.push(latitude);
		editFormValues.push(longitude);
		editFormValues.push(dbId);
		editFormValues.push(userName);				

		// START here -> get parameters to edit.html component

		//ServerCalls.GetView(VIEW_MAIN_EDIT, contentDiv, editFormValues)
	};

	public FormEdit(dbId) {
		//if (IsJQueryClient()) {
		//	ServerCalls.DeleteBucketListItem(BUCKET_LIST_PROCESS_DELETE, dbId);
		//} else {
		//	ServerCalls.DeleteBucketListItem(BUCKET_LIST_PROCESS_DELETE, dbId);
		//}
	};

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
