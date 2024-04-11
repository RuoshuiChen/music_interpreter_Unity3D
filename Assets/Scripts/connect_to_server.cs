using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
 

public class connect_to_server : MonoBehaviour
{
    
    public TMP_InputField  iP;
    public TMP_InputField  port;
    public Button connect;

    public static bool _connected;
    // Update is called once per frame
    // void Update()
    // {
    //     Scene currentScene = SceneManager.GetActiveScene();
    //     string sceneName = currentScene.name;
    //     if (!_connected & sceneName != "connect_to_server")
    //     {
    //         SceneManager.LoadScene (sceneName:"connect_to_server");
    //     }
    // }
    public void Connect_server()
    {
        if (!_connected)
        {
            try
            {   
                Debug.Log(iP.text);
                Debug.Log(int.Parse(port.GetComponent<TMP_InputField>().text));
                TcpConnection.ConnectToTcpServer(iP.GetComponent<TMP_InputField>().text,
                    int.Parse(port.GetComponent<TMP_InputField>().text));
                _connected = true;
                SceneManager.LoadScene (sceneName:"Select_genre");
                //connect.GetComponent<TextMeshProUGUI>().text = "connected";
            }
            catch (Exception e)
            {
                Debug.Log(e);
                _connected = false;
            }
            
        }
    }
}
