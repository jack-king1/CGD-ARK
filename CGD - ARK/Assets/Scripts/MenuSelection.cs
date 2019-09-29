using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EventTypes;

public class MenuSelection : MonoBehaviour
{
    public Text m_Start;
    public Text m_Leaderboard;
    public Text m_Exit;

    private MENU_SELECTION current_selection;

    private void Start()
    {
        current_selection = MENU_SELECTION.start;
    }

    private void Update()
    {
        if (InputManager.KeyReleased_W())
        {
            if(current_selection == MENU_SELECTION.start)
            {
                current_selection = MENU_SELECTION.exit;
            }
            else
            {
                current_selection -= 1;
            }
        }
        else if(InputManager.KeyReleased_S())
        {
            if (current_selection == MENU_SELECTION.exit)
            {
                current_selection = MENU_SELECTION.start;
            }
            else
            {
                current_selection += 1;
            }
        }

        switch(current_selection)
        {
            case MENU_SELECTION.start:
                m_Start.color = Color.gray;
                m_Leaderboard.color = Color.white;
                m_Exit.color = Color.white;
                break;
            case MENU_SELECTION.leaderboard:
                m_Start.color = Color.white;
                m_Leaderboard.color = Color.grey;
                m_Exit.color = Color.white;
                break;
            case MENU_SELECTION.exit:
                m_Start.color = Color.white;
                m_Leaderboard.color = Color.white;
                m_Exit.color = Color.grey;
                break;
            default:
                break;
        }

        if(InputManager.KeyUp_Enter())
        {
            switch (current_selection)
            {
                case MENU_SELECTION.start:
                    SceneLoader.changeScene(SCENE_TYPE.game_scene);
                    break;
                case MENU_SELECTION.leaderboard:
                    SceneLoader.changeScene(SCENE_TYPE.leaderboard_scene);
                    break;
                case MENU_SELECTION.exit:
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
    }
}
