using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

/// <summary>
/// サーバーへ接続
/// </summary>
public class ConnectPunServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("OtosuRoom", new RoomOptions(){EmptyRoomTtl = 300000}, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        
    }
}

