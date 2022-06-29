using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningsView : BaseView
{
    [SerializeField] private TMPro.TMP_Text _noMoneyWarning;

    public TMPro.TMP_Text NoMoneyWarning
    {
        get => _noMoneyWarning;
        set => _noMoneyWarning = value;
    }
    public void ShowWarning(TMPro.TMP_Text warning)
    {
        warning.gameObject.SetActive(true);
        StartCoroutine(WaitToHide(warning));
    }

    private IEnumerator WaitToHide(TMPro.TMP_Text warning)
    {
        yield return new WaitForSeconds(2.0f);
        warning.gameObject.SetActive(false);
    }
}
