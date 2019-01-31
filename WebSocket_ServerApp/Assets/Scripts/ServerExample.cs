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
        /*
         server自体の機能をカスタマイズしていく（下記のクラス内メソッドをoverrideしていく）
        */
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
    //eには送信されたメッセージ内容がパックになって詰まってる
    protected override void OnMessage (MessageEventArgs e)
    {
        Debug.Log("Comming Message ! : " + e.Data);
    }
}