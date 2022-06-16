using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameCommand : Command
{
    private PlayerModel _player;
    private BoardModel _board;
    [Inject] public PlayerCreatedSignal PlayerCreatedSignal { get; set; }
    [Inject] public BoardCreatedSignal BoardCreatedSignal { get; set; }

    public override void Execute()
    {
        Retain();
        PlayerCreatedSignal.AddListener(GetPlayer);
        BoardCreatedSignal.AddListener(GetBoard);
        Release();
        CreateGame(_player, _board);
    }

    private void GetPlayer(PlayerModel player)
    {
        _player = player;
        PlayerCreatedSignal.RemoveListener(GetPlayer);
    }

    private void GetBoard(BoardModel board)
    {
        _board = board;
        BoardCreatedSignal.RemoveListener(GetBoard);
    }
    private void CreateGame(PlayerModel player, BoardModel board)
    {
        var game = new GameModel(player, board);
        Debug.Log("CreateGame");
    }
}
