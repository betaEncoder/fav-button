using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections;

namespace favUtil
{
    // win32 API での変数の型とC#での型を対応させる
    using WORD = System.UInt16;
    using DWORD = UInt32;
    using PDWORD = IntPtr;
    using ULONG_PTR = IntPtr;
    using PCHAR = System.Text.StringBuilder;
    using LPCSTR = String;
    using HDEVINFO = System.Int32;
    using GUID = Guid;

    [StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVINFO_DATA
    {
        public DWORD cbSize;
        public GUID ClassGuid;
        public DWORD DevInst;
        public ULONG_PTR Reserved;
    }

    // Device interface data
    [StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVICE_INTERFACE_DATA
    {
        public DWORD cbSize;
        public GUID InterfaceClassGuid;
        public DWORD Flags;
        public ULONG_PTR Reserved;
    }

    // Device interface detail data
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        public DWORD cbSize;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string DevicePath;
        //        public System.Text.StringBuilder DevicePath;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HIDD_ATTRIBUTES
    {
        public UInt32 Size;
        public UInt16 VendorID;
        public UInt16 ProductID;
        public UInt16 VersionNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HIDP_CAPS
    {
        public System.UInt16 Usage;
        public System.UInt16 UsagePage;
        public System.UInt16 InputReportByteLength;
        public System.UInt16 OutputReportByteLength;
        public System.UInt16 FeatureReportByteLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
        public System.UInt16[] Reserved;
        public System.UInt16 NumberLinkCollectionNodes;
        public System.UInt16 NumberInputButtonCaps;
        public System.UInt16 NumberInputValueCaps;
        public System.UInt16 NumberInputDataIndices;
        public System.UInt16 NumberOutputButtonCaps;
        public System.UInt16 NumberOutputValueCaps;
        public System.UInt16 NumberOutputDataIndices;
        public System.UInt16 NumberFeatureButtonCaps;
        public System.UInt16 NumberFeatureValueCaps;
        public System.UInt16 NumberFeatureDataIndices;
    }

    public class hidReport
    {
        public uint length;
        public byte[] data;
        public hidReport(uint reportLength)
        {
            length = reportLength;
            data = new byte[length];
            for (int i = 0; i < length; i++)
            {
                data[i] = 0;
            }
        }
    }

    public class hidWrapper
    {
        #region Win32 API宣言
        internal static readonly IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFile(
            string lpFileName, // ファイル名
            DesiredAccess dwDesiredAccess, // アクセスモード
            ShareMode dwShareMode, // 共有モード
            int lpSecurityAttributes, // セキュリティ記述子
            CreationDisposition dwCreationDisposition, // 作成方法
            FlagsAndAttributes dwFlagsAndAttributes, // ファイル属性
            IntPtr hTemplateFile // テンプレートファイルのハンドル
            );

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CloseHandle(
            IntPtr fileHandle);
        #endregion

        #region 列挙体

        private enum DesiredAccess : uint
        {
            GENERIC_READ = 0x80000000,
            GENERIC_WRITE = 0x40000000,
            GENERIC_EXECUTE = 0x20000000
        }

        private enum ShareMode : uint
        {
            FILE_SHARE_READ = 0x00000001,
            FILE_SHARE_WRITE = 0x00000002,
            FILE_SHARE_DELETE = 0x00000004
        }

        private enum CreationDisposition : uint
        {
            CREATE_NEW = 1,
            CREATE_ALWAYS = 2,
            OPEN_EXISTING = 3,
            OPEN_ALWAYS = 4,
            TRUNCATE_EXISTING = 5
        }

        private enum FlagsAndAttributes : uint
        {
            FILE_ATTRIBUTE_ARCHIVE = 0x00000020,
            FILE_ATTRIBUTE_ENCRYPTED = 0x00004000,
            FILE_ATTRIBUTE_HIDDEN = 0x00000002,
            FILE_ATTRIBUTE_NORMAL = 0x00000080,
            FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = 0x00002000,
            FILE_ATTRIBUTE_OFFLINE = 0x00001000,
            FILE_ATTRIBUTE_READONLY = 0x00000001,
            FILE_ATTRIBUTE_SYSTEM = 0x00000004,
            FILE_ATTRIBUTE_TEMPORARY = 0x00000100
        }

        #endregion

        #region hid.dll API宣言

        public const int DIGCF_PRESENT = 0x00000002;
        public const int DIGCF_DEVICEINTERFACE = 0x00000010;

        [DllImport("hid.dll")]
        static public extern void HidD_GetHidGuid(ref Guid HidGuid);

        [DllImport("hid.dll", SetLastError = true)]
        static public extern Boolean HidD_GetAttributes(
            IntPtr HidDeviceObject,
            ref HIDD_ATTRIBUTES Attributes);

        [DllImport("hid.dll")]
        static public extern Boolean HidD_SetFeature(
            IntPtr HidDeviceObject,
            byte[] ReportBuffer,
            UInt32 ReportBufferLength);

        [DllImport("hid.dll")]
        static public extern Boolean HidD_GetFeature(
            IntPtr HidDeviceObject,
            byte[] ReportBuffer,
            UInt32 ReportBufferLength);

        [DllImport("hid.dll")]
        static public extern Boolean HidD_GetPreparsedData(
            IntPtr HidDeviceObject,
            ref int PreparsedData);    //PHIDP_PREPARSED_DATA

        [DllImport("hid.dll")]
        static public extern Boolean HidP_GetCaps(
            int PreparsedData,
            ref HIDP_CAPS Capabilities);

        [DllImport("hid.dll")]
        static public extern Boolean HidD_SetOutputReport(
            IntPtr HidDeviceObject,
            byte[] ReportBuffer,
            UInt32 ReportBufferLength);

        [DllImport("setupapi.dll")]
        static public unsafe extern int SetupDiGetClassDevs(
            ref Guid ClassGuid,
            IntPtr Enumerator,     //ref int
            IntPtr hWndParent,     //ref int
            int Flags);

        [DllImport("setupapi.dll")]
        public static extern bool SetupDiEnumDeviceInterfaces(
            HDEVINFO DeviceInfoSet, int DeviceInfoData, ref Guid InterfaceClassGuid,
            int MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);
        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean SetupDiGetDeviceInterfaceDetail(
            HDEVINFO DeviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
            ref SP_DEVICE_INTERFACE_DETAIL_DATA DeviceInterfaceDetailData,  //ref SP_DEVICE_INTERFACE_DETAIL_DATA
            DWORD DeviceInterfaceDetailDataSize,
            ref WORD RequiredSize,
            IntPtr DeviceInfoData                     //ref SP_DEVINFO_DATA
        );
        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Boolean SetupDiGetDeviceInterfaceDetail(
            HDEVINFO DeviceInfoSet,
            ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
            IntPtr DeviceInterfaceDetailData,  //ref SP_DEVICE_INTERFACE_DETAIL_DATA
            DWORD DeviceInterfaceDetailDataSize,
            ref WORD RequiredSize,
            IntPtr DeviceInfoData                     //ref SP_DEVINFO_DATA
        );
        

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool WriteFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            ref uint lpNumberOfBytesWritten,
            IntPtr ipOverlapped);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadFile(
            IntPtr hFile,
            byte[] lpBuffer,
            uint nNumberOfBytesToWrite,
            ref uint lpNumberOfBytesWritten,
            IntPtr ipOverlapped);

        #endregion


        public class device
        {
            public IntPtr fileHandle;
            public string path;

            public device(string str)
            {
                path = str;
                fileHandle = CreateFile(
                    path,
                    DesiredAccess.GENERIC_WRITE | DesiredAccess.GENERIC_READ,
                    ShareMode.FILE_SHARE_READ, 0,
                    CreationDisposition.OPEN_ALWAYS,
                    FlagsAndAttributes.FILE_ATTRIBUTE_NORMAL,
                    IntPtr.Zero);
            }
            public void Dispose()
            {
                CloseHandle(fileHandle);
            }

            public uint sendReport(hidReport report)
            {
                uint written = 0;
                bool result = WriteFile(
                    fileHandle,
                    report.data,
                    report.length,
                    ref written,
                    IntPtr.Zero);
                return written;
            }

            public uint getReport(ref hidReport report)
            {
                uint written = 0;
                bool result = ReadFile(
                    fileHandle,
                    report.data,
                    report.length,
                    ref written,
                    IntPtr.Zero);
                return written;
            }
        }

        private static string[] getHIDPath()
        {
            ArrayList pathList = new ArrayList();
            Guid guid = new Guid();

            HidD_GetHidGuid(ref guid);

            // HIDに関する情報を持つ構造体の配列を取得する
            HDEVINFO hDevInfo = SetupDiGetClassDevs(ref guid, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);

            SP_DEVICE_INTERFACE_DATA spid = new SP_DEVICE_INTERFACE_DATA();
            spid.cbSize = (UInt32)Marshal.SizeOf(spid);

            int i = 0;
            // usbデバイスを列挙する。なくなったら0を返す。
            while (SetupDiEnumDeviceInterfaces(hDevInfo, 0, ref guid, i++, ref spid))
            {
                ushort size = 0;
                //デバイスインターフェース詳細情報のメモリサイズを取得する.
                SetupDiGetDeviceInterfaceDetail(hDevInfo, ref spid, IntPtr.Zero, 0, ref size, IntPtr.Zero);

                SP_DEVICE_INTERFACE_DETAIL_DATA detail = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                if (IntPtr.Size == 8) // for 64 bit operating systems
                {
                    detail.cbSize = 8;
                }
                else
                {
                    detail.cbSize = 4 + (uint)Marshal.SystemDefaultCharSize; // for 32 bit systems
                }
                ushort len = 0;
                if (SetupDiGetDeviceInterfaceDetail(hDevInfo, ref spid, ref detail, size, ref len, IntPtr.Zero))
                {
                    //デバイスへアクセスするためのパスが手に入った
                    pathList.Add(detail.DevicePath);
                }
            }

            return (String[])pathList.ToArray(typeof(String));
        }

        private static string[] getFilteredPath(int vid, int pid)
        {
            string[] path = getHIDPath();
            ArrayList filteredPath = new ArrayList();
            for(int i=0;i<path.Length;i++)
            {
                //一つづつ開いていく
                IntPtr fileHandle = CreateFile(path[i],
                                            DesiredAccess.GENERIC_WRITE | DesiredAccess.GENERIC_READ,
                                            ShareMode.FILE_SHARE_READ, 0,
                                            CreationDisposition.OPEN_ALWAYS,
                                            FlagsAndAttributes.FILE_ATTRIBUTE_NORMAL,
                                            IntPtr.Zero);
                if (fileHandle != INVALID_HANDLE_VALUE)
                {
                    //デバイスのオープン成功
                    HIDD_ATTRIBUTES attribute = new HIDD_ATTRIBUTES();      // 詳しい情報を取得する
                    HidD_GetAttributes(fileHandle, ref attribute);
                    if (attribute.VendorID == vid && attribute.ProductID == pid)// 引数と同じvid,pidを見つけたら
                    {
                        filteredPath.Add(path[i]);
                    }
                    // 閉じておく
                    CloseHandle(fileHandle);
                }
                else
                {
                    Console.Write("Device open failed.");
                }
            }

            return (string[])filteredPath.ToArray(typeof(string));
        }

        public device[] devices;
        public int length;
        public hidWrapper(int vid, int pid)
        {
            string[] path = getFilteredPath(vid, pid);
            length = path.Length;
            devices = new device[length];
            for (int i = 0; i < length; i++)
            {
                devices[i] = new device(path[i]);
            }
        }
        public void Dispose()
        {
            for (int i = 0; i < length; i++)
            {
                devices[i].Dispose();
            }
        }
    }
}
