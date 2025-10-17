using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteConfigLoader : MonoBehaviour
{
    [SerializeField] private string url;
    [SerializeField] private float timeout = 15f;
    [SerializeField] private bool isConnected;

    private void Awake()
    {
        StartCoroutine(LoadConfig());
    }

    private IEnumerator LoadConfig()
    {
        using(UnityWebRequest www = new UnityWebRequest(url))
        {
            DownloadHandlerBuffer dH = new DownloadHandlerBuffer();
            www.timeout = (int)timeout;
            www.downloadHandler = dH;
            yield return www.SendWebRequest();
            if(www.result != UnityWebRequest.Result.Success || !isConnected)
            {
                Debug.Log("not success");
                if (File.ReadAllText(Path.Combine(Application.persistentDataPath, "savegame.json")) == null) Debug.Log("no saved copy");
                else
                {
                    WeaponConfigContainer savedContainer = JsonConvert.DeserializeObject<WeaponConfigContainer>(File.ReadAllText(Path.Combine(Application.persistentDataPath, "savegame.json")));
                    //Debug.Log(JsonConvert.DeserializeObject(File.ReadAllText(Path.Combine(Application.persistentDataPath, "savegame.json"))));
                    ApplyConfig(savedContainer);
                }
                yield break;
            }
            string csv = www.downloadHandler.text;
            Debug.Log(csv);
            List<WeaponConfig> csvConfigs = new();
            string[] lines = csv.Split('\n');
            for(int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                string id = values[0];
                int damage = int.Parse(values[1]);
                float cooldown = float.Parse(values[2], System.Globalization.NumberStyles.Float);
                csvConfigs.Add(new(id, damage, cooldown));
            }
            WeaponConfigContainer container = new(csvConfigs);
            string json = JsonConvert.SerializeObject(container);
            string filePath = Path.Combine(Application.persistentDataPath, "savegame.json");
            File.WriteAllText(filePath, json);
            ApplyConfig(container);
        }
    }

    private void ApplyConfig(WeaponConfigContainer container)
    {
        foreach(var config in container.WeaponConfigs)
        {
            Weapon newWeapon = new(config);
            newWeapon.DebugWeapon();
        }
    }
}
