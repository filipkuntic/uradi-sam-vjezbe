using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Server : MonoBehaviourPunCallbacks
{
    public static Server instance;
    readonly private int multiplayerSceneIndex = 1;

    public GameObject mainMenu, loadingScreen, roomCreate, roomjoin;

    [SerializeField] private int roomSize;
    [SerializeField] private InputField nameField;
    [HideInInspector] public string nickname;

    private void Start()
    {
        if(instance == null) instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Connect()
    {
        nickname = nameField.text.ToString();
        PhotonNetwork.ConnectUsingSettings();
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        //roomCreate.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(PhotonNetwork.CurrentRoom);
        
        if (PhotonNetwork.IsMasterClient)
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }

    public override void OnDisconnected(DisconnectCause cause) => SceneManager.LoadScene("MainMenu");
}
