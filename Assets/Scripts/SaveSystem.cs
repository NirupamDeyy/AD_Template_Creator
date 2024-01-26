using UnityEngine;
using System.IO;
public static class SaveSystem
{
    /// <summary>
    /// SaveSystem handles saving, loading, and deleting data to/from text files.
    /// This is reused from an old project so some function/s are present but may not require
    /// </summary>
    public static int loadNumber = 0;
    public static int largestNumber = 0;
    public static string ignoredFileNamePattern = "largest_number";

    private static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    // Initializes the save folder if it doesn't exist
    public static void Init()
    {
        if (!Directory.Exists(SAVE_FOLDER))
        {
            Directory.CreateDirectory(SAVE_FOLDER);
        }
    }

    // Starts the save process
    public static void StartSave()
    {
        string[] textFiles = Directory.GetFiles(SAVE_FOLDER, "*.txt");

        int lgnum = 0;
        foreach (string textFile in textFiles)
        {
            string fileName = Path.GetFileName(textFile);
            if (fileName.StartsWith(ignoredFileNamePattern))
            {
                lgnum++;
            }
        }

        if (lgnum == 0)
        {
            File.Create(SAVE_FOLDER + "largest_number" + 0 + ".txt");
            File.Create(Application.persistentDataPath + "aA" + 0 + ".txt");
        }
    }

    // Saves the data to a file
    public static void Save(string saveString)
    {
        int saveNumber = 0;
        int largestNumber = 0;

        while (!File.Exists(SAVE_FOLDER + "largest_number" + largestNumber + ".txt"))
        {
            largestNumber++;
        }
        int newLargest = largestNumber + 1;
        File.Move(SAVE_FOLDER + "largest_number" + largestNumber + ".txt", SAVE_FOLDER + "largest_number" + newLargest + ".txt");
        largestNumber = newLargest;
        saveNumber = largestNumber;

        File.WriteAllText(SAVE_FOLDER + "save_" + saveNumber + ".txt", saveString);
        Debug.Log("SAVED FILE: " + "save_" + saveNumber + ".txt");
    }

    // Loads data from a file
    public static string Load()
    {
        if (File.Exists(SAVE_FOLDER + "save_" + loadNumber + ".txt"))
        {
            string saveString = File.ReadAllText(SAVE_FOLDER + "save_" + loadNumber + ".txt");
            return saveString;
        }
        else
        {
            Debug.Log("File Does not exist");
            return null;
        }
    }

    // Deletes the specified file
    public static void Delete()
    {
        if (File.Exists(SAVE_FOLDER + "save_" + loadNumber + ".txt"))
        {
            File.Delete(SAVE_FOLDER + "save_" + loadNumber + ".txt");
        }
    }
}