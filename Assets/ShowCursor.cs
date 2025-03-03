using UnityEngine;

public class ShowCursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool bShowCursor;
	
	void Start()
    {
         bShowCursor = true;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = bShowCursor;
    }
}
