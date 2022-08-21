using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{
    string Buttonclicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

    
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

       
    }

    public void HomeButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
