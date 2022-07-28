using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VNLoginDLL
{
    public class VNLoginDLL
    {
        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateWin", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateWin(string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateMac", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateMac(string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateLinux", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateLinux(string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateAndroid", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateAndroid(string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateIphone", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateIphone(string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "SetProxy", CallingConvention = CallingConvention.StdCall)]
        public static extern void SetProxy(string id, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "Backup", CallingConvention = CallingConvention.StdCall)]
        public static extern void Backup(string id, string pathBackup);
    }
}
