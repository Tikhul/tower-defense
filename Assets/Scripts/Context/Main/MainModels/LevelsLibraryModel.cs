using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelsLibraryModel : LibraryModel<LevelsPipelineSO>
{
	public LevelsPipelineSO GetPipelineById(string id)
	{
		var pipeline = GetAllLibraryData().FirstOrDefault(e => e.Id.Equals(id));
		if (pipeline == null)
		{
			Debug.LogError("Can't find pipeline with id: " + id);
		}

		return pipeline;
	}
}
