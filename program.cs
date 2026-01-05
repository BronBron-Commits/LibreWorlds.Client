using LibreWorlds.WorldQueue.Queue;

namespace LibreWorlds.Client;

internal static class Program
{
    private static void Main()
    {
        var queue = new WorldCommandQueue();
        var engine = new global::LibreWorlds.WorldRuntime.LoggingWorldEngine();
        var processor = new global::LibreWorlds.WorldRuntime.WorldCommandProcessor(engine);

        while (true)
        {
            while (queue.TryDequeue(out var command))
            {
                processor.Process(command);
            }
        }
    }
}
