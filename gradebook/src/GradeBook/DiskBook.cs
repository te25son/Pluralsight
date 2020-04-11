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

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {            
            using (var file = File.AppendText($"./{Name}.txt"))
            {
                file.WriteLine(grade.ToString());
                GradeAdded?.Invoke(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            throw new System.NotImplementedException();
        }
    }
}