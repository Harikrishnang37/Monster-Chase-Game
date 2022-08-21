using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    
    public void PlayGame()
    {
        int selectedIndex;
        string clickedObj = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name; //gives us the name of the button pressed

        if(clickedObj=="Button 1")
        {
            selectedIndex = 0;
        }
        else
        {
            selectedIndex = 1;
        } // checking which button is clicked

        GameManager.instance.CharIndex = selectedIndex; // giving the selectedIndex value to the charIndex variable of the GameManager class

        SceneManager.LoadScene("GamePlay");
       
    }

}
