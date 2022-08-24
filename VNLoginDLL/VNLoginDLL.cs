using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using xNet;

namespace VNLoginDLL
{
    
    public class VNLoginDLL
    {
        public static string Open(string Orbitar, string id, string ProxyType, string ip, string port)
        {
            string User = AppDomain.CurrentDomain.BaseDirectory + "\\profile\\" + id;
            string proxy = "";
            string host = "";
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(Orbitar + "\\chrome.exe");
            switch (ProxyType)
            {
                case "http":
                    proxy = $@"--proxy-server={ip}:{port}";
                    host = $@"--host-resolver-rules=""MAP * 0.0.0.0 , EXCLUDE {ip}""";
                    process.StartInfo.Arguments = $@"--user-data-dir=""{User}"" --disable-encryption --restore-last-session --font-masking-mode=2 {proxy} {host}";
                    break;
                case "socks4":
                    proxy = $@"--proxy-server=socks4://{ip}:{port}";
                    host = $@"--host-resolver-rules=""MAP * 0.0.0.0 , EXCLUDE {ip}""";
                    process.StartInfo.Arguments = $@"--user-data-dir=""{User}"" --disable-encryption --restore-last-session --font-masking-mode=2 {proxy} {host}";
                    break;
                case "socks5":
                    proxy = $@"--proxy-server=socks5://{ip}:{port}";
                    host = $@"--host-resolver-rules=""MAP * 0.0.0.0 , EXCLUDE {ip}""";
                    process.StartInfo.Arguments = $@"--user-data-dir=""{User}"" --disable-encryption --restore-last-session --font-masking-mode=2 {proxy} {host}";
                    break;
                default:
                    process.StartInfo.Arguments = $@"--user-data-dir=""{User}"" --disable-encryption --restore-last-session --font-masking-mode=2";
                    break;
            }
            process.Start();
            string PID = process.Id.ToString();
            return PID;
        }
        public static string Win(string name, string ProxyType, string ip, string port, string userip, string passip, string url)
        {
            string LoaiProxy = "";

            switch (ProxyType)
            {
                case "http":
                    LoaiProxy = "HTTP Proxy";
                    break;
                case "socks4":
                    LoaiProxy = "Socks 4 Proxy";
                    break;
                case "socks5":
                    LoaiProxy = "Socks 5 Proxy";
                    break;
                default:
                    LoaiProxy = "No_Proxy";
                    break;
            }

            DoPhanGiaiPC();
            string width = Marshal.PtrToStringAnsi(DPG()).Split('x')[0];
            string height = Marshal.PtrToStringAnsi(DPG()).Split('x')[1];
            string UA = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.60 Safari/537.36";
            GPU_win();
            string txtvendor = Marshal.PtrToStringAnsi(vendorLB());
            string txtrender = Marshal.PtrToStringAnsi(rendererLB());
            string mess = Newprofile("true", "noise", "8", "4", "1", "2", "1", "false", height, width, name, "0", "Win32", LoaiProxy, "", ip, port, userip, passip, url, UA, txtrender, txtvendor);
            if (mess != "er1" && mess != "er2" && mess != "er3" && mess != "expired")
            {
                //return Marshal.PtrToStringAnsi(id());
                return Marshal.PtrToStringAnsi(id());
            }    
            else
            {
                return mess;
            }    
        }
        public static string Mac(string user, string pass, string name, string ProxyType, string ip, string port, string userip, string passip, string url)
        {
            string LoaiProxy = "";
            switch (ProxyType)
            {
                case "http":
                    LoaiProxy = "HTTP Proxy";
                    break;
                case "socks4":
                    LoaiProxy = "Socks 4 Proxy";
                    break;
                case "socks5":
                    LoaiProxy = "Socks 5 Proxy";
                    break;
                default:
                    LoaiProxy = "No_Proxy";
                    break;
            }
            DoPhanGiaiPC();
            string width = Marshal.PtrToStringAnsi(DPG()).Split('x')[0];
            string height = Marshal.PtrToStringAnsi(DPG()).Split('x')[1];
            string UA = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.60 Safari/537.36";
            GPU_mac_intel();
            string txtvendor = Marshal.PtrToStringAnsi(vendorLB());
            string txtrender = Marshal.PtrToStringAnsi(rendererLB());
            Newprofile("true", "noise", "8", "4", "1", "2", "1", "false", height, width, name, "0", "Win32", LoaiProxy, "", ip, port, userip, passip, url, UA, txtrender, txtvendor);
            return Marshal.PtrToStringAnsi(id());
        }
        public static string Linux(string user, string pass, string name, string ProxyType, string ip, string port, string userip, string passip, string url)
        {
            string LoaiProxy = "";
            switch (ProxyType)
            {
                case "http":
                    LoaiProxy = "HTTP Proxy";
                    break;
                case "socks4":
                    LoaiProxy = "Socks 4 Proxy";
                    break;
                case "socks5":
                    LoaiProxy = "Socks 5 Proxy";
                    break;
                default:
                    LoaiProxy = "No_Proxy";
                    break;
            }
            DoPhanGiaiPC();
            Plat_Linux();
            string txtPlatform = Marshal.PtrToStringAnsi(platform());
            string width = Marshal.PtrToStringAnsi(DPG()).Split('x')[0];
            string height = Marshal.PtrToStringAnsi(DPG()).Split('x')[1];
            string UA = "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.60 Safari/537.36";
            GPU_linux();
            string txtvendor = Marshal.PtrToStringAnsi(vendorLB());
            string txtrender = Marshal.PtrToStringAnsi(rendererLB());
            Newprofile( "true", "noise", "8", "4", "1", "2", "1", "false", height, width, name, "0", txtPlatform, LoaiProxy, "", ip, port, userip, passip, url, UA, txtrender, txtvendor);
            return Marshal.PtrToStringAnsi(id());
        }
        public static string Android(string user, string pass, string name, string ProxyType, string ip, string port, string userip, string passip, string url)
        {
            string LoaiProxy = "";
            switch (ProxyType)
            {
                case "http":
                    LoaiProxy = "HTTP Proxy";
                    break;
                case "socks4":
                    LoaiProxy = "Socks 4 Proxy";
                    break;
                case "socks5":
                    LoaiProxy = "Socks 5 Proxy";
                    break;
                default:
                    LoaiProxy = "No_Proxy";
                    break;
            }
            DoPhanGiaiPhone();
            string width = Marshal.PtrToStringAnsi(DPG()).Split('x')[0];
            string height = Marshal.PtrToStringAnsi(DPG()).Split('x')[1];
            UA_Android();
            string UA = Marshal.PtrToStringAnsi(useragent());
            Plat_Android();
            string txtPlatform = Marshal.PtrToStringAnsi(platform());
            GPU_win();
            string txtvendor = Marshal.PtrToStringAnsi(vendorLB());
            string txtrender = Marshal.PtrToStringAnsi(rendererLB());
            Newprofile( "true", "noise", "8", "4", "1", "2", "1", "true", height, width, name, "5", txtPlatform, LoaiProxy, "", ip, port, userip, passip, url, UA, txtrender, txtvendor);
            return Marshal.PtrToStringAnsi(id());
        }
        public static string Iphone(string user, string pass, string name, string ProxyType, string ip, string port, string userip, string passip, string url)
        {
            string LoaiProxy = "";
            switch (ProxyType)
            {
                case "http":
                    LoaiProxy = "HTTP Proxy";
                    break;
                case "socks4":
                    LoaiProxy = "Socks 4 Proxy";
                    break;
                case "socks5":
                    LoaiProxy = "Socks 5 Proxy";
                    break;
                default:
                    LoaiProxy = "No_Proxy";
                    break;
            }
            DoPhanGiaiPhone();
            string width = Marshal.PtrToStringAnsi(DPG()).Split('x')[0];
            string height = Marshal.PtrToStringAnsi(DPG()).Split('x')[1];
            UA_Iphone();
            string UA = Marshal.PtrToStringAnsi(useragent());
            GPU_win();
            Newprofile( "true", "noise", "8", "4", "1", "2", "1", "true", height, width, name, "5", "iOS", LoaiProxy, "", ip, port, userip, passip, url, UA, "Apple GPU", "Apple Inc.");
            return Marshal.PtrToStringAnsi(id());
        }
        [DllImport("VNLogin.Library.dll", EntryPoint = "id", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr id();
        [DllImport("VNLogin.Library.dll", EntryPoint = "chrome_version", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr chrome_version();
        [DllImport("VNLogin.Library.dll", EntryPoint = "audioContext_mode", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr audioContext_mode();
        [DllImport("VNLogin.Library.dll", EntryPoint = "audioContext_value", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr audioContext_value();
        [DllImport("VNLogin.Library.dll", EntryPoint = "canvasMode", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr canvasMode();
        [DllImport("VNLogin.Library.dll", EntryPoint = "canvasNoise", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr canvasNoise();
        [DllImport("VNLogin.Library.dll", EntryPoint = "client_rects_noise_enable", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr client_rects_noise_enable();
        [DllImport("VNLogin.Library.dll", EntryPoint = "deviceMemory", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr deviceMemory();
        [DllImport("VNLogin.Library.dll", EntryPoint = "dns", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr dns();
        [DllImport("VNLogin.Library.dll", EntryPoint = "doNotTrack", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr doNotTrack();
        [DllImport("VNLogin.Library.dll", EntryPoint = "geoLocation_latitude", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr geoLocation_latitude();
        [DllImport("VNLogin.Library.dll", EntryPoint = "geoLocation_longitude", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr geoLocation_longitude();
        [DllImport("VNLogin.Library.dll", EntryPoint = "geoLocation_mode", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr geoLocation_mode();
        [DllImport("VNLogin.Library.dll", EntryPoint = "getClientRectsNoice", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr getClientRectsNoice();
        [DllImport("VNLogin.Library.dll", EntryPoint = "hardwareConcurrency", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr hardwareConcurrency();
        [DllImport("VNLogin.Library.dll", EntryPoint = "is_m1", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr is_m1();
        [DllImport("VNLogin.Library.dll", EntryPoint = "langHeader", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr langHeader();
        [DllImport("VNLogin.Library.dll", EntryPoint = "languages", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr languages();
        [DllImport("VNLogin.Library.dll", EntryPoint = "audioInputs", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr audioInputs();
        [DllImport("VNLogin.Library.dll", EntryPoint = "audioOutputs", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr audioOutputs();
        [DllImport("VNLogin.Library.dll", EntryPoint = "audio_mode", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr audio_mode();
        [DllImport("VNLogin.Library.dll", EntryPoint = "audio_uid", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr audio_uid();
        [DllImport("VNLogin.Library.dll", EntryPoint = "videoInputs", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr videoInputs();
        [DllImport("VNLogin.Library.dll", EntryPoint = "mobile_enable", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr mobile_enable();
        [DllImport("VNLogin.Library.dll", EntryPoint = "mobile_height", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr mobile_height();
        [DllImport("VNLogin.Library.dll", EntryPoint = "mobile_width", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr mobile_width();
        [DllImport("VNLogin.Library.dll", EntryPoint = "name", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr name();
        [DllImport("VNLogin.Library.dll", EntryPoint = "name_ID", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr name_ID();
        [DllImport("VNLogin.Library.dll", EntryPoint = "name_Path", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr name_Path();
        [DllImport("VNLogin.Library.dll", EntryPoint = "max_touch_points", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr max_touch_points();
        [DllImport("VNLogin.Library.dll", EntryPoint = "platform", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr platform();
        [DllImport("VNLogin.Library.dll", EntryPoint = "plugins_mode", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr plugins_mode();
        [DllImport("VNLogin.Library.dll", EntryPoint = "proxy_password", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr proxy_password();
        [DllImport("VNLogin.Library.dll", EntryPoint = "proxy_username", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr proxy_username();
        [DllImport("VNLogin.Library.dll", EntryPoint = "startupUrl", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr startupUrl();
        [DllImport("VNLogin.Library.dll", EntryPoint = "storage_mode", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr storage_mode();
        [DllImport("VNLogin.Library.dll", EntryPoint = "timezone", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr timezone();
        [DllImport("VNLogin.Library.dll", EntryPoint = "userAgent", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr userAgent();
        [DllImport("VNLogin.Library.dll", EntryPoint = "webGl_mode", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr webGl_mode();
        [DllImport("VNLogin.Library.dll", EntryPoint = "renderer", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr renderer();
        [DllImport("VNLogin.Library.dll", EntryPoint = "vendor", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr vendor();
        [DllImport("VNLogin.Library.dll", EntryPoint = "webRtc_mode", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr webRtc_mode();
        [DllImport("VNLogin.Library.dll", EntryPoint = "webRtc_fill_based_on_ip", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr webRtc_fill_based_on_ip();
        [DllImport("VNLogin.Library.dll", EntryPoint = "webRtc_localIps", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr webRtc_localIps();
        [DllImport("VNLogin.Library.dll", EntryPoint = "webRtc_local_ip_masking", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr webRtc_local_ip_masking();
        [DllImport("VNLogin.Library.dll", EntryPoint = "publicIP", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr publicIP();
        [DllImport("VNLogin.Library.dll", EntryPoint = "IP_Port", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr IP_Port();
        [DllImport("VNLogin.Library.dll", EntryPoint = "webglNoiceEnable", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr webglNoiceEnable();
        [DllImport("VNLogin.Library.dll", EntryPoint = "webglNoiseValue", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr webglNoiseValue();
        [DllImport("VNLogin.Library.dll", EntryPoint = "ALIASED_LINE_WIDTH_RANGE_0", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ALIASED_LINE_WIDTH_RANGE_0();
        [DllImport("VNLogin.Library.dll", EntryPoint = "ALIASED_LINE_WIDTH_RANGE_1", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ALIASED_LINE_WIDTH_RANGE_1();
        [DllImport("VNLogin.Library.dll", EntryPoint = "ALIASED_POINT_SIZE_RANGE_0", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ALIASED_POINT_SIZE_RANGE_0();
        [DllImport("VNLogin.Library.dll", EntryPoint = "ALIASED_POINT_SIZE_RANGE_1", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ALIASED_POINT_SIZE_RANGE_1();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_3D_TEXTURE_SIZE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_3D_TEXTURE_SIZE();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_ARRAY_TEXTURE_LAYERS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_ARRAY_TEXTURE_LAYERS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_COLOR_ATTACHMENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_COLOR_ATTACHMENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_COMBINED_TEXTURE_IMAGE_UNITS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_COMBINED_TEXTURE_IMAGE_UNITS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_COMBINED_UNIFORM_BLOCKS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_COMBINED_UNIFORM_BLOCKS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_CUBE_MAP_TEXTURE_SIZE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_CUBE_MAP_TEXTURE_SIZE();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_DRAW_BUFFERS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_DRAW_BUFFERS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_FRAGMENT_INPUT_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_FRAGMENT_INPUT_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_FRAGMENT_UNIFORM_BLOCKS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_FRAGMENT_UNIFORM_BLOCKS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_FRAGMENT_UNIFORM_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_FRAGMENT_UNIFORM_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_FRAGMENT_UNIFORM_VECTORS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_FRAGMENT_UNIFORM_VECTORS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_PROGRAM_TEXEL_OFFSET", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_PROGRAM_TEXEL_OFFSET();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_RENDERBUFFER_SIZE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_RENDERBUFFER_SIZE();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_SAMPLES", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_SAMPLES();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_TEXTURE_IMAGE_UNITS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_TEXTURE_IMAGE_UNITS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_TEXTURE_LOD_BIAS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_TEXTURE_LOD_BIAS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_TEXTURE_SIZE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_TEXTURE_SIZE();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_UNIFORM_BLOCK_SIZE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_UNIFORM_BLOCK_SIZE();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_UNIFORM_BUFFER_BINDINGS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_UNIFORM_BUFFER_BINDINGS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VARYING_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VARYING_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VARYING_VECTORS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VARYING_VECTORS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VERTEX_ATTRIBS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VERTEX_ATTRIBS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VERTEX_OUTPUT_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VERTEX_OUTPUT_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VERTEX_TEXTURE_IMAGE_UNITS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VERTEX_TEXTURE_IMAGE_UNITS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VERTEX_UNIFORM_BLOCKS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VERTEX_UNIFORM_BLOCKS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VERTEX_UNIFORM_COMPONENTS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VERTEX_UNIFORM_COMPONENTS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VERTEX_UNIFORM_VECTORS", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VERTEX_UNIFORM_VECTORS();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VIEWPORT_DIMS_0", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VIEWPORT_DIMS_0();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MAX_VIEWPORT_DIMS_1", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MAX_VIEWPORT_DIMS_1();
        [DllImport("VNLogin.Library.dll", EntryPoint = "MIN_PROGRAM_TEXEL_OFFSET", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr MIN_PROGRAM_TEXEL_OFFSET();
        [DllImport("VNLogin.Library.dll", EntryPoint = "UNIFORM_BUFFER_OFFSET_ALIGNMENT", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr UNIFORM_BUFFER_OFFSET_ALIGNMENT();
        [DllImport("VNLogin.Library.dll", EntryPoint = "LoaiProxy", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr LoaiProxy();
        [DllImport("VNLogin.Library.dll", EntryPoint = "note", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr note();
        [DllImport("VNLogin.Library.dll", EntryPoint = "status", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr status();
        [DllImport("VNLogin.Library.dll", EntryPoint = "thumuc", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr thumuc();

        [DllImport("VNLogin.Library.dll", EntryPoint = "DPG", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr DPG();

        [DllImport("VNLogin.Library.dll", EntryPoint = "vendorLB", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr vendorLB();

        [DllImport("VNLogin.Library.dll", EntryPoint = "rendererLB", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr rendererLB();

        [DllImport("VNLogin.Library.dll", EntryPoint = "useragent", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr useragent();

        

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateWin", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateWin(string user, string pass, string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateMac", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateMac(string user, string pass, string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateLinux", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateLinux(string user, string pass, string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateAndroid", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateAndroid(string user, string pass, string uid, string nameProfile, string fullproxy);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CreateIphone", CallingConvention = CallingConvention.StdCall)]
        public static extern void CreateIphone(string user, string pass, string uid, string nameProfile, string fullproxy);
   
        [DllImport("VNLogin.Library.dll", EntryPoint = "Token", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Token(string user, string license);

        [DllImport("VNLogin.Library.dll", EntryPoint = "CheckInfo", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CheckInfo(string token);
        public static string Session { get; set; }
        public static string userVNLogin { get; set; }
        public static string licenseVNLogin { get; set; }
        public static string SignIn(string user, string license)
        {
            Session = Marshal.PtrToStringAnsi(Token(user, license));
            string mess = "";
            switch (Session)
            {
                case "this user can not have more than 1 device":
                    mess = "er1";
                    return mess;
                    break;
                case "license key is incorect":
                    mess = "er2";
                    return mess;
                    break;
                case "{error:The exception handler configured on ExceptionHandlerOptions produced a 404 status response. This InvalidOperationException containing the original exception was thrown since this is often due to a misconfigured ExceptionHandlingPath. If the exception handler is expected to return 404 status responses then set AllowStatusCode404Response to true.}":
                    mess = "er3";
                    return mess;
                    break;
            }    

            string info = Marshal.PtrToStringAnsi(CheckInfo(Session));
            if ( info == "")
            {
                mess = "er4";
                return mess;
            }   
            else
            {
                userVNLogin = user;
                licenseVNLogin = license;

                string site = "https://dinhtu.vn/timenow.php";

                string[] timeNow = new WebClient().DownloadString(site).Split('/');
                int dayNow = int.Parse(timeNow[0]);
                int monthNow = int.Parse(timeNow[1]);
                int yearNow = int.Parse(timeNow[2]);

                string TimeEx = Regex.Match(info, @"expTime...*?0000", RegexOptions.Singleline).Value
                        .Replace(Regex.Match(info, @"expTime..", RegexOptions.Singleline).Value, "")
                        .Replace(@"0000", "");

                int dayEx = int.Parse(TimeEx.Substring(6, 2));
                int monthEx = int.Parse(TimeEx.Substring(4, 2));
                int yearEx = int.Parse(TimeEx.Substring(0, 4));

                DateTime now = new DateTime(yearNow, monthNow, dayNow);
                DateTime ex = new DateTime(yearEx, monthEx, dayEx);

                int days = (int)Math.Ceiling(ex.Subtract(now).TotalDays);
                return days.ToString();
            }    
        }

        [DllImport("VNLogin.Library.dll", EntryPoint = "UpdateNameProfile", CallingConvention = CallingConvention.StdCall)]
        public static extern void UpdateNameProfile(string ID, string NewName);

        [DllImport("VNLogin.Library.dll", EntryPoint = "UpdateProxy", CallingConvention = CallingConvention.StdCall)]
        public static extern void UpdateProxy(string ID, string IP, string UserIP, string PassIP, string TimeZone, string Long, string Lat);

        public static void Proxy(string ID, string ProxyType, string IP, string Port, string UserIP, string PassIP)
        {
            string _IPupdate = _IP(ProxyType, IP, Port, UserIP, PassIP);
            _infoIP(_IPupdate);
            UpdateProxy(ID, _IPupdate, UserIP, PassIP,tizo,longitude,latitude);
        }

        private static string _IP(string ProxyType, string IP, string Port, string UserIP, string PassIP)
        {
            HttpRequest http = new HttpRequest();
            try
            {
                string fullIP = IP + ":" + Port + ":" + UserIP + ":" + PassIP;
                switch (ProxyType)
                {
                    case "http":
                        http.Proxy = HttpProxyClient.Parse(fullIP);
                        break;
                    case "socks4":
                        http.Proxy = Socks4ProxyClient.Parse(fullIP);
                        break;
                    case "socks5":
                        http.Proxy = Socks5ProxyClient.Parse(fullIP);
                        break;
                }
                return http.Get("http://checkip.amazonaws.com/").ToString().Replace("\n","");
            }
            catch
            {
                return string.Empty;
            }

        }

        private static void _infoIP(string IP)
        {
            HttpRequest http = new HttpRequest();
            try
            {
                string info = http.Get($"http://ip-api.com/json/{IP}").ToString();
                latitude = Regex.Match(info, @"""lat...*?,", RegexOptions.Singleline).Value.
                    Replace(Regex.Match(info, @"""lat..", RegexOptions.Singleline).Value, "").
                    Replace(@",", "");

                longitude = Regex.Match(info, @"""lon...*?,", RegexOptions.Singleline).Value.
                Replace(Regex.Match(info, @"""lon..", RegexOptions.Singleline).Value, "").
                Replace(@",", "");

                tizo = Regex.Match(info, @"timezone....*?""", RegexOptions.Singleline).Value.
                Replace(Regex.Match(info, @"timezone...", RegexOptions.Singleline).Value, "").
                Replace(@"""", "");
            }
            catch { }
            
        }
        public static string latitude { get; set; }
        public static string longitude { get; set; }
        public static string tizo { get; set; }

        [DllImport("VNLogin.Library.dll", EntryPoint = "UpdateUA", CallingConvention = CallingConvention.StdCall)]
        public static extern void UpdateUA(string ID, string NewUA);

        [DllImport("VNLogin.Library.dll", EntryPoint = "Backup", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Backup(string user, string license, string token,
            string profile, string pathBackup, string name);

        [DllImport("VNLogin.Library.dll", EntryPoint = "Restore", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Restore(string user, string license, string token,
            string PathRestore, string pathVNLogin);

        public static string BackupVNLogin(string ID, string PathBackup, bool DeleteProfile)
        {
            string info = Marshal.PtrToStringAnsi(CheckInfo(Session));
            string mess = "success";
            if (info == "")
            {
                Session = Marshal.PtrToStringAnsi(Token(userVNLogin, licenseVNLogin));
                switch (Session)
                {
                    case "this user can not have more than 1 device":
                        mess = "er1";
                        return mess;
                        break;
                    case "license key is incorect":
                        mess = "er2";
                        return mess;
                        break;
                    case "{error:The exception handler configured on ExceptionHandlerOptions produced a 404 status response. This InvalidOperationException containing the original exception was thrown since this is often due to a misconfigured ExceptionHandlingPath. If the exception handler is expected to return 404 status responses then set AllowStatusCode404Response to true.}":
                        mess = "er3";
                        return mess;
                        break;
                }
            }

            string PathProfile = AppDomain.CurrentDomain.BaseDirectory + "\\profile\\" + ID;
            DeleteCache(PathProfile);
            mess = Marshal.PtrToStringAnsi(Backup(userVNLogin, licenseVNLogin, Session,PathProfile, PathBackup, ID));

            if (DeleteProfile == true)
            {
                try
                {
                   Directory.Delete(PathProfile, true);
                }
                catch { }
            }    

            return mess;

        }

        public static string RestoreVNLogin(string FileBackup, bool DeleteBackup)
        {
            string info = Marshal.PtrToStringAnsi(CheckInfo(Session));
            string mess = "success";
            if (info == "")
            {
                Session = Marshal.PtrToStringAnsi(Token(userVNLogin, licenseVNLogin));
                switch (Session)
                {
                    case "this user can not have more than 1 device":
                        mess = "er1";
                        return mess;
                        break;
                    case "license key is incorect":
                        mess = "er2";
                        return mess;
                        break;
                    case "{error:The exception handler configured on ExceptionHandlerOptions produced a 404 status response. This InvalidOperationException containing the original exception was thrown since this is often due to a misconfigured ExceptionHandlingPath. If the exception handler is expected to return 404 status responses then set AllowStatusCode404Response to true.}":
                        mess = "er3";
                        return mess;
                        break;
                }
            }

            string PathProfile = AppDomain.CurrentDomain.BaseDirectory + "\\profile\\";
            mess = Marshal.PtrToStringAnsi(Restore(userVNLogin, licenseVNLogin, Session, FileBackup, PathProfile));

            if (DeleteBackup == true)
            {
                try
                {
                    Directory.Delete(FileBackup, true);
                }
                catch { }
            }

            return mess;

        }

        [DllImport("VNLogin.Library.dll", EntryPoint = "UA_Android", CallingConvention = CallingConvention.StdCall)]
        public static extern void UA_Android();

        [DllImport("VNLogin.Library.dll", EntryPoint = "UA_Iphone", CallingConvention = CallingConvention.StdCall)]
        public static extern void UA_Iphone();

        [DllImport("VNLogin.Library.dll", EntryPoint = "DoPhanGiaiPC", CallingConvention = CallingConvention.StdCall)]
        public static extern void DoPhanGiaiPC();

        [DllImport("VNLogin.Library.dll", EntryPoint = "DoPhanGiaiPhone", CallingConvention = CallingConvention.StdCall)]
        public static extern void DoPhanGiaiPhone();

        [DllImport("VNLogin.Library.dll", EntryPoint = "GPU_win", CallingConvention = CallingConvention.StdCall)]
        public static extern void GPU_win();

        [DllImport("VNLogin.Library.dll", EntryPoint = "GPU_mac_intel", CallingConvention = CallingConvention.StdCall)]
        public static extern void GPU_mac_intel();

        [DllImport("VNLogin.Library.dll", EntryPoint = "GPU_linux", CallingConvention = CallingConvention.StdCall)]
        public static extern void GPU_linux();

        [DllImport("VNLogin.Library.dll", EntryPoint = "GPU_Android", CallingConvention = CallingConvention.StdCall)]
        public static extern void GPU_Android();

        [DllImport("VNLogin.Library.dll", EntryPoint = "Plat_Linux", CallingConvention = CallingConvention.StdCall)]
        public static extern void Plat_Linux();

        [DllImport("VNLogin.Library.dll", EntryPoint = "Plat_Android", CallingConvention = CallingConvention.StdCall)]
        public static extern void Plat_Android();

        [DllImport("VNLogin.Library.dll", EntryPoint = "DirectoryCopy", CallingConvention = CallingConvention.StdCall)]
        public static extern void DirectoryCopy(string fileGoc, string fileCopy);
                
        [DllImport("VNLogin.Library.dll", EntryPoint = "DeleteCache", CallingConvention = CallingConvention.StdCall)]
        public static extern void DeleteCache(string PathProfile);

        [DllImport("VNLogin.Library.dll", EntryPoint = "LoadDesign", CallingConvention = CallingConvention.StdCall)]
        public static extern void LoadDesign(string user, string pass);

        [DllImport("VNLogin.Library.dll", EntryPoint = "GetConfig", CallingConvention = CallingConvention.StdCall)]
        public static extern void GetConfig(string user, string pass, string id2,
        string chrome_version2,
        string audioContext_mode2,
        string audioContext_value2,
        string canvasMode2,
        string canvasNoise2,
        string client_rects_noise_enable2,
        string deviceMemory2,
        string dns2,
        string doNotTrack2,
        string geoLocation_latitude2,
        string geoLocation_longitude2,
        string geoLocation_mode2,
        string getClientRectsNoice2,
        string hardwareConcurrency2,
        string is_m12,
        string langHeader2,
        string languages2,
        string audioInputs2,
        string audioOutputs2,
        string audio_mode2,
        string audio_uid2,
        string videoInputs2,
        string mobile_enable2,
        string mobile_height2,
        string mobile_width2,
        string name2,
        string name_ID2,
        string name_Path2,
        string max_touch_points2,
        string platform2,
        string plugins_mode2,
        string proxy_password2,
        string proxy_username2,
        string startupUrl2,
        string storage_mode2,
        string timezone2,
        string userAgent2,
        string webGl_mode2,
        string renderer2,
        string vendor2,
        string webRtc_mode2,
        string webRtc_fill_based_on_ip2,
        string webRtc_localIps2,
        string webRtc_local_ip_masking2,
        string publicIP2,
        string IP_Port2,
        string webglNoiceEnable2,
        string webglNoiseValue2,
        string ALIASED_LINE_WIDTH_RANGE_02,
        string ALIASED_LINE_WIDTH_RANGE_12,
        string ALIASED_POINT_SIZE_RANGE_02,
        string ALIASED_POINT_SIZE_RANGE_12,
        string MAX_3D_TEXTURE_SIZE2,
        string MAX_ARRAY_TEXTURE_LAYERS2,
        string MAX_COLOR_ATTACHMENTS2,
        string MAX_COMBINED_FRAGMENT_UNIFORM_COMPONENTS2,
        string MAX_COMBINED_TEXTURE_IMAGE_UNITS2,
        string MAX_COMBINED_UNIFORM_BLOCKS2,
        string MAX_COMBINED_VERTEX_UNIFORM_COMPONENTS2,
        string MAX_CUBE_MAP_TEXTURE_SIZE2,
        string MAX_DRAW_BUFFERS2,
        string MAX_FRAGMENT_INPUT_COMPONENTS2,
        string MAX_FRAGMENT_UNIFORM_BLOCKS2,
        string MAX_FRAGMENT_UNIFORM_COMPONENTS2,
        string MAX_FRAGMENT_UNIFORM_VECTORS2,
        string MAX_PROGRAM_TEXEL_OFFSET2,
        string MAX_RENDERBUFFER_SIZE2,
        string MAX_SAMPLES2,
        string MAX_TEXTURE_IMAGE_UNITS2,
        string MAX_TEXTURE_LOD_BIAS2,
        string MAX_TEXTURE_SIZE2,
        string MAX_TRANSFORM_FEEDBACK_INTERLEAVED_COMPONENTS2,
        string MAX_TRANSFORM_FEEDBACK_SEPARATE_ATTRIBS2,
        string MAX_TRANSFORM_FEEDBACK_SEPARATE_COMPONENTS2,
        string MAX_UNIFORM_BLOCK_SIZE2,
        string MAX_UNIFORM_BUFFER_BINDINGS2,
        string MAX_VARYING_COMPONENTS2,
        string MAX_VARYING_VECTORS2,
        string MAX_VERTEX_ATTRIBS2,
        string MAX_VERTEX_OUTPUT_COMPONENTS2,
        string MAX_VERTEX_TEXTURE_IMAGE_UNITS2,
        string MAX_VERTEX_UNIFORM_BLOCKS2,
        string MAX_VERTEX_UNIFORM_COMPONENTS2,
        string MAX_VERTEX_UNIFORM_VECTORS2,
        string MAX_VIEWPORT_DIMS_02,
        string MAX_VIEWPORT_DIMS_12,
        string MIN_PROGRAM_TEXEL_OFFSET2,
        string UNIFORM_BUFFER_OFFSET_ALIGNMENT2,
        string LoaiProxy2,
        string note2,
        string status2,
        string thumuc2);

        [DllImport("VNLogin.Library.dll", EntryPoint = "Creat", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Creat(string user, string license, string token,
        string audioContext_mode2, string canvasMode2, string deviceMemory2, string hardwareConcurrency2,
        string audioInputs2, string audioOutputs2, string videoInputs2,
        string mobile_enable2, string mobile_height2, string mobile_width2,
        string nameProfile, string max_touch_points2, string platform2,
        string LoaiProxy2, string comboProxyFree, string publicIP2, string IP_Port2, string proxy_username2, string proxy_password2,
        string startupUrl2,
        string userAgent2,
        string renderer2, string vendor2);

        public static string Newprofile(string audioContext_mode2, string canvasMode2, string deviceMemory2, string hardwareConcurrency2,
        string audioInputs2, string audioOutputs2, string videoInputs2,
        string mobile_enable2, string mobile_height2, string mobile_width2,
        string nameProfile, string max_touch_points2, string platform2,
        string LoaiProxy2, string comboProxyFree, string publicIP2, string IP_Port2, string proxy_username2, string proxy_password2,
        string startupUrl2,
        string userAgent2,
        string renderer2, string vendor2)
        {
            string info = Marshal.PtrToStringAnsi(CheckInfo(Session));
            string mess = "success";
            if (info == "")
            {
                Session = Marshal.PtrToStringAnsi(Token(userVNLogin, licenseVNLogin));
                switch (Session)
                {
                    case "this user can not have more than 1 device":
                        mess = "er1";
                        return mess;
                        break;
                    case "license key is incorect":
                        mess = "er2";
                        return mess;
                        break;
                    case "{error:The exception handler configured on ExceptionHandlerOptions produced a 404 status response. This InvalidOperationException containing the original exception was thrown since this is often due to a misconfigured ExceptionHandlingPath. If the exception handler is expected to return 404 status responses then set AllowStatusCode404Response to true.}":
                        mess = "er3";
                        return mess;
                        break;
                }
            }

            mess = Marshal.PtrToStringAnsi(Creat( userVNLogin,  licenseVNLogin,  Session,
         audioContext_mode2,  canvasMode2,  deviceMemory2,  hardwareConcurrency2,
         audioInputs2,  audioOutputs2,  videoInputs2,
         mobile_enable2,  mobile_height2,  mobile_width2,
         nameProfile,  max_touch_points2,  platform2,
         LoaiProxy2,  comboProxyFree,  publicIP2,  IP_Port2,  proxy_username2,  proxy_password2,
         startupUrl2,
         userAgent2,
         renderer2,  vendor2));

            return mess;
            
        }

    }
}
