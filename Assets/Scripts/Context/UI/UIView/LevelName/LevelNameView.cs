using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelNameView : BaseView
{
    [SerializeField] private TMPro.TMP_Text _levelName;

    public TMPro.TMP_Text LevelName
    {
        get => _levelName;
        set => _levelName = value;
    }
}
