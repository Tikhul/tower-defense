public class PlayerModel
{
    public int InitialCoins { get; set; }
    public int InitialHealth { get; private set; }
    public int ActualCoins { get; set; }
    public int ActualHealth { get; set; }
    public void Initialize(PlayerConfig settings)
    {
        InitialCoins = settings.InitialCoins;
        InitialHealth = settings.InitialHealth;
        ActualCoins = settings.InitialCoins;
        ActualHealth = settings.InitialHealth;
    }
}
