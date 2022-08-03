using UnityEngine;

public class BoardView : BaseView
{
    [SerializeField] private GameObject _boardParent;
    [SerializeField] private GameObject _cameraPosition;
    public GameObject BoardParent
    {
        get => _boardParent;
        set => _boardParent = value;
    }

    private void OnEnable()
    {
        Camera _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _mainCamera.orthographic = false;
        _mainCamera.transform.position = _cameraPosition.transform.position;
        _mainCamera.transform.rotation = _cameraPosition.transform.rotation;
    }
}
