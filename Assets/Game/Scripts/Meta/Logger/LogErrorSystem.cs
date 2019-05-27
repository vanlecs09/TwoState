using System.Collections.Generic;
using Entitas;
using UnityEngine;
public class LogErrorSystem : ReactiveSystem<LogEntity>
{

    public LogErrorSystem(Contexts contexts) : base(contexts.log)
    {
    }

    protected override ICollector<LogEntity> GetTrigger(IContext<LogEntity> context)
    {
        return context.CreateCollector(LogMatcher.LogError);
    }

    protected override bool Filter(LogEntity entity)
    {
        return entity.hasLogError;
    }
    protected override void Execute(List<LogEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log(e.logError.message);
            e.Destroy();
        }
    }
}