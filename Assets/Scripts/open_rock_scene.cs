using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class open_rock_scene : MonoBehaviour
{
    public void to_rock_scene()
    {
        song_function.genre = "rock";
        SceneManager.LoadScene (sceneName:"rock");
    }
}
