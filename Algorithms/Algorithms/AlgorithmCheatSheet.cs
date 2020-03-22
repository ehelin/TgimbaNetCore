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
        // delete when done


        public void RunBinarySearchSentencesSingleSearchTermPrototype()
        {
            //var bucketListItems = GetBucketListItems();
            
            var sentences = GetBinarySearchSentences();
            var sentenceTerms = CreateSentenceIdTermArray(sentences);
            var sortedSentenceTerms = SortSentenceTerms(sentenceTerms);

            var result = "Search Not Run";
            var searchTerm = "word";  //picked arbitrarily
            var searchTermChar = Convert.ToChar(searchTerm.Substring(0,1).ToLower());

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
                var currentTermChar = Convert.ToChar(currentValue.Term.Substring(0,1).ToLower());
                if (currentTermChar < searchTermChar) { start = mid + 1; }
                if (currentTermChar > searchTermChar) { end = mid - 1; }
            }

            var test = result;

            //"A sentence that contains a word"
            //"A sentence that contains the word"
            //"French is a language"
            //"Robin and Lili are our cats."
            //"Silvia is my wife"
            //"Zeus is a word for a greek god"
        }

        private List<BucketListItem> GetBucketListItems()
        {
            var bucketListItems = new List<BucketListItem>();

            bucketListItems.Add(new BucketListItem() { Name = "Zeus is a greek god" });
            bucketListItems.Add(new BucketListItem() { Name = "French is a language" });
            bucketListItems.Add(new BucketListItem() { Name = "Silvia is my wife" });
            bucketListItems.Add(new BucketListItem() { Name = "A sentence that contains the word" });
            bucketListItems.Add(new BucketListItem() { Name = "A sentence that contains a word" });
            bucketListItems.Add(new BucketListItem() { Name = "Robin and Lili are our cats." });

            return bucketListItems;
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

                    if (term1 == "word") {
                        var test = 1;
                    }

                    var term1CharVal = Convert.ToChar(term1.Substring(0, 1).ToLower());
                    var term2CharVal = Convert.ToChar(term2.Substring(0, 1).ToLower());

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
