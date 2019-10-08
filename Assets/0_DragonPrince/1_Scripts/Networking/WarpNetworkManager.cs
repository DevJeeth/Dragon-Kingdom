using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeplayVR.Base;

#region WARP
using com.shephertz.app42.gaming.multiplayer.client;
using com.shephertz.app42.gaming.multiplayer.client.events;
using com.shephertz.app42.gaming.multiplayer.client.command;
using com.shephertz.app42.gaming.multiplayer.client.listener;
#endregion



public class WarpNetworkManager : MBSingleton<WarpNetworkManager>
{
	private string m_strAppKey = "9a8f11688a5028bd91cee478f992c94a69bfbdfbf5fe661b498a922603c5cd2a";
	private string m_strPrivateKey = "073e537d85b820a19b211ac9714d432726b83537f85037b3631e358d31c384b8";
	private string m_strRoomID = "523090743";

	private WarpClient m_warpClient;
	private WarpListerner m_warpListener = new WarpListerner();

	private string m_strPlayerName;
	public string PlayerName
	{
		set
		{
			m_strPlayerName = value;
		}
		get
		{
			return m_strPlayerName;
		}
	}

	private int m_iSessionID = 0;

	private void Awake()
	{
	}

	//Api refernce: http://appwarp.shephertz.com/game-development-center/csharp-api-reference/
	//Callbacks: http://appwarp.shephertz.com/game-development-center/windows-game-developers-home/windows-client-listener/#connectionrequestlistener
	// Start is called before the first frame update
	private void Start()
    {
		WarpClient.initialize("9a8f11688a5028bd91cee478f992c94a69bfbdfbf5fe661b498a922603c5cd2a", "073e537d85b820a19b211ac9714d432726b83537f85037b3631e358d31c384b8");
		WarpClient.setRecoveryAllowance(5);
		m_warpClient = WarpClient.GetInstance();

		//Registering to connection callbacks
		m_warpClient.AddConnectionRequestListener(m_warpListener);
		//Registering to Chat callbacks
		m_warpClient.AddChatRequestListener(m_warpListener);
		//Registering to Update Request callbacks
		m_warpClient.AddUpdateRequestListener(m_warpListener);
		//Registering to Lobby callbacks
		m_warpClient.AddLobbyRequestListener(m_warpListener);
		//Registering to Notifier callbacks
		m_warpClient.AddNotificationListener(m_warpListener);
		//Registering to Room/Subscribe callbacks
		m_warpClient.AddRoomRequestListener(m_warpListener);
		//Registering to Zone callbacks
		m_warpClient.AddZoneRequestListener(m_warpListener);
		//Registering to Turn Based callbacks
		m_warpClient.AddTurnBasedRoomRequestListener(m_warpListener);
	}

	public void ConnectedToServer()
	{
		if (string.IsNullOrEmpty(m_strPlayerName))
		{
			m_strPlayerName = "JohnDoe_";
			Debug.LogError("[WarpNetworkManager] Playername is empty: Settings Default Name: JohnDoe");
		}
		m_strPlayerName = m_strPlayerName + "_";
		m_strPlayerName = string.Concat(m_strPlayerName, System.DateTime.UtcNow.Ticks.ToString());
		Debug.Log("[WarpNetworkManager] Connecting to server: PLAYERNAME: " + m_strPlayerName);

		
		m_warpClient.Connect(m_strPlayerName);
	}

	public void DisconnectedFromServer()
	{
		Debug.Log("[WarpNetworkManager] Disconnection from server: PLAYERNAME: " + m_strPlayerName);
		m_warpClient.Disconnect();
	}

	public void SubscribeRoom()
	{
		Debug.Log("[WarpNetworkManager]Subscribe to room [SubscribeRoom]");
		m_warpClient.SubscribeRoom(m_strRoomID);
	}

	public void JoinRoom()
	{
		Debug.Log("[WarpNetworkManager] Join room [JoinRoom]");
		m_warpClient.JoinRoom(m_strRoomID);
	}

	public void ReconnectToServer()
	{
		if(m_warpClient == null)
		{
			Debug.LogError("[WarpNetworkManager] not initialized, its NULL [ReconnectToServer]");
			return;
		}
		if (m_iSessionID == 0)
		{
			Debug.Log("[WarpNetworkManager] no session ID [ReconnectToServer]");
			m_warpClient.RecoverConnection();
		}
		else
		{
			m_warpClient.RecoverConnectionWithSessioId(m_iSessionID,PlayerName);
		}
	}

//Connection States
//byte CONNECTED = 0;
//byte CONNECTING = 1;
//byte DISCONNECTED = 2;
//byte DISCONNECTING = 3;
//byte RECOVERING = 4;

	public void GetConnectionState()
	{
		m_warpClient.GetConnectionState();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

//WarpResponseResultCode States
 //SUCCESS = 0;
 //AUTH_ERROR = 1;
 //RESOURCE_NOT_FOUND = 2;
 //RESOURCE_MOVED = 3;
 //BAD_REQUEST = 4;
 //CONNECTION_ERR = 5;
 //UNKNOWN_ERROR = 6;
 //RESULT_SIZE_ERROR = 7;
 //SUCCESS_RECOVERED = 8;
 //CONNECTION_ERROR_RECOVERABLE = 9;
 //USER_PAUSED_ERROR = 10;


/// <summary>
/// This class is used to register istelf to all the listeners provided by AppWarp sdk
/// </summary>
public class WarpListerner : ConnectionRequestListener, LobbyRequestListener, ZoneRequestListener, RoomRequestListener, ChatRequestListener, UpdateRequestListener, NotifyListener, TurnBasedRoomListener
{

	#region ConnectionListener
	public void onConnectDone(ConnectEvent eventObj)
	{

		switch (eventObj.getResult())
		{
			case WarpResponseResultCode.SUCCESS:
				Debug.Log("[WarpNetworkManager] connection success: " + eventObj.getResult().ToString()+"Subscribe to Room");
				WarpNetworkManager.Instance.SubscribeRoom();
				break;
			case WarpResponseResultCode.CONNECTION_ERR:
				Debug.Log("[WarpNetworkManager] connection error [Non-Recoverable]: " + eventObj.getResult().ToString());
				break;
			case WarpResponseResultCode.CONNECTION_ERROR_RECOVERABLE:
				Debug.Log("[WarpNetworkManager] connection error [Recoverable]: " + eventObj.getResult().ToString());
				WarpNetworkManager.Instance.ReconnectToServer();
				break;
			case WarpResponseResultCode.AUTH_ERROR:
				Debug.Log("[WarpNetworkManager] connection error: " + eventObj.getResult().ToString());
				break;
			case WarpResponseResultCode.BAD_REQUEST:
				Debug.Log("[WarpNetworkManager] connection error: " + eventObj.getResult().ToString());
				break;	
			case WarpResponseResultCode.RESOURCE_MOVED:
				Debug.Log("[WarpNetworkManager] connection error: " + eventObj.getResult().ToString());
				break;
			case WarpResponseResultCode.RESOURCE_NOT_FOUND:
				Debug.Log("[WarpNetworkManager] connection error: " + eventObj.getResult().ToString());
				break;
			case WarpResponseResultCode.RESULT_SIZE_ERROR:
				Debug.Log("[WarpNetworkManager] connection error: " + eventObj.getResult().ToString());
				break;
			case WarpResponseResultCode.UNKNOWN_ERROR:
				Debug.Log("[WarpNetworkManager] connection error: " + eventObj.getResult().ToString());
				break;
			case WarpResponseResultCode.USER_PAUSED_ERROR:
				Debug.Log("[WarpNetworkManager] connection error: " + eventObj.getResult().ToString());
				break;
			default:
				break;
		}
	}

	public void onDisconnectDone(ConnectEvent eventObj)
	{
		// handle Disconnect here      
	}
	public void onInitUDPDone(byte resultCode)
	{
		// handle onInitUDPDone here      
	}
	#endregion

	//LobbyRequestListener
	#region LobbyRequestListener
	public void onJoinLobbyDone (LobbyEvent eventObj)
	{
		Debug.Log("onJoinLobbyDone : " + eventObj.getResult());
		if(eventObj.getResult() == 0)
		{
			
		}
	}
		
	public void onLeaveLobbyDone (LobbyEvent eventObj)
	{
		Debug.Log("onLeaveLobbyDone : " + eventObj.getResult());
	}
		
	public void onSubscribeLobbyDone (LobbyEvent eventObj)
	{
		Debug.Log("onSubscribeLobbyDone : " + eventObj.getResult());
		if(eventObj.getResult() == 0)
		{
			WarpClient.GetInstance().JoinLobby();
		}
	}
		
	public void onUnSubscribeLobbyDone (LobbyEvent eventObj)
	{
		Debug.Log("onUnSubscribeLobbyDone : " + eventObj.getResult());
	}
		
	public void onGetLiveLobbyInfoDone (LiveRoomInfoEvent eventObj)
	{
		Debug.Log("onGetLiveLobbyInfoDone : " + eventObj.getResult());
	}
	#endregion
		
	//ZoneRequestListener
	#region ZoneRequestListener
	public void onDeleteRoomDone (RoomEvent eventObj)
	{
		Debug.Log("onDeleteRoomDone : " + eventObj.getResult());
	}
		
	public void onGetAllRoomsDone (AllRoomsEvent eventObj)
	{
		Debug.Log("onGetAllRoomsDone : " + eventObj.getResult());
		for(int i=0; i< eventObj.getRoomIds().Length; ++i)
		{
			Debug.Log("Room ID : " + eventObj.getRoomIds()[i]);
		}
	}
		
	public void onCreateRoomDone (RoomEvent eventObj)
	{
		Debug.Log("onCreateRoomDone : " + eventObj.getResult());
	}
		
	public void onGetOnlineUsersDone (AllUsersEvent eventObj)
	{
		Debug.Log("onGetOnlineUsersDone : " + eventObj.getResult());
	}
		
	public void onGetLiveUserInfoDone (LiveUserInfoEvent eventObj)
	{
		Debug.Log("onGetLiveUserInfoDone : " + eventObj.getResult());
	}
		
	public void onSetCustomUserDataDone (LiveUserInfoEvent eventObj)
	{
		Debug.Log("onSetCustomUserDataDone : " + eventObj.getResult());
	}
		
    public void onGetMatchedRoomsDone(MatchedRoomsEvent eventObj)
	{
		if (eventObj.getResult() == WarpResponseResultCode.SUCCESS)
        {
            Debug.Log("GetMatchedRooms event received with success status");
            foreach (var roomData in eventObj.getRoomsData())
            {
                Debug.Log("Room ID:" + roomData.getId());
            }
        }
	}		
	#endregion

	//RoomRequestListener
	#region RoomRequestListener
	public void onSubscribeRoomDone (RoomEvent eventObj)
	{
		if(eventObj.getResult() == 0)
		{
			Debug.Log("[WarpListener] Subscribe successful");
			WarpNetworkManager.Instance.JoinRoom();
		}
			
		Debug.Log("onSubscribeRoomDone : " + eventObj.getResult());
	}
		
	public void onUnSubscribeRoomDone (RoomEvent eventObj)
	{
		Debug.Log("onUnSubscribeRoomDone : " + eventObj.getResult());
	}
		
	public void onJoinRoomDone (RoomEvent eventObj)
	{
		if (eventObj.getResult() == 0)
		{
			Debug.Log("[WarpListener] Joining Room successful");
		}
		Debug.Log("onJoinRoomDone : " + eventObj.getResult());	
	}
		
	public void onLockPropertiesDone(byte result)
	{
		Debug.Log("onLockPropertiesDone : " + result);
	}
		
	public void onUnlockPropertiesDone(byte result)
	{
		Debug.Log("onUnlockPropertiesDone : " + result);
	}
		
	public void onLeaveRoomDone (RoomEvent eventObj)
	{
		Debug.Log("onLeaveRoomDone : " + eventObj.getResult());
	}
		
	public void onGetLiveRoomInfoDone (LiveRoomInfoEvent eventObj)
	{
		Debug.Log("onGetLiveRoomInfoDone : " + eventObj.getResult());
	}
		
	public void onSetCustomRoomDataDone (LiveRoomInfoEvent eventObj)
	{
		Debug.Log("onSetCustomRoomDataDone : " + eventObj.getResult());
	}
		
	public void onUpdatePropertyDone(LiveRoomInfoEvent eventObj)
    {
        if (WarpResponseResultCode.SUCCESS == eventObj.getResult())
        {
            Debug.Log("UpdateProperty event received with success status");
        }
        else
        {
            Debug.Log("Update Propert event received with fail status. Status is :" + eventObj.getResult().ToString());
        }
    }
	#endregion
		
	//ChatRequestListener
	#region ChatRequestListener
	public void onSendChatDone (byte result)
	{
		Debug.Log("onSendChatDone result : " + result);
			
	}
		
	public void onSendPrivateChatDone(byte result)
	{
		Debug.Log("onSendPrivateChatDone : " + result);
	}
	#endregion
		
	//UpdateRequestListener
	#region UpdateRequestListener
	public void onSendUpdateDone (byte result)
	{
	}
	public void onSendPrivateUpdateDone (byte result)
	{
		Debug.Log("onSendPrivateUpdateDone : " + result);
	}
	#endregion

	//NotifyListener
	#region NotifyListener
	public void onRoomCreated (RoomData eventObj)
	{
		Debug.Log("onRoomCreated");
	}
	public void onPrivateUpdateReceived (string sender, byte[] update, bool fromUdp)
	{
		Debug.Log("onPrivateUpdate");
	}
	public void onRoomDestroyed (RoomData eventObj)
	{
		Debug.Log("onRoomDestroyed");
	}
		
	public void onUserLeftRoom (RoomData eventObj, string username)
	{
		Debug.Log("onUserLeftRoom : " + username);
	}
		
	public void onUserJoinedRoom (RoomData eventObj, string username)
	{
		Debug.Log("onUserJoinedRoom : " + username);
	}
		
	public void onUserLeftLobby (LobbyData eventObj, string username)
	{
		Debug.Log("onUserLeftLobby : " + username);
	}
		
	public void onUserJoinedLobby (LobbyData eventObj, string username)
	{
		Debug.Log("onUserJoinedLobby : " + username);
	}
		
	public void onUserChangeRoomProperty(RoomData roomData, string sender, Dictionary<string, object> properties, Dictionary<string, string> lockedPropertiesTable)
	{
		Debug.Log("onUserChangeRoomProperty : " + sender);
	}
			
	public void onPrivateChatReceived(string sender, string message)
	{
		Debug.Log("onPrivateChatReceived : " + sender);
	}
		
	public void onMoveCompleted(MoveEvent move)
	{
		Debug.Log("onMoveCompleted by : " + move.getSender());
	}
		
	public void onChatReceived (ChatEvent eventObj)
	{
		Debug.Log(eventObj.getSender() + " sended " + eventObj.getMessage());
		com.shephertz.app42.gaming.multiplayer.client.SimpleJSON.JSONNode msg =  com.shephertz.app42.gaming.multiplayer.client.SimpleJSON.JSON.Parse(eventObj.getMessage());
		//msg[0] 
		if(eventObj.getSender() != WarpNetworkManager.Instance.PlayerName)
		{

		}
	}
		
	public void onUpdatePeersReceived (UpdateEvent eventObj)
	{
		Debug.Log("onUpdatePeersReceived");
	}
		
	public void onUserChangeRoomProperty(RoomData roomData, string sender, Dictionary<string, System.Object> properties)
    {
        Debug.Log("Notification for User Changed Room Propert received");
        Debug.Log(roomData.getId());
        Debug.Log(sender);
        foreach (KeyValuePair<string, System.Object> entry in properties)
        {
            Debug.Log("KEY:" + entry.Key);
            Debug.Log("VALUE:" + entry.Value.ToString());
        }
    }

		
	public void onUserPaused(string locid, bool isLobby, string username)
	{
		Debug.Log("onUserPaused");
	}
		
	public void onUserResumed(string locid, bool isLobby, string username)
	{
		Debug.Log("onUserResumed");
	}
		
	public void onGameStarted(string sender, string roomId, string nextTurn)
	{
		Debug.Log("onGameStarted");
	}
		
	public void onGameStopped(string sender, string roomId)
	{
		Debug.Log("onGameStopped");
	}

	public void onNextTurnRequest (string lastTurn)
	{
		Debug.Log("onNextTurnRequest");
	}
	#endregion

	//TurnBasedRoomListener
	#region TurnBasedRoomListener
	public void onSendMoveDone(byte result)
	{
	}
		
	public void onStartGameDone(byte result)
	{
	}
		
	public void onStopGameDone(byte result)
	{
	}
		
	public void onSetNextTurnDone(byte result)
	{
	}
		
	public void onGetMoveHistoryDone(byte result, MoveEvent[] moves)
	{
	}
	#endregion

}