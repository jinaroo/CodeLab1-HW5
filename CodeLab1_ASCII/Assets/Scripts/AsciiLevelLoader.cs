using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AsciiLevelLoader : MonoBehaviour
{
    public float cellWidth;
    
    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.dataPath + "/level0.txt";

        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "X");

        string[] inputLines = File.ReadAllLines(filePath);

        // NEW
        float startingY = ((inputLines.Length * cellWidth)/2);
        
        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[y];
            
            // NEW
            float startingX = -((line.Length * cellWidth)/2);
            
            // go through each character in that line
            for (int x = 0; x < line.Length; x++)
            {
                GameObject tile;

                switch (line[x])
                {
                    case 'X':
                        tile = Instantiate(Resources.Load<GameObject>("Prefabs/square"), transform);
                        break;
                    default:
                        tile = null;
                        break;
                }

                if (tile != null)
                    tile.transform.localPosition = new Vector2(startingX + (x * cellWidth), startingY - (y * cellWidth)); // NEW
                    //tile.transform.position = new Vector2(x - line.Length/2f, inputLines.Length/2f - y);
            }
        }
    }
}
