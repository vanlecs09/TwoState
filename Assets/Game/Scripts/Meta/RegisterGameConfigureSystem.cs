using Entitas;

public class RegisterGameConfigureSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IGameConfigureService _service;

    public RegisterGameConfigureSystem(Contexts contexts, IGameConfigureService gameConfigureService)
    {
        _metaContext = contexts.meta;
        _service = gameConfigureService;
    }

    public void Initialize()
    {
        _metaContext.ReplaceGameConfigure(_service);
    }
}