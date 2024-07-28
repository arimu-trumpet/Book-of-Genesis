// HierarchyでFlowchartオブジェクトを選択し、Inputコンポーネントを追加
// FlowchartのVariablesタブで、新しいString変数 playerName を作成
// Inputコンポーネントの設定
using UnityEngine;
using UnityEngine.UI;
using Fungus;
public class NameInputHandler : MonoBehaviour
{
    public InputField nameInputField;         // InputFieldコンポーネントを参照
    public Flowchart flowchart;               // Flowchartコンポーネントを参照
    public string enteredMessage = "Entered"; //名前が入力されてた時
    public string emptyMessage = "Empty";     //名前が入力されてないとき
    void Start()
    {
        // InputFieldのOn End Editイベントにリスナーを追加
        nameInputField.onEndEdit.AddListener(OnNameInputEnd);
    }
    void OnNameInputEnd(string inputName)
    {
        if (string.IsNullOrEmpty(inputName))
        {
            flowchart.SendFungusMessage(emptyMessage);
            //もし名前が空だったらセットしても意味ないからelse内で処理
            flowchart.SetBooleanVariable("isEmptyName", true);
        }
        else
        {
            flowchart.SetStringVariable("nameInput", inputName);
            flowchart.SendFungusMessage(enteredMessage);
            flowchart.SetBooleanVariable("isEnteredName", true);
            // Fungusの変数 playerName にユーザー入力を設定
            
        }
        // Fungusの変数をいじりたいときは flowchart.SethogehogeVariable("unity上で設定した変数名", 引数)で実装する
    }
}