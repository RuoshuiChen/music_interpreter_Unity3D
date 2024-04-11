using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class open_connect_scene : MonoBehaviour
{
    public void to_connect_scene()
    {
        SceneManager.LoadScene (sceneName:"Connect_to_server");
    }
}
