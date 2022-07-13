using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemiesCommand : Command
{
    [Inject] public List<EnemyModel> ReceivedEnemies { get; set; }
    public override void Execute()
    {
        Debug.Log("CreateEnemiesCommand");
    }
}
