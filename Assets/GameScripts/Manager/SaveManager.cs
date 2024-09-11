using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void Save()
    {
        // create file
        FileStream file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.OpenOrCreate);

        try
        {
            // Binary formatter
            BinaryFormatter formatter = new BinaryFormatter();
            // serialization method to write to the file
            // down here i need to find what file i want to save
            formatter.Serialize(file, file);          // (file, here i put the data i want to save rather it being file)
        }
        catch (SerializationException ex) 
        {
            Debug.LogError("There was an issue serializing this data: " + ex.Message);
        }
        finally
        {
            file.Close();
        }
    }

    public void Load(int level)
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/Player.dat", FileMode.Open);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //script you want to save, Script Name in here
            //player =               (PlayerControl) formatter.Deserialize(file);
        }
        catch (SerializationException ex)
        {
            Debug.LogError("There was an issue DE serializing this data: " + ex.Message);
        }
        finally
        {
            file.Close();
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}
