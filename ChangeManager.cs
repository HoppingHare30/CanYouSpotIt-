using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour
{
    public List<GameObject> objectsToChange; 
    private GameObject changedObject;
private GameObject correctObject; 
    void Start()
    {
        PickRandomObject();
    }

    public void PickRandomObject()
    {
        if (objectsToChange == null || objectsToChange.Count == 0) return;


        int index = Random.Range(0, objectsToChange.Count);
        changedObject = objectsToChange[index];
        correctObject = changedObject;
        ApplyChange(changedObject);
    }
    

    private void ApplyChange(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().enabled = false;

    }




    public bool CheckGuess(GameObject guessedObject)
    {
        if (guessedObject == correctObject)
        {
            Debug.Log("✅ Correct Guess!");
            PickRandomObject(); 
            return true; 
        }
        else
        {
            Debug.Log("❌ Wrong Guess!");
            return false; 
        }
    }
}
