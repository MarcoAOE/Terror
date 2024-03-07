using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelAgarre : MonoBehaviour

{

    public Canvas cartelCanvas; 
    public Transform playerTransform;
    public float distanciaActivacion = 3f;


    void Update()
    {

        float distanciaAlPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanciaAlPlayer < distanciaActivacion)
        {
            cartelCanvas.gameObject.SetActive(true);

        }
        else
        {
            cartelCanvas.gameObject.SetActive(false);

        }
      }
    }

