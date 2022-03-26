

class NewThreadPool
{

    
    public static async Task RunTasksAsync(int tasks,int threads)
    {
        var messages = Enumerable.Range(1, 300).Select(i => $"Задача-{i}");

        var result = await Task.WhenAll(messages.Select(m => ProcessMessageAsync(m)));

        Console.WriteLine($"Сумма = {result.Sum()}");
    }

    private static async Task<int> ProcessMessageAsync(string Message)
    {
        //// стартуем в исходном потоке
        //await Task.Yield();
        //// продолжаем в потоке из пула (не всегда!)

        Console.WriteLine($"Обработка сообщения {Message}...");
        //Thread.Sleep(10); // в асинхронных методах этого быть не должно!!!
        await Task.Delay(10).ConfigureAwait(false); // false - продолжение будет выполнено в одном из потоков пула потоков
        //await Task.Yield();
        Console.WriteLine($"Обработка сообщения {Message} завершена.");

        return Message.Length;
    }

    /// <summary>
    /// Запуск задач
    /// </summary>
    /// <param name="maxThreads">Задать максимальное количество потоков</param>
    /// <param name="threads">Количество потоков</param>
    public static void Run(int maxThreads, int threads)
    {
        var messages = Enumerable.Range(1, 1000)
           .Select(i => $"Message-{i}");

        if (maxThreads>=threads)
        {
            ThreadPool.SetMaxThreads(threads, threads);
            foreach (var message in messages)
                ThreadPool.QueueUserWorkItem(_ => ProcessMessage(message));

            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Количество потоков больше допустимого значения!");
        }


    }

    private static void ProcessMessage(string Message, int Timeout = 1000)
    {
        Console.WriteLine($"[Tid:{Environment.CurrentManagedThreadId}] Запуск процесса обработки {Message}...");
        if (Timeout > 0)
            Thread.Sleep(Timeout);
        Console.WriteLine($"[Tid:{Environment.CurrentManagedThreadId}] Процесса обработки {Message} завершён.");
    }

}