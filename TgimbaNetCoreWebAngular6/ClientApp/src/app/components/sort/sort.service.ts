import { Injectable } from "@angular/core";

@Injectable({
	providedIn: "root"
})
export class SortService {
	public sort: string;

	constructor() {
		this.sort = '';
	}

	setSort(sort: string) {
		this.sort = sort;
	}

	getSort() {
		return this.sort;
	}
}