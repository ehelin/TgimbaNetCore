using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.AlgorithmsToInclude
{
	public class BinarySearch
	{
		public BinarySearch() 
		{	   
			Run();
		}	

		private void Run() 
		{
			int searchTerm = 34;
            int[] values = BubbleSort();
            int start = 0;
            int end = values.Length - 1;

            while (start < end)
            {
                int mid = start + (end - start) / 2;
                int curVal = values[mid];

                if (curVal == searchTerm) { break; }

                if (searchTerm > curVal) { start = mid + 1; }
                if (searchTerm < curVal) { end = mid - 1; }
            }
		}
				   
        public int[] BubbleSort()
        {
            int[] values = SetValues();

            for (int outer = 0; outer < values.Length; outer++)
            {
                if (outer > values.Length + 1) { break; }

                for (int inner = 0; inner < values.Length; inner++)
                {
                    int curVal1 = values[outer];
                    int curVal2 = values[inner];

                    if (curVal1 < curVal2)
                    {
                        values[outer] = curVal2;
                        values[inner] = curVal1;
                    }
                }
            }

            return values;
        }
				   		
		private int[] SetValues()
        {
            return new int[] { 89, 4, 2, 145, 5, 982, 5, 4, 34, 53, 3 };
        }
	}
}
