using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttoncontro : MonoBehaviour

   
    {

        // Use this for initialization
        void Start()
        {

        }
        public bool entro = false;
        // Update is called once per frame
        void OnTriggerEnter()
        {
            entro = true;
        }

        void OnTriggerExit()
        {
            entro = false;
        }
        void OnGUI()
        {

            if (entro == true)
            {
                GUI.Label(new Rect(600, 400, 300, 200), "ESTAS DENTRO");
            }
        }
    
}
