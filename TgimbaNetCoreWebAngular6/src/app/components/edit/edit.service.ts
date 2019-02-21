import { Injectable } from "@angular/core";

@Injectable({
	providedIn: "root"
})
export class EditService {
	public bucketListItem: any;

	constructor() {
		this.bucketListItem = {};
	}
	setBucketListItem(bucketListItem: any) {
		this.bucketListItem = bucketListItem;
	}
	getBucketListItem() {
		return this.bucketListItem;
	}
}