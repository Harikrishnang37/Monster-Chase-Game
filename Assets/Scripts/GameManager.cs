using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // an instance of this class itself

    [SerializeField]
    private GameObject[] characters;

    private int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
         } // if there is no instance, then set the instance to this gameobject
          // dontdestroyonload makes sure that the gameobject isnt destroyed when we open another scene
        else
        {
            Destroy(gameObject);
        }// if there is already an instance present, then we delete it.

        // this gameManager instance will be common to both the scenes.
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnlevelFinishedLoading;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnlevelFinishedLoading;
    }

    void OnlevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GamePlay")
        {
            Instantiate(characters[CharIndex]);
        }
    }

}
