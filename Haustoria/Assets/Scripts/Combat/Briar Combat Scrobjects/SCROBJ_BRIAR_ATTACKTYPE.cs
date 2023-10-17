using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Briar_Attack_Minigame", menuName = "ScriptableObjects/BriarCombat/AttackType")]
public class SCROBJ_BRIAR_ATTACKTYPE : ScriptableObject
{
    [Header("Stats")]
    public int Damage;
    public int Multiplier;

}
