using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerCommand : Command
{
    [Inject] public PlayerLibraryCreatedSignal PlayerLibraryCreatedSignal { get; set; }
    [Inject] public PlayerCreatedSignal PlayerCreatedSignal { get; set; }
    public override void Execute()
    {
        PlayerLibraryCreatedSignal.AddListener(CreatePlayer);
        Debug.Log("Execute");
    }

    private void CreatePlayer(PlayerSO settings)
    {
        var player = new PlayerModel(settings);
        PlayerCreatedSignal.Dispatch(player);
        PlayerLibraryCreatedSignal.RemoveListener(CreatePlayer);
        Debug.Log("CreatePlayer");
    }
}
