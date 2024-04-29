using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class SCR_SnakeFollow : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Segment;
    [SerializeField] private List<GameObject> Segments;
    // Start is called before the first frame update
    private float AngularVelocity = 0.0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        for (int i = 0; i < Random.Range(5,15); i++)
        {
            GameObject segment = Instantiate(Segment, transform.position, Quaternion.identity);
            Segments.Add(segment);

        }

        for(int i = 0; i<Segments.Count;i++)
        {

            Segments[i].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 0,0,0,0,1);

            if (i == 0)
            {

                Segments[0].transform.parent = this.gameObject.transform;
                Segments[0].GetComponent<DampedTransform>().data.sourceObject = this.gameObject.transform;
            }
            else
            {
                Segments[i].transform.parent = Segments[i - 1].gameObject.transform;
                Segments[i].GetComponent<DampedTransform>().data.sourceObject = Segments[i - 1].transform;
                Segments[i].transform.localScale = Segments[i - 1].transform.localScale;

            }
         
        }

        GetComponentInParent<RigBuilder>().Build();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ((transform.right * 4)  + (transform.up * 5) * Mathf.Sin(Time.time)) * Time.deltaTime;
        Vector3 sinemove = (player.transform.position - transform.position).normalized;
           transform.right = sinemove;

//        Debug.Log(Mathf.Sin(Time.time));

    //    transform.right = Vector3.Lerp( transform.position, (player.transform.position - transform.position).normalized, Mathf.Sin(Time.time)+1);
        
    }
}
