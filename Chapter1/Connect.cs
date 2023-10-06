using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Connect : MonoBehaviour
{
    public void Join()

    {
        NetworkManager.Singleton.StartClient();
    }
}

