using strange.extensions.command.impl;
using UnityEngine;

/// <summary>
/// ����������� ���������� ���������� ��������
/// </summary>
/// <typeparam name="TC">��� ����������� ��������</typeparam>
public abstract class LoadConfigsCommand<TC> : Command where TC : ScriptableObject
{
	public override void Execute()
	{
		var configs = Resources.LoadAll<TC>(GetPath());

		Debug.Log("Loaded " + typeof(TC) + ". Count: " + configs.Length);
	}

	protected abstract string GetPath();
}
