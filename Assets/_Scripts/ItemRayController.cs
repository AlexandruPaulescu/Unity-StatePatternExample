using System;
using UnityEngine;

public class ItemRayController : MonoBehaviour
{
    public delegate void MenuItemClicked_EventHandler(ItemStateManager item);
    public event MenuItemClicked_EventHandler OnMenuItemClicked = null;

    private ItemStateManager stateManager = null;
    private Camera mainCamera = null;
    private RaycastHit hit;
    private Ray ray;

    private void Awake()
    {
        stateManager = GetComponent<ItemStateManager>();
        mainCamera = Camera.main;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.transform.CompareTag("MenuItem") && stateManager.IsAvailable)
                {
                    OnMenuItemClicked?.Invoke(stateManager);    // Call event when the player clicks on an item tagged "MenuItem"
                }
            }
        }
    }
}
