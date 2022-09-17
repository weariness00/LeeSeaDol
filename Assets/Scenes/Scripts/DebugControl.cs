using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugControl : MonoBehaviour
{
    private static DebugControl instance = null;

    public bool isOnLog = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
    }

    public static DebugControl Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    public void Log(object message)
    {
        if (!isOnLog)
            return;

        Debug.Log(message);
    }
}
