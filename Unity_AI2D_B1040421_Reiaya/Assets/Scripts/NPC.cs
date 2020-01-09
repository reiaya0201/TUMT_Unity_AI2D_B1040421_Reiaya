using UnityEngine;
using UnityEngine.UI; //引用
using System.Collections;

public class NPC : MonoBehaviour
{
    #region 欄位
    //列舉
    public enum NPCstate
    {
        //一般、尚未完成、完成
        normal, notcomplete, complete
    }
    //使用列舉
    public NPCstate _state;

    [Header("對話")]
    public string sayStart = "這張地圖沒什麼東西，你就到處去玩最後跳下去就過關了。";
    public string sayNotComplete = "可以幫我拿個奇異果嗎？";
    public string sayComplete = "感洩里(嚼嚼)";
    [Header("對話速度")]
    public float speed = 1.5f;
    [Header("任務相關")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;
    #endregion

    //觸發2D事件
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果碰到"主角"物件
        if(collision.name == "藍人")
        {
            Say();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "藍人")
        {
            SayClose();
        }
    }

    /// <summary>
    /// 對話
    /// </summary>
    private void Say()
    {
        //顯示畫布
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = NPCstate.complete;

        //用切換表示不同對話
        switch (_state)
        {
            case NPCstate.normal:
                StartCoroutine(ShowDialog(sayStart));
                _state = NPCstate.notcomplete;
                break;
            case NPCstate.notcomplete:
                StartCoroutine(ShowDialog(sayNotComplete));
                break;
            case NPCstate.complete:
                StartCoroutine(ShowDialog(sayComplete));
                break;
        }
    }

    private IEnumerator ShowDialog(string say)
    {
        //清空文字
        textSay.text = "";

        //跑迴圈
        for (int i = 0; i < say.Length; i++)
        {
            //累加文字
            textSay.text += say[i];
            //等待
            yield return new WaitForSeconds(speed);
        }
    }

    /// <summary>
    /// 對話結束
    /// </summary>
    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    /// <summary>
    /// 道具取得
    /// </summary>
    public void PlayerGet()
    {
        countPlayer++;
    }
}
