using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GUIStyle style;
    public Texture texture;
    GUIContent content;
    Vector2 scrollPos = Vector2.zero;

    void Start() => CreatePlayer();
    private void CreatePlayer() => PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0, 0, 0), Quaternion.identity, 0);

   /* private void OnGUI()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            GUILayout.Label(PhotonNetwork.CurrentRoom.ToString());
            GUILayout.BeginArea(new Rect(10, 10, 500, 500));
            scrollPos.Set(600, 200);
            scrollPos = GUILayout.BeginScrollView(scrollPos, GUILayout.Width(100), GUILayout.Height(100));
            GUILayout.EndArea();
            foreach (Player item in PhotonNetwork.PlayerList)
            {
                content = new GUIContent(item.NickName.ToString(), texture);
                GUILayout.Box(content, style);
            }
            GUILayout.EndScrollView();
        }
    }*/
}
