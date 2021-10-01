using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBase : MonoBehaviour
{
    public enum collisionGroups
    {
        Undecided = 0,
        Prefab,
        Player,
        Enemy,
        Movement
    };
    [SerializeField] protected collisionGroups cGroup = collisionGroups.Undecided;
    public collisionGroups CGroup { get => cGroup; }
    protected virtual void OnEnable()
    {
        if(cGroup == collisionGroups.Undecided)
            Debug.Log(gameObject.name + ": this gameObject is undecided [CollisionStrategy]");
    }
    public bool AreMatchingCGroups(collisionGroups cGroup) { return this.cGroup == cGroup; }
    public void SetCGroup(collisionGroups c) { cGroup = c; }
    
}
