using System.Collections.Generic;
using Entitas;
using UnityEngine;
public class LogWarning : ReactiveSystem<LogEntity>
{

    public LogWarning(Contexts contexts) : base(contexts.log)
    {
    }

    protected override ICollector<LogEntity> GetTrigger(IContext<LogEntity> context)
    {
        return context.CreateCollector(LogMatcher.LogWarning);
    }

    protected override bool Filter(LogEntity entity)
    {
        return entity.hasLogWarning;
    }
    protected override void Execute(List<LogEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.LogWarning(e.logWarning.message);
            e.Destroy();
        }
    }
}