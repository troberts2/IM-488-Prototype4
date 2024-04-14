using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerClickFunctionality : MonoBehaviour
{
    [Header("ClickRaycast")]
    [SerializeField] private float _clickRange;
    [SerializeField] private GameObject _clickFrom;
    [SerializeField] private LayerMask _clickableMask;

    private PlayerInputActions PIA;

    // Start is called before the first frame update
    void Start()
    {
        EnablePlayerInput();
    }

    private void OnDestroy()
    {
        DisablePlayerInput();
    }

    private void PlayerClick(InputAction.CallbackContext context)
    {
        RayCastClick();
    }

    private void RayCastClick()
    {
        RaycastHit rayHit;

        if (Physics.Raycast(_clickFrom.transform.position, _clickFrom.transform.forward,
            out rayHit, _clickRange, _clickableMask))
        {
            IClickable _clickableObj;
            _clickableObj = rayHit.collider.gameObject.GetComponentInChildren<IClickable>();
            if(_clickableObj == null)
                _clickableObj = rayHit.collider.gameObject.GetComponentInParent<IClickable>();
            if (_clickableObj != null)
                _clickableObj.OnPlayerClick();
        }

    }

    #region Input Setup
    private void EnablePlayerInput()
    {
        PIA = new PlayerInputActions();
        PIA.MainGameplay.Enable();

        PIA.MainGameplay.Click.started += PlayerClick;
    }

    private void DisablePlayerInput()
    {
        PIA.MainGameplay.Click.started -= PlayerClick;

        PIA.MainGameplay.Disable();
    }
    #endregion
}
