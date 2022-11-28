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
        DeadScene.SetActive(true);
    }
}
