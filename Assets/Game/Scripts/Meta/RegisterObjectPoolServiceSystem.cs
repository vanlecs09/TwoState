using Entitas;

public class RegisterObjectPoolServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IObjectPoolService _objectPoolService;

    public RegisterObjectPoolServiceSystem(Contexts contexts, IObjectPoolService objectPoolService)
    {
        _metaContext = contexts.meta;
        _objectPoolService = objectPoolService;
    }

    public void Initialize()
    {
        _metaContext.ReplaceObjectPool(_objectPoolService);
    }
}