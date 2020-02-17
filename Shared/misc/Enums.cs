namespace Shared.misc
{
    public class Enums
    {
        public enum LogLevel { Error, Info, Verbose }  
        public enum BucketListItemTypes { Cool, Cold, Warm, Hot }
        public enum SortColumns 
        { 
            ListItemName, 
            Created, 
            Category, 
            Achieved 
        }
        public enum SortAlgorithms
        {
            Linq,
            Bubble,
            Insertion
        }
    }
}
