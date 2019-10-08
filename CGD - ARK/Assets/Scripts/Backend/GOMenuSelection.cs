using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventTypes;

public class GOMenuSelection : MonoBehaviour
{
    public Text m_Restart;
    public Text m_Menu;
    public Text m_Exit;

    private bool can_select = false;

    private GAMEOVER_SELECTION current_selection;

    public GameObject gameManager;
    private float DPAD_Delay = 0.2f;
    private float currentDelay = 0.0f;

    private void Start()
    {
        current_selection = GAMEOVER_SELECTION.restart;
        //AudioManager.instance.Play("background_menu");
    }

    private void Update()
    {
        menuSelection();
        menuColors();
        selectionDelay();
    }

    private void menuSelection()
    {
        if (InputManager.KeyReleased_W() || InputManager.DPAD_Up())
        {
            if (current_selection == GAMEOVER_SELECTION.restart && currentDelay <= 0)
            {
                current_selection = GAMEOVER_SELECTION.exit;
                AudioManager.instance.Play("menu_option_switch");
                currentDelay = DPAD_Delay;
            }
            else if(currentDelay <= 0)
            {
                current_selection -= 1;
                AudioManager.instance.Play("menu_option_switch");
                currentDelay = DPAD_Delay;
            }
        }
        else if (InputManager.KeyReleased_S() || InputManager.DPAD_Down())
        {
            if (current_selection == GAMEOVER_SELECTION.exit && currentDelay <= 0)
            {
                
                current_selection = GAMEOVER_SELECTION.restart;
                AudioManager.instance.Play("menu_option_switch");
                currentDelay = DPAD_Delay;
            }
            else if(currentDelay <= 0)
            {
                
                current_selection += 1;
                AudioManager.instance.Play("menu_option_switch");
                currentDelay = DPAD_Delay;
            }
        }
        if ((InputManager.KeyUp_Enter() || InputManager.NES_A()) && can_select)
        {
            selectionMade();
        }
        
    }

    private void selectionMade()
    {
        switch (current_selection)
        {
            case GAMEOVER_SELECTION.restart:
                SceneLoader.changeScene(SCENE_TYPE.game_scene);
                AudioManager.instance.Play("background_menu");
                gameManager.GetComponent<GameState>().initGameScene();
                break;
            case GAMEOVER_SELECTION.main_menu:
                SceneLoader.changeScene(SCENE_TYPE.menu_scene);
                break;
            case GAMEOVER_SELECTION.exit:
                // save any game data here
            #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                    Application.Quit();
            #endif
                break;
            default:
                break;
        }
    }

    private void menuColors()
    {
        switch(current_selection)
        {
            case GAMEOVER_SELECTION.restart:
                m_Restart.color = Color.gray;
                m_Menu.color = Color.white;
                m_Exit.color = Color.white;
                break;
            case GAMEOVER_SELECTION.main_menu:
                m_Restart.color = Color.white;
                m_Menu.color = Color.grey;
                m_Exit.color = Color.white;
                break;
            case GAMEOVER_SELECTION.exit:
                m_Restart.color = Color.white;
                m_Menu.color = Color.white;
                m_Exit.color = Color.grey;
                break;
            default:
                break;
        }
    }

    public void selectionDelay()
    {
        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime;
        }
        else
        {
            currentDelay = 0;
        }
    }

    IEnumerator ButtonDelay()
    {
        yield return new WaitForSeconds(1);
        can_select = true;
    }
}
