using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BriarStats : MonoBehaviour, IDataPersistance
{
    [SerializeField] public int Health;
    [SerializeField] public int XP, Attack, Defence;
    [SerializeField] public int AbilityPoints;
    [SerializeField] public int Stamina;

    [SerializeField] private SCROBJ_BRIAR_STATS BriarStats;

    [SerializeField] private GameObject SkillTree;
    [SerializeField] public int RootAbilityPointsSpent;
    [SerializeField] public bool[] AbilitiesUnlocked;




    private void Start()
    {
       // transform.position = BriarPosition;
       if(XP >= 500)
        {
            AbilityPoints += 1;
            XP -= 500;
            GetSkillTree();

            Debug.Log("too much xp in start, giving ability point");
        }
    }


    public void EarnXP(int Experience)
    {
        XP += Experience;
        if (XP >= 500)
        {
            AbilityPoints += 1;
            XP -= 500;
            GetSkillTree();

            Debug.Log("Given Experience, Enough to get a point");
        }
    }

    public void AddHealth(int num)
    {
        Health += num;

        Debug.Log(string.Format("Briars Health is at {0}", Health));
    }

    private void GetSkillTree()
    {
        SkillTree.SetActive(true);
    }


    public void UnlockAbility(int id)
    {
        AbilitiesUnlocked[id] = true;

        DataPersistanceManager.instance.SaveGame();
    }
    public void AddDefence(int defence)
    {
        Defence += defence;

        DataPersistanceManager.instance.SaveGame();
    }
    public void AddAttack(int attack)
    {

        Attack += attack;
        DataPersistanceManager.instance.SaveGame();
    }


    /*  public void SetBriarPosition(Vector3 BriarPosition)
      {

      }
      */
    public void SaveData(GameData data)
    {

        data.RootAbilityPointsUsed = RootAbilityPointsSpent;
        data.health = this.Health;
        data.stamina = this.Stamina;
        data.Xp = this.XP;
        data.Atk = this.Attack;
        data.Def = this.Defence;

        data.AbilityID = AbilitiesUnlocked;
    }

    public void LoadData(GameData data)
    {
        transform.localPosition = data.BriarPosition;
        Debug.Log(data.BriarPosition);
        this.XP = data.Xp;
        this.Health = data.health;
        this.Stamina = data.stamina;
        RootAbilityPointsSpent = data.RootAbilityPointsUsed;
        AbilitiesUnlocked = data.AbilityID;
    }

 
}
