using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseClickVisualizer : MonoBehaviour
{
	private UnityEngine.UI.Image cursorImage;
	public Color normalColor = Color.white;
    public Color clickColor = Color.red;

	void Start()
	{
		// Get the Image component
		 
		cursorImage = GetComponent<UnityEngine.UI.Image>();
		if (cursorImage == null)
		{
			Debug.LogError("This script requires an Image component");
		}
		
		// Ensure the cursor doesn't block raycasts
		cursorImage.raycastTarget = false;
		
	}

	void Update()
	{
		
		// 1. Move cursor UI to mouse position
		transform.position = Input.mousePosition;
		
		// 2. Change cursor color on click
		if (Input.GetMouseButtonDown(0))
			cursorImage.color = clickColor;
		else if (Input.GetMouseButtonUp(0))
			cursorImage.color = normalColor;
		
		// 3. Handle UI button clicks separately
		if (Input.GetMouseButtonDown(0))
		{
			// Use EventSystem to detect UI elements under the pointer
			if (EventSystem.current.IsPointerOverGameObject())
			{
				Debug.Log("Clicked on UI element");
				// Button clicks will be handled by Button.onClick events
				// No need for additional code here unless you want custom behavior
			}
		}
		
	}
}