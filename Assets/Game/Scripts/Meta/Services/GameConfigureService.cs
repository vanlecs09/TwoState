public class GameConfigureService : IGameConfigureService
{

    GameConfig _gameConfigure;
    public GameConfigureService(GameConfig gameConfigure)
    {
        _gameConfigure = gameConfigure;
    }

    public BoardConfig GetBoardConfigure(string boardName)
    {
        // throw new System.NotImplementedException();
        foreach(BoardConfig boardConfigure in _gameConfigure.BoardConfigs)
        {
            if(boardConfigure.BoardName == boardName)
                return boardConfigure;
        }

        throw new System.NotFiniteNumberException();
    }

    public GameConfig GetGameConfigure()
    {
        return _gameConfigure;
    }

    // public BoardConfig Getbo
}