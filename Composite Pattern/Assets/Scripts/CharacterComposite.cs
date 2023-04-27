/*
 * (Jacob Welch)
 * (CharacterComposite)
 * (Composite Pattern)
 * (Description: Handles funcitonality for a character composite.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComposite : PlacableCharacter
{
    #region Fields
    /// <summary>
    /// All of the character leafs associated with this composite.
    /// </summary>
    private List<PlacableCharacter> characterLeafs = new List<PlacableCharacter>();
    #endregion

    #region Functions
    /// <summary>
    /// Gets all of the direct children of this character composite.
    /// </summary>
    private void Awake()
    {
        foreach (Transform childObject in gameObject.transform)
        {
            AddCharacter(childObject.gameObject.GetComponent<PlacableCharacter>());
        }
    }

    /// <summary>
    /// Spawns all of the child characters of this object.
    /// </summary>
    public override void Spawn()
    {
        SpawnAllCharacters(characterLeafs);
    }

    /// <summary>
    /// Loops through and spawn every object that is a child of this object.
    /// </summary>
    /// <param name="characterLeafs">All of the character objects.</param>
    private void SpawnAllCharacters(IEnumerable<PlacableCharacter> characterLeafs)
    {
        IEnumerator<PlacableCharacter> enumerator = characterLeafs.GetEnumerator();

        while (enumerator.MoveNext())
        {
            PlacableCharacter component = enumerator.Current;

            // Spawns the object
            component.Spawn();
            component.transform.parent = null;
        }

        Destroy(gameObject);
    }

    /// <summary>
    /// Gets a child charcter at a given index.
    /// </summary>
    /// <param name="i">The index of the character.</param>
    /// <returns></returns>
    public override PlacableCharacter GetChildCharacter(int i)
    {
        if(i >= characterLeafs.Count)
        {
            print("Character Index is Invalid");

            return null;
        }

        return characterLeafs[i];
    }

    /// <summary>
    /// Adds a character to the composite.
    /// </summary>
    /// <param name="character">The character to be added.</param>
    public override void AddCharacter(PlacableCharacter character)
    {
        characterLeafs.Add(character);
    }

    /// <summary>
    /// Removes a character from a composite.
    /// </summary>
    /// <param name="character">The character to be removed.</param>
    public override void RemoveCharacter(PlacableCharacter character)
    {
        characterLeafs.Remove(character);
    }
    #endregion
}
