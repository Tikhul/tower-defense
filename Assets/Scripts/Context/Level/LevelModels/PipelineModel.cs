using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipelineModel<TC> where TC : LevelsPipelineSO
{
	protected TC _config;
	public TC Config => _config;

	public PipelineModel(TC config)
	{
		_config = config;
	}
}
