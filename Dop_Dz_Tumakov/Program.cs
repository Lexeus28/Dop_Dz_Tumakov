using Dop_Dz_Tumakov;
using System;
namespace DopTumakov
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie();
        }
        static void Zadanie()
        {
            Queue<Resident> heatingQueue = new Queue<Resident>();
            Queue<Resident> paymentQueue = new Queue<Resident>();
            Queue<Resident> otherQueue = new Queue<Resident>();
            Stack<Resident> zinaStack = new Stack<Resident>();
            Dictionary<int, List<string>> problemKeywords = new Dictionary<int, List<string>>
        {
            { 1, new List<string> { "отопление", "подключение" } },
            { 2, new List<string> { "оплата", "счёт" } },
        };
            zinaStack.Push(new Resident("Иван", "123456", new Problem(1, "Проблема с отоплением"), new Temperament(6, true)));
            zinaStack.Push(new Resident("Анна", "654321", new Problem(2, "Проблема с оплатой"), new Temperament(3, false)));
            zinaStack.Push(new Resident("Олег", "112233", new Problem(3, "Другая проблема"), new Temperament(8, false)));
            while (zinaStack.Count > 0)
            {
                Resident resident = zinaStack.Pop();
                if (!resident.Temperament.IsSmart)
                {
                    Random random = new Random();
                    int randomWindow = random.Next(1, 4);
                    AddToQueue(resident, randomWindow, heatingQueue, paymentQueue, otherQueue);
                    continue;
                }
                int window = DetermineWindow(resident.Problem.Description, problemKeywords);
                AddToQueue(resident, window, heatingQueue, paymentQueue, otherQueue);
            }
            Console.WriteLine("Очередь к первому окну (отопление):");
            PrintQueue(heatingQueue);

            Console.WriteLine("Очередь ко второму окну (оплата):");
            PrintQueue(paymentQueue);

            Console.WriteLine("Очередь к третьему окну (прочее):");
            PrintQueue(otherQueue);
        }
        static int DetermineWindow(string problemDescription, Dictionary<int, List<string>> keywords)
        {
            foreach (var keyword in keywords)
            {
                if (keyword.Value.Any(kw => problemDescription.Contains(kw, StringComparison.OrdinalIgnoreCase)))
                {
                    return keyword.Key;
                }
            }
            return 3;
        }
        static void AddToQueue(Resident resident, int window, Queue<Resident> heatingQueue, Queue<Resident> paymentQueue, Queue<Resident> otherQueue)
        {
            if (resident.Temperament.Scandalousness >= 5)
            {
                Console.WriteLine($"{resident.Name} обгоняет очередь!");
            }

            switch (window)
            {
                case 1:
                    heatingQueue.Enqueue(resident);
                    break;
                case 2:
                    paymentQueue.Enqueue(resident);
                    break;
                case 3:
                    otherQueue.Enqueue(resident);
                    break;
            }
        }
        static void PrintQueue(Queue<Resident> queue)
        {
            while (queue.Count > 0)
            {
                Resident resident = queue.Dequeue();
                Console.WriteLine($"{resident.Name} ({resident.PassportNumber}) - {resident.Problem.Description}");
            }
        }
    }
}
