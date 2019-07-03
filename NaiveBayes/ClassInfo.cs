using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayes
{
    public class ClassInfo
    {
        public ClassInfo(string Nom, List<String> training)
        {
            Name = Nom;
            var info = training.SelectMany(z => z.ExtractInfos());
            WordsNumber = info.Count();
            WordCount =
                info.GroupBy(z => z)
                .ToDictionary(z => z.Key, z => z.Count());
            NumberOfClasses = training.Count;
        }
        public string Name { get; set; }
        public int WordsNumber { get; set; }
        public Dictionary<string, int> WordCount { get; set; }
        public int NumberOfClasses { get; set; }
        public int NumberOfOccurencesInTrainClasses(String word)
        {
            if (WordCount.Keys.Contains(word))
                return WordCount[word];
            return 0;
            
        }
    }
}
