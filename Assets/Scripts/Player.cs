using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    float player_speed = 10;

    [SerializeField]
    Camera camer;

    [SerializeField]
    GameObject bullet;

    [SerializeField]
    float bullet_offset;

    [SerializeField]
    float bullet_speed;

    Rigidbody selfrigid;
    // Start is called before the first frame update
    void Start()
    {
        selfrigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
            direction += new Vector3(0, 0, 1);
        if (Input.GetKey(KeyCode.A))
            direction += new Vector3(-1, 0, 0);
        if (Input.GetKey(KeyCode.S))
            direction += new Vector3(0, 0, -1);
        if (Input.GetKey(KeyCode.D))
            direction += new Vector3(1, 0, 0);
        selfrigid.velocity = direction.normalized * player_speed;
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = camer.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhit;

            if (Physics.Raycast(ray, out rhit))
            {
                Vector3 bullet_direction = new Vector3(rhit.point.x - transform.position.x, 2, rhit.point.z - transform.position.z).normalized;
                GameObject blt = Instantiate(bullet, transform.position + bullet_direction * bullet_offset, Quaternion.identity);
                blt.GetComponent<Rigidbody>().velocity = bullet_direction * bullet_speed;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            GameObject.Find("Canvas").GetComponent<UI_Control>().lose_screen();
        
    }
}
