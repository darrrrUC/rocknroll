using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class RegisterMatch : NetworkBehaviour {

    public Guid playerId;
    private bool isMatchRegistred;
    void Start()
    {
        playerId = Guid.NewGuid();

    }

    public Guid GetPlayerId()
    {
        return playerId;
    }

    void Update()
    {

        if (!isServer)
        {
            return;
        }
        if (!isLocalPlayer)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.P) && !isMatchRegistred)
        {
            List<GameObject> players = new List<GameObject>();
            List<Guid> playerIds = new List<Guid>();
            foreach (var player in GameObject.FindGameObjectsWithTag("Player").Distinct().ToList())
            {
                players.Add(player);
            }

            foreach (var player in players)
            {
                playerIds.Add(player.GetComponent<RegisterMatch>().GetPlayerId());
            }
            StartCoroutine(PostMatch(playerIds));
            isMatchRegistred = true;

            

        }
    
    }


 
    IEnumerator PostMatch(List<Guid> playerIds)
    {
        Guid p1 = new Guid(), p2 = new Guid(), p3 = new Guid(), p4 = new Guid(), p5 = new Guid(), p6 = new Guid(), p7 = new Guid(), p8 = new Guid();
        Guid gameId = Guid.NewGuid();
        WWWForm form = new WWWForm();

        if (playerIds.Count == 1)
        {
            p1 = playerIds[0];
        }
        if (playerIds.Count == 2)
        {
            p1 = playerIds[0];
            p2 = playerIds[1];
        }
        if (playerIds.Count == 3)
        {
            p1 = playerIds[0];
            p2 = playerIds[1];
            p3 = playerIds[2];
        }
        if (playerIds.Count == 4)
        {
            p1 = playerIds[0];
            p2 = playerIds[1];
            p3 = playerIds[2];
            p4 = playerIds[3];
        }
        if (playerIds.Count == 5)
        {
            p1 = playerIds[0];
            p2 = playerIds[1];
            p3 = playerIds[2];
            p4 = playerIds[3];
            p5 = playerIds[4];
        }
        if (playerIds.Count == 6)
        {
            p1 = playerIds[0];
            p2 = playerIds[1];
            p3 = playerIds[2];
            p4 = playerIds[3];
            p5 = playerIds[4];
            p6 = playerIds[5];
        }
        if (playerIds.Count == 7)
        {
            p1 = playerIds[0];
            p2 = playerIds[1];
            p3 = playerIds[2];
            p4 = playerIds[3];
            p5 = playerIds[4];
            p6 = playerIds[5];
            p7 = playerIds[6];
        }
        if (playerIds.Count == 8)
        {
            p1 = playerIds[0];
            p2 = playerIds[1];
            p3 = playerIds[2];
            p4 = playerIds[3];
            p5 = playerIds[4];
            p6 = playerIds[5];
            p7 = playerIds[6];
            p8 = playerIds[7];
        }




        var download = UnityWebRequest.Post("http://localhost:60728/api/Score/RegisterNewGame" + "?GameId=" + gameId + "&Player1=" + p1 + "&Player2=" + p2 + "&Player3=" + p3 + "&Player4=" + p4 + "&Player5=" + p5 + "&Player6=" + p6 + "&Player7=" + p7 + "&Player8=" + p8, form);

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
