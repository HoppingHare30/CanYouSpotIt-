using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse click
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null) 
            {
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);

                
                ChangeManager changeManager = FindAnyObjectByType<ChangeManager>();

                if (changeManager != null)
                {
                    
                    bool isCorrect = changeManager.CheckGuess(hit.collider.gameObject);

                    if (isCorrect)
                    {
                        Debug.Log("✅ Correct! Loading next level...");
                        
                    }
                    else
                    {
                        Debug.Log("❌ Wrong! You lose...");
                    }
                }
                else
                {
                    Debug.LogError("❌ ChangeManager not found!");
                }
            }
        }
    }
}

