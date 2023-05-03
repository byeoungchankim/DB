using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class add_button : MonoBehaviour
{
    [SerializeField]
    private InputField id = null;
    [SerializeField]
    private InputField pw = null;
    [SerializeField]
    Database database = null;
    [SerializeField]
    Coroutine coroutine = null;



    public void push()
    {
        if (id.text == "" || pw.text == "")
        {
            this.gameObject.transform.parent.gameObject.transform.GetChild(5).gameObject.SetActive(true);
            this.gameObject.transform.parent.gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            return;

        }
        else if (false==pw.text.All(char.IsDigit))
        {
            this.gameObject.transform.parent.gameObject.transform.GetChild(5).gameObject.SetActive(true);
            this.gameObject.transform.parent.gameObject.transform.GetChild(5).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            return;
        }
        else
        {
            
            Debug.Log("확인용 : " + id.text + "확인용 : " + pw.text);
            //database.StartCoroutine(database.AddScoreCoroutine(id.text, int.Parse(pw.text)));
            database.add(id.text, int.Parse(pw.text));
            id.text = "";
            pw.text = "";
            
            this.gameObject.transform.parent.gameObject.transform.GetChild(5).gameObject.SetActive(true);
            this.gameObject.transform.parent.gameObject.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void quit()
    {
        this.gameObject.transform.parent.gameObject.SetActive(false);
        this.gameObject.transform.parent.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        this.gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.SetActive(false);

    }
    public void input()
    {

    }
    public int input_id(int _pw)
    {
        return _pw;
    }

}
