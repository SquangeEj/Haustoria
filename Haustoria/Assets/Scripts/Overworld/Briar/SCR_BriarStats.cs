using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_BriarStats : MonoBehaviour, IDataPersistance
{
    [SerializeField] private int Health;


    private void Start()
    {
       // transform.position = BriarPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health -= 1;
        }
    }

    public void LoadData(GameData data)
    {
        transform.position = data.BriarPosition;
        this.Health = data.health;
    }

    public void SaveData(GameData data)
    {
        data.BriarPosition = transform.position;
        data.health = this.Health;
    }
}
