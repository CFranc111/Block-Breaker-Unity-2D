using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler {

	private Vector2 pointerOffset;
	private RectTransform canvasRectTransform;
	private RectTransform panelRectTransform;
	
	void Awake () {
		Canvas canvas = GetComponentInParent<Canvas>();
		if (canvas != null) {
		
			// Get references
			canvasRectTransform = canvas.transform as RectTransform; // Canvas transform, cast as a RectTransform
			panelRectTransform = transform.parent as RectTransform; // Panel transform (b/c hotspot is a child of panel)
		}
	}
	
	//
	// Get the mouse offset
	//
	public void OnPointerDown (PointerEventData data) {
	
		// Bring the panel to the front (in case it it's below another panel)
		panelRectTransform.SetAsLastSibling();
		
		// Find where the point came down on the panel
		//-- data.position = position of mouse
		//-- data.pressEventCamera = the camera we're taking it from
		RectTransformUtility.ScreenPointToLocalPointInRectangle(panelRectTransform, data.position, data.pressEventCamera, out pointerOffset);
	}
	
	//
	// Drag panel
	//
	public void OnDrag (PointerEventData data) {
		if (panelRectTransform == null) { return; }
		
		Vector2 pointerPosition = ClampToWindow(data); // Keep pointer position from going off page (so panel can't get lost outside edges of game)
		Vector2 localPointerPosition;
		
		// Set offset
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, pointerPosition, data.pressEventCamera, out localPointerPosition)) { 
			panelRectTransform.localPosition = localPointerPosition - pointerOffset;
		}
	}
	
	//
	// Keep pointer position within confines of canvas
	//
	Vector2 ClampToWindow (PointerEventData data) {
		Vector2 rawPointerPosition = data.position; // data.position = actual position coming in of pointer
		
		// Get corners of canvas
		Vector3[] canvasCorners = new Vector3[4];
		canvasRectTransform.GetWorldCorners(canvasCorners); // Populates array with the corner coordinates
		
		float clampX = Mathf.Clamp(rawPointerPosition.x,canvasCorners[0].x, canvasCorners[2].x);
		float clampY = Mathf.Clamp(rawPointerPosition.y,canvasCorners[0].y, canvasCorners[2].y);
		
		Vector2 newPointerPosition = new Vector2(clampX, clampY);
		return newPointerPosition;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
