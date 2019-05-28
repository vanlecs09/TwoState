using UnityEngine;
using System.Collections;
using System.Threading;
using System.Net;

public class MyLog : MonoBehaviour
{
    string myLog;
    Queue myLogQueue = new Queue();
    Vector2 scrollPosition = Vector2.zero;
    bool isShowLog = false;

    void Start()
    {
        
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        if (myLogQueue.Count > 100)
        {
            myLogQueue.Dequeue();
        }

        myLog = logString;
        string newString = "\n [" + type + "] : " + myLog;
        myLogQueue.Enqueue(newString);
        if (type == LogType.Exception)
        {
            newString = "\n" + stackTrace;
            myLogQueue.Enqueue(newString);
        }
        myLog = string.Empty;
        foreach (string mylog in myLogQueue)
        {
            myLog += mylog;
        }
    }

    void OnGUI()
    {

        if(GUI.Button(new Rect(10, 10, 100, 30), "Show Log"))
        {
            isShowLog = !isShowLog;
        }
        if (isShowLog)
        {
            scrollPosition = GUI.BeginScrollView(new Rect(20, 20, Screen.width - 20, Screen.height - 20), scrollPosition, new Rect(0, 0, 220, 2000));
            GUI.TextArea(new Rect(20, 20, Screen.width - 20, 2000), myLog);
            GUI.EndScrollView();
        }
    }
}