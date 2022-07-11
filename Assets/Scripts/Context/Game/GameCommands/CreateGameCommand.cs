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
        GameModel.Player = new PlayerModel();
        GameModel.Player.Initialize(PlayerLibraryModel.GetLibraryDataById("player"));
        GameModel.Board = new BoardModel();
        GameModel.Board.Initialize(BoardLibraryModel.GetLibraryDataById("board"));

        injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(GameModel.Player);
    }
}
