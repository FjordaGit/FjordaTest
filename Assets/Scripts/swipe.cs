using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class swipe : MonoBehaviour
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
    public GameObject ZoomableList;
    public string textUrl;
    [SerializeField] private float ZoomCoefficiennt = 1;
    [SerializeField] private float FurthestLeftPoint;
    private float HalfOfWidthOfTheScreen;

    public DataList mDataList = new DataList();


    float scroll_pos = 0;
    float[] pos;

    void Start()
    {
        HalfOfWidthOfTheScreen = Screen.width / 2;
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

    private Vector3 DivideOrReturn(Vector3 dividend, float divisor, float N, float M)
    {
        if(divisor >= N)
        {
            return dividend / divisor;
        }
        else
        {
            return Vector3.one * M;
        }
    }

    private float CastAbscissaOfContent(float currentAbscissa)
    {
        currentAbscissa *= -1;
        currentAbscissa += FurthestLeftPoint;
        return currentAbscissa;
    }

    private Vector3 GetScale(float abscissaContentt, float abscissaOfUI, Vector3 currentScale)
    {
        return DivideOrReturn(currentScale, System.Math.Abs(abscissaContentt - abscissaOfUI), ZoomCoefficiennt, 1 / ZoomCoefficiennt) * ZoomCoefficiennt;
    }

    private IEnumerator SetListView()
    {
        Vector3 position = new Vector3(0, 0, 0);
        int i = 0;

        void InstantiateEmptyBlock()
        {
            GameObject obj1;
            obj1 = Instantiate(ZoomableList);
            GetDataApi ComponentGetDataApi = obj1.GetComponent<GetDataApi>();
            ComponentGetDataApi.thumbnailUrl = "";
            obj1.GetComponentInChildren<Text>().text = "";
            obj1.transform.SetParent(scrollViewPos);
            position.x = obj1.transform.localPosition.x;
            obj1.transform.GetChild(0).gameObject.SetActive(false);
            obj1.transform.localScale = Vector3.zero;
        }

        InstantiateEmptyBlock();

        foreach (Data data in mDataList.data)
        {
            if (i >= 20) break;

            GameObject obj;

            obj = Instantiate(ZoomableList);

            obj.GetComponent<GetDataApi>().thumbnailUrl = data.thumbnailUrl;
            obj.GetComponentInChildren<Text>().text = data.title;

            obj.transform.SetParent(scrollViewPos);
            position.x = obj.transform.localPosition.x;
            Debug.Log(position.x);


            i++;
        }
        InstantiateEmptyBlock();

        yield return null;
    }

    private void Update()
    {
        foreach (Transform child in transform)
        {
            GameObject obj = child.gameObject;
            Vector3 CurrentScale = obj.transform.localScale;
            float AbscissaWithNewFormat = CastAbscissaOfContent(transform.localPosition.x) + HalfOfWidthOfTheScreen;
            obj.transform.localScale = GetScale(AbscissaWithNewFormat, obj.transform.localPosition.x, Vector3.one);
        }

    }
 
    
}