// using Entitas;
// public class CollisionSystem : ReactiveSystem<InputEntity>, ICleanupSystem
// {
//     IViewService _viewService;
//     readonly Contexts _contexts;
//     public void Cleanup()
//     {
//         throw new System.NotImplementedException();
//     }

//     //  protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) {
//     //     return context.CreateCollector(GameStateMatcher.Asset);
//     // }

//     // protected override bool Filter(GameEntity entity) {
//     //     return entity.hasAsset;
//     // }


//     public CollisionSystem(Contexts contexts) : base(contexts.input)
//     {

//     }
// }