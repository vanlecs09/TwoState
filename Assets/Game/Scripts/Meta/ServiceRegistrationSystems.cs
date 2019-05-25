using Entitas;
public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, Services services)
    {
        // Add(new RegisterViewServiceSystem(contexts, services.View));
        Add(new RegisterTimeServiceSystem(contexts, services.Time));
        Add(new RegisterViewServiceSystem(contexts, services.View));
        Add(new RegisterObjectPoolServiceSystem(contexts, services.ObjectPool));
        Add(new ReigsterGenerateBoardService(contexts, services.GenerateBoard));
        Add(new RegisterUiManagementServiceSystem(contexts, services.UiManagement));
        // Add(new RegisterGameStateServiceSystem(contexts, services.GameState));
        // Add(new RegisterApplicationServiceSystem(contexts, services.Application));
        // Add(new RegisterInputServiceSystem(contexts, services.Input));
        // Add(new RegisterAiServiceSystem(contexts, services.Ai));
        // Add(new RegisterConfigurationServiceSystem(contexts, services.Config));
        // Add(new RegisterCameraServiceSystem(contexts, services.Camera));
        // Add(new RegisterPhysicsServiceSystem(contexts, services.Physics));
        // Add(new ServiceRegistrationCompleteSystem(contexts));
    }
}