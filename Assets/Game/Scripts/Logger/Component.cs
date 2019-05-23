using Entitas;

[Log]
public class LogDebugComponent : IComponent
{
    public string message;
}

[Log]
public class LogWarningComponent: IComponent
{
    public string message;
}

[Log]
public class LogErrorComponent: IComponent
{
    public string message;
}