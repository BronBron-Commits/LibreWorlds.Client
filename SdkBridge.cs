using LibreWorlds.WorldQueue.Queue;

namespace LibreWorlds.Client;

public sealed class SdkBridge
{
    private readonly WorldCommandQueue _queue;

    public SdkBridge()
    {
        _queue = new WorldCommandQueue();
    }

    public WorldCommandQueue Queue => _queue;
}
