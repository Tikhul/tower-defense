using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Заполнение модели игры GameModel
/// </summary>
public class CreateGameCommand : Command
{
    [Inject] public GameModel GameModel { get; set; }
    [Inject] public PlayerLibraryModel PlayerLibraryModel { get; set; }
    [Inject] public BoardLibraryModel BoardLibraryModel { get; set; }

    public override void Execute()
    {
        var player = new PlayerModel(PlayerLibraryModel.GetLibraryDataById("player"));
        var board = new BoardModel(BoardLibraryModel.GetLibraryDataById("board"));
        GameModel.Player = player;
        GameModel.Board = board;

        injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(player);
    }
}
