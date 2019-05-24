//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TileCoponent tileCoponent { get { return (TileCoponent)GetComponent(GameComponentsLookup.TileCoponent); } }
    public bool hasTileCoponent { get { return HasComponent(GameComponentsLookup.TileCoponent); } }

    public void AddTileCoponent(UnityEngine.Vector2 newPosition) {
        var index = GameComponentsLookup.TileCoponent;
        var component = (TileCoponent)CreateComponent(index, typeof(TileCoponent));
        component.position = newPosition;
        AddComponent(index, component);
    }

    public void ReplaceTileCoponent(UnityEngine.Vector2 newPosition) {
        var index = GameComponentsLookup.TileCoponent;
        var component = (TileCoponent)CreateComponent(index, typeof(TileCoponent));
        component.position = newPosition;
        ReplaceComponent(index, component);
    }

    public void RemoveTileCoponent() {
        RemoveComponent(GameComponentsLookup.TileCoponent);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTileCoponent;

    public static Entitas.IMatcher<GameEntity> TileCoponent {
        get {
            if (_matcherTileCoponent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TileCoponent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTileCoponent = matcher;
            }

            return _matcherTileCoponent;
        }
    }
}
