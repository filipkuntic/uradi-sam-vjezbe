using Photon.Pun;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private PhotonView view;
    public GameObject bulletPrefab;
    public Transform shootPoint;
    public Transform orientation;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(view.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
                Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = PhotonNetwork.Instantiate(bulletPrefab.name, shootPoint.position, Camera.main.transform.rotation);
        bullet.transform.parent = transform;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 80f, ForceMode.Impulse);
        Destroy(bullet, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && view.IsMine && other.transform.parent != transform)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (view.AmOwner) view.TransferOwnership(PhotonNetwork.LocalPlayer.ActorNumber);
            PhotonNetwork.Destroy(other.gameObject);
            PhotonNetwork.Disconnect();
        }
    }
}
