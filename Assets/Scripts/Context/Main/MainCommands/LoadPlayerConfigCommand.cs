using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerConfigCommand : LoadConfigsCommand<PlayerLibraryModel, PlayerSO>
{
    [Inject] public CreatePlayerLibrarySignal CreatePlayerLibrarySignal { get; set; }
    [Inject] public PlayerLibraryCreatedSignal PlayerLibraryCreatedSignal { get; set; }
    protected override string GetPath()
    {
        CreatePlayerLibrarySignal.AddListener(PassData);
        return StaticName.PLAYER_PATH;
    }

    public override void PassData()
    {
        var model = new PlayerLibraryModel();
        PlayerLibraryCreatedSignal.Dispatch(model.GetLibraryDataById("player"));
        CreatePlayerLibrarySignal.RemoveListener(PassData);
        Debug.Log("PassPlayerData");
    }
}
