using UnityEngine;

public class MobileNetwork_Cube : Photon.PunBehaviour
{
    // TODO-1.b: write any functions needed to establish connection
    //   and join a room. Joining a random room will do for now if you are testing
    //   it yourself. But you can also list the rooms or require player to enter
    //   the room name in case there are more people playing
    //   your game - though it is not required for the assignment.
    private string roomName;

    private void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		roomName = "HannahRoom";
        Screen.orientation = ScreenOrientation.Portrait; //-- CHECK - NEED TO DELETE? depends on phone orientation (1d)
    }

    private void OnGUI()
    {
        GUILayout.Space(87);
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

	public override void OnJoinedLobby()
	{
		PhotonNetwork.JoinRoom(roomName);
		base.OnJoinedLobby ();
	}

    public override void OnJoinedRoom()
    {
        //TODO-1.c: DONE
        // use PhotonNetwork.Instantiate to create a "PhoneCube" across the network
        GetComponent<GyroController>().ControlledObject
            = PhotonNetwork.Instantiate("MyPhoneCube",
                                        new Vector3(0, 0, 0),
                                        Quaternion.identity,
                                        0);

		base.OnJoinedRoom ();
	}
}