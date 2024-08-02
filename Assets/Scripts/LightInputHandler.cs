// HierarchyでFlowchartオブジェクトを選択し、Inputコンポーネントを追加
// FlowchartのVariablesタブで、新しいString変数 playerName を作成
// Inputコンポーネントの設定
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class LightInputHandler : MonoBehaviour
{
    [SerializeField]
     InputField inputField;                              // InputFieldコンポーネントを参照
    [SerializeField]
     Flowchart flowchart;                                // Flowchartコンポーネントを参照

    private string enteredMessage = "LightEntered";      //名前が入力されてた時
    private string emptyMessage = "Empty";               //名前が入力されてないとき
    void Start()
    {
        // InputFieldのOn End Editイベントにリスナーを追加
        inputField.onEndEdit.AddListener(OnLightInputEnd);
    }

    void OnLightInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            flowchart.SendFungusMessage(emptyMessage);
            //もし名前が空だったらセットしても意味ないからelse内で処理
        }
        else
        {
            flowchart.SetStringVariable("Light", inputName);
            flowchart.SendFungusMessage(enteredMessage);
            // Fungusの変数 playerName にユーザー入力を設定   
        }
        // Fungusの変数をいじりたいときは flowchart.SethogehogeVariable("unity上で設定した変数名", 引数)で実装する
    }
}