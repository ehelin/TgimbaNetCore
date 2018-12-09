namespace DAL.misc.sql
{
    public class DashboardSql
    {
        public const string DASHBOARD_USER_SQL = " select count(distinct username) UserCount, 'Total Users' Label "
                                               + " from Bucket.[User] ";

        public const string DASHBOARD_CATEGORY_SQL = "  select distinct bli.Category Category, "
                                                    + " 	   count(bli.Category) CategoryCount "
                                                    + " from Bucket.[User] u "
                                                    + " inner join Bucket.BucketListUser blu on u.UserId = blu.UserId "
                                                    + " inner join Bucket.BucketListItem bli on blu.BucketListItemId = bli.BucketListItemId "
                                                    + " where bli.Category in ('Hot','Warm','Cool') "
                                                    + " group by bli.Category ";

        public const string DASHBOARD_ACHIEVED_SQL = "  select distinct  "
                                                    + " 	   case  "
                                                    + " 			when bli.Achieved = 1 then 'True' "
                                                    + " 			else 'False' "
                                                    + " 	   end Achieved, "
                                                    + " 	   count(bli.Achieved) AchievedCount "
                                                    + " from Bucket.[User] u "
                                                    + " inner join Bucket.BucketListUser blu on u.UserId = blu.UserId "
                                                    + " inner join Bucket.BucketListItem bli on blu.BucketListItemId = bli.BucketListItemId "
                                                    + " group by bli.Achieved "
                                                    + " order by Achieved desc ";

        public const string DASHBOARD_CREATED_SQL = "  select distinct DatePart(yyyy, bli.Created) CreatedYear,  "
                                                    + " 	   count(bli.Created) CreatedCount  "
                                                    + " from Bucket.[User] u  "
                                                    + " inner join Bucket.BucketListUser blu on u.UserId = blu.UserId  "
                                                    + " inner join Bucket.BucketListItem bli on blu.BucketListItemId = bli.BucketListItemId  "
                                                    + " group by DatePart(yyyy, bli.Created) ";
    }
}
