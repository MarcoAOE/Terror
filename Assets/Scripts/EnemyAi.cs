using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad;
    public NavMeshAgent IA;

    public Animation Anim;
    public string AnimacionCaminar;
    public string AnimacionGolpe;


    

    // Update is called once per frame
    void Update()
    {
        IA.speed = velocidad;
        IA.SetDestination(objetivo.position);

        if(IA.velocity == Vector3.zero)
        {
            Anim.CrossFade(AnimacionGolpe);
        }
        else
        {
            Anim.CrossFade(AnimacionCaminar);
        }
    }
}
