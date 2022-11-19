using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LocationController : MonoBehaviour
{
    public LocParams Params = new LocParams();
    public List<string> locNames = new List<string>(); // не используется
    public string LocParemetrs;

    public Sprite DefeatIcon;
    public int MinBuildIndex;
    public int MaxBuildIndex;
    public MapReward _MapReward;
    public int LocTypeInt;

    void Awake()
    {
        if(Params.LocPos == Vector3.zero)
        {
            Params.LocPos = transform.position;
        }
        LocParemetrs = JsonUtility.ToJson(Params);
        Params.LocTypeNum = LocTypeInt;

        switch (LocTypeInt)
        {
            case 0:
                _MapReward = new VillageReward();
                _MapReward.MoneyReward = Random.Range(100, 130);
                break;
            case 1:
                _MapReward = new FortressReward();
                _MapReward.MoneyReward = Random.Range(120, 200);
                break;
            case 2:
                _MapReward = new CastleReward();
                break;
        }
    }

    private void Start()
    {
        if (Params.locationComplite)
        {
            //Debug.Log("location " + transform.position + "Is complite");
            gameObject.GetComponent<SpriteRenderer>().sprite = DefeatIcon;
        }
    }
    public void GoInLocation()
    {
        if (Params.locationComplite)
        {
            Debug.Log("Локация уже пройдена");
            return;
        }
        //Debug.Log("Go in loc сработал");
        ProgressController.instance.CurLoc = this;
        CampainTimerController.instance.MapIsRun = true;
        GameObject.Find("Canvas").GetComponent<LoadingScreenHandler>().LoadScreen.SetActive(true);
        //Debug.Log("текущая локация передала парамс в контроллер как " + ProgressController.instance.CurLoc.Params.locationComplite);
        //SceneManager.LoadScene(locNames[Random.Range(0, locNames.Count)]);
        SceneManager.LoadScene(Random.Range(MinBuildIndex, MaxBuildIndex));
    }

}
[SerializeField]
public class LocParams
{
    public bool locationComplite;
    public Vector3 LocPos;
    public int LocTypeNum;
}
