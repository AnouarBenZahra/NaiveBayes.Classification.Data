using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NaiveBayes
{
    public static class Helpers
    {
        public static List<String> ExtractInfos(this String ch)
        {
            return Regex.Replace(ch, "\\p{P}+", "").Split(' ').ToList();
        }
    }
}
