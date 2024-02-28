using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_SpawnAndDelete : MonoBehaviour
{
    // unused
    [SerializeField] private GameObject Create;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Created = Instantiate(Create, transform.position, Quaternion.identity);

        Destroy(Created, 5);
        Destroy(this.gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
