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

    void Start()
    {
        _contexts = Contexts.sharedInstance;
        CreateService();
        _systems = CreateSystems(_contexts);
        // _contexts.game.CreateSimpleMovingEntity();
        _systems.Initialize();
        // _contexts.game.CreateGenerateBoardEntity();
        for(int i = 0; i < 100; i++) {
            Debug.Log(GetNextRandomPoint());
        }
    }

    Vector2 GetNextRandomPoint()
    {
        return new Vector2(UnityEngine.Random.Range(0, 5), UnityEngine.Random.Range(0, 5));
    }


    private void CreateService()

    {
        _services = new Services(
        // new GameStateService(_contexts),
        new UnityViewService(), // responsible for creating gameobjects for views
                                // new UnityApplicationService(), // gives app functionality like .Quit()
        new UnityTimeService(), // gives .deltaTime, .fixedDeltaTime etc
        new PrefabPoolService(),
        new GenerateBoardService()
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
        .Add(new GeneratteBoardSystem(contexts))
        .Add(new AddViewSystem(contexts))
        .Add(new SimpleMovementSystem(contexts))
        .Add(new SimpleRotationSystem(contexts))
        .Add(new GameEventSystems(contexts));
    }

    private IEnumerator Spawn()
    {
        float extraTime = 0f;
        while (true)
        {
            _contexts.game.CreateSimpleMovingEntity();
            float spawnTime = Time.time;
            yield return new WaitForSeconds(.77f);
            extraTime = Time.time - .77f - spawnTime;
        }
    }

    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }
}
