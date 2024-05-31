using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEnemy : MonoBehaviour
{
    [HideInInspector] public bool IsControlledByPlayer;
    public abstract void Attack();
}