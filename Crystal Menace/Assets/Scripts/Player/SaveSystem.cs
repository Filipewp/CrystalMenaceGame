using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath,"player.data");
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);
       

        formatter.Serialize(stream, data);
        
        stream.Close();
    }

    public static void SaveSpawn(Spawner spawner)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "spawner.data");
        FileStream stream = new FileStream(path, FileMode.Create);

        SpawnerData data = new SpawnerData(spawner);


        formatter.Serialize(stream, data);

        stream.Close();
    }


    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + @"\player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static SpawnerData LoadSpawn()
    {
        string path = Application.persistentDataPath + @"\spawner.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SpawnerData data = formatter.Deserialize(stream) as SpawnerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

}
