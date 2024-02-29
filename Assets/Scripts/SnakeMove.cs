using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeMove : MonoBehaviour
{
    public float MoveSpeed;
    public float RotateSpeed;
    public float bodySpeed;
    public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PosHistory = new List<Vector3>();

    public int Gap = 2;
    public AppleSpawner appleRespawner;
    private Score score;
    private bool appleEaten = false;
    public Rigidbody rb;
    public string pauseMenuSceneName = "PauseMenu";
    private bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        GrowSnake();
        GrowSnake();
    }

    // Update is called once per frame
    void Update()
    {
            // Move Forward
            transform.position += transform.forward * this.MoveSpeed * Time.deltaTime;

            // Move Sides
            float RotateDirection = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * RotateDirection * this.RotateSpeed * Time.deltaTime);

            // Store Position History
            PosHistory.Insert(0, transform.position);

            // Move Body Parts
            int index = 0;
            foreach (var body in BodyParts)
            {
                Vector3 point = PosHistory[Mathf.Min(index * Gap, PosHistory.Count - 1)];
                Vector3 moveDirection = point - body.transform.position;
                body.transform.position += moveDirection * this.bodySpeed * Time.deltaTime;
                body.transform.LookAt(point);
                index++;
            }

            // Respawn apple only if it has been eaten
            if (appleEaten)
            {
                RespawnApple();

                // Reset
                appleEaten = false;
            }
            if (rb.position.y < -1f)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pause 
    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        SceneManager.LoadScene(pauseMenuSceneName, LoadSceneMode.Additive);
    }

    // Resume
    public void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.UnloadSceneAsync(pauseMenuSceneName);
    }

    // Snake Grow
    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    // When apple is eaten the Snake will Grow
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple"))
        {
            Destroy(other.gameObject);
            Debug.Log("Apple eaten!");

            if (score != null)
            {
                score.IncreaseScore();
            }

            // Grow the snake
            GrowSnake();

            // Mark that the apple has been eaten
            appleEaten = true;
        }
    }

    // Respawn Apple
    private void RespawnApple()
    {
        if (appleRespawner != null)
        {
            appleRespawner.AppleEaten();
        }
    }
}
