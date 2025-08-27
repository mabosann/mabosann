using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class StartTimeCountUI : MonoBehaviour
{
    private StartTimeCountUI startTimeCountUI;
    /// <summary>
    /// �C���[�W��\��������ꏊ
    /// </summary>
    [SerializeField] private Image displayImage;
    /// <summary>
    /// �Q�[���J�n���̃C���[�W�z��
    /// </summary>
    [SerializeField] private Sprite[] GameStartImg;
    /// <summary>
    /// �\���Ԋu
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
