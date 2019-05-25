using Entitas;

public class MainScreenInitSystem : IInitializeSystem
{
    Contexts _contexts;

    public MainScreenInitSystem (Contexts contexts) {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.input.CreateShowUiCommandEntity("MainMenu");
    }
}