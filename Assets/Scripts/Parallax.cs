using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private MeshRenderer mesh;
    [SerializeField]
    public float speed = 1; //đặt tốc độ của ground,background
    void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //thay đổi khoảng cách, tạo hiệu ứng chuyển động
        mesh.material.mainTextureOffset += new Vector2((speed) *Time.deltaTime, 0);
    }
}
