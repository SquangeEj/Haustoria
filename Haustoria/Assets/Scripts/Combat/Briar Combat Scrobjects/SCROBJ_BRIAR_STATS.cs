using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BriarStats", menuName = "ScriptableObjects/BriarCombat/BriarStats")]
public class SCROBJ_BRIAR_STATS : ScriptableObject
{
    [Header("Stats")]
    public int Health;
    public int MaxHealth;
    public int XP, Attack, Defence; 
    public int AbilityPoints;
    public int Stamina;

    public Vector3 Position;

}
