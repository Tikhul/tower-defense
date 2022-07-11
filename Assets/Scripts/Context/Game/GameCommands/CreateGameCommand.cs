using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Заполнение модели игры GameModel
/// </summary>
public class CreateGameCommand : Command
{
    private GameModel GameModel => injectionBinder.GetInstance<GameModel>();
    private PlayerLibraryModel PlayerLibraryModel => injectionBinder.GetInstance<PlayerLibraryModel>();
    private BoardLibraryModel BoardLibraryModel => injectionBinder.GetInstance<BoardLibraryModel>();

    public override void Execute()
    {
        var player = new PlayerModel(PlayerLibraryModel.GetLibraryDataById("player"));
        var board = new BoardModel(BoardLibraryModel.GetLibraryDataById("board"));
        GameModel.Player = player;
        GameModel.Board = board;

        injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(player);
    }
}
