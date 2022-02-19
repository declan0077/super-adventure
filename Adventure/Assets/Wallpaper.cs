using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Wallpaper : MonoBehaviour
{
    public string NAME;
    public string ComputerName;
    public RawImage RawImage;
    private const UInt32 SPI_GETDESKWALLPAPER = 0x73;
    private const int MAX_PATH = 260;
    public TMP_Text Name;
    public TMP_Text Test;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(UInt32 uAction, int uParam, string lpvParam, int fuWinIni);

    void Start()
    {
        RawImage.texture = LoadTextureFromPath(GetCurrentDesktopWallpaperPath());
        Name.text = Environment.UserName;
 
        Test.text = Environment.ProcessorCount.ToString();
    }

    private Texture2D LoadTextureFromPath(string path)
    {
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(System.IO.File.ReadAllBytes(path));
        return texture;
    }

    private string GetCurrentDesktopWallpaperPath()
    {
        string currentWallpaper = new string('\0', MAX_PATH);
        SystemParametersInfo(SPI_GETDESKWALLPAPER, currentWallpaper.Length, currentWallpaper, 0);
        return currentWallpaper.Substring(0, currentWallpaper.IndexOf('\0'));
    }
}