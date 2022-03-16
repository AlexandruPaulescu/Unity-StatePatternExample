using UnityEngine;

public class ItemBaseState : MonoBehaviour
{
    public virtual void EnterState(ItemStateManager item) { }   // The base method for each state. You can create as many methods as you like.
}
