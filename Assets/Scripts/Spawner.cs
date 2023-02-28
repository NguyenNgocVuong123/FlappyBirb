using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject pipe;

    //tỉ lệ spawn
    [SerializeField]
    private float spawnRate = 1.5f;
    
    //vị trí spawn
    public float minH = -2;
    public float maxH = -2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        InvokeRepeating(nameof(PipeSpawn), spawnRate, spawnRate);
    }
    void PipeSpawn()
    {
        //dùng hàm Instantiate để tạo bản sao của prefabs và đặt vị trí spawn chính là vị trí của GameObj đó,
        //Quaternion.identity là set cho obj đó k bị xoay chuyển
        GameObject pipes = Instantiate(pipe, transform.position, Quaternion.identity);
        //tạo độ cao ngẫu nhiên cho ống
        pipes.transform.position += Vector3.up * Random.Range(minH, maxH);
    }


    private void OnDisable()
    {
        //dừng lặp hàm spawn
        CancelInvoke("PipeSpawn");
    }
}
