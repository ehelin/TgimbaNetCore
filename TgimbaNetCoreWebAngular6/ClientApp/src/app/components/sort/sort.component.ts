import { Injectable, Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { SessionComponent } from '../common/session.component';
import { ConstantsComponent } from '../common/constants.component';
import { UtilitiesComponent } from '../common/utilities.component';
import { SortService } from './sort.service';

@Component({
	selector: 'app-root',
	templateUrl: './sort.component.html',
	styleUrls: ['./sort.component.css']
})

@Injectable()
export class SortComponent {		
	private baseUrl: string;	
	public descOrder: boolean;
	public selectedSortingAlgorithm = ''; 
	public sortingAlgorithms: string[];

	constructor(
		private http: HttpClient,
		private router: Router,
		private sortService: SortService
	) {
		this.baseUrl = UtilitiesComponent.GetBaseUrl(); 
		let sortingAlgorithmsStr = SessionComponent.SessionGetValue(ConstantsComponent.SESSION_SORT_ALGORITHMS);		
		this.sortingAlgorithms = sortingAlgorithmsStr.split(",");
	}

	public Sort(sortColumn) { 
		let sort = 'order by ' + sortColumn;

		if (this.descOrder === true) {
			sort += ' desc';
		}

		this.sortService.setSort(sort, this.selectedSortingAlgorithm);
		this.router.navigate(['/main']);
	};
						 
	public Cancel() {
		this.sortService.setSort('','');

		if (LoginComponent.IsLoggedIn() === true) {
			this.router.navigate(['/main']);
		}
		else {
			this.router.navigate(['/login']);
		}	
	};
}
