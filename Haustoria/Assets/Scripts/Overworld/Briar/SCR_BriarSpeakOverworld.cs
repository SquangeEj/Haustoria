using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SCR_BriarSpeakOverworld : MonoBehaviour
{
    [SerializeField] private GameObject Text;

    public void BriarSpeak(string String)
    {
        GameObject Talking = Instantiate(Text, transform.position + new Vector3(0,5,0), Quaternion.identity, transform);
        Talking.GetComponent<TextMeshPro>().text = String;
        Destroy(Talking, 4f);
    }
}
