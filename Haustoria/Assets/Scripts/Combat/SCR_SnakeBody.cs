using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SnakeBody : MonoBehaviour
{
    [SerializeField] private GameObject venom;
    void Start()
    {
        StartCoroutine(SpawnVenom());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnVenom()
    {
        GameObject Venom = Instantiate(venom, transform.position, Quaternion.identity);
        Venom.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        Venom.GetComponent<Rigidbody2D>().AddForce(-Venom.transform.up *150, ForceMode2D.Force);
       
        Destroy(Venom, 3f);
        yield return new WaitForSeconds(Random.Range(0.2f,1f));
        StartCoroutine(SpawnVenom());
    }
}
