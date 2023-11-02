using UnityEngine;

public class InputView : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private KeyCode _shootKey;
    [SerializeField] private KeyCode _menuKey;
    [SerializeField] private LayerMask _layerMask;
    void Update()
    {
        if (Input.GetKeyDown(_shootKey) || Input.GetKeyDown(_menuKey))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _layerMask))
            {
                var interactable = hit.transform.GetComponentInParent<IInteractable>();
                if(interactable != null && Input.GetKeyDown(_shootKey))
                {
                    Debug.Log("TryShoot");
                    interactable.TryShoot();   
                }
                else if(interactable != null && Input.GetKeyDown(_menuKey))
                {
                    interactable.TryOpenMenu();
                }
            }
        }
    }
}
