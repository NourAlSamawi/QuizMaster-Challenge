using System;
using System.Collections.Generic;

namespace QuizMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartQuiz();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Quiz has ended.");
            }
        }

        static void StartQuiz()
        {
            List<string> questions = new List<string>
            {
                "What is the capital of Jordan?",
                "What is 2 + 2?",
                "Who wrote 'Eat the frog first'?"
            };

            List<string> answers = new List<string>
            {
                "Amman",
                "4",
                "brian"
            };

            int score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                try
                {
                    Console.WriteLine(questions[i]);
                    var timer = new System.Timers.Timer(10000); // 10 seconds
                    timer.Elapsed += (sender, e) => TimerElapsed(sender, e, ref i);
                    timer.Start();

                    string userAnswer = Console.ReadLine();

                    timer.Stop();


                    if (string.IsNullOrWhiteSpace(userAnswer))
                    {
                        throw new ArgumentException("Answer cannot be empty.");
                    }

                    if (userAnswer.Equals(answers[i], StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Correct!");
                        score++;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect. The correct answer is: " + answers[i]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    i--; 
                }
            }
            Console.WriteLine($"Your final score is: {score}/{questions.Count}");
        }
        static void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e, ref int questionIndex)
        {
            Console.WriteLine("Time's up!");
            questionIndex++;
        }
    }
}
