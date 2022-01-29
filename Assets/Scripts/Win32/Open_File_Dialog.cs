using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Open_File_Dialog
{
    public  static string OpenFileDialog()
    {
        Win32API.OpenFileName ofn = new Win32API.OpenFileName();
        ofn.structSize = Marshal.SizeOf(ofn);
        ofn.filter = "Json file(*.json)\0*.json\0\0";
        ofn.file = new string(new char[256]);
        ofn.maxFile = ofn.file.Length;
        ofn.fileTitle = new string(new char[64]);
        ofn.maxFileTitle = ofn.fileTitle.Length;
        ofn.initialDir = UnityEngine.Application.dataPath;
        ofn.title = "Open File";
        ofn.defExt = "json";
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;

        if(Win32API.GetOpenFileName(ofn))
        {
            return ofn.file;
        }
        else
        {
            return null;
        }

    }
}
