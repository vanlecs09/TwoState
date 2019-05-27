//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class MetaContext {

    public MetaEntity gameDifficultyEntity { get { return GetGroup(MetaMatcher.GameDifficulty).GetSingleEntity(); } }
    public GameDifficultyComponent gameDifficulty { get { return gameDifficultyEntity.gameDifficulty; } }
    public bool hasGameDifficulty { get { return gameDifficultyEntity != null; } }

    public MetaEntity SetGameDifficulty(string newValue) {
        if (hasGameDifficulty) {
            throw new Entitas.EntitasException("Could not set GameDifficulty!\n" + this + " already has an entity with GameDifficultyComponent!",
                "You should check if the context already has a gameDifficultyEntity before setting it or use context.ReplaceGameDifficulty().");
        }
        var entity = CreateEntity();
        entity.AddGameDifficulty(newValue);
        return entity;
    }

    public void ReplaceGameDifficulty(string newValue) {
        var entity = gameDifficultyEntity;
        if (entity == null) {
            entity = SetGameDifficulty(newValue);
        } else {
            entity.ReplaceGameDifficulty(newValue);
        }
    }

    public void RemoveGameDifficulty() {
        gameDifficultyEntity.Destroy();
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

    public GameDifficultyComponent gameDifficulty { get { return (GameDifficultyComponent)GetComponent(MetaComponentsLookup.GameDifficulty); } }
    public bool hasGameDifficulty { get { return HasComponent(MetaComponentsLookup.GameDifficulty); } }

    public void AddGameDifficulty(string newValue) {
        var index = MetaComponentsLookup.GameDifficulty;
        var component = (GameDifficultyComponent)CreateComponent(index, typeof(GameDifficultyComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGameDifficulty(string newValue) {
        var index = MetaComponentsLookup.GameDifficulty;
        var component = (GameDifficultyComponent)CreateComponent(index, typeof(GameDifficultyComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGameDifficulty() {
        RemoveComponent(MetaComponentsLookup.GameDifficulty);
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

    static Entitas.IMatcher<MetaEntity> _matcherGameDifficulty;

    public static Entitas.IMatcher<MetaEntity> GameDifficulty {
        get {
            if (_matcherGameDifficulty == null) {
                var matcher = (Entitas.Matcher<MetaEntity>)Entitas.Matcher<MetaEntity>.AllOf(MetaComponentsLookup.GameDifficulty);
                matcher.componentNames = MetaComponentsLookup.componentNames;
                _matcherGameDifficulty = matcher;
            }

            return _matcherGameDifficulty;
        }
    }
}