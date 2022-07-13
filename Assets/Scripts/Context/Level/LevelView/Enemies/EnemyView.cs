using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : View
{
    [SerializeField] private EnemyConfig _config;
    public EnemyConfig Config => _config;
}
