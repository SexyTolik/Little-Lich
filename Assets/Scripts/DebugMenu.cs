using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DebugMenu : MonoBehaviour
{
    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResetCampainProg()
    {
        GlobalMapSaver.instance.SetCompanyProgress(false);
        GlobalMapSaver.instance.save = new GameSave();
        GlobalMapSaver.instance.SaveMoney();
        GlobalMapSaver.instance.CheckSelectedMobs();
        CampainTimerController.instance.LoadTime();
    }
}
