using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSelectionManager : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button confirmButton;
    private string playerName;
    private int selectedCharacterIndex = -1; // Initialize with an invalid index

    private void Start()
    {
        confirmButton.interactable = false; // Disable confirm button until a name is entered and a character is selected
    }

    public void SelectCharacter(int characterIndex)
    {
        selectedCharacterIndex = characterIndex;
        CheckIfReadyToConfirm();
    }

    public void OnNameInputChanged()
    {
        playerName = nameInputField.text;
        CheckIfReadyToConfirm();
    }

    private void CheckIfReadyToConfirm()
    {
        // Enable confirm button only if a name is entered and a character is selected
        confirmButton.interactable = !string.IsNullOrEmpty(playerName) && selectedCharacterIndex >= 0;
    }

    public void ConfirmSelection()
    {
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacterIndex);
        SceneManager.LoadScene("MianScene");
    }
}
