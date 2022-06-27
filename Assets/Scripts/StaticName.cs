using System;
using UnityEngine;

public static class StaticName
{
    #region scenes

    public const string MAIN_CONTEXT_SCENE = "Main";
    public const string UI_CONTEXT_SCENE = "UI";
    public const string GAME_CONTEXT_SCENE = "Game";
    public const string LEVEL_CONTEXT_SCENE = "Level";

    #endregion

    #region content_paths

    public const string PLAYER_PATH = "Configs/Player";
    public const string BOARD_PATH = "Configs/Board";
    public const string ENEMIES_PATH = "Configs/Enemies";
    public const string TOWERS_PATH = "Configs/Towers";
    public const string PIPELINES_PATH = "Configs/Pipelines";
    public const string ENEMIES_WAYS_PATH = "Configs/EnemiesWays";
    public const string UPGRADES_PATH = "Configs/Upgrades";

    #endregion

    #region strings

    public const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    #endregion

    #region prefabs

    public const string TOWER_BUTTON_PATH = "Prefabs/TowerButton";
    public const string UPGRADE_BUTTON_PATH = "Prefabs/UpgradeButton";

    #endregion
}
