using TgimbaNetCoreWebShared.Models;
using System.Collections.Generic;

namespace TgimbaNetCoreWebShared
{
	public interface IWebClient
	{
		string Login(string encodedUser, string encodedPass);
		bool Registration(string encodedUser, string encodedEmail, string encodedPassword);
		bool AddBucketListItem
		(
			SharedBucketListModel bucketListItem,
			string encodedUser, 
			string encodedToken
		);
		List<SharedBucketListModel> GetBucketListItems
		(
			string encodedUserName, 
			string encodedSortString, 
			string encodedToken
		);		
	}
}
