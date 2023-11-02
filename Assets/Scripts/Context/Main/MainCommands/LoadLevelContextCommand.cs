using context.main;
using strange.extensions.command.impl;
using UnityEngine.SceneManagement;

public class LoadLevelContextCommand : Command
{
	public override void Execute()
	{
		SceneManager.LoadSceneAsync(StaticName.LEVEL_CONTEXT_SCENE, LoadSceneMode.Additive);
		injectionBinder.GetInstance<LevelContextLoadedSignal>().Dispatch();
	}
}