# LibreWorlds.Client

LibreWorlds.Client is a minimal, reference .NET client that proves and exercises the LibreWorlds runtime architecture end-to-end.

It wires together the **SDK**, **WorldAdapter**, **WorldQueue**, and **WorldRuntime** into a runnable host process. The client is intentionally lightweight and exists to validate correctness, integration, and lifecycle flow — not to provide UI or final gameplay logic.

---

## Purpose

This project exists to:

- Verify the LibreWorlds command pipeline works end-to-end
- Serve as a reference host for engine integrations (e.g. Godot)
- Provide a controlled environment for debugging WorldCommands
- Act as a staging point between SDK/network events and runtime execution

It is **not** a production client and does **not** include rendering or networking UI.



## Architecture


LibreWorlds.Sdk
      ↓
LibreWorlds.WorldAdapter
      ↓
LibreWorlds.WorldQueue
      ↓
LibreWorlds.WorldRuntime
      ↓
LibreWorlds.Client (host)


The client:
- Creates the runtime
- Owns the command queue
- Steps the runtime loop
- Logs command execution



## Key Components

- **Program.cs**  
  Entry point. Creates the runtime host and executes the main loop.

- **GodotRuntimeHost.cs**  
  Example host that demonstrates how an external engine (e.g. Godot) would tick the runtime and drain the command queue.

- **SdkBridge.cs**  
  Placeholder integration point for feeding SDK events into the WorldAdapter.

- **LoggingWorldEngine.cs**  
  Simple diagnostic engine implementation used to verify command execution during bring-up.

---

## Build & Run

### Requirements
- .NET SDK 10.x
- Windows x64 (current reference platform)

### Build
```bash
dotnet build
```

### Run
```bash
dotnet run
```

The client will start, initialize the runtime, and idle until commands are injected.

---

## Intended Usage

This client is intended for:

- Runtime bring-up and validation
- Debugging command flow
- Developing and testing WorldCommands
- Serving as a template for engine-specific hosts

Downstream projects are expected to:

- Replace `LoggingWorldEngine`
- Drive the runtime from a real engine loop
- Inject commands from real SDK/network sources

---

## Status

- ✅ Builds and runs
- ✅ End-to-end pipeline verified
- ⚠️ Logging engine duplication will be cleaned up during stabilization
- ⚠️ No UI by design

---

## Related Repositories

- [LibreWorlds.WorldQueue](https://github.com/yourorg/LibreWorlds.WorldQueue)
- [LibreWorlds.WorldRuntime](https://github.com/yourorg/LibreWorlds.WorldRuntime)
- [LibreWorlds.WorldAdapter](https://github.com/yourorg/LibreWorlds.WorldAdapter)
- [LibreWorlds.Sdk](https://github.com/yourorg/LibreWorlds.Sdk)
- [LibreWorlds.Controller](https://github.com/yourorg/LibreWorlds.Controller)

---

## License

MIT (see [LICENSE](LICENSE))

### GitHub Repository Description (paste directly into repo settings)

Reference .NET client that wires LibreWorlds SDK, WorldAdapter, WorldQueue, and WorldRuntime into a runnable host for testing, debugging, and engine integration (Godot, etc.).


### Commit command (run after adding the file)

bash
git add README.md
git commit -m "docs: add comprehensive README describing client purpose and architecture"
git push
