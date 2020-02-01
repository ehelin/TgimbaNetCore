using System.Collections.Generic;
using Shared.misc;

namespace Shared.dto
{
    public class InitializeResult
    {
        public bool IsMobile { get; set; }
        public string[] AvailableSortingAlgorithms { get; set; }
    }
}
