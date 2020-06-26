import { Injectable } from "@angular/core";

@Injectable({
	providedIn: "root"
})
export class SortService {
	public sort: string;
	public sortAlgorithm: string;

	constructor() {
		this.sort = '';
		this.sortAlgorithm = '';
	}

	setSort(sort: string, sortAlgorithm: string) {
		this.sort = sort;
		this.sortAlgorithm = sortAlgorithm;
	}

	getSort() {
		return this.sort;
	}

	getSortAlgorithm() {
		return this.sortAlgorithm;
	}
}