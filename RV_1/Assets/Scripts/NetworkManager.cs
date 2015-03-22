using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour
{


	string registeredGameName = "SubmarineSafari";
	bool isRefreshing = false;
	float refreshingRequestLength = 2.0f;
	HostData[] hostData;

	private void StartServer ()
	{
		Network.InitializeServer (16, 25002, false);

		MasterServer.RegisterHost (registeredGameName, "Networkinf Tutorial Test Game", "Test Implementation Of Server Code");
	}

	void OnServerInitialized ()
	{
		Debug.Log ("Server has been initialized");
	}

	void OnMasterServerEvent (MasterServerEvent masterServerEvent)
	{
		if (masterServerEvent == MasterServerEvent.RegistrationSucceeded)
			Debug.Log ("Registration successful");
	}

	public IEnumerator RefreshingHostList ()
	{
		Debug.Log ("Refreshing..");
		MasterServer.RequestHostList (registeredGameName);

		float timeStarted = Time.time;
		float timeEnd = Time.time + refreshingRequestLength;

		while (Time.time < timeEnd) {
			hostData = MasterServer.PollHostList ();
			yield return new WaitForEndOfFrame ();
		}

		if (hostData == null || hostData.Length == 0) {
			Debug.Log ("No active servers have been found");
		} else
			Debug.Log (hostData.Length + " Have been found");
	}
		
	public void OnGUI ()
	{

		if (Network.isClient || Network.isServer) {
			return;
		}

		if (GUI.Button (new Rect (25f, 25f, 150f, 30f), "Start New Server")) {
			StartServer ();
			//Start server functions
		}

		if (GUI.Button (new Rect (25f, 65f, 150f, 30f), "Refresh Server List")) {//Refresh Servers List Function Here
			 
			StartCoroutine ("RefreshingHostList");
		}

		if (hostData != null) {
			for (int i=0; i<hostData.Length; i++) {
				if (GUI.Button (new Rect (Screen.width / 2, 65f + (30f * i), 300f, 30f), hostData [i].gameName)) {//checar esto para conectarse al server
					Network.Connect (hostData [i]);
				}

			}
		}
	}
	
}
