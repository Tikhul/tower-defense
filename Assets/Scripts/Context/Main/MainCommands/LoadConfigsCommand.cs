using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// Абстрактная реализация загрузчика ресурсов
/// </summary>
/// <typeparam name="TL">Загружаемая библиотека</typeparam>
/// <typeparam name="TC">Тип загружаемых ресурсов</typeparam>
public abstract class LoadConfigsCommand<TL, TC> : Command where TL : LibraryModel<TC> where TC : ScriptableObject
{
	public override void Execute()
	{
		var configs = Resources.LoadAll<TC>(GetPath());

		Debug.Log("Loaded " + typeof(TC) + ". Count: " + configs.Length);
	}

	protected abstract string GetPath();
}
