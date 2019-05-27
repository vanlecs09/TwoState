using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using System.Threading;
using System;

public class App : MonoBehaviour
{
    private Systems _systems;
    private Contexts _contexts;
    private Services _services;

    // BoardConfig easy;
    // BoardConfig hard;

    [SerializeField] UiScreensData uiScreensData = null;
    [SerializeField] GameConfig _gameConfigure = null;

    void Start()
    {
        _contexts = Contexts.sharedInstance;
        CreateService();
        _systems = CreateSystems(_contexts);
        _systems.Initialize();
        // _contexts.game.CreateGenerateBoardEntity();
    }


    private void CreateService()

    {
        _services = new Services(
        // new GameStateService(_contexts),
        new UnityViewService(), // responsible for creating gameobjects for views
                                // new UnityApplicationService(), // gives app functionality like .Quit()
        new UnityTimeService(), // gives .deltaTime, .fixedDeltaTime etc
        new PrefabPoolService(),
        new GenerateBoardService3(),
        new UnityUiManagementService(uiScreensData),
        new GameConfigureService(_gameConfigure)
        // new InControlInputService(), // provides user input
        // next two are monobehaviours attached to gamecontroller
        // GetComponent<UnityAiService>(), // async steering calculations on MB
        // GetComponent<UnityConfigurationService>(), // editor accessable global config
        // new UnityCameraService(), // camera bounds, zoom, fov, orthsize etc
        // new UnityPhysicsService() // raycast, checkcircle, checksphere etc.
        );


    }
    private Systems CreateSystems(Contexts contexts)
    {
        return new Feature("Systems")
        // .Add(new LogSystems(contexts))
        .Add(new ServiceRegistrationSystems(contexts, _services))
        .Add(new MainScreenInitSystem(contexts))        
        .Add(new ShowHideUICommandSystem(contexts))
        .Add(new ShowHideUiSystem(contexts))
        .Add(new StartGameSystem(contexts))
        .Add(new GameOverSystem(contexts))
        .Add(new GameMainSystem(contexts))
        .Add(new InputTileTouchSystem(contexts))
        .Add(new ClearBoardSystem(contexts))
        .Add(new GeneratteBoardSystem(contexts))
        .Add(new UpdateBoardSystem(contexts))
        .Add(new AddViewSystem(contexts))
        .Add(new SimpleMovementSystem(contexts))
        .Add(new SimpleRotationSystem(contexts))
        .Add(new GameEventSystems(contexts));
    }


    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
