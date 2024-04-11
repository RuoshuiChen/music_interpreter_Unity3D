using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class open_EDM_scene : MonoBehaviour
{
    public void to_EDM_scene()
    {
        song_function.genre = "EDM";
        SceneManager.LoadScene (sceneName:"EDM");
    }
}
