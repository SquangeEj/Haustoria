using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BriarStats : MonoBehaviour, IDataPersistance
{
    [SerializeField] public int Health, MaxHealth;
    [SerializeField] public int XP, Attack, Defence;
    [SerializeField] public int AbilityPoints;
    [SerializeField] public int Stamina;

    [SerializeField] private SCROBJ_BRIAR_STATS BriarStats;

    [SerializeField] private GameObject SkillTree;
    [SerializeField] public int RootAbilityPointsSpent;
    [SerializeField] public bool[] AbilitiesUnlocked;




    private void Start()
    {
        BriarStats.Attack = DataPersistanceManager.instance.gameData.Atk;
        Health = BriarStats.Health;
        MaxHealth = BriarStats.MaxHealth;
        Attack = BriarStats.Attack;
        Debug.Log("XP :" + DataPersistanceManager.instance.gameData.Xp);
        BriarStats.XP = DataPersistanceManager.instance.gameData.Xp;
        XP = DataPersistanceManager.instance.gameData.Xp; 
        Defence = BriarStats.Defence;
        AbilityPoints = BriarStats.AbilityPoints;
        Stamina = BriarStats.Stamina;

        
        // transform.position = BriarPosition;
        if (XP >= 500)
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

        if(Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        BriarStats.Health = Health; //Test to see if healing saves to Stats and if combat gets info
        Debug.Log(string.Format("Briars Health is at {0}", Health));
        DataPersistanceManager.instance.SaveGame();
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

        DataPersistanceManager.instance.gameData.Def = Defence;
        DataPersistanceManager.instance.SaveGame();
    }
    public void AddAttack(int attack)
    {
        
        Attack += attack;

        DataPersistanceManager.instance.gameData.Atk = Attack;
        DataPersistanceManager.instance.SaveGame();
    }

    public void AddWeaponDamage(int p, int c)
    {

        Debug.Log("New  +ATK: " + c + ". Previous Weapon " + p);
        int weaponDam = c - p;
        Debug.Log("MATHS: " + c + " - " + p + " = " + weaponDam);
        AddAttack(weaponDam);
    }

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
        this.Attack = data.Atk;
        this.Defence = data.Def;
        RootAbilityPointsSpent = data.RootAbilityPointsUsed;
        AbilitiesUnlocked = data.AbilityID;
    }

 
}
