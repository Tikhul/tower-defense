public class EnemyModel
{
    public EnemyConfig Config { get; }
    public int InitialHealth { get; private set; }
    public int ActualHealth { get; set; }
    public EnemyModel(EnemyConfig config)
    {
        Config = config;
        InitialHealth = config.InitialHealth;
        ActualHealth = config.InitialHealth;
    }
}
