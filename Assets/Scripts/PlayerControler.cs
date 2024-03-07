using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public CharacterController _charactercontroller;
    public float PlayerSpeed;

    public Animator _Animator;
    Vector3 _direction;
    bool _running;
    public float FuerzaDeEmpuje;
    public int jumpForce;
    public float gravity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Esta linea sirve para mover el player     
        _direction = new Vector3(Input.GetAxis("Horizontal"),_direction.y, Input.GetAxis("Vertical"));

        var PlayerAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, PlayerAngle, 0);
        
        _charactercontroller.Move(_direction * Time.deltaTime * PlayerSpeed);
            
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
        {
            _Animator.SetFloat("MovX", 1);
        }
        else 
        {
            _Animator.SetFloat("MovX", 0);
        }

        if (Input.GetKey(KeyCode.F))
        {
            _Animator.SetTrigger("Punch");
        }

        if (Input.GetKey(KeyCode.P))
        {
            _Animator.SetTrigger("Death");
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _running = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _running = false;
        }
        if(_running == true)
        {
            _Animator.SetBool("Running", true);
        }
        if (_running == false)
        {
            _Animator.SetBool("Running", false);
        }
        if(Input.GetButtonDown("Jump") && _charactercontroller.isGrounded) 
        {
            //print("aaa");
            _direction.y = jumpForce;
        }
        else
        {
            _direction.y -= gravity * Time.deltaTime;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if(rb != null)
        {
            Vector3 DireccionFuerza = hit.gameObject.transform.position - transform.position;
            DireccionFuerza.y = 0;
            DireccionFuerza.Normalize();

            rb.AddForceAtPosition(DireccionFuerza * FuerzaDeEmpuje, transform.position, ForceMode.Impulse);
        }
    }





    private void OnTriggerEnter(Collider other)     
    {
          if(other.CompareTag("Wall"))
        {
            _Animator.SetBool("Push", true);

        }
       else if (other.CompareTag("Sea"))
        {
          
        }

    }

    private void OnTriggerExit(Collider other)
    {
        _Animator.SetBool("Push", false);
    }
}
