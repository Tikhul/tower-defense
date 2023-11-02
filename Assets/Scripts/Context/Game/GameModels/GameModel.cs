public class GameModel
{
    public PlayerModel Player { get; set; }
    public BoardModel Board { get; set; }

    public GameModel(PlayerModel player, BoardModel board)
    {
        Player = player;
        Board = board;
    }
}
