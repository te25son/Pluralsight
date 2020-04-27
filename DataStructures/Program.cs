using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericDelegateExamples();
            EventExamples();
            ConverterExamples();

            var buffer = new Buffer<double>();
            ProcessInput(buffer);
            ProcessBuffer(buffer);
        }

        private static void ConverterExamples()
        {
            var buffer = new Buffer<double>();

            ProcessInput(buffer);

            // Converts given buffer items to a DateTime object.
            var asDates = buffer.Map(
                d => new DateTime(2010, 1, 1).AddDays(d)
            );

            foreach (var date in asDates)
            {
                Console.WriteLine(date);
            }

            buffer.Dump(d => Console.WriteLine(d));

            Converter<double, int> converter2 = d => Convert.ToInt32(d);
            var asInts = buffer.Map(converter2);
            foreach (var item in asInts)
            {
                Console.WriteLine($"{item} : {item.GetType()}");
            }
        }

        private static void EventExamples()
        {
            var buffer = new CircularBuffer<double>(3);
            buffer.ItemDiscarded +=  ItemDiscarded;
            ProcessInput(buffer);
            ProcessBuffer(buffer);
        }

        private static void ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine($"Buffer full. Discarding {e.ItemDiscarded}. Adding {e.NewItem}");
        }

        private static void GenericDelegateExamples()
        {
            // Action always returns void.
            Action<object> print = d => Console.WriteLine(d);

            // Func always returns the last parameter passed to it.
            Func<double, double> square = d => d * d;
            Func<double, double, double> add = (x, y) => x + y;

            // Predicate always returns a boolean.
            Predicate<double> isLessThanTen = d => d < 10;

            var result = add(3, 5);
            var squaredResult = square(result);
            var squaredResultIsLessThanTen = isLessThanTen(squaredResult);
            if (squaredResultIsLessThanTen)
            {
                print($"{squaredResult} is less than 10.");
            }
            else
            {
                print($"{squaredResult} is greater than 10.");
            }
        }

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");

            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
