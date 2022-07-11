using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WavePipelineConfig", menuName = "ScriptableObjects/WavePipelineConfig", order = 10)]
public class WavePipelineConfig : Config
{
    [SerializeField] private List<WaveConfig> _waves;
    public List<WaveConfig> Waves => _waves;
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
