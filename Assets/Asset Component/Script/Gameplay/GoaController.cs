using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoaController : MonoBehaviour
{
    [Header("Goa Component")]
    [SerializeField] private Vector2 goaOpenPosition;
    [SerializeField] private Vector2 goaClosePosition;

    #region RWU Callbacks

    public void CloseGoa()
    {
        transform.position = new Vector2(13.18f, 4.9255f);
    }
    
    public void OpenGoa()
    {
        transform.position = new Vector2(13.18f, 8.77f); 
    }

    #endregion
    
}
