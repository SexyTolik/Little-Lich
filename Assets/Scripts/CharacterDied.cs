using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterDied : MonoBehaviour
{
    public GameObject DeadScene;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI MaxScore;

    public GameObject GhostEff;

    private void OnDestroy()
    {
        int curScore = PlayerValuesStorage.instance.MoneyValue;
        int savedScore = ScoreSaver.instance.ShowScore();
        if (curScore > savedScore)
        {
            savedScore= curScore;
            ScoreSaver.instance.SaveScore(savedScore);
        }
        Score.text = $"{curScore}";
        MaxScore.text = $"{savedScore}";

        if (!this.gameObject.scene.isLoaded) return;
        Instantiate(GhostEff, transform.position, Quaternion.identity);
        DeadScene.SetActive(true);
    }
}
