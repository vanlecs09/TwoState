using Entitas;

public class RegisterUiManagementServiceSystem : IInitializeSystem
{
    private readonly MetaContext _metaContext;
    private readonly IUiManagementService _uiManagement;

    public RegisterUiManagementServiceSystem(Contexts contexts, IUiManagementService uiManagement)
    {
        _metaContext = contexts.meta;
        _uiManagement = uiManagement;
    }

    public void Initialize()
    {
        _metaContext.ReplaceUiManagementService(_uiManagement);
    }
}