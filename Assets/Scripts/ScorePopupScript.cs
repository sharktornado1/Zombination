using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class ScorePopupScript : MonoBehaviour
{
    public Text scorepopuptext;
    
    void Update()
    {

        if (GameManager.Instance.scorepopup!=0)
        {
            StopAllCoroutines();
            scorepopuptext.text = "+" + GameManager.Instance.scorepopup.ToString();
            GameManager.Instance.scorepopup = 0;
            StartCoroutine(removepopup());
            
        }
    }
    IEnumerator removepopup()
    {
        yield return new WaitForSeconds(2f);
        scorepopuptext.text = "";
        
    }
}
