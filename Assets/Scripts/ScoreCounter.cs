
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text Scoretext;
    void Start()
    {
        
    }

    
    void Update()
    {
        Scoretext.text = GameManager.Instance.Score.ToString();
    }
}
