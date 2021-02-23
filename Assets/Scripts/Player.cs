using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    private bool jumpWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            jumpWasPressed = true;
        }
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void FixedUpdate(){

        if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Length == 1){
            return;
        }

        if(jumpWasPressed){
            rigidbodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpWasPressed = false;
        }

        rigidbodyComponent.velocity = new Vector3(horizontalInput * 2, rigidbodyComponent.velocity.y , 0);

    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer == 9){
            Destroy(other.gameObject);
        }
    }
}
