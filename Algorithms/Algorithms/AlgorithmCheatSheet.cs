using System.Collections.Generic;
using System.Linq;
using System;
using Algorithms.Algorithms.Sorting.Implementations;
using Shared.dto;
using Shared.misc;

namespace Algorithms.Algorithms
{
    /// <summary>
    /// Quick visual reference only
    /// </summary>
    public class AlgorithmCheatSheet
    {
        public AlgorithmCheatSheet(bool doNotRun = false) 
        {
            if (!doNotRun)
            {
                RunInsertionSort(SetValues());
                RunBubbleSort(SetValues());
                RunBinarySearch(SetValues());
            }
        }

        #region Cheat Sheet :)

        private int[] RunInsertionSort(int[] values)
        {
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

            return values;
        }
        private int[] RunBubbleSort(int[] values)
        {
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
        private void RunBinarySearch(int[] values)
        {
            var result = "Search Not Run";
            var sortedValues = RunBubbleSort(values);
            var searchTerm = 34;  //picked arbitrarily
            
            int start = 0;
            int end = sortedValues.Length -1;

            while (start < end)
            {
                int mid = start + (end - start) / 2;
                var currentValue = sortedValues[mid];

                if (currentValue == searchTerm)
                {
                    result = "Search term '" + searchTerm.ToString() + "' found!";
                    break;
                } 
                if (currentValue < searchTerm) { start = mid + 1; }
                if (currentValue > searchTerm) { end = mid - 1; } 
            }            
        }
        private int[] SetValues()
        {
            return new int[] { 89, 4, 2, 145, 5, 982, 5, 4, 34, 53, 3 };
        }

        #endregion

        #region Binary search multiple sentence single search term prototype

        public void RunBinarySearchSentencesSingleSearchTermPrototype()
        {
            var sentences = GetBinarySearchSentences();
            var sentenceTerms = CreateSentenceIdTermArray(sentences);
            var sortedSentenceTerms = SortSentenceTerms(sentenceTerms);

            var result = "Search Not Run";
            var searchTerm = "word";  //picked arbitrarily

            int start = 0;
            int end = sortedSentenceTerms.Count - 1;

            while (start < end)
            {
                int mid = start + (end - start) / 2;
                var currentValue = sortedSentenceTerms[mid];

                if (currentValue.Term == searchTerm)
                {
                    result = "Search term '" + searchTerm.ToString() + "' found!";
                    break;
                }
                
                var currentTermChar = '0';
                var searchTermChar = '0';

                GetTermCharForComparison(currentValue.Term, searchTerm, out currentTermChar, out searchTermChar);
                if (currentTermChar < searchTermChar) { start = mid + 1; }
                if (currentTermChar > searchTermChar) { end = mid - 1; }
            }

            var test = result;
        }

        private void GetTermCharForComparison(string term1, string term2, out char term1Char, out char term2Char)
        {
            var charCountToIterate = term1.Length > term2.Length ? term2.Length : term1.Length;
            var ctr = 0;
            char term1CharTmp = '0';
            char term2CharTmp = '0';

            while (ctr < charCountToIterate)
            {
                term1CharTmp = Convert.ToChar(term1.Substring(ctr, 1).ToLower());
                term2CharTmp = Convert.ToChar(term2.Substring(ctr, 1).ToLower());

                if (term1CharTmp == term2CharTmp)
                {
                    ctr++;
                    continue; 
                }
                else 
                {
                    break;
                }
            }

            term1Char = term1CharTmp;
            term2Char = term2CharTmp;
        }
        private List<SentenceTerm> SortSentenceTerms(List<SentenceTerm> sentenceTerms)
        {
            for(var outer=0; outer<sentenceTerms.Count; outer++)
            {
                for (var inner=0; inner<sentenceTerms.Count; inner++)
                {
                    if (inner + 1 >= sentenceTerms.Count) { break; }

                    var term1 = sentenceTerms[inner].Term;
                    var term2 = sentenceTerms[inner+1].Term;
                    var term1CharVal = '0';
                    var term2CharVal = '0';

                    GetTermCharForComparison(term1, term2, out term1CharVal, out term2CharVal);

                    if (term1CharVal > term2CharVal)
                    {
                        var tmp = sentenceTerms[inner];
                        sentenceTerms[inner] = sentenceTerms[inner+1];
                        sentenceTerms[inner+1] = tmp;
                    }
                }
            }

            return sentenceTerms;
        }
        private List<string> GetBinarySearchSentences()
        {
            var sentences = new List<string>();

            sentences.Add("Zeus is a word for a greek god");
            sentences.Add("French is a language");
            sentences.Add("Silvia is my wife");
            sentences.Add("A sentence that contains the word");
            sentences.Add("A sentence that contains a word");
            sentences.Add("Joe, Kookie, Robin and Lili are our cats");

            return sentences;
        }
        private List<SentenceTerm> CreateSentenceIdTermArray(List<string> sentences)
        {
            var sentenceTerms = new List<SentenceTerm>();

            var sentenceId = 1;
            foreach (var sentence in sentences)
            {
                var curSentenceTerms = sentence.Split(" ").ToList();

                foreach (var sentenceTerm in curSentenceTerms)
                {
                    sentenceTerms.Add(new SentenceTerm()
                    {
                        Term = sentenceTerm,
                        SentenceId = sentenceId
                    });
                }

                sentenceId++;
            }

            return sentenceTerms;
        }

        #endregion
    }

    public class SentenceTerm
    {
        public int SentenceId { get; set; }
        public string Term { get; set; }
    }
}
