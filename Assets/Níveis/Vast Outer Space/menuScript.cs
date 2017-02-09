using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {


    public Canvas quitMenu;
    public Canvas instrucoesMenu;
    public Button startText;
    public Button exitText;
    public Button instrucoesText;


    // Use this for initialization
    void Start() {


        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;

        instrucoesMenu = instrucoesMenu.GetComponent<Canvas>();
        instrucoesMenu.enabled = false;


    }

    public void ExitPress()

    {

        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
        instrucoesText.enabled = false;

    }

    public void InstrucoesPress()

    {
        instrucoesMenu.enabled = true;
        quitMenu.enabled = false;
        startText.enabled = false;
        exitText.enabled = false;
       
    }


    public void NoPress()
    {


        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
      instrucoesMenu.enabled = false;
    }




    public void StartLevel()
    {
		
		Application.LoadLevel (1);
	}

     public void ExitGame()
    {
        Application.Quit();

    }

}
