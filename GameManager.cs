using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class GameManager : MonoBehaviour
{
    public float timeLimit = 10f;
    public Text timerText;
    private float timer;

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timer).ToString();

        if (timer <= 0)
        {
            GameOver();
        }
   
    
    if (Input.GetMouseButtonDown(0)) 
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log("Mouse Clicked at World Position: " + worldPoint);

        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log("Hit Object: " + hit.collider.gameObject.name);
            GameObject guessedObject = hit.collider.gameObject;
            ChangeManager changeManager = FindAnyObjectByType<ChangeManager>();
            changeManager.CheckGuess(guessedObject);
        }
        else
        {
            Debug.Log("No object hit.");
        }
    }
}
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject guessedObject = gameObject; 
        ChangeManager changeManager = FindAnyObjectByType<ChangeManager>(); 
        changeManager.CheckGuess(guessedObject); 
    }

    void GameOver()
    {
        Debug.Log("Game Over! The entity got you.");
        SceneManager.LoadScene("MainRoom"); 
    }
}
