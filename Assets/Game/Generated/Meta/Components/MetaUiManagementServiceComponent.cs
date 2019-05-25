//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity uiManagementServiceEntity { get { return GetGroup(MetaMatcher.UiManagementService).GetSingleEntity(); } }
    public UiManagementServiceComponent uiManagementService { get { return uiManagementServiceEntity.uiManagementService; } }
    public bool hasUiManagementService { get { return uiManagementServiceEntity != null; } }

    public MetaEntity SetUiManagementService(IUiManagementService newInstance) {
        if (hasUiManagementService) {
            throw new Entitas.EntitasException("Could not set UiManagementService!\n" + this + " already has an entity with UiManagementServiceComponent!",
                "You should check if the context already has a uiManagementServiceEntity before setting it or use context.ReplaceUiManagementService().");
        }
        var entity = CreateEntity();
        entity.AddUiManagementService(newInstance);
        return entity;
    }

    public void ReplaceUiManagementService(IUiManagementService newInstance) {
        var entity = uiManagementServiceEntity;
        if (entity == null) {
            entity = SetUiManagementService(newInstance);
        } else {
            entity.ReplaceUiManagementService(newInstance);
        }
    }

    public void RemoveUiManagementService() {
        uiManagementServiceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaEntity {

    public UiManagementServiceComponent uiManagementService { get { return (UiManagementServiceComponent)GetComponent(MetaComponentsLookup.UiManagementService); } }
    public bool hasUiManagementService { get { return HasComponent(MetaComponentsLookup.UiManagementService); } }

    public void AddUiManagementService(IUiManagementService newInstance) {
        var index = MetaComponentsLookup.UiManagementService;
        var component = (UiManagementServiceComponent)CreateComponent(index, typeof(UiManagementServiceComponent));
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceUiManagementService(IUiManagementService newInstance) {
        var index = MetaComponentsLookup.UiManagementService;
        var component = (UiManagementServiceComponent)CreateComponent(index, typeof(UiManagementServiceComponent));
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveUiManagementService() {
        RemoveComponent(MetaComponentsLookup.UiManagementService);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class MetaMatcher {

    static Entitas.IMatcher<MetaEntity> _matcherUiManagementService;

    public static Entitas.IMatcher<MetaEntity> UiManagementService {
        get {
            if (_matcherUiManagementService == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.UiManagementService);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherUiManagementService = matcher;
            }

            return _matcherUiManagementService;
        }
    }
}