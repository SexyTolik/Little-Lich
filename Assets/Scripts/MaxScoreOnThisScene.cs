using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MaxScoreOnThisScene : MonoBehaviour
{
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        Scene cScene = SceneManager.GetActiveScene();
        //text.text = "MaxScore " + ScoreSaver.instance.ShowScore(cScene.name);
    }
    
}
