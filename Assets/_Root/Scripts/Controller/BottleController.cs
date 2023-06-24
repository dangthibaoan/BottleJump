using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class BottleController : MonoBehaviour
{
    private bool isEnd;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject TrashCan;
    [SerializeField] Level CurrentLevel;

    private void Awake()
    {
        isEnd = false;
        rigid.bodyType = RigidbodyType2D.Dynamic;
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isEnd == false && (gameObject.transform.position.y < TrashCan.transform.position.y - 30 || gameObject.transform.position.x > TrashCan.transform.position.x + 10))
        {
            isEnd = true;
            rigid.bodyType = RigidbodyType2D.Static;
            CurrentLevel.endLevel(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("chai da va cham voi " + other.gameObject.name);
        if (other.gameObject.tag == "GetPoint")
        {
            other.gameObject.SetActive(false);
            CurrentLevel.GetScore(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("chai da va cham voi " + other.gameObject.name);

        if (other.gameObject.tag == "Finish")
        {
            isEnd = true;
            CurrentLevel.endLevel(false);
        }
        if (other.gameObject.name == TrashCan.name)
        {
            isEnd = true;
            rigid.bodyType = RigidbodyType2D.Static;
            CurrentLevel.endLevel(true);
        }
    }
}
