using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public TMP_Text popupText;
    public TMP_Text interactionText;
    public GameObject popupImage; // Reference to the image GameObject

    // Transition UI Elements
    public GameObject transitionCanvas;
    public TMP_Text transitionText;
    public Button transitionButton;

    private GameObject currentElement;
    private GameObject currentChangeElement;
    private bool isPopupVisible; // Added this line to track popup visibility

    // Dictionary to store unique transition texts
    private Dictionary<string, string> transitionTexts;

    private void Start()
    {
        ShowRoom(1);
        popupText.gameObject.SetActive(false);
        popupImage.SetActive(false); // Hide the image when start
        interactionText.gameObject.SetActive(false);
        transitionCanvas.SetActive(false); // Hide the transition canvas wen start

        // Add listener to transition button
        transitionButton.onClick.AddListener(ContinueToNextRoom);

        // Initialize the transition texts dictionary
        transitionTexts = new Dictionary<string, string>
        {
            { "change1", "You are about to enter the second room, where secrets of the past are unveiled. The parents, Jack and Jill, used to spend most of their free time here. Teaching their 8 year old daughter how to play the piano." },
            { "change2", "Get ready to enter the third room, this was the kitchen. When Jill was here, this room always smelt of freshly baked cookies." },
            { "change3", "Congratulations! You have found the secret scroll(A note from Jack and Jill)! Although we loved this home dearly, we have discovered a more beautiful land. A valley in the mountain with a creek and a small cabin.We got a noise complaint about the piano so we decided to leave. Letting the house get ugly and rundown would lower the value of the rest of the homes. Thats what they get for complaining." }
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentElement != null)
            {
                CheckElementClick();
            }
            if (currentChangeElement != null)
            {
                ShowTransitionPage(currentChangeElement.name);
            }
        }

        if (isPopupVisible && Input.GetMouseButtonDown(0)) // Added this check
        {
            HidePopup(); // Call HidePopup on mouse click
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (IsPopupElement(other.gameObject))
        {
            currentElement = other.gameObject;
            interactionText.text = "Press E to interact";
            interactionText.gameObject.SetActive(true);
        }
        else if (IsChangeRoomElement(other.gameObject))
        {
            currentChangeElement = other.gameObject;
            interactionText.text = "Press E to change room";
            interactionText.gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == currentElement)
        {
            currentElement = null;
            interactionText.gameObject.SetActive(false);
        }
        else if (other.gameObject == currentChangeElement)
        {
            currentChangeElement = null;
            interactionText.gameObject.SetActive(false);
        }
    }

    private bool IsPopupElement(GameObject element)
    {
        return element.name.StartsWith("Element");
    }

    private bool IsChangeRoomElement(GameObject element)
    {
        return element.name.StartsWith("change");
    }

    private void CheckElementClick()
    {
        string elementName = currentElement.name;
        string message = "";

        switch (elementName)
        {
            // Room 1 Elements
            case "Element1":
                message = "You have found the first hint: go to a place where many bets are made and friends become foe.";
                break;
            case "Element1.2":
                message = "You are closer to the next room, find the password to the computer, in a place where things are kept safe.";
                break;
            case "Element1.3":
                message = "Take a rest on the couch, then continue to the next room. Use the portal to the metaverse to travel.";
                break;

            // Room 2 Elements
            case "Element2":
                message = "Congratulations, you have made it to the second level of the abandoned mansion, here you will explore the tunes of the dead. Find the next hint.";
                break;
            case "Element2.2":
                message = "An old piano stands here, its keys dusty and silent. Find a tape of a past recording.";
                break;
            case "Element2.3":
                message = "A torn piece of sheet music lies on the floor. ";
                break;

            // Room 3 Elements
            case "Element3":
                message = "Here, used to lay a plate of fresh cookies every day. Jill was an expert, go take a look at the pantry to see the ingredients, and maybe a new hint.";
                break;
            case "Element3.2":
                message = "Jill took all the ingredients before disapearing, connect the dots? Yes, this was all planned. The next hint lies in the only ingredient left, not used in cookies, but green.";
                break;
            case "Element3.3":
                message = "The note is hidden where things should be taken to be dissapeared forever..";
                break;
        }

        ShowPopup(message);
    }

    private void ShowPopup(string message)
    {
        popupText.text = message;
        popupText.gameObject.SetActive(true);
        popupImage.SetActive(true); // Show the image
        isPopupVisible = true; // Set flag to true
    }

    private void HidePopup()
    {
        popupText.gameObject.SetActive(false);
        popupImage.SetActive(false); // Hide the image
        isPopupVisible = false; // Reset flag
    }

    private void ShowTransitionPage(string elementName)
    {
        if (transitionTexts.TryGetValue(elementName, out string transitionMessage))
        {
            transitionText.text = transitionMessage;
            transitionCanvas.SetActive(true); // Show the transition canvas
        }
    }

    private void ContinueToNextRoom()
    {
        transitionCanvas.SetActive(false); // Hide the transition canvas
        ChangeRoom();
    }

    private void ChangeRoom()
    {
        string elementName = currentChangeElement.name;
        if (elementName == "change1")
        {
            ShowRoom(2);
        }
        else if (elementName == "change2")
        {
            ShowRoom(3);
        }
        else if (elementName == "change3")
        {
            ShowRoom(1);
        }
    }

    private void ShowRoom(int roomNumber)
    {
        room1.SetActive(roomNumber == 1);
        room2.SetActive(roomNumber == 2);
        room3.SetActive(roomNumber == 3);
    }
}
