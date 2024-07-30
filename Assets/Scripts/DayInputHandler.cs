// HierarchyでFlowchartオブジェクトを選択し、Inputコンポーネントを追加
// FlowchartのVariablesタブで、新しいString変数 playerName を作成
// Inputコンポーネントの設定
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class DayInputHandler : MonoBehaviour
{
    [SerializeField]
     InputField dayInputField;                       // InputFieldコンポーネントを参照
    [SerializeField]
     Flowchart dayFlowchart;                         // Flowchartコンポーネントを参照

    private string enteredMessage = "DayEntered";    //名前が入力されてた時
    private string emptyMessage = "DayEmpty";        //名前が入力されてないとき
    void Start()
    {
        // InputFieldのOn End Editイベントにリスナーを追加
        dayInputField.onEndEdit.AddListener(OnDayInputEnd);
    }
    void OnDayInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            dayFlowchart.SendFungusMessage(emptyMessage);
            //もし名前が空だったらセットしても意味ないからelse内で処理
            dayFlowchart.SetBooleanVariable("isEmptyName", true);
        }
        else
        {
            dayFlowchart.SetStringVariable("Day", inputName);
            dayFlowchart.SendFungusMessage(enteredMessage);
            dayFlowchart.SetBooleanVariable("isEnteredName", true);
            // Fungusの変数 playerName にユーザー入力を設定

        }
        // Fungusの変数をいじりたいときは flowchart.SethogehogeVariable("unity上で設定した変数名", 引数)で実装する
    }
}