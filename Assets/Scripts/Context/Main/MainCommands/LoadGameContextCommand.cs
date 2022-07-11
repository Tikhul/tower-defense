using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameContextCommand : Command
{
	public override void Execute()
	{
		SceneManager.LoadSceneAsync(StaticName.GAME_CONTEXT_SCENE, LoadSceneMode.Additive);
		injectionBinder.GetInstance<GameContextLoadedSignal>().Dispatch();
		Debug.Log("LoadGameContextCommand");
	}
}

