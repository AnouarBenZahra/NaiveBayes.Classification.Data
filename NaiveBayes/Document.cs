using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaiveBayes
{
    public class Document
    {
        public Document(string @class, string text)
        {
            Class = @class;
            Text = text;
        }
        public string Class { get; set; }
        public string Text { get; set; }
    }

}
