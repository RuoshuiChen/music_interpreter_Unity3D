using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class open_pop_scene : MonoBehaviour
{
    public void to_pop_scene()
    {
        song_function.genre = "pop";
        SceneManager.LoadScene (sceneName:"pop");
    }
}
