using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonScaler : MonoBehaviour, ISelectHandler, IDeselectHandler
{

    public GameObject startGameButton;

    // Start is called before the first frame update
    private void Start()
    {
		if (startGameButton != null)
		{
            EventSystem.current.SetSelectedGameObject(startGameButton);
        }
    }


    public void OnSelect(BaseEventData eventData)
    {
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;
        currentButton.transform.localScale = new Vector3(currentButton.transform.localScale.x * 1.1f, currentButton.transform.localScale.y * 1.1f);

    }

    public void OnDeselect(BaseEventData eventData)
	{
        GameObject currentButton = EventSystem.current.currentSelectedGameObject;
        currentButton.transform.localScale = new Vector3(currentButton.transform.localScale.x / 1.1f, currentButton.transform.localScale.y / 1.1f);
    }

}
