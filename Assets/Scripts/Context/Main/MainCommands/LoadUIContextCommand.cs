using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadUIContextCommand : Command
{
	public override void Execute()
    {
		SceneManager.LoadSceneAsync(StaticName.UI_CONTEXT_SCENE, LoadSceneMode.Additive);
		injectionBinder.GetInstance<UIContextLoadedSignal>().Dispatch();
	}
}
