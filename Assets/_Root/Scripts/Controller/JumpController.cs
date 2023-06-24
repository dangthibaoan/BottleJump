using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class JumpController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // [SerializeField] float jumpPower = 3;
    // [SerializeField] int jumpCount = 1;
    // [SerializeField] float duration = 1;
    [SerializeField] Vector3 cameraPositionDefine;
    [SerializeField] GameObject bottle;
    [SerializeField] GameObject MCamera;
    private void Awake()
    {
        MCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void Update()
    {
        Jump();
    }
    // private Vector3 GetPointerPosition()
    // {
    //     Vector3 pointerPosition = Vector3.zero;
    //     // pointerPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     pointerPosition.z = 0;
    //     pointerPosition.y = bottle.transform.position.y + 1;
    //     pointerPosition.x = bottle.transform.position.x + 2;
    //     return pointerPosition;
    // }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        bottle.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 300));
        //bottle.transform.DOJump(GetPointerPosition(), jumpPower, jumpCount, duration);
    }
    public void Jump()
    {
        PopupController.Instance.MoveCamera(bottle.transform.position, cameraPositionDefine);
    }
}
