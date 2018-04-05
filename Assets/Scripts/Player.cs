using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject block;
    private Block latestBlock;
    public bool isGameOver;

    public Text scoreText;
    public Text loseText;
    public Text scorePoints;
    public Text accuracyText;
    public Text accuracyPoints;

    private int score;

    //private float percent;

    public Camera followCamera;
    private Vector3 cameraPosition;

    public int count;
    public float moveSpeed = 10f;
    private Vector3 direction = Vector3.left;

    private int index = -1;
    public List<Block> stackOfBlocks = new List<Block>();
    private Vector3 spawnPosition = new Vector3(0, 5, -27);
     

    // Use this for initialization
    void Start () {
        cameraPosition = new Vector3(0, 41.5f, -96.9f);
        BlocksSpawn();
        scoreText.text = "Score";
        scorePoints.text = 0.ToString();
        accuracyText.text = "Accuracy";
        accuracyPoints.text = 0.ToString();        
    }

    // Update is called once per frame
    void Update() {        
        if (Input.GetMouseButtonDown(1))
        {
            latestBlock.GetComponent<Rigidbody>().useGravity = true;
            count = 0;

            Debug.Log(count);

            stackOfBlocks.Add(latestBlock);
            index++;

            SetScore();
            scorePoints.text = score.ToString();
            accuracyPoints.text = (score / (float)(index + 1)).ToString();

            if (moveSpeed <= 30)
                moveSpeed += 0.2f;

            Debug.Log(moveSpeed);
            if(index > 0)
                Debug.Log(Mathf.Abs(stackOfBlocks[index - 1].transform.position.x - latestBlock.transform.position.x));
        }

        if (latestBlock.isCollided && !isGameOver)
        {
            BlocksSpawn();
            CameraMovement();
        }
        else if (latestBlock.transform.position.y == spawnPosition.y)
            Move();

        if (index > 0)
        {
            if (latestBlock.transform.position.y < stackOfBlocks[index - 1].transform.position.y && latestBlock.isCollided == false)
            {
                isGameOver = true;                
            }       
            
        }            
        
        if (isGameOver)
        {
            cameraPosition = new Vector3(0, 116, -251);
            loseText.text = "Game Over!";
        }                  
    }

    public void Move()
    {
        if (Mathf.Abs(latestBlock.transform.position.x) > 15)
        {
            direction *= -1;
            count++;
        }

        if(count == 6)
        {
            isGameOver = true;
        }

        latestBlock.transform.Translate(direction * Time.deltaTime * moveSpeed);
    }

    public void CameraMovement()
    {
        cameraPosition.y += block.transform.localScale.y;
        followCamera.transform.position = cameraPosition;
    }


    public void BlocksSpawn()
    {
        spawnPosition.y += block.transform.localScale.y;
        block.GetComponent<Rigidbody>().useGravity = false;
        latestBlock = Instantiate(block, spawnPosition, Quaternion.identity).GetComponent<Block>();
    }

    public void SetScore()
    {
        int maxPoints = 10;
        int minPoints = 5;

        if (index > 0)
        {
            float distance = Mathf.Abs(stackOfBlocks[index - 1].transform.position.x - latestBlock.transform.position.x);
            Debug.Log("Distance " + distance);

            if (distance <= latestBlock.transform.localScale.x / 3)
                score += (int)(maxPoints - (maxPoints - minPoints) * (1 - (distance - latestBlock.transform.localScale.x / 2) * (-1)));
            else if (distance >= latestBlock.transform.localScale.x / 2)
                isGameOver = true;
            else
                score += minPoints;
        }
        else
            score += minPoints;
    }   
}
