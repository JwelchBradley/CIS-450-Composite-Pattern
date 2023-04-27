/*
 * (Jacob Welch)
 * (CharacterPlacer)
 * (Composite Pattern)
 * (Description: Functionality for aiming and placing characters.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlacer : MonoBehaviour
{
    #region Fields
    // string of the different placeable groups
    private const string smallGroup = "Small Group";
    private const string mediumGroup = "Medium Group";
    private const string largeGroup = "Large Group";

    [Tooltip("The prefabs for placable characters")]
    [SerializeField] private GameObject[] placableCharacters;

    // References to the current group being placed
    private string currentCharacterTag = "Small Group";
    private PlacableCharacter currentCharacterBeingPlaced;

    /// <summary>
    /// The main camera of the scene.
    /// </summary>
    private Camera mainCamera;
    #endregion

    #region Functions
    /// <summary>
    /// Handles initilization of components and other fields before anything else.
    /// </summary>
    private void Awake()
    {
        mainCamera = Camera.main;

        ChangePlacableCharacter(currentCharacterTag, true);
    }

    /// <summary>
    /// Calls for an event to take place once per frame.
    /// </summary>
    private void Update()
    {
        TakePlayerInput();
    }

    /// <summary>
    /// Takes user input for changing characters, aiming them, and placing them.
    /// </summary>
    private void TakePlayerInput()
    {
        ChangeCharacterInput();

        AimCharacter();

        PlaceCharacterInput();
    }

    #region Change Character
    /// <summary>
    /// Checks if the user wants to change which character they are placing.
    /// </summary>
    private void ChangeCharacterInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangePlacableCharacter(smallGroup);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangePlacableCharacter(mediumGroup);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangePlacableCharacter(largeGroup);
        }
    }

    /// <summary>
    /// Changes the current character that is being aim and that can be placed.
    /// </summary>
    /// <param name="newCharacter">The new character to be placed.</param>
    /// <param name="shouldOverride">Spawns a character to be placed even if it is the same as the current one.</param>
    private void ChangePlacableCharacter(string newCharacter, bool shouldOverride = false)
    {
        if (!shouldOverride && newCharacter == currentCharacterTag) return;

        GameObject newGroup;

        switch (newCharacter)
        {
            case smallGroup:
            default:
                newGroup = placableCharacters[0];
                break;
            case mediumGroup:
                newGroup = placableCharacters[1];
                break;
            case largeGroup:
                newGroup = placableCharacters[2];
                break;
        }

        if(newGroup != null)
        {
            if (currentCharacterBeingPlaced != null) DestroyImmediate(currentCharacterBeingPlaced.gameObject);

            var spawnObject = Instantiate(newGroup, GetAimPosition(), Quaternion.identity);
            currentCharacterBeingPlaced = spawnObject.GetComponent<PlacableCharacter>();
            currentCharacterTag = newCharacter;
        }
    }
    #endregion

    #region Place Character
    /// <summary>
    /// Checks if the user wants to place something.
    /// </summary>
    private void PlaceCharacterInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlaceCharacter();
        }
    }

    /// <summary>
    /// Places the currently selected character.
    /// </summary>
    private void PlaceCharacter()
    {
        currentCharacterBeingPlaced.Spawn();
        currentCharacterBeingPlaced = null;

        ChangePlacableCharacter(currentCharacterTag, true);
    }
    #endregion

    /// <summary>
    /// Aims the current character that is selected.
    /// </summary>
    private void AimCharacter()
    {
        currentCharacterBeingPlaced.transform.position = GetAimPosition();
    }

    /// <summary>
    /// Gets the position that the user is currently aiming at.
    /// </summary>
    /// <returns></returns>
    private Vector2 GetAimPosition()
    {
        return (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    #endregion
}
