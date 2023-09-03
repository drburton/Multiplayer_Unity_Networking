using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ServerJoin : MonoBehaviour
{
    public void Join()
    {
        NetworkManager.Singleton.StartClient();
        Debug.Log("Joining");
    }

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        Debug.Log("Hosting");
    }


}
