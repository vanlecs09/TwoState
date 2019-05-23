using Entitas;

public class LogSystems : Feature
{
    public LogSystems(Contexts contexts) : base("Logger")
    {
        Add(new LogDebugSystem(contexts));
        Add(new LogWarning(contexts));
        Add(new LogErrorSystem(contexts));
    }
}