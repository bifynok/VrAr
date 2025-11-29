using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    private const string ApiUrl = "http://localhost:3000/api/leaderboard";

    public GameObject leaderboardEntryUIPrefab, requestButton;
    public Transform contentParent;

    public void FetchDataButtonClick()
    {
        StartCoroutine(FetchLeaderboardData(ApiUrl));
    }

    IEnumerator FetchLeaderboardData(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string jsonText = webRequest.downloadHandler.text;
                DisplayLeaderboardInUI(jsonText); 
            }
        }
    }

    private void DisplayLeaderboardInUI(string jsonString)
{
    requestButton.SetActive(false);

    GameObject headerUIObject = Instantiate(leaderboardEntryUIPrefab, contentParent);
    
    TMP_Text headerPosText = headerUIObject.transform.Find("Position").GetComponent<TMP_Text>();
    TMP_Text headerNameText = headerUIObject.transform.Find("Name").GetComponent<TMP_Text>();
    TMP_Text headerScoreText = headerUIObject.transform.Find("Score").GetComponent<TMP_Text>();

    headerPosText.text = "Position";
    headerNameText.text = "Name";
    headerScoreText.text = "Score";

    string wrappedJson = "{\"entries\":" + jsonString + "}";
    LeaderboardDataWrapper dataWrapper = JsonUtility.FromJson<LeaderboardDataWrapper>(wrappedJson);
    
    foreach (var entry in dataWrapper.entries)
    {
        GameObject entryUIObject = Instantiate(leaderboardEntryUIPrefab, contentParent);
        
        TMP_Text posText = entryUIObject.transform.Find("Position").GetComponent<TMP_Text>();
        TMP_Text nameText = entryUIObject.transform.Find("Name").GetComponent<TMP_Text>();
        TMP_Text scoreText = entryUIObject.transform.Find("Score").GetComponent<TMP_Text>();

        if (posText != null) posText.text = entry.position.ToString();
        if (nameText != null) nameText.text = entry.name;
        if (scoreText != null) scoreText.text = entry.score.ToString();
    }
}

}
