using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class print_lyrics : MonoBehaviour
{
    public TMP_Text lyrics1;
    public TMP_Text lyrics2;
    public TMP_Text lyrics3;
    public TMP_Text lyrics4;
    public Button stop;
    public TextMeshProUGUI currSong;
    public Image albumCover;
    public void activeLyrics(int j)
    {
        Color active = new Color(0f, 0f, 0f, 1f);
        Color nActive = new Color(0f, 0f, 0f, .2f);
        if (j == 0)
        {
            lyrics1.color = active;
            lyrics2.color = nActive;
            lyrics3.color = nActive;
            lyrics4.color = nActive;
        } else if (j == 1)
        {
            lyrics1.color = nActive;
            lyrics2.color = active;
            lyrics3.color = nActive;
            lyrics4.color = nActive;
                    
        } else if (j == 2)
        {
            lyrics1.color = nActive;
            lyrics2.color = nActive;
            lyrics3.color = active;
            lyrics4.color = nActive;
        } else if (j == 3)
        {
            lyrics1.color = nActive;
            lyrics2.color = nActive;
            lyrics3.color = nActive;
            lyrics4.color = active;
        }
        
    }

    private void Start()
    {
        Sprite currSprite = Resources.Load("shimi_pictures/" + song_function.genre + "/" + song_function.songName, typeof(Sprite)) as Sprite;
        albumCover.GetComponent<Image>().sprite = currSprite;
        currSong.GetComponent<TextMeshProUGUI>().text = song_function.songName.Replace("_", " ");
    }

    void Update()
    {
        int currState = TcpConnection.count % 4;
        if (currState == 0)
        {
            if(TcpConnection.count < song_function.lyricsText.Count - 1) lyrics1.text = song_function.lyricsText[TcpConnection.count];
            if(TcpConnection.count + 1 <= song_function.lyricsText.Count - 1)lyrics2.text = song_function.lyricsText[TcpConnection.count + 1];
            if(TcpConnection.count + 2 <= song_function.lyricsText.Count - 1)lyrics3.text = song_function.lyricsText[TcpConnection.count + 2];
            if(TcpConnection.count + 3 <= song_function.lyricsText.Count - 1)lyrics4.text = song_function.lyricsText[TcpConnection.count + 3];
        }
        activeLyrics(currState);
    }

    public void Stop_playing()
    {
        TcpConnection.SendMessage("stop");
        lyrics1.text = "";
        lyrics1.text = "";
        lyrics1.text = "";
        lyrics1.text = "";
        SceneManager.LoadScene(sceneName: song_function.genre);
    }
}
