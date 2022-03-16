using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAvailableState : ItemBaseState
{
    private ItemRayController rayController = null;
    [SerializeField] private float delayUntillDissapear = 5.0f;

    private void Awake()
    {
        rayController = GetComponent<ItemRayController>();
    }
    private void Start()
    {
        rayController.OnMenuItemClicked += PickupItem_OnMenuItemClicked;
    }
    public override void EnterState(ItemStateManager item)
    {
        item.IsAvailable = true;
        StartCoroutine(DelayUntillItemDissapear(item, delayUntillDissapear));
    }
    public void PickupItem_OnMenuItemClicked(ItemStateManager item)
    {
        item.IsAvailable = false;
        item.SwitchState(item.PickupState);
        StopAllCoroutines();    // I was lazy. Don't be like me...
    }
    /// <summary>
    /// Waits and if the item is not picked up, it destroys it
    /// </summary>
    /// <param name="item"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    private IEnumerator DelayUntillItemDissapear(ItemStateManager item, float delay)
    {
        yield return new WaitForSeconds(delay);
        item.IsAvailable = false;
        item.SwitchState(item.DissapearingState);
    }
}
