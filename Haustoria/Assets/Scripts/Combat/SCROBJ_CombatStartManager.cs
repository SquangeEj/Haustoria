using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CombatEnemyScriptableObject", menuName = "ScriptableObjects/Enemies/Enemy")]
public class SCROBJ_CombatStartManager : ScriptableObject
{
    //  public int Health;
    public int Scenetogotoafter;
    public int EnemyID;
    public int BackgroundID;

    public string[] EnemyNames;

  //  [SerializeField] private EnemyAttackType enemyAttackType;
}
