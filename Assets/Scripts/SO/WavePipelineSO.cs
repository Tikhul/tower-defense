using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WavePipelineScriptableObject", menuName = "ScriptableObjects/WavePipelineSO", order = 10)]
public class WavePipelineSO : Config
{
    [SerializeField] private List<WaveSO> _waves;
    public List<WaveSO> Waves => _waves;
    public List<IWaveModel> GetWaveModels()
    {
        var list = new List<IWaveModel>();

        foreach (var wave in _waves)
        {
            list.Add(new WaveModel(wave));
        }

        return list;
    }
}
