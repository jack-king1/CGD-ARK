using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;
using UnityEngine.SceneManagement;

public static class SceneLoader
{

    public static void changeScene(SCENE_TYPE new_scene)
    {
        switch(new_scene)
        {
            case SCENE_TYPE.menu_scene:
                SceneManager.LoadScene(0);

                break;
            case SCENE_TYPE.game_scene:
                SceneManager.LoadScene(1);
                break;
            case SCENE_TYPE.leaderboard_scene:
                SceneManager.LoadScene(2);
                break;
            default:
                break;
        }
    }
}
