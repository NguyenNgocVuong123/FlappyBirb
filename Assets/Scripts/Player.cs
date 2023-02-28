using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 direction; //hướng di chuyển của chim
    [SerializeField]
    private float gravity = -9f; //mức trọng lực
    [SerializeField]
    private float jumpHeight = 5f; //mức nhảy
    private SpriteRenderer spriteR; //khai báo spriteRenderer
    [SerializeField]
    private Sprite[] sprites; //tạo mạng chứa animation
    private Sprite[] die;
    public AudioClip fly;
    public AudioClip fall;
    
    public AudioClip score;
    public AudioClip hit;
    public Player bird;

    private AudioSource audioSource;
    
    private int spirtesIndex;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteR = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //hàm lặp lại liên tục một hàm nào đó với giá trị (tên hàm, thời gian chờ để bắt đầu, thời gian chờ để lặp lại)
        InvokeRepeating("BirdAnimation", 0.15f, 0.15f);
    }

    // Update is called once per frame
    void Update()
    {
        BirdJump();

    }
    void BirdJump()
    {
        //cài phím nhảy là space hoặc chuột trái
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * jumpHeight; //nhảy hướng lên trên dựa theo mức nhảy
            //bỏ đè âm thanh để khi nhận điểm thì âm thanh nhận điểm k bị âm thanh nhảy đè lên làm ngắt quãng
            if(audioSource.isPlaying == false){
                audioSource.clip = fly;
                audioSource.Play();
            }
            
        }
        //kiểm tra tính năng chạm trên mobile
        if (Input.touchCount > 0) //nếu lần ngón tay chạm > 0
        {
            Touch touch = Input.GetTouch(0);//nhận giá trị lần chạm
            if(touch.phase == TouchPhase.Began) //kiểm tra xem trạng thái chạm là bắt đầu hay kết thúc
            {
                direction = Vector3.up * jumpHeight;
            }
        }
        //áp dụng trọng lực vào
        direction.y += gravity * Time.deltaTime;
        //time.deltaltime sẽ giúp cho khung hình trên giây(frame) luôn nhất quán dù ở bất cứ thiết bị nào
        transform.position += direction * Time.deltaTime; //cập nhật vị trí của player
        // x2 giá trị gravity vì trọng lực là giá trị gia tăng theo mét/giây bình phương lên
    }
    void BirdAnimation()
    {
        //lặp lại animation index1 => index2 =>index3 =>quay lại index1=>...
        spirtesIndex++;
        if (spirtesIndex >= sprites.Length) //nếu hoạt ảnh của bird đang ở index cuối thì quay lại hoạt ảnh đầu
        {
            spirtesIndex = 0;
        }
        spriteR.sprite = sprites[spirtesIndex]; //cập nhật lại sprite
    }

    //Kiểm tra va chạm và ghi điểm
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="ObjDead"){ //nếu va chạm với obj có tag là ObjDead thì gọi hàm EndGame
            FindObjectOfType<GameManager>().EndGame();
            audioSource.clip = hit;
            audioSource.Play();

        } else if(other.gameObject.tag=="Scoring"){//nếu va chạm với obj có tag là Scoring thì gọi hàm ScoreUp
            FindObjectOfType<GameManager>().ScoreUp();
            audioSource.clip = score;
            audioSource.Play();
        }
    }

    //reset vị trí player khi chơi lại
    private void OnEnable() {
        Vector3 pos = transform.position;
        pos.y = 0;
        transform.position = pos;
        direction = Vector3.zero;
    }
}
