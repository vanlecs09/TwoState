using UnityEngine;
using Entitas;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainController : MonoBehaviour {
    Systems _systems;
    Services _services;

    [SerializeField] UiScreensData uiScreensData = null;

    private void Awake() {
        _services = new Services(
            new UnityViewService()
            , new UnityTimeService()
            , new PrefabPoolService()
            , new GenerateBoardService()
            , new UnityUiManagementService(uiScreensData)
        );
    }

    private void Start()
    {
        var contexts = Contexts.sharedInstance;
        _systems = new Systems()
            .Add(new ServiceRegistrationSystems(contexts, _services))
            .Add(new MainScreenInitSystem(contexts))
            .Add(new ShowHideUICommandSystem(contexts))
            .Add(new ShowHideUiSystem(contexts))
            .Add(new StartGameSystem(contexts))
            .Add(new GameOverSystem(contexts));
        
        _systems.Initialize();
    }

    private void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }

    private void OnDestroy() {
        _systems.TearDown();
    }
}