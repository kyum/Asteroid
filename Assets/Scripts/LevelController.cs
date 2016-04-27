using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{

    Vector2 spawn_pos;
    public GameObject player;
    public GameObject asteroid_mid;
    GameObject play;
    bool player_exist = false;
    bool asteroids_exist = false;
    public int medexist = 5; //do zmiany 


    void spawn_asteroids()
    {
        if (!asteroids_exist)
        {
            Vector2 poz = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            for (int i = 0; i < 5; i++)
            {
                GameObject newast_mid = (GameObject)Instantiate(asteroid_mid, new Vector2(Random.Range(-poz.x, poz.x), Random.Range(-poz.y, poz.y)), transform.rotation);
                newast_mid.name = asteroid_mid.name;
                asteroids_exist = true;
            }

        }
    }

    void spawn_player()
    {
        if (!player_exist)
        {
            spawn_pos = new Vector2(0, 0);
            GameObject newplayer = (GameObject)Instantiate(player, spawn_pos, transform.rotation);
            newplayer.name = player.name;
            player_exist = true;
        }
    }

    // Use this for initialization
    void Start()
    {
        spawn_player();
        spawn_asteroids();
    }

    // Update is called once per frame
    void Update()
    {
        if(medexist==0)
        {
            asteroids_exist = false;
            spawn_asteroids();
            medexist = 5;
        }
    }
}
