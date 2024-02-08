using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SCR_CutoutObject : MonoBehaviour
{

    [SerializeField]
    private Transform targetObject;

    [SerializeField]
    private LayerMask wallMask;

    private Camera mainCamera;

    [SerializeField]
    private List<GameObject> Walls = new List<GameObject>();

 

    Vector2 cutoutPos;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }


    void Update()
    {
        cutoutPos = mainCamera.WorldToViewportPoint(targetObject.position);
        cutoutPos.y /= (Screen.width / Screen.height);

        Vector3 offset = targetObject.position - transform.position;
        RaycastHit[] hitObjects = Physics.RaycastAll(transform.position, offset, offset.magnitude, wallMask);
       // RaycastHit[] hitObjects = Physics.SphereCastAll(transform.position, 5, offset, offset.magnitude, wallMask);

        for (int i = 0; i < hitObjects.Length; i++)
        {

            if (!Walls.Contains(hitObjects[i].transform.gameObject))
            {
                Walls.Add(hitObjects[i].transform.gameObject);

                StartCoroutine(MaterialSet(hitObjects[i].transform.gameObject));
              
            }
            
           

        }
      if (hitObjects.Length == 0)
            {
                StartCoroutine(MaterialUnset());
            }
 
       
    }

    IEnumerator MaterialSet(GameObject Wall)
    {
      
     
            Material[] materials = Wall.transform.GetComponent<Renderer>().materials;

            for (int m = 0; m < materials.Length; m++)
            {
                materials[m].SetVector("_Cutout_Position", cutoutPos);
            for (float t = 0.4f; t < 1; t += Time.deltaTime*4)
            {
                materials[m].SetFloat("_CutoutSize", 0.4f *t);
                materials[m].SetFloat("_FalloffSize", 0.1f*t);
                yield return null;
            }
            }

   //     yield return new WaitForSeconds(5f);
  //      StartCoroutine(MaterialUnset());


        yield return null;
    }

    IEnumerator MaterialUnset()
    {
        foreach (GameObject wall in Walls)
        {
          
            Material[] materials = wall.transform.GetComponent<Renderer>().materials;

            for (int m = 0; m < materials.Length; m++)
            {
                materials[m].SetVector("_Cutout_Position", cutoutPos);
                for (float t = 1f; t > 0; t -= Time.deltaTime * 5)
                {
                    materials[m].SetFloat("_CutoutSize", 0.2f * t);
                    materials[m].SetFloat("_FalloffSize", 0.1f * t);
                    yield return null;
                }
            }



            yield return null;
        }
        Walls.Clear();



    }
}
