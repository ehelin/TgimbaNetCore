namespace AlgorithmsUnit.Searching.models
{
    public class BucketListItemNameTerm
    {   
        public int BucketListItemNameId { get; set; }
        public string Term { get; set; }

        public override string ToString()
        {
            return Term;
        }
    }
}
