using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class GetDataApi : MonoBehaviour
{
    public string thumbnailUrl;
    public Image image;

    void Start()
    {
        
        image = GetComponentInChildren<Image>();


        StartCoroutine(GetTexture(thumbnailUrl));
    }

    IEnumerator GetTexture(string url)
    {

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("@@@");
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            image.color = Color.red;

            Sprite newSprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(.5f, .5f));
            image.sprite = newSprite;
        }
    }
}
