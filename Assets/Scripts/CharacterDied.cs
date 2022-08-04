using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CharacterDied : MonoBehaviour
{
    public GameObject DeadScene;

    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded) return;
        gameObject.GetComponentInChildren<Camera>().transform.SetParent(null);
        DeadScene.SetActive(true);
        if(UnitSpawner.instance.score > PlayerPrefs.GetInt("MaxScore"))
        {
            Scene cScene = SceneManager.GetActiveScene(); 
            ScoreSaver.instance.SaveScore(UnitSpawner.instance.score, cScene.name);
        }
    }
}
