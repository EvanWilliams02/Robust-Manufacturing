using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset = 2;
    private Vector3 playerPosition;
    public float offsetSmoothing = 2;
    public Text textBox;
    public float timeStart = 0;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "Time: " + timeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        else
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);

        timeStart += Time.deltaTime;
        textBox.text = "Time: " + Mathf.Round(timeStart).ToString();

    }
}
