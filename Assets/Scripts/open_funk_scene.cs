using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class open_funk_scene : MonoBehaviour
{
    public void to_funk_scene()
    {
        song_function.genre = "funk";
        SceneManager.LoadScene (sceneName:"funk");
    }
}
