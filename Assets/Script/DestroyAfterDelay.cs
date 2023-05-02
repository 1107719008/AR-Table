using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay = 3f; // 延遲時間
    [SerializeField]public GameObject ObjectToSetActive;
    private void Start()
    {
        // 啟動協程
        StartCoroutine(DestroyAfterDelayCoroutine());
    }

    private IEnumerator DestroyAfterDelayCoroutine()
    {
        // 等待指定時間
        yield return new WaitForSeconds(delay);

        // 刪除物件
        Destroy(gameObject);

        ObjectToSetActive.SetActive(true);

    }
}
