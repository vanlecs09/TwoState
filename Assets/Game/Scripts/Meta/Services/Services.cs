public class Services
{
    public readonly IViewService View;
    // public readonly IGameStateService  GameState;
    // public readonly IApplicationService Application;
    public readonly ITimeService Time;
    public readonly IObjectPoolService ObjectPool;
    public readonly IGenerateBoardService GenerateBoard;
    // public readonly IInputService Input;
    // public readonly IAiService Ai;
    // public readonly IConfigurationService Config;
    // public readonly ICameraService Camera;
    // public readonly IPhysicsService Physics;

    public Services(IViewService view, ITimeService time, IObjectPoolService objectPool, IGenerateBoardService generateBoard)
    {
        View = view;
        // Application = application;
        Time = time;
        ObjectPool = objectPool;
        GenerateBoard = generateBoard;
        // GameState = gameState;
        // Input = input;
        // Ai = ai;
 //       Config = config;
        // Camera = camera;
        // Physics = physics;
    }
}