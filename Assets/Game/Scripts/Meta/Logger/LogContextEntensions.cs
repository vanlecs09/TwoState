using Entitas;
using System;
public static class LogContextExtension
{
    public static void CreateDebugMessage(this LogContext logContext, string debugMessage)
    {
        LogEntity entity = logContext.CreateEntity();
        entity.AddLogDebug(debugMessage);
    }

    public static void CreateErrorMessage(this LogContext logContext, string erroMessage)
    {
        LogEntity entity = logContext.CreateEntity();
        entity.AddLogError(erroMessage);
    }

    public static void CreateWarningMessage(this LogContext logContext, string wariningMessage)
    {
        LogEntity entity = logContext.CreateEntity();
        entity.AddLogWarning(wariningMessage);
    }
        
}