using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDissapearingState : ItemBaseState
{
    public override void EnterState(ItemStateManager item)
    {
        Destroy(this.gameObject);
    }
}
