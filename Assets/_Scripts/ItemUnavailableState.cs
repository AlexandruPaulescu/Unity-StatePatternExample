using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUnavailableState : ItemBaseState
{
    private SpriteRenderer spriteRenderer = null;

    [SerializeField] private Color unavaibleColor;
    [SerializeField] private Color avaibleColor;
    [SerializeField] private float delayUntillAvailable = 5.0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void EnterState(ItemStateManager item)
    {
        item.IsAvailable = false;
        spriteRenderer.color = unavaibleColor;  // Sets color of item to 'Unavailable'
        StartCoroutine(MakeItemAvailableDelay(item, delayUntillAvailable));
    }

    /// <summary>
    /// Waits and then changes the object to the available state
    /// </summary>
    /// <param name="item"></param>
    /// <param name="delay"></param>
    /// <returns></returns>
    private IEnumerator MakeItemAvailableDelay(ItemStateManager item , float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.color = avaibleColor;  // Sets color of item to 'Available'
        item.SwitchState(item.AvailableState);
    }
}
