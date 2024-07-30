// HierarchyでFlowchartオブジェクトを選択し、Inputコンポーネントを追加
// FlowchartのVariablesタブで、新しいString変数 playerName を作成
// Inputコンポーネントの設定
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class LightInputHandler : MonoBehaviour
{
    [SerializeField]
     InputField lightInputField;                         // InputFieldコンポーネントを参照
    [SerializeField]
     Flowchart lightFlowchart;                           // Flowchartコンポーネントを参照

    private string enteredMessage = "LightEntered";      //名前が入力されてた時
    private string emptyMessage = "LightEmpty";          //名前が入力されてないとき
    void Start()
    {
        // InputFieldのOn End Editイベントにリスナーを追加
        lightInputField.onEndEdit.AddListener(OnLightInputEnd);
    }
    void OnLightInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            lightFlowchart.SendFungusMessage(emptyMessage);
            //もし名前が空だったらセットしても意味ないからelse内で処理
            lightFlowchart.SetBooleanVariable("isEmptyName", true);
        }
        else
        {
            lightFlowchart.SetStringVariable("Light", inputName);
            lightFlowchart.SendFungusMessage(enteredMessage);
            lightFlowchart.SetBooleanVariable("isEnteredName", true);
            // Fungusの変数 playerName にユーザー入力を設定
            
        }
        // Fungusの変数をいじりたいときは flowchart.SethogehogeVariable("unity上で設定した変数名", 引数)で実装する
    }
}