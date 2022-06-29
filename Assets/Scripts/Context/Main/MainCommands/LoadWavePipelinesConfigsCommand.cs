using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWavePipelinesConfigsCommand : LoadConfigsCommand<WavesLibraryModel, WavePipelineSO>
{
    protected override string GetPath()
    {
        return StaticName.WAVE_PIPELINES_PATH;
    }
}
