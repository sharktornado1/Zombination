
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButtonScript : MonoBehaviour, IPointerUpHandler, IPointerDownHandler 
{
    [HideInInspector]
    public bool isPressed;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
        
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
        
    }
}
