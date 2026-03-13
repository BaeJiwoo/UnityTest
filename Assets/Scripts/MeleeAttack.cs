using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour, IAction
{
    public void Attack()
    {
        Debug.Log("MeleeAttack");
    }
}
