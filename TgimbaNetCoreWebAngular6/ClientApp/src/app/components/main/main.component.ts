import { Injectable, Component, Inject, Input } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UtilitiesComponent } from '../common/utilities.component';
import { Router } from '@angular/router';
import { SessionComponent } from '../common/session.component';
import { ConstantsComponent } from '../common/constants.component';
import { EditService } from '../edit/edit.service';
import { SortService } from '../sort/sort.service';
	 
@Component({
	selector: 'app-root',
	templateUrl: './main.component.html',
	styleUrls: ['./main.component.css']
})

@Injectable()
export class MainComponent {		
	private baseUrl: string;
	public htmlTableWData: any;	
	public searchTerm: string;
	public selectedSearchAlgorithm = ''; 
	public searchAlgorithms: string[];

	constructor(
		private http: HttpClient,
		private router: Router,
		private editService: EditService,
		private sortService: SortService
	) {
		this.baseUrl = UtilitiesComponent.GetBaseUrl();
		this.LoadBucketListItems("");
		this.searchTerm = '';
		let searchAlgorithmsStr = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_SEARCH_ALGORITHMS);
		this.searchAlgorithms = searchAlgorithmsStr.split(",");
	}

	public FormEdit(bucketListItem) {
		this.editService.setBucketListItem(bucketListItem);
		this.router.navigate(['/edit']);				
	};

	public FormDelete(databaseId) {
		let userName = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_USERNAME);
		let token = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_TOKEN);		   

		const url = this.baseUrl + '/BucketListItem/DeleteBucketListItem/' + databaseId;

		const headers = new HttpHeaders()
			.set('EncodedUserName', btoa(userName))
			.set('EncodedToken', btoa(token));

		return this.http.delete(
			url,
			{ headers: headers })
			.subscribe(
			data => {
				if (data && data === true) {
					this.LoadBucketListItems("");
				} else {
					// TODO - handle error
					alert('Delete failed');
				}
			},
			error => {
				alert('Error: ' + error);
			}
		);
		
	};										

	public ShowMainMenu() {
		this.router.navigate(['/menu']);
	}	

	public Search() {	  
		this.LoadBucketListItems(this.searchTerm);
	}

	public Cancel() {
		this.searchTerm = '';
		this.LoadBucketListItems('');			 
	}

	private LoadBucketListItems(searchTerm) {
		let encodedUserName = btoa(SessionComponent.SessionGetValue(ConstantsComponent.SESSION_USERNAME));
		let encodedToken = btoa(SessionComponent.SessionGetValue(ConstantsComponent.SESSION_TOKEN));
		let encodedSortString = btoa(this.sortService.getSort());
		let encodedSortingAlgorithm = btoa(this.sortService.getSortAlgorithm());

		let url = this.baseUrl + '/BucketListItem/GetBucketListItems?'
			+ 'encodedUserName=' + encodedUserName
			+ '&encoderedSortString=' + encodedSortString
			+ '&encodedToken=' + encodedToken;

		if (searchTerm && searchTerm.length > 0) {
			url += '&encodedSrchTerm=' + btoa(this.searchTerm);
		}

		// temp until all supported parameters added
		url += "&encodedSortType=" + encodedSortingAlgorithm;
		url += "&encodedSearchType=" + btoa("Linq");

		const headers = new HttpHeaders()
			.set('Content-Type', 'application/json')
			.set('Accept', 'application/json');

		return this.http.get(url).subscribe(
			bucketListItems => {
				bucketListItems = this.AddNumberColumn(bucketListItems);
				this.htmlTableWData = bucketListItems;

				// srch results	cancel			
				var cancelSrchResultsContainer = document.getElementById('cancelSrchResults');
				if (searchTerm && searchTerm.length > 0) {
					cancelSrchResultsContainer.style.display = "block";
				} else {
					cancelSrchResultsContainer.style.display = "none";
				}
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
