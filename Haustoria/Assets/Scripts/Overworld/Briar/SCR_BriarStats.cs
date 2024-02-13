using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BriarStats : MonoBehaviour, IDataPersistance
{
    [SerializeField] private int Health;
    [SerializeField] private int XP;
    [SerializeField] private int AbilityPoints;




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

    }


    public void LoadData(GameData data)
    {
        transform.position = data.BriarPosition;
        this.XP = data.Xp;
        this.Health = data.health;
    }

    public void SaveData(GameData data)
    {
        data.BriarPosition = transform.position;
        data.health = this.Health;
        data.Xp = this.XP;
    }
}
