using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class StartTimeCountUI : MonoBehaviour
{
    private StartTimeCountUI startTimeCountUI;
    /// <summary>
    /// イメージを表示させる場所
    /// </summary>
    [SerializeField] private Image displayImage;
    /// <summary>
    /// ゲーム開始時のイメージ配列
    /// </summary>
    [SerializeField] private Sprite[] GameStartImg;
    /// <summary>
    /// 表示間隔
    /// </summary>
    [SerializeField] private float interval = 1f;


    private void Start()
    {
        startTimeCountUI = GetComponent<StartTimeCountUI>();
        StartCoroutine(CountDownImage());
    }

    private IEnumerator CountDownImage()
    {
       for(int i = 0; i < GameStartImg.Length; i++)
       {
            displayImage.sprite = GameStartImg[i];
            displayImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(interval);
       }

       displayImage.gameObject.SetActive(false);
       
    }
}
