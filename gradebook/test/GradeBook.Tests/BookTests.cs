using System;
using System.Collections.Generic;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookStatisticsResult()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(88.3);
            book.AddGrade(90.7);
            book.AddGrade(73.7);

            // act
            var statistics = book.GetStatistics();

            // assert
            Assert.Equal(84.23, statistics.Average, 1);
            Assert.Equal(90.7, statistics.Highest, 1);
            Assert.Equal(73.7, statistics.Lowest, 1);
            Assert.Equal('B', statistics.Letter);
        }

        [Fact]
        public void AddGradeThrowsInvalidMessage()
        {
            var book = new Book("Book");
            
            Assert.Throws<ArgumentException>(() => book.AddGrade(101.00));
            Assert.Throws<ArgumentException>(() => book.AddGrade(-1.0));
        }
    }
}
