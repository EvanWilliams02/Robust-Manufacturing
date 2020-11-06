using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public float respawnDelay = 0f; 
    public PlayerController player;
    public int coins = 0;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        coinText.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnSceneLoaded()
    {
        coins = 0;
    }
    public void Respawn()
	{
		StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
		player.transform.position = player.respawnPoint;
		player.gameObject.SetActive(true);
	}

    public void AddPoints(int numberOfPoints)
    {
        coins += numberOfPoints;
        coinText.text = "Coins: " + coins;
    }
}
