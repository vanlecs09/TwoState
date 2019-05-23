using System.Collections.Generic;
using Entitas;
using UnityEngine;
public class LogDebugSystem : ReactiveSystem<LogEntity>
{

    public LogDebugSystem(Contexts contexts) : base(contexts.log)
    {
    }

    protected override ICollector<LogEntity> GetTrigger(IContext<LogEntity> context)
    {
        return context.CreateCollector(LogMatcher.LogDebug);
    }

    protected override bool Filter(LogEntity entity)
    {
        return entity.hasLogDebug;
    }
    protected override void Execute(List<LogEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log(e.logDebug.message);
            e.Destroy();
        }
    }
}