using UnityEngine;
using System.Runtime.InteropServices;

public class Save_File_Dialog
{
    public static string SaveFileDialog()
    {
        Win32API.OpenFileName ofn = new Win32API.OpenFileName();
        ofn.structSize = Marshal.SizeOf(ofn);
        ofn.dlgOwner = System.IntPtr.Zero;
        ofn.instance = System.IntPtr.Zero;
        ofn.customFilter = null;
        ofn.maxCustFilter = 0;
        ofn.filterIndex = 0;
        ofn.fileOffset = 0;
        ofn.fileExtension = 0;
        ofn.custData = System.IntPtr.Zero;
        ofn.hook = System.IntPtr.Zero;
        ofn.templateName = null;
        ofn.reservedPtr = System.IntPtr.Zero;
        ofn.reservedInt = 0;
        ofn.flagsEx = 0;
        ofn.filter = "All files\0*.*\0\0";
        ofn.file = new string(new char[256]);
        ofn.maxFile = ofn.file.Length;
        ofn.fileTitle = new string(new char[64]);
        ofn.maxFileTitle = ofn.fileTitle.Length;
        ofn.initialDir = Application.dataPath;
        ofn.title = "Save File";
        ofn.defExt = "json";
        ofn.flags = 0x00080000 | 0x00001000 | 0x00000800| 0x00000008;
        if(Win32API.GetSaveFileName(ofn))
        {
            return ofn.file;
        }
        else
        {
            return null;
        }
    }
}
