using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LocationController : MonoBehaviour
{
    public LocParams Params = new LocParams();
    public List<string> locNames = new List<string>();
    public string LocParemetrs;

    void Awake()
    {
        if(Params.LocPos == Vector3.zero)
        {
            Params.LocPos = transform.position;
        }

        if (Params.locationComplite)
        {
            Debug.Log("location " + transform.position + "Is complite");
        }

        LocParemetrs = JsonUtility.ToJson(Params);
    }

    public void GoInLocation()
    {
        if (Params.locationComplite)
        {
            Debug.Log("Локация уже пройдена");
            return;
        }
        Debug.Log("Go in loc сработал");
        ProgressController.instance.CurLoc = Params;
        Debug.Log("текущая локация передала парамс в контроллер как " + ProgressController.instance.CurLoc.locationComplite);
        SceneManager.LoadScene(locNames[Random.Range(0, locNames.Count)]);
    }

}
[SerializeField]
public class LocParams
{
    public bool locationComplite;
    public Vector3 LocPos;
}
