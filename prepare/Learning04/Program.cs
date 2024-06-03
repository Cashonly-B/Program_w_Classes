using System;

class Program
{
    static void Main(string[] args)
    { 
    }
        public class MathAssignment
        {
            private string _textbookSection;
            private string _problems;
            
            public string GetHomeworkList()
            {
                return _problems;
            }
        }

        public class WritingAssignment
        {
            private string _title;
            
            public string GetHomeworkList()
            {
                return _title;
            }
        }

        public class Assignment
        {
            private string _studentName;
            private string _topic;

            public string GetSummary()
            {
                return _studentName;
            }
        }
}

