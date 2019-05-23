//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LogEntity {

    public LogErrorComponent logError { get { return (LogErrorComponent)GetComponent(LogComponentsLookup.LogError); } }
    public bool hasLogError { get { return HasComponent(LogComponentsLookup.LogError); } }

    public void AddLogError(string newMessage) {
        var index = LogComponentsLookup.LogError;
        var component = (LogErrorComponent)CreateComponent(index, typeof(LogErrorComponent));
        component.message = newMessage;
        AddComponent(index, component);
    }

    public void ReplaceLogError(string newMessage) {
        var index = LogComponentsLookup.LogError;
        var component = (LogErrorComponent)CreateComponent(index, typeof(LogErrorComponent));
        component.message = newMessage;
        ReplaceComponent(index, component);
    }

    public void RemoveLogError() {
        RemoveComponent(LogComponentsLookup.LogError);
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
public sealed partial class LogMatcher {

    static Entitas.IMatcher<LogEntity> _matcherLogError;

    public static Entitas.IMatcher<LogEntity> LogError {
        get {
            if (_matcherLogError == null) {
                var matcher = (Entitas.Matcher<LogEntity>)Entitas.Matcher<LogEntity>.AllOf(LogComponentsLookup.LogError);
                matcher.componentNames = LogComponentsLookup.componentNames;
                _matcherLogError = matcher;
            }

            return _matcherLogError;
        }
    }
}
