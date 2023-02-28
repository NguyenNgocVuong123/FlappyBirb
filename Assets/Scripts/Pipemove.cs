using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipemove : MonoBehaviour
{
    [SerializeField]
    public float speed =2f;
    private float leftEgde;
    // Start is called before the first frame update
    void Start()
    {
        //đặt giới hạn rìa trái
        leftEgde = Camera.main.ScreenToWorldPoint(Vector3.zero).x -9f;
    }

    // Update is called once per frame
    void Update()
    {
        //cho ống di chuyển về bên trái
        transform.position += Vector3.left * speed * Time.deltaTime;
        //nếu ống đi hết rìa trái thì tự bay màu
        if (transform.position.x < leftEgde)
            Destroy(gameObject);
    }

    
}
