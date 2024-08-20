
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   


    Rigidbody rb;
    public Joystick joystick;
    public Joystick joystick1;
    [SerializeField] float movementSpeed = 2f;
    public JoyButtonScript joyButton;
    
    
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        
        
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector3(joystick.Horizontal*movementSpeed, rb.velocity.y,joystick.Vertical*movementSpeed);
        
        Vector3 moveVector = (Vector3.right * joystick1.Horizontal + Vector3.forward * joystick1.Vertical);
        if (joystick1.Horizontal != 0 || joystick1.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(moveVector, Vector3.up);

        }
        if ((joystick1.Horizontal == 0 || joystick1.Vertical == 0) && (joystick.Horizontal!=0 || joystick.Vertical !=0))
        {
            Vector3 moveVector1 = (Vector3.right * joystick.Horizontal + Vector3.forward * joystick.Vertical);
            transform.rotation = Quaternion.LookRotation(moveVector1, Vector3.up);

        }
      

    }
    
}
