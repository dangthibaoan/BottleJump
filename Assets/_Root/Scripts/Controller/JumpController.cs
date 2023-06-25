using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class JumpController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
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
    public void OnPointerDown(PointerEventData eventData)
    {

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        bottle.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 300));
    }
    public void Jump()
    {
        PopupController.Instance.MoveCamera(bottle.transform.position, cameraPositionDefine);
    }
}
