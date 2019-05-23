using Entitas;

public class ReigsterGenerateBoardService : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IGenerateBoardService _viewService;

    public ReigsterGenerateBoardService(Contexts contexts, IGenerateBoardService viewService)
    {
        _metaContext = contexts.meta;
        _viewService = viewService;
    }

    public void Initialize()
    {
        _metaContext.ReplaceGenerateBoardService(_viewService);
    }
}