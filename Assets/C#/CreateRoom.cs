using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    public InputField roomNameIF;
    private string imeSobe;

    public void OnCreateRoom()
    {
        imeSobe = roomNameIF.ToString();
        PhotonNetwork.CreateRoom(imeSobe);
    }
}
