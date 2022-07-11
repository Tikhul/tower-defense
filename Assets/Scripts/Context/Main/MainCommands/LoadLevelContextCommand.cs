using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelContextCommand : Command
{
	public override void Execute()
	{
		SceneManager.LoadSceneAsync(StaticName.LEVEL_CONTEXT_SCENE, LoadSceneMode.Additive);
		injectionBinder.GetInstance<LevelContextLoadedSignal>().Dispatch();
		Debug.Log("LoadLevelContextCommand");
	}
}