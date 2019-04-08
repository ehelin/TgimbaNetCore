using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.AlgorithmsToInclude
{
	public class InsertionSort
	{
		public InsertionSort() 
		{	   
			Run();
		}	

		private void Run() 
		{
            int[] values = SetValues();

            for (int outer = 0; outer < values.Length; outer++)
            {
                if (outer == 0) { continue; }

                for (int inner = outer; inner > 0; inner--)
                {
                    int curVal1 = values[inner];
                    int curVal2 = values[inner - 1];

                    if (curVal2 > curVal1)
                    {
                        values[inner] = curVal2;
                        values[inner - 1] = curVal1;
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
