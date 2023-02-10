using Photon.Pun;
using UnityEngine;

public class NicknameShow : MonoBehaviourPun
{
    private PhotonView view;
    private Collider[] objects;
    public Texture texture;
    public float radius = 20f;
    [HideInInspector] public string nickname;

    GUIContent content;
    public GUIStyle style;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
        if(view.IsMine)
        {
            nickname = Server.instance.nickname;
            gameObject.name = nickname;
            view.Owner.NickName = nickname;
        }
    }

    private void Update()
    {
        objects = Physics.OverlapSphere(transform.position, 20f, LayerMask.GetMask("Player"));
    }

    private void OnGUI()
    {
        GUI.color = Color.white;
        for (int i = 0; i < objects.Length; i++)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(objects[i].transform.position);
            screenPos.y = Screen.height - screenPos.y;
            screenPos.x = screenPos.x - 50;
            content = new GUIContent(objects[i].GetComponent<PhotonView>().Owner.NickName.ToString(), texture);
            if (view.IsMine) GUI.Box(new Rect(screenPos.x, screenPos.y - 100, Screen.width / 8, Screen.height / 20), content, style);
        }
    }
}
