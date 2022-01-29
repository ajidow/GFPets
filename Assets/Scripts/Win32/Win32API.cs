using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class Win32API
{
    public struct OpenFileName
    {
        public int structSize;
        public IntPtr dlgOwner;
        public IntPtr instance;
        public String filter;
        public String customFilter;
        public int maxCustFilter;
        public int filterIndex;
        public String file;
        public int maxFile;
        public String fileTitle;
        public int maxFileTitle;
        public String initialDir;
        public String title;
        public int flags;
        public short fileOffset;
        public short fileExtension;
        public String defExt;
        public IntPtr custData;
        public IntPtr hook;
        public String templateName;
        public IntPtr reservedPtr;
        public int reservedInt;
        public int flagsEx;
    }

    [DllImport("Comdlg32.dll")]
    public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
}
