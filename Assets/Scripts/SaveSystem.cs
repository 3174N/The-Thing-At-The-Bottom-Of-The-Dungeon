using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveShop (GameManager manager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/manager.pdd";
        FileStream stream = new FileStream(path, FileMode.Create);

        ShopData data = new ShopData(manager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static ShopData LoadShop()
    {
        string path = Application.persistentDataPath + "/manager.pdd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ShopData data = formatter.Deserialize(stream) as ShopData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
