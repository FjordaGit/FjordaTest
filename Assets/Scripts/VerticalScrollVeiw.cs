using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class VerticalScrollVeiw : MonoBehaviour
{
    [System.Serializable]
    public class Data
    {
        public int id;
        public string title;
        public string thumbnailUrl;
    }

    [System.Serializable]
    public class DataList
    {
        public Data[] data;
    }

    public Transform scrollViewPos;
    public GameObject ScrollLine1;
    public GameObject ScrollLine2;
    public string textUrl;

    public DataList mDataList = new DataList();

    void Start()
    {
        StartCoroutine(GetText());
    }

    private IEnumerator GetText()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(textUrl))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.Log("Successfully download text");

                var text = request.downloadHandler.text;
                text = "{\"data\":" + text + "}";
                mDataList = JsonUtility.FromJson<DataList>(text);

                if (mDataList != null)
                {
                    yield return StartCoroutine(SetListView()); ;
                }

            }

        }
    }

    private IEnumerator SetListView()
    {
        Vector3 position = new Vector3(0, 0, 0);
        int i = 0;
        foreach (Data data in mDataList.data)
        {
            if (i >= 20) break;

            GameObject obj;
            if (i % 2 == 0)
            {
                obj = Instantiate(ScrollLine1);
            }
            else
            {
                obj = Instantiate(ScrollLine2);
            }
            obj.GetComponent<GetDataApi>().thumbnailUrl = data.thumbnailUrl;
            obj.GetComponentInChildren<Text>().text = data.title;

            obj.transform.SetParent(scrollViewPos);
            obj.transform.localPosition = position;
            position.y = obj.transform.localPosition.y;
            i++;

        }
        yield return null;
    }
}
