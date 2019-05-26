using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
public class StartGameComponent: IComponent {
    public string diffculty;
}

[Input]
public class GameOverComponent: IComponent {

}

[Input]
public class UiViewComponent: IComponent {
    public string id;
}

[Input]
public class ShowUiComponent: IComponent {
    // UI should be visualized
}

// [Input]
// public class InteractableComponent: IComponent {
//     // UI should be interactable
// }

[Input]
public class BlockableComponent: IComponent {
    // UI should block raycast interaction with game entity
}

[Input]
public class ShowUiCommandComponent: IComponent {
    public string screenId;
}

[Input]
public class HideUiCommandComponent: IComponent {
    public string screenId;
}

[Input, Unique]
public class BlockSceneRayCastComponent: IComponent {
    // Global component to check if UI has block game scene
    public bool isPermanent;
    public bool isInThisFrame;
}

[Input, Unique]
public class SceneRaycastBlockerComponent: IComponent {
    // Global component to check if UI has block game scene
    public bool value;
}

[Input]
public class PointerOverUiComponent: IComponent {
    // if this component is presented, SceneRaycastBlocker = true
}

[Input]
public class PermanentBlockRaycastComponent: IComponent {
    // if this component is presented, SceneRaycastBlocker = true
}

[Meta, Unique]
public class UiManagementServiceComponent: IComponent {
    public IUiManagementService instance;
}