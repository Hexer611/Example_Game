using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy_Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;

    [SerializeField]
    int total_enemies = 100;

    [SerializeField]
    Text remaining_enemies_text;

    float timer = 0f;
    
    GameObject player;

    int remaining_enemies;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        remaining_enemies = total_enemies + gameObject.transform.childCount;
        if (timer < 0.5f)
        {
            timer += Time.deltaTime;
        }
        else if (gameObject.transform.childCount < 100 && total_enemies > 0)
        {
            total_enemies -= 1;
            int rn_enemy = Random.Range(0, enemies.Length);
            int rn_border = Random.Range(0, 4);
            Vector3 n_pos = new Vector3();
            switch(rn_border)
            {
                case 0:
                    n_pos = new Vector3(-47, 2, Random.Range(-47, 47));
                    break;
                case 1:
                    n_pos = new Vector3(47, 2, Random.Range(-47, 47));
                    break;
                case 2:
                    n_pos = new Vector3(Random.Range(-47, 47), 2, -47);
                    break;
                case 3:
                    n_pos = new Vector3(Random.Range(-47, 47), 2, 47);
                    break;
            }
            GameObject enemy = Instantiate(enemies[rn_enemy], n_pos, Quaternion.identity, transform);
            enemy.GetComponent<Easy_Enemy>().player = player.transform;
        }
        else if (remaining_enemies <= 0)
        {
            GameObject.Find("Canvas").GetComponent<UI_Control>().win_screen();
        }
        remaining_enemies_text.text = "Remaining Enemies\n" + remaining_enemies;
    }
}
