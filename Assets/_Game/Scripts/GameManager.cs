using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayerIOClient;

public class GameManager : MonoBehaviour {
	private Connection pioconnection;
	private List<PlayerIOClient.Message> msgList = new List<PlayerIOClient.Message>(); //  Messsage queue implementation
	private bool joinedroom = false;

	public string infomsg = "";

	public static GameManager Instance { get; private set; }
	public Client _client;

	public string userid;

	// Use this for initialization
	void Start () {
		if (FindObjectsOfType (GetType ()).Length > 1) {
			Destroy (gameObject);
		} else {
			Instance = this;

			Screen.sleepTimeout = SleepTimeout.NeverSleep;

			DontDestroyOnLoad(gameObject);
		}

	}

	public void ConnectServer(){
		// create a random userid 
		userid = PlayerPrefs.GetString ("username", "");

		Debug.Log("Starting");

		var authargs = new Dictionary<string, string> {
			{"userId", userid}				// The id of the user connecting. This can be any string you like. For instance, it might be "fb10239" if youґre building a Facebook app and the user connecting has id 10239
		};

		PlayerIOClient.PlayerIO.Authenticate(
			"deberc-2wqci8fheumyedcfrbbzq",	// Game id (Get your own at playerio.com. 1: Create user, 2:Goto admin pannel, 3:Create game, 4: Copy game id inside the "")
			"public",						// The id of the connection, as given in the settings section of the admin panel. By default, a connection with id='public' is created on all games.
			authargs,							
			null,							// If you are using PlayerInsight, you can specify segments here that the connecting user should be part of.
			delegate(Client client) {
				Debug.Log("Successfully connected to Player.IO");
				infomsg = "Successfully connected to Player.IO";

				//target.transform.Find("NameTag").GetComponent<TextMesh>().text = userid;
				//target.transform.name = userid;

				// Uncoment the line below to use the Development Server
				client.Multiplayer.DevelopmentServer = new ServerEndpoint("localhost",8184);

				_client = client;
				
			},
			delegate(PlayerIOError error) {
				Debug.Log("Error connecting: " + error.ToString());
				infomsg = error.ToString();
			}
		);
	}

	public void ConnectRoom(){
		//Create or join the room 
		_client.Multiplayer.CreateJoinRoom(
			"UnityDemoRoom",					//Room id. If set to null a random roomid is used
			"DebercRoom",						//The room type started on the server
			true,								//Should the room be visible in the lobby?
			null,
			null,
			delegate(Connection connection) {
				Debug.Log("Joined Room.");
				infomsg = "Joined Room.";
				// We successfully joined a room so set up the message handler
				pioconnection = connection;
				pioconnection.OnMessage += handlemessage;
				joinedroom = true;
			},
			delegate(PlayerIOError error) {
				Debug.Log("Error Joining Room: " + error.ToString());
				infomsg = error.ToString();
			}
		);
	}

	public void StartGame() {
		SceneManager.LoadScene("game");
	}

	void handlemessage(object sender, PlayerIOClient.Message m) {
		msgList.Add(m);
	}

	
	// Update is called once per frame
	void FixedUpdate () {
		// process message queue
		/*foreach(PlayerIOClient.Message message in msgList) {
			switch (message.Type) {
				case "Connect":
					textUI.text = message.GetString (0);
					break;
				case "Left":
					textUI.text = message.GetString (0);
					break;
			}
		}*/
	}

	void Update (){
		
	}
}
