using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	public class ControlDisplay : MonoBehaviour
	{
		public enum Screens
		{
			Shop,
		}

		public GameObject ShopWindow;
		//public GUI_PreLoaded GUI_preloaded;

		/// <summary>
		/// Основные UI изменения
		/// </summary>
		/// <param name="screen">UI действия в изменениях</param>
		public void SetScreenFor(Screens screen)
		{
			Logger.Log($"Setting screen for {screen}", Category.UI);
			switch (screen)
			{
				case Screens.Shop:
					SetScreenForShop();
					break;
			}
		}

		public void SetScreenForShop()
		{
            if (ShopWindow.activeInHierarchy)
            {
				ShopWindow.SetActive(false);
            }
            else
            {
				ShopWindow.SetActive(true);
            }
			
		}
	}
}
