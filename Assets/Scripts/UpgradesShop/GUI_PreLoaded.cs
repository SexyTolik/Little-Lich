using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class GUI_PreLoaded : MonoBehaviour
    {
		[SerializeField] private TMP_Text loadingText = null;

		[SerializeField] private Scrollbar loadingBar = null;

		public static GUI_PreLoaded Instance;

		private void Awake()
		{
			//localJobPref = null;
			if (Instance == null)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public void UpdateLoadingBar(string text, float loadedAmt)
		{
			loadingText.text = text;
			loadingBar.size = loadedAmt;
		}

	}
}