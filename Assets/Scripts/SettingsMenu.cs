using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI; // SQL but code!

public class SettingsMenu : MonoBehaviour
{
   [Header("Resolution Set")]
   public TMP_Dropdown resolutionDropdown;
   Resolution[] resolutions;
   public Toggle fullscreenToggle;
   
   public void Awake()
   {
      #region Resolution Start
      resolutionDropdown.ClearOptions();
      List<string> resOptions = new List<string>();
      resolutions = Screen.resolutions;
      int currentResolutionIndex = 0;

      for (int i = 0; i < resolutions.Length; i++)
      {
         string option = resolutions[i].width + " x " +
                         resolutions[i].height;
         resOptions.Add(option);
         if (resolutions[i].width == Screen.currentResolution.width
             && resolutions[i].height == Screen.currentResolution.height)
         {
            currentResolutionIndex = i; 
         }
      }

      resolutionDropdown.AddOptions(resOptions);
      if (PlayerPrefs.HasKey("Resolution"))
      {
         int resIndex = PlayerPrefs.GetInt("Resolution");
         resolutionDropdown.value = resIndex;
         resolutionDropdown.RefreshShownValue();
         ChangeResolution(resIndex);
      }
      else
      {
         resolutionDropdown.value = currentResolutionIndex;
         resolutionDropdown.RefreshShownValue();
      }
      #endregion 
   }

   private void Start()
   {
      LoadSettings();
   }

   /// <summary>
   /// This is method allows for players to cap framerate.
   /// </summary>
   /// <param name="target">The framerate the player wants to cap to</param>
   public void LimitFramerate(int target)
   {
      Application.targetFrameRate = 60;
   }

   /// <summary>
   /// The number of vSyncs that should pass for each frame.
   /// 0 - 4
   /// If this setting is set to a value other than 'Don't Sync' (0),
   /// the value of Application.targetFramerate WILL BE IGNORED.
   /// </summary>
   public void vSyncCount()
   {
      QualitySettings.vSyncCount = 0;

      QualitySettings.vSyncCount = 1;
   }

   /// <summary>
   /// The resolution 
   /// </summary>
   /// <param name="resolutionIndex"></param>
   public void ChangeResolution(int resolutionIndex)
   {
      PlayerPrefs.SetInt("Resolution", resolutionIndex);
      Resolution resolution = resolutions[resolutionIndex];
      Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
   }

   private void LoadSettings()
   {
      if (PlayerPrefs.HasKey("Resolution"))
      {
         int resIndex = PlayerPrefs.GetInt("Resolution");
         resolutionDropdown.value = resIndex;
         resolutionDropdown.RefreshShownValue();
         ChangeResolution(resIndex);
      }
   }
   
}
