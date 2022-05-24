using UnityEngine;

public class MoveObj : MonoBehaviour
{
   // public GameObject selectedObjects;
    private GameObject[] selectedObjects;
    private GameObject currentSelectedObject;
    public Renderer myRenderer;
    Vector3 offset;

    private void Start()
    {
        selectedObjects = GameObject.FindGameObjectsWithTag("Part");
    }
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                foreach(GameObject obj in selectedObjects)
                {
                    if(obj == targetObject.transform.gameObject)
                    {
                        currentSelectedObject = obj;
                    }
                }
                currentSelectedObject = targetObject.transform.gameObject;
                offset = currentSelectedObject.transform.position - mousePosition;
            }
        }
        if (currentSelectedObject)
        {
            currentSelectedObject.transform.position = mousePosition + offset;
        }
        if (Input.GetMouseButtonUp(0) && currentSelectedObject)
        {
            currentSelectedObject = null;
        }
    }

    void CheckForClick()
    {
        Vector3 positionToCheck = ClickManager.mousePosition;
        positionToCheck.z = myRenderer.bounds.center.z;
        if (myRenderer.bounds.Contains(positionToCheck))
        {
            ClickManager.selectedObject = gameObject;
        }
    }
}
