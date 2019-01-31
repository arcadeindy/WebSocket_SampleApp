using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;

public class SendMessage : MonoBehaviour {
	WebSocket ws;
	void Start () {
		//portとipの指定 
		ws = new WebSocket("ws://localhost:3000/");
		
		//イベント処理の追加（文法はラムダ式とかってググるとわかりやすいかも）
		ws.OnOpen += (sender, e) =>
		{
			Debug.Log("WebSocket Open");
		};

		ws.OnMessage += (sender, e) =>
		{
			Debug.Log("Data: " + e.Data);
		};

		ws.OnError += (sender, e) =>
		{
			Debug.Log("WebSocket Error Message: " + e.Message);
		};

		ws.OnClose += (sender, e) =>
		{
			Debug.Log("WebSocket Close");
		};

		ws.Connect();

	}
	
	//データの送信
	void Update () {
		if (Input.GetKeyUp("s"))
		{
			ws.Send("Test Message");
		}
	}
	//接続を断つ
	void OnDestroy()
	{
		ws.Close();
		ws = null;
	}
}
