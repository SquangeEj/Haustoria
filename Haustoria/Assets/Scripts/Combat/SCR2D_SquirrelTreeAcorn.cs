using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR2D_SquirrelTreeAcorn : MonoBehaviour
{
    [SerializeField] private GameObject Acorn;
    void SpawnAcorns()
    {
        StartCoroutine(Acorns());
    }

    IEnumerator Acorns()
    {
        for (int i = 0; i < Random.Range(2, 5f); i += 1)
        {
            GameObject acorn = Instantiate(Acorn, transform.position, Quaternion.identity);
            acorn.transform.position += new Vector3(Random.Range(-1,1f), Random.Range(-1,2f), 0);
            acorn.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360)));
            acorn.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5f), Random.Range(3, 9)), ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.1f);
            Destroy(acorn, 5f);
        }
        yield return null;
    }
}
