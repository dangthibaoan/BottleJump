using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class JumpController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] float jumpPower = 3;
    [SerializeField] int jumpCount = 1;
    [SerializeField] float duration = 1;
    [SerializeField] GameObject bottle;
    public Camera MCamera;
    [SerializeField] Vector3 cameraPositionDefine;
    private void Awake()
    {
        MCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void Update()
    {
        Jump();
    }
    private Vector3 GetPointerPosition()
    {
        Vector3 pointerPosition = Vector3.zero;
        // pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointerPosition.z = 0;
        pointerPosition.y = bottle.transform.position.y + 1;
        pointerPosition.x = bottle.transform.position.x + 2;
        return pointerPosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bottle.transform.DOJump(GetPointerPosition(), jumpPower, jumpCount, duration);
    }
    public void Jump()
    {
        PopupController.Instance.MoveCamera(bottle.transform.position, cameraPositionDefine);
    }
}
