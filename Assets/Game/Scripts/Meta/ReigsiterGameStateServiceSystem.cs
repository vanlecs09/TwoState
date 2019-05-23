// using Entitas;

// public sealed class RegisterGameStateServiceSystem: IInitializeSystem
// {
//     readonly MetaContext _metaContext;
//     private IGameStateService _gameStateService;


//     public RegisterGameStateServiceSystem(Contexts contexts, IGameStateService inputService)
//     {
//         _gameStateService = inputService;
//         _metaContext = contexts.meta;
//     }
//     public void Initialize()
//     {
//         _metaContext.ReplaceGameStateService(_gameStateService);
//     }
// }