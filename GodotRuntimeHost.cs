using LibreWorlds.WorldQueue.Queue;

namespace LibreWorlds.Client;

public sealed class GodotRuntimeHost
{
    private readonly WorldCommandQueue _queue;
    private readonly global::LibreWorlds.WorldRuntime.WorldCommandProcessor _processor;

    public GodotRuntimeHost(
        WorldCommandQueue queue,
        global::LibreWorlds.WorldRuntime.LoggingWorldEngine engine)
    {
        _queue = queue;
        _processor = new global::LibreWorlds.WorldRuntime.WorldCommandProcessor(engine);
    }

    public void Tick()
    {
        while (_queue.TryDequeue(out var command))
        {
            _processor.Process(command);
        }
    }
}
