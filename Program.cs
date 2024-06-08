using System;

namespace ConsoleApp39
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine();
            if (File.Exists(filePath))
            {
                string fileContent = File.ReadAllText(filePath);
                Console.WriteLine($"File content:\n{fileContent}");
            }
            else
            {
                Console.WriteLine("Error: File not found.");
            }
            Console.WriteLine("Enter array elements separated by space:");
            string input = Console.ReadLine();
            int[] array = Array.ConvertAll(input.Split(' '), int.Parse);
            Console.WriteLine("Enter the path to the file to save the array:");
            string filePath2 = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filePath2))
            {
                foreach (int num in array)
                {
                    writer.Write(num + " ");
                }
            }
            Console.WriteLine("Array saved to file successfully.");
            Console.WriteLine("Enter the path to the file to load the array:");
            string filePath3 = Console.ReadLine();
            if (File.Exists(filePath3))
            {
                string content = File.ReadAllText(filePath3);
                int[] array2 = Array.ConvertAll(content.Split(' '), int.Parse);
                Console.WriteLine($"Array loaded from file: [{string.Join(", ", array2)}]");
            }
            else
            {
                Console.WriteLine("Error: File not found.");
            }
            Random random = new Random();
            const int count = 10000;
            int[] numbers = new int[count];
            for (int i = 0; i < count; i++)
            {
                numbers[i] = random.Next(int.MinValue, int.MaxValue);
            }
            string evenFilePath = "even_numbers.txt";
            string oddFilePath = "odd_numbers.txt";
            using (StreamWriter evenWriter = new StreamWriter(evenFilePath))
            using (StreamWriter oddWriter = new StreamWriter(oddFilePath))
            {
                foreach (int num in numbers)
                {
                    if (num % 2 == 0)
                    {
                        evenWriter.WriteLine(num);
                    }
                    else
                    {
                        oddWriter.WriteLine(num);
                    }
                }
            }
            int evenCount = File.ReadLines(evenFilePath).Count();
            int oddCount = File.ReadLines(oddFilePath).Count();
            Console.WriteLine($"Total numbers: {count}");
            Console.WriteLine($"Even numbers: {evenCount}");
            Console.WriteLine($"Odd numbers: {oddCount}");
            Console.WriteLine("Enter the path to the file:");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                Console.WriteLine("Enter the word to search:");
                string word = Console.ReadLine();

                int wordCount = File.ReadLines(filePath)
                                    .SelectMany(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                                    .Count(w => w.Equals(word, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"Occurrences of '{word}': {wordCount}");

                string reversedWord = new string(word.Reverse().ToArray());
                int reversedWordCount = File.ReadLines(filePath)
                                            .SelectMany(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                                            .Count(w => w.Equals(reversedWord, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine($"Occurrences of '{reversedWord}' (reversed): {reversedWordCount}");
            }
            else
            {
                Console.WriteLine("Error: File not found.");
            }
        }
    }
}
