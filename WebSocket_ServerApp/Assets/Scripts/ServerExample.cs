using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

public class ServerExample: MonoBehaviour {

    WebSocketServer server;

    private void OnEnable()
    {
        //serverオブジェクトの生成
        server = new WebSocketServer(3000);
    }

    void Start ()
    {
        server.AddWebSocketService<TestFunc>("/");
        server.Start();

    }

    void OnDestroy()
    {
        server.Stop();
        server = null;
    }

}

public class TestFunc : WebSocketBehavior
{
    protected override void OnOpen()
    {
        Debug.Log ("opend");
    }
    
    protected override void OnMessage (MessageEventArgs e)
    {
        Debug.Log("Comming Message ! : " + e.Data);
    }
}