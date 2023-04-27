/*
 * (Jacob Welch)
 * (PlacableCharacter)
 * (Composite Pattern)
 * (Description: A default class for all placable characters)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlacableCharacter : MonoBehaviour
{
    #region Functions
    /// <summary>
    /// Spawns the character
    /// </summary>
    public abstract void Spawn();

    /// <summary>
    /// The routine for when this character is active.
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator CharacterRoutine()
    {
        throw new System.NotSupportedException("CharacterRoutine() is not supported for " + GetType().Name);
    }

    /// <summary>
    /// Gets a child charcter at a given index.
    /// </summary>
    /// <param name="i">The index of the character.</param>
    /// <returns></returns>
    public virtual PlacableCharacter GetChildCharacter(int i)
    {
        throw new System.NotSupportedException("GetChildCharacter() is not supported for " + GetType().Name);
    }

    /// <summary>
    /// Adds a character to the composite.
    /// </summary>
    /// <param name="character">The character to be added.</param>
    public virtual void AddCharacter(PlacableCharacter character)
    {
        throw new System.NotSupportedException("AddCharacter() is not supported for " + GetType().Name);
    }

    /// <summary>
    /// Removes a charactger from a composite
    /// </summary>
    /// <param name="character">The character to be removed.</param>
    public virtual void RemoveCharacter(PlacableCharacter character)
    {
        throw new System.NotSupportedException("RemoveCharacter() is not supported for " + GetType().Name);
    }
    #endregion
}
