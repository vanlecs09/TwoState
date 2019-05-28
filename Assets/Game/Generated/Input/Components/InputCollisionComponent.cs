//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public CollisionComponent collision { get { return (CollisionComponent)GetComponent(InputComponentsLookup.Collision); } }
    public bool hasCollision { get { return HasComponent(InputComponentsLookup.Collision); } }

    public void AddCollision(Entitas.Entity newSelf, Entitas.Entity newOther) {
        var index = InputComponentsLookup.Collision;
        var component = (CollisionComponent)CreateComponent(index, typeof(CollisionComponent));
        component.self = newSelf;
        component.other = newOther;
        AddComponent(index, component);
    }

    public void ReplaceCollision(Entitas.Entity newSelf, Entitas.Entity newOther) {
        var index = InputComponentsLookup.Collision;
        var component = (CollisionComponent)CreateComponent(index, typeof(CollisionComponent));
        component.self = newSelf;
        component.other = newOther;
        ReplaceComponent(index, component);
    }

    public void RemoveCollision() {
        RemoveComponent(InputComponentsLookup.Collision);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherCollision;

    public static Entitas.IMatcher<InputEntity> Collision {
        get {
            if (_matcherCollision == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Collision);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherCollision = matcher;
            }

            return _matcherCollision;
        }
    }
}
