using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Абстрактная реализация загрузчика ресурсов
/// </summary>
/// <typeparam name="TC">Тип загружаемых ресурсов</typeparam>
public abstract class LoadConfigsCommand<TC> : Command where TC : ScriptableObject
{
	public override void Execute()
	{
		var configs = Resources.LoadAll<TC>(GetPath());

		Debug.Log("Loaded " + typeof(TC) + ". Count: " + configs.Length);
	}

	protected abstract string GetPath();
}
