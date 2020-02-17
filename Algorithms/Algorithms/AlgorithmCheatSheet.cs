namespace Algorithms.Algorithms
{
    /// <summary>
    /// Quick visual reference only
    /// </summary>
    public class AlgorithmCheatSheet
    {
        public AlgorithmCheatSheet() 
        {
            RunInsertionSort();
            RunBubbleSort();
        }

        private void RunInsertionSort()
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

        private void RunBubbleSort()
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
