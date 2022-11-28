using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaStartGame : MonoBehaviour
{
    public GameObject SpawnController;
    public GameObject MobChoiceWindow;

    public void CloseChoiceWindow()
    {
        SpawnController.SetActive(true);
        MobChoiceWindow.SetActive(false);
    }


}
