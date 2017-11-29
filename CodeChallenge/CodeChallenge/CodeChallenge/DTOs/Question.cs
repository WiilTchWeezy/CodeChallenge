using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.DTOs
{
    public class Question
    {
        public string QuestionText { get; set; }
        public string[] Alternatives { get; set; }
        public string CorrectAlternative { get; set; }
    }
}
