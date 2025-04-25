using System.Collections;
using System.Collections.Generic;
using GameUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameUI
{
   public class UI : MonoBehaviour
   {
      [SerializeField] private GameObject _pausePanelObject, _inventoryPanelObject;

      #region Pause

      public void SetPausePanelActive(bool active)
      {
         _pausePanelObject.SetActive(active);
      }

      #endregion

      #region MainMenu

      public void GoToMainMenu()
      {
         GetComponentInChildren<Pause>().SetPauseEnable(false);
         Cursor.lockState = CursorLockMode.Confined;
         SceneManager.LoadScene("MainMenu");
      }

      #endregion
      

   }
}
