using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private KeyCode _shootKey;
    [SerializeField] private KeyCode _menuKey;
    void Update()
    {
        if (Input.GetKeyDown(_shootKey) || Input.GetKeyDown(_menuKey))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                var interactable = hit.transform.GetComponentInParent<CellView>();
                if(interactable != null && Input.GetKeyDown(_shootKey) && interactable.Interactable)
                {
                    interactable.TryShoot();
                    Debug.Log("Shoot");
                }
                else if(interactable != null && Input.GetKeyDown(_menuKey) && interactable.Interactable)
                {
                    interactable.TryOpenMenu();
                    Debug.Log("Menu");
                }
            }
        }
    }
}
