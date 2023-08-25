using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{   
    [Header("levels to load")]
    public string _newGameLevel;
    private string levelToLoad;

    [SerializeField] private GameObject NoSaveFound = null;

    public void NewGameDialogYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void LoadGameDialogYes()
    {
        if(PlayerPrefs.HasKey("SavedLevel"))
        {
            levelToLoad = PlayerPrefs.GetString("SavedLevel");
            SceneManager.LoadScene(levelToLoad);

        }
        else
        {
            NoSaveFound.SetActive(true);
        }
    }
    public void exitbutton() 
    { 
        Application.Quit();
    }
}
