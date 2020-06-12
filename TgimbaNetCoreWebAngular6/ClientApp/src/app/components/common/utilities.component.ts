import { Injectable, Component } from '@angular/core';

@Component({
	selector: 'app-root',
	templateUrl: './emptyHtml/utilities.component.html',
})

@Injectable()
export class UtilitiesComponent {
	public static GetBaseUrl() {
		let baseUrl: string = window.location.protocol + "//"
			+ window.location.hostname + ':' + window.location.port; 

		return baseUrl;
	}
}