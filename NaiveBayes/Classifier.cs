using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayes
{
    public class Classifier
    {
        List<ClassInfo> _classes;
        int _countOfDocs;
        int _uniqWordsNumber;
        public Classifier(List<Document> training)
        {
            _classes = training.GroupBy(x => x.Class).Select(g => new ClassInfo(g.Key, g.Select(x => x.Text).ToList())).ToList();
            _countOfDocs = training.Count;
            _uniqWordsNumber = training.SelectMany(x => x.Text.Split(' ')).GroupBy(x => x).Count();
        }

        public double Probability(string className, string ch)
        {
            var charr = ch.ExtractInfos();
            var resClass = _classes
                .Select(x => new
                {
                    Result = Math.Pow(Math.E, Calc(x.NumberOfClasses, _countOfDocs, charr, x.WordsNumber, x, _uniqWordsNumber)),
                    ClassName = x.Name
                });


            return resClass.Single(x => x.ClassName == className).Result / resClass.Sum(x => x.Result);
        }

        private static double Calc(double dc, double d, List<String> q, double lc, ClassInfo @class, double v)
        {
            return Math.Log(dc / d) + q.Sum(x => Math.Log((@class.NumberOfOccurencesInTrainClasses(x) + 1) / (v + lc)));
        }
    }
}
