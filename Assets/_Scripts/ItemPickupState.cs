using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickupState : ItemBaseState
{
    private SpriteRenderer spriteRenderer = null;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void EnterState(ItemStateManager item)
    {
        Debug.Log("Picked it up");
        spriteRenderer.enabled = false;
        /*
         * More code goes here...
         */
    }
}
