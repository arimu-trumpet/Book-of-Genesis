using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class StartFungus : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(nameof(waiter));
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        
        Flowchart.BroadcastFungusMessage("fire");//ボタンが消えたと同時にファンガスのウィンドウを出す
    }
}
