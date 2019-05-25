public interface IUiManagementService {
    object GetUiScreen (string id);
    void ShowScreen (string id);
    void HideScreen (string id);
    IScreenData GetScreenData (string id);
}