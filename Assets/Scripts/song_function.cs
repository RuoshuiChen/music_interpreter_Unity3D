using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class song_function : MonoBehaviour
{
    public static string genre;
    public static List<String> lyricsText;
    public static string songName;
    // public Button song0;
    // public Button song1;
    // public Button song2;
    // public Button song3;
    // public Button song4;
    // public Button song5;
    // public Button song6;
    // public Button song7;
    // public Button song8;
    // public Button song9;
    public void select_song()
    {
        
        songName = EventSystem.current.currentSelectedGameObject.name;

        string lyrics_path = "Lyrics/" + genre + "/" + songName;
        TextAsset lyrics = Resources.Load<TextAsset>(lyrics_path);
        lyricsText = new List<string>();
        if (lyrics.text[0] == 'T') //deal with txt file
        {
            IEnumerable<string> lyricsData = lyrics.text.Split("\n");
            int count2 = 0;
            foreach (string line in lyricsData)
            {
                if (count2 != 0)
                {
                    string startText = line.Split("]")[0];
                    string currText = line.Split("]")[1];
                    lyricsText.Add(currText.Substring(0));
                    float min = float.Parse(startText.Substring(1, 2)) * 60;
                    float sec = float.Parse(startText.Substring(4, 2));
                    float mSec = float.Parse(startText.Substring(7, 2)) * (float).1;
                    float start = min + sec + mSec;
                    Debug.Log(start);
                    Debug.Log(currText.Substring(0));
                }
        
                count2++;
            }
            
        }
        else //dealing with json file
        {
            IEnumerable<string> lyricsData = lyrics.text.Split("},");
            foreach (string line in lyricsData)
            {
                String[] lineData = line.Split(":");
                string currLine = lineData[1];
                string currStart = lineData[2];
                string currText = System.Text.RegularExpressions.Regex.Unescape(@currLine.Split("\"")[1]);
                lyricsText.Add(currText);
                Debug.Log(currText);
                Debug.Log(float.Parse(currStart.Split(",")[0]));
            }
        }
        
        TcpConnection.count = 0;
        TcpConnection.SendMessage("genre: " + genre + " " + "name: " + songName);
        TcpConnection.SendMessage("start");
        SceneManager.LoadScene (sceneName:"Lyrics_scene"); 
        
        
        //Debug.Log(songName);
        
    }
}
