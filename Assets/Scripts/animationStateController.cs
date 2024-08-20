using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    public Joystick joystick;
    public JoyButtonScript joyButton;
    public shooting script;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (joystick.Horizontal !=0 || joystick.Vertical!=0)
        {
            animator.SetBool("isWalking",true);

        }
        if (joystick.Horizontal ==0 && joystick.Vertical==0)
        {
            animator.SetBool("isWalking",false);

        }
        
        

    }
}
