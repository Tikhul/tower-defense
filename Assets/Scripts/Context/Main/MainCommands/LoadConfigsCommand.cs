using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// ����������� ���������� ���������� ��������
/// </summary>
/// <typeparam name="TL">����������� ����������</typeparam>
/// <typeparam name="TC">��� ����������� ��������</typeparam>
public abstract class LoadConfigsCommand<TL, TC> : Command where TL : LibraryModel<TC> where TC : Config
{
	public override void Execute()
	{
		var configs = Resources.LoadAll<TC>(GetPath());

		Debug.Log("Loaded " + typeof(TC) + ". Count: " + configs.Length);

		injectionBinder.GetInstance<TL>().Initialize(configs);

		PassData();
	}

	protected abstract string GetPath();
	public virtual void PassData()
    {

    }
}
