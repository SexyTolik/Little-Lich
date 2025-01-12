using TMPro;
using UnityEditor;
using UnityEngine;

public class VersionSinh : MonoBehaviour
{
    void Start()
    {
       GetComponent<TextMeshProUGUI>().text = PlayerSettings.bundleVersion;
    }

}
