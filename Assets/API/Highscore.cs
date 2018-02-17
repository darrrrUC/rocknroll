using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using Assets.API;


public class Highscore : NetworkBehaviour {

    string GetHighScoreUrl = "http://localhost:60728/api/Score/getscore";
    string PostHighScoreUrl = "http://localhost:60728/api/Score/postscore";
    string name = "Emil";
    int score = 10;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(PostScore());
        }
    }

    IEnumerator GetScore()
    {
        WWWForm form = new WWWForm();

        var download = UnityWebRequest.Get(GetHighScoreUrl);

        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError)
        {
            Debug.Log("Shit has hit the fan");
        }
        else
        {
            HighscoreModel highscore = new HighscoreModel();
            highscore = JsonUtility.FromJson<HighscoreModel>(download.downloadHandler.text);
            Debug.Log(download.downloadHandler.text);
            Debug.Log("Player name is: " + highscore.Name + " with score " + highscore.Score);
        }
    }

    IEnumerator PostScore()
    {
        WWWForm form = new WWWForm();

        var download = UnityWebRequest.Post("http://localhost:60728/api/Score/postscore" + "?name=" + name + "&score=" + score, form);

        yield return download.SendWebRequest();

        if (download.isNetworkError || download.isHttpError)
        {
            Debug.Log("Shit has hit the fan");
        }
        else
        {
            Debug.Log("Successfully posted score");
        }


    }
}
