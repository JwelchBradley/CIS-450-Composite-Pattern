/*
 * (Jacob Welch)
 * (CharacterLeaf)
 * (Composite Pattern)
 * (Description: Handles funcitonality for charaters that are a part of a composite.)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLeaf : PlacableCharacter
{
    #region Fields
    [Tooltip("The speed at which this character leaf moves")]
    [SerializeField] private float moveSpeed = 15;
    #endregion

    #region Functions
    /// <summary>
    /// Spawns this object by starting its character routine.
    /// </summary>
    public override void Spawn()
    {
        StartCoroutine(CharacterRoutine());
    }

    /// <summary>
    /// Moves the character upwards a its movespeed.
    /// </summary>
    /// <returns></returns>
    protected override IEnumerator CharacterRoutine()
    {
        while(transform.position.y < 15)
        {
            yield return new WaitForFixedUpdate();

            var position = transform.position;
            position.y += Time.fixedDeltaTime * moveSpeed;
            transform.position = position;
        }

        DestroyImmediate(gameObject);
    }
    #endregion
}
