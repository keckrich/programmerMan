using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public GameObject parentObject;  // Assign this from the editor or from another script
    private DraggableItem grandchild;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStartButton()
    {
        List<DraggableItem> grandchildScripts = GetDragableItems();
        StartCoroutine(CallFunctionOnItems(grandchildScripts));
    }

    private IEnumerator CallFunctionOnItems(List<DraggableItem> grandchildScripts)
    {
        foreach (DraggableItem gc in grandchildScripts)
        {
            ProcessItem(gc);
            yield return new WaitForSeconds(2); // Wait for 2 seconds
        }
    }

    private void ProcessItem(DraggableItem item)
    {
        item.onExecute();
    }

    public List<DraggableItem> GetDragableItems()
    {
        // List to hold all the script instances found on the grandchildren
        List<DraggableItem> grandchildScripts = new();

        // Traverse all children
        foreach (Transform child in parentObject.transform)
        {
            // Traverse all grandchildren of each child
            foreach (Transform grandchild in child)
            {

                // Try to get the script component on the grandchild
                DraggableItem script = grandchild.GetComponent<DraggableItem>();

                // If the script component exists, add it to the list
                if (script != null)
                {
                    grandchildScripts.Add(script);
                }
            }
        }

        return grandchildScripts;
    }
}
