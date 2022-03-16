using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemUnavailableState))]
[RequireComponent(typeof(ItemAvailableState))]
[RequireComponent(typeof(ItemPickupState))]
[RequireComponent(typeof(ItemDissapearingState))]
[RequireComponent(typeof(ItemRayController))]
public class ItemStateManager : MonoBehaviour
{
    private ItemBaseState currentItemState = null;
    [HideInInspector] public ItemUnavailableState UnavailableState = null;
    [HideInInspector] public ItemAvailableState AvailableState = null;
    [HideInInspector] public ItemPickupState PickupState = null;
    [HideInInspector] public ItemDissapearingState DissapearingState = null;
    public bool IsAvailable { get; set; }  // Created the variable here so all the states will use it without creating refferences

    private void Awake()
    {
        // Always cache stuff. Please.
        UnavailableState = GetComponent<ItemUnavailableState>();
        AvailableState = GetComponent<ItemAvailableState>();
        PickupState = GetComponent<ItemPickupState>();
        DissapearingState = GetComponent<ItemDissapearingState>();
    }
    private void Start()
    {
        // Start the game with initializing the items as 'unavailable'
        currentItemState = UnavailableState;
        currentItemState.EnterState(this);
    }

    /// <summary>
    /// Used to update the 'currentItemState' to the newly provided state and also call the base 'EnterState' method
    /// </summary>
    /// <param name="state"></param>
    public void SwitchState(ItemBaseState state)
    {
        currentItemState = state;
        state.EnterState(this);
    }
}
