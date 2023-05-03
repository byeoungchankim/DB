using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEngine.UI;

public class Database : MonoBehaviour
{
    [SerializeField]
    GameObject textPrefab = null;
    [SerializeField]
    GameObject Content = null;
    public class DataScore
    {
        public string id { get; set; }
        public int score { get; set; }
    }


    private void Start()
    {
        /*
        ArrayList arrayList = new ArrayList();
        // Boxing, Unboxing
        arrayList.Add(1);
        arrayList.Add("asdf");

        // Template
        List<int> list = new List<int>();
        list.Add(1);
        int val = list[0];

        Dictionary<string, int> dict =
            new Dictionary<string, int>();
        dict.Add("kch", 1234);
        int score = dict["kch"];
        */

        //StartCoroutine(AddScoreCoroutine("qweasd", 400)); //디비에 넣기
        
        //StartCoroutine(GetScoreCoroutine()); //디비에서 가져오기
    }

    public void get()
    {
        
    }

   private IEnumerator AddScoreCoroutine(
        string _id, int _score)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", _id);
        form.AddField("score", _score);

        using (UnityWebRequest www =
            UnityWebRequest.Post("" +
            "http://localhost/addscore.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result ==
                UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(
                    "AddScore Success : " +
                    _id + "(" + _score + ")");
            }
        }
    }

    private IEnumerator GetScoreCoroutine() {
        using (UnityWebRequest www =
            UnityWebRequest.Post("http://localhost/getscore.php","")) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError) {
                Debug.Log(www.error);
            } else {
                Debug.Log("핸들러 "+www.downloadHandler.text); 
                string data  = www.downloadHandler.text; //텍스트로 받아온다

                List<DataScore> dataScores =
                   JsonConvert.DeserializeObject<List<DataScore>>(data); //역직열화 숫자는 인트 같은작업을 해준다 제이슨사용이유
                //목록으로 만들어줌

                foreach (DataScore dataScore in dataScores) {
                    Debug.Log(dataScore.id + " : " + dataScore.score);

                    GameObject text = GameObject.Instantiate(textPrefab,Content.transform);
                    Text text1 = text.GetComponent<Text>();
                    text1.text = string.Format("아이디 : [ {0,10} ] \t점수 : [ {1,10} ]",dataScore.id,dataScore.score);
                    //text.transform.parent = Content.transform;

                }
            }
        }
    }

    public void add(string _id, int _pw)
    {

        StartCoroutine(AddScoreCoroutine(_id, _pw));
    }
    public void Info()
    {
        StartCoroutine(GetScoreCoroutine());
    }
}