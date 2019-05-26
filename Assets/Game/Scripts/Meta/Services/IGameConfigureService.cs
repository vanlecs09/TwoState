public interface IGameConfigureService {
    GameConfig GetGameConfigure();
    BoardConfig GetBoardConfigure(string boardName);
}