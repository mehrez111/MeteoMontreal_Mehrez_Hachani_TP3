using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class MeteoManager : MonoBehaviour
{
    public TextMeshProUGUI MeteoAPI;
    string url = "https://api.open-meteo.com/v1/forecast?latitude=45.5088&longitude=-73.5540&current_weather=true";

    void Start()
    {
        StartCoroutine(GetWeatherData());
    }

    IEnumerator GetWeatherData()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error: " + request.error);
        }
        else
        {
            string json = request.downloadHandler.text;
            WeatherData weather = JsonUtility.FromJson<WeatherData>(json);
            Debug.Log("Température à Montréal: " + weather.current_weather.temperature);
            // Affichez la donnée dans l'UI ici
        }
    }
}

[System.Serializable]
public class WeatherData
{
    public CurrentWeather current_weather;
}

[System.Serializable]
public class CurrentWeather
{
    public float temperature;
}


