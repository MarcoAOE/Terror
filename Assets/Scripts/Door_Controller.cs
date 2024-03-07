using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Controller : MonoBehaviour

{
    public Animator _Door;
    public GameObject _cartel;

    private void OnTriggerEnter(Collider other)
    {
        _Door.Play("Abrir");
        _cartel.SetActive(true);
        
    }

    private void OnTriggerExit(Collider other)
    {
        _Door.Play("Cerrar");
        _cartel.SetActive(false);

    }
}
