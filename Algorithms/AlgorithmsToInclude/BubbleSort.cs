using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.AlgorithmsToInclude
{
	public class BubbleSort
	{
		public BubbleSort() 
		{	   
			Run();
		}	

		private void Run() 
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
		}
		
		private int[] SetValues()
        {
            return new int[] { 89, 4, 2, 145, 5, 982, 5, 4, 34, 53, 3 };
        }
	}
}
