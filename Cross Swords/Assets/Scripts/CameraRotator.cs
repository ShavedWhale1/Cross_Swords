using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    public static CameraRotator instance;

    [SerializeField] float speed;
    public float cameraDistOffset = 10;
    private GameObject mainCamera;
    private GameObject player;

    public bool rotate = false;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = this.gameObject;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInfo = player.transform.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z);

        if (rotate)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }
}
