using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BriarStats : MonoBehaviour, IDataPersistance
{
    [SerializeField] private int Health;
    [SerializeField] private int XP, Attack, Defence;
    [SerializeField] private int AbilityPoints;

    [SerializeField] private GameObject SkillTree;




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


    private void GetSkillTree()
    {
        SkillTree.SetActive(true);
    }


    public void LoadData(GameData data)
    {
        transform.localPosition = data.BriarPosition;
        this.XP = data.Xp;
        this.Health = data.health;

    }

    public void SaveData(GameData data)
    {

    
        data.health = this.Health;
        data.Xp = this.XP;
        data.Atk = this.Attack;
        data.Def = this.Defence;
    }
}
