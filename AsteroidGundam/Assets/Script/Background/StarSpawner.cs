using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] GameObject star;
    [SerializeField] int nbStar;
    public int xBound;
    public int yBound;

    void Awake()
    {
        for(int i = 0; i < nbStar; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-xBound, xBound), Random.Range(-yBound,yBound), 2);
            var newStar = Instantiate(star,pos, Quaternion.identity,this.transform);

            var anim = newStar.GetComponent<Animator>();
            anim.speed = Random.Range(0.5f,1.5f);
        }
    }

}
