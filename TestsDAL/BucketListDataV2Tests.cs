using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsDAL
{
    [TestClass]
    public class BucketListDataV2Tests : BucketListDataV1Tests
    {
        public BucketListDataV2Tests() : base() { }
	
        [TestMethod]
        public void RunBucketListDataV2Tests()
        {
            AddUser(userName, email, password);

            var bucketListItems = GetBucketListItem(userName, "", "", true);

            var savedBucketListItems = UpsertGetBucketListItemV2Test(bucketListItems);

            int pos = savedBucketListItems[0].LastIndexOf(',');
            string dbIdStr = savedBucketListItems[0].Substring(pos + 1, savedBucketListItems[0].Length - (pos + 1));
            int dbId = Int32.Parse(dbIdStr);

            bdb.DeleteBucketListItem(dbId);
            mdb.DeleteUser(userName, password, email);
        }
				  
        [TestMethod]
        public void SortSearchTests()
        {
			AddUser(userName, email, password);

			InsertBucketListItem("an awesome list item name");
			SearchTest("an awesome list item name");

			InsertBucketListItem("bi 2");
			InsertBucketListItem("bi 3");
			InsertBucketListItem("bi 4");
			InsertBucketListItem("bi 5");
			SortTest();

			var bucketListItems =  this.bdb.GetBucketListV2(userName, "", "");
			foreach (string bucketListItem in bucketListItems)
			{
				int pos = bucketListItem.LastIndexOf(',');
				string dbIdStr = bucketListItem.Substring(pos + 1, bucketListItem.Length - (pos + 1));
				int dbId = Int32.Parse(dbIdStr);

				bdb.DeleteBucketListItem(dbId);
			}

			mdb.DeleteUser(userName, password, email);
        }
															
		private void InsertBucketListItem(string bucketListItemName) 
		{													   
		    var bucketListItems = GetBucketListItem(userName, bucketListItemName, "", true);
			bdb.UpsertBucketListItemV2(bucketListItems);					  								  
		}

		private void SortTest() 
		{								  
			var currentBucketListItems =  this.bdb.GetBucketListV2(userName, "order by ListItemName", ""); 
			Assert.IsNotNull(currentBucketListItems);   											   
			Assert.AreEqual(currentBucketListItems.Length, 5);   
			Assert.IsTrue(currentBucketListItems[0].IndexOf("an awesome list item name") != -1);
			Assert.IsTrue(currentBucketListItems[1].IndexOf("bi 2") != -1);
			Assert.IsTrue(currentBucketListItems[2].IndexOf("bi 3") != -1);
			Assert.IsTrue(currentBucketListItems[3].IndexOf("bi 4") != -1);
			Assert.IsTrue(currentBucketListItems[4].IndexOf("bi 5") != -1);

			currentBucketListItems =  this.bdb.GetBucketListV2(userName, "order by ListItemName desc", ""); 
			Assert.IsNotNull(currentBucketListItems);   											   
			Assert.AreEqual(currentBucketListItems.Length, 5);    
			Assert.IsTrue(currentBucketListItems[0].IndexOf("bi 5") != -1);
			Assert.IsTrue(currentBucketListItems[1].IndexOf("bi 4") != -1); 
			Assert.IsTrue(currentBucketListItems[2].IndexOf("bi 3") != -1);	 
			Assert.IsTrue(currentBucketListItems[3].IndexOf("bi 2") != -1);
			Assert.IsTrue(currentBucketListItems[4].IndexOf("an awesome list item name") != -1);																										
		}

		private void SearchTest(string bucketListItemName) 
		{
			var srchTerms = bucketListItemName.Split(' ');
			var firstSearchTerm = srchTerms[0];		
			var secondSearchTerm = srchTerms[1];	
			var notPresentSrchTerm = "MyawesomeNonPresentSrchTrm";					 								  
			var currentBucketListItems =  this.bdb.GetBucketListV2(userName, "", firstSearchTerm); 	   
			Assert.IsTrue(currentBucketListItems[0].IndexOf(firstSearchTerm) != -1);

			currentBucketListItems =  this.bdb.GetBucketListV2(userName, "", secondSearchTerm); 	   
			Assert.IsTrue(currentBucketListItems[0].IndexOf(secondSearchTerm) != -1);		

			currentBucketListItems =  this.bdb.GetBucketListV2(userName, "", notPresentSrchTerm); 	   
			Assert.IsTrue(currentBucketListItems[0].IndexOf(secondSearchTerm) == -1);	   	   
			Assert.AreEqual(currentBucketListItems[0],"No Items");	
		}

        private string[] UpsertTest(string[] bucketListItems)
        {
            bdb.UpsertBucketListItemV2(bucketListItems);
            var savedBucketListItems = bdb.GetBucketListV2(userName, "");
            var listItemName = bucketListItems[0];
            int pos = savedBucketListItems[0].IndexOf(listItemName);
            Assert.IsTrue(pos != -1);

            return savedBucketListItems;
        }
        private string[] UpsertGetBucketListItemV2Test(string[] bucketListItems)
        {
            var savedBucketListItems = UpsertTest(bucketListItems);

            bucketListItems[0] = "an updated list item name";
            bucketListItems[6] = GetBucketListItemDbId(savedBucketListItems[0]);

            savedBucketListItems = UpsertTest(bucketListItems);

            return savedBucketListItems;
        }
    }
}
