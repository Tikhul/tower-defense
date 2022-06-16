using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public PlayerSO Settings { get; set; }
    public PlayerModel(PlayerSO settings)
    {
        Settings = settings;
    }
}
