using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCColors : IColorable
{
    public List<string> GetSkinColors()
    {
        List<string> skinColors = new List<string>() { "B3A883", "DB9E56", "8E8E8E" };
        return skinColors;
        /*
         * "#B3A883",  yellow
         * "#DB9E56",  brown
         * "#8E8E8E"   likeaboss
         */
    }
    public List<string> GetClothColors()
    {
        List<string> skinColors = new List<string>() { "FF0000", "00FF00", "0000FF" };
        return skinColors;
        /*
        "#FF0000", // Красный
        "#00FF00", // Зеленый
        "#0000FF", // Синий
        */
    }
}
