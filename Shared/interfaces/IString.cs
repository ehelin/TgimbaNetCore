using Shared.misc;

namespace Shared.interfaces
{
    public interface IString
    {
        string DecodeBase64String(string val);
        string EncodeBase64String(string val);
        bool HasSortOrderAsc(string sortString);
        string GetLowerCaseSortString(string sortString);
        Enums.SortColumns GetSortColumn(string sortString);
    }
}
