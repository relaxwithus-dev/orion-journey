using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LavaController : MonoBehaviour
{
    [Header("Lava Component")]
    [SerializeField] private Transform endPosition;
    [SerializeField] private Transform lavaPos;
    [SerializeField] private float lavaSpeed;

    #region MonoBehaviour Callbacks

    private void Start()
    {
        InitializedLavaPosition();
    }

    private void FixedUpdate()
    {
        LavaMove();
    }

    #endregion

    #region RWU Callbacks

    private void InitializedLavaPosition()
    {
        if (lavaPos.position.y >= endPosition.position.y)
        {
            transform.position = new Vector2(transform.position.x, endPosition.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, lavaPos.position.y);
        }
        
        this.enabled = false;
    }

    private void LavaMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            new Vector2(transform.position.x, endPosition.position.y),
            lavaSpeed * Time.fixedDeltaTime);
    }
    
    public void CutScene() => transform.position = new Vector2(transform.position.x, endPosition.position.y - 1f);

    #endregion

}
