using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class open_main_scene : MonoBehaviour
{
    public void to_main_scene()
    {
        SceneManager.LoadScene (sceneName:"Select_genre");
    }
}
