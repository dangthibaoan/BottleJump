using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BottleController : MonoBehaviour
{
    public Rigidbody2D rigid;
    public GameObject Land;
    public Level1 lv1;

    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("chai da va cham voi " + other.gameObject.name);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("chai da va cham voi " + other.gameObject.name);
        if (other.gameObject.name == Land.name)
        {
            lv1.endLevel();
        }
    }
}
