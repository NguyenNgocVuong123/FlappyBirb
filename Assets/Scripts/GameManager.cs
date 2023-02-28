using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int score;
    public Player bird;
    public Text scoreText;
    public AudioClip die;
    private AudioSource audioSource;
    public GameObject playbtn;
    public GameObject gameOver;

    // Start is called before the first frame update
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
        //cài đặt fps = 60
        Application.targetFrameRate = 60;
        Pause();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //điểm số
    public void ScoreUp(){
        score++;
        scoreText.text =score.ToString(); //cập nhật điểm số
    }
    //Gameover
    public void EndGame(){
        gameOver.SetActive(true); //hiển thị ui GameOver
        playbtn.SetActive(true);//hiển thị nút play
            audioSource.clip = die;
            audioSource.Play();
            Pause();
        
    }
    public void Play(){
        score = 0; //reset lại điểm
        scoreText.text = score.ToString(); //cập nhật điểm
        //ẩn bảng gameover và nút play
        playbtn.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1; //đặt lại thời gian là 1 để hàm update tiếp tục
        bird.enabled = true;

        //tìm và xóa toàn bộ pipe cũ
        Pipemove[] pipes = FindObjectsOfType<Pipemove>();
        for (int i =0; i< pipes.Length; i++)
            Destroy(pipes[i].gameObject);
    }

    //tạm thời dừng trò chơi bằng cách set timescale = 0 để hàm update k cập nhật
    void Pause(){
        Time.timeScale = 0;
        bird.enabled = false;

    }
}
