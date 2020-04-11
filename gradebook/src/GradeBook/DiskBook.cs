using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name;
        }

        public string FilePath
        {
            get
            {
                return $"{Name}.txt";
            }
            set
            {
                string path = value;
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {            
            using (var file = File.AppendText(FilePath))
            {
                file.WriteLine(grade.ToString());
                GradeAdded?.Invoke(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            using (var file = File.OpenText(FilePath))
            {
                var line = file.ReadLine();
                
                while (line != null)
                {
                    var number = double.Parse(line);
                    statistics.Add(number);
                    line = file.ReadLine();
                }
            }
            
            return statistics;
        }
    }
}