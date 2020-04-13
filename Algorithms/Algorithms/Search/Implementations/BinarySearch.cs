using System;
using System.Collections.Generic;
using Shared.dto;
using Shared.misc;
using System.Linq;
using AlgorithmsUnit.Searching.models;

namespace Algorithms.Algorithms.Search.Implementations
{
    public class BinarySearch : ISearch
    {
        public Enums.SearchAlgorithms GetSearchingAlgorithm()
        {
            return Enums.SearchAlgorithms.Binary;
        }

        public IList<BucketListItem> Search(IList<BucketListItem> bucketListItems, string srchTerm)
        {
            IList<BucketListItem> matchingBucketListItems = null;
            var bucketListItemNameTerms = CreateBucketListItemIdTermArray(bucketListItems);
            var sortedBucketListItemNameTerms = SortBucketListItemNameTerms(bucketListItemNameTerms);
            var searchResult = SentenceBinarySearch(sortedBucketListItemNameTerms, srchTerm);

            if (searchResult.SearchTermFound)
            {
                var matchingIndexes = FindAdditionalMatches(sortedBucketListItemNameTerms, searchResult.Index, srchTerm);
                matchingBucketListItems = GetMatchingSentences(bucketListItems, matchingIndexes);
            }

            return matchingBucketListItems;
        }

        #region Private Methods

        private List<BucketListItemNameTerm> CreateBucketListItemIdTermArray(IList<BucketListItem> bucketListItems)
        {
            var sentenceTerms = new List<BucketListItemNameTerm>();

            var bucketListItemNameId = 0;
            var ctr = 1;
            foreach (var bucketListItem in bucketListItems)
            {
                var curSentenceTerms = bucketListItem.Name.Split(" ").ToList();

                foreach (var sentenceTerm in curSentenceTerms)
                {
                    var processedSentenceTerm = RemoveCharacters(sentenceTerm);
                    if (!string.IsNullOrEmpty(processedSentenceTerm))
                    {
                        sentenceTerms.Add(new BucketListItemNameTerm()
                        {
                            Term = processedSentenceTerm.ToLower(),
                            BucketListItemNameId = bucketListItemNameId
                        });
                        ctr++;
                    }
                }

                bucketListItemNameId++;
            }

            return sentenceTerms;
        }
        private string RemoveCharacters(string sentenceTerm)
        {
            sentenceTerm = sentenceTerm.Replace("(", "");
            sentenceTerm = sentenceTerm.Replace(")", "");
            sentenceTerm = sentenceTerm.Replace("'", "");
            sentenceTerm = sentenceTerm.Replace("\"", "");
            sentenceTerm = sentenceTerm.Replace("-", "");
            sentenceTerm = sentenceTerm.Replace("<", "");
            sentenceTerm = sentenceTerm.Replace(">", "");
            sentenceTerm = sentenceTerm.Replace(".", "");

            return sentenceTerm;
        }
        private List<BucketListItemNameTerm> SortBucketListItemNameTerms(List<BucketListItemNameTerm> sentenceTerms)
        {
            var sortedSentenceTerms = (from sentenceTerm in sentenceTerms
                                       orderby sentenceTerm.Term
                                       select sentenceTerm).ToList();

            return sortedSentenceTerms;
        }
        private SentenceBinarySearchResult SentenceBinarySearch(List<BucketListItemNameTerm> sortedSentenceTerms, string searchTerm)
        {
            var srchResult = new SentenceBinarySearchResult();
            var searchTermLower = searchTerm.ToLower();

            int start = 0;
            int end = sortedSentenceTerms.Count - 1;

            while (start <= end)
            {
                bool startLastIncremented = false;
                int mid = start + (end - start) / 2;
                var currentValue = sortedSentenceTerms[mid];
                var compareTerm = currentValue.Term.ToLower();

                if (compareTerm == searchTerm)
                {
                    srchResult.SearchTermFound = true;
                    srchResult.Index = mid;
                    break;
                }

                var currentTermChar = '0';
                var searchTermChar = '0';
                GetTermCharForComparison(currentValue.Term, searchTerm, out currentTermChar, out searchTermChar);
                if (currentTermChar == searchTermChar && startLastIncremented)
                {
                    start++;
                    continue;
                }
                if (currentTermChar == searchTermChar && !startLastIncremented)
                {
                    end--;
                    continue;
                }

                if (currentTermChar < searchTermChar) 
                { 
                    start = mid + 1;
                    startLastIncremented = true;
                }
                if (currentTermChar > searchTermChar) { end = mid - 1; }
            }

            return srchResult;
        }
        private List<int> FindAdditionalMatches(List<BucketListItemNameTerm> sortedBucketListItemNameTerms, int fndIndex, string srchString)
        {
            var matchingIndexes = new List<int>();
            matchingIndexes.Add(sortedBucketListItemNameTerms[fndIndex].BucketListItemNameId);

            //search greater than index
            matchingIndexes = SearchIndexes(matchingIndexes, sortedBucketListItemNameTerms, fndIndex, srchString, true);

            //search less than index
            matchingIndexes = SearchIndexes(matchingIndexes, sortedBucketListItemNameTerms, fndIndex, srchString, false);

            return matchingIndexes;
        }
        private List<int> SearchIndexes(List<int> matchingIndexes, List<BucketListItemNameTerm> sortedBucketListItemNameTerms, int fndIndex, string srchString, bool greaterThan)
        {
            int ctr = greaterThan ? ++fndIndex : --fndIndex;

            while (true)
            {
                var curSortedSentenceTerm = sortedBucketListItemNameTerms[ctr];

                if (curSortedSentenceTerm.Term == srchString)
                {
                    if (!matchingIndexes.Contains(curSortedSentenceTerm.BucketListItemNameId))
                    {
                        matchingIndexes.Add(curSortedSentenceTerm.BucketListItemNameId);
                    }
                }
                else
                {
                    break;
                }

                if (greaterThan && ctr >= sortedBucketListItemNameTerms.Count) { break; }
                if (!greaterThan && ctr <= 0) { break; }

                if (greaterThan) { ctr++; } else { ctr--; }
            }

            return matchingIndexes;
        }
        private List<BucketListItem> GetMatchingSentences(IList<BucketListItem> bucketListItems, List<int> matchingIndexes)
        {
            var matchingSentences = new List<BucketListItem>();

            for (int i = 0; i < bucketListItems.Count; i++)
            {
                if (matchingIndexes.Contains(i))
                {
                    matchingSentences.Add(bucketListItems[i]);
                }
            }

            return matchingSentences;
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

        #endregion
    }
}
