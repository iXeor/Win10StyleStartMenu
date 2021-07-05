
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace StartMenuChanger
{
    partial class MainForm
    {
        [SecurityCritical]
        [DllImport("ntdll.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern int RtlGetVersion(ref OSVERSIONINFOEX versionInfo);
 
        [StructLayout(LayoutKind.Sequential)]
        internal struct OSVERSIONINFOEX
        {
            internal int OSVersionInfoSize;
            internal int MajorVersion;
            internal int MinorVersion;
            internal int BuildNumber;
            internal int PlatformId;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            internal string CSDVersion;
            internal ushort ServicePackMajor;
            internal ushort ServicePackMinor;
            internal short SuiteMask;
            internal byte ProductType;
            internal byte Reserved;
        }

        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            var osVersionInfo = new OSVERSIONINFOEX { OSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX)) };
            if (RtlGetVersion(ref osVersionInfo) != 0)
            {
                DialogResult result = MessageBox.Show("无法获取当前系统版本信息");
                if (result == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }
            if (osVersionInfo.BuildNumber != 22000)
            {
                DialogResult result = MessageBox.Show(
                    $"当前系统版本为： {osVersionInfo.MajorVersion}.{osVersionInfo.MinorVersion}.{osVersionInfo.BuildNumber}，该程序暂仅支持10.0.22000",
                    "提示",MessageBoxButtons.OK,MessageBoxIcon.Warning
                );
                if (result == DialogResult.OK)
                {
                    Environment.Exit(0);
                }
            }

            this.label1 = new System.Windows.Forms.Label();
            this.Switch = new HZH_Controls.Controls.UCSwitch();
            this.SuspendLayout();

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(51, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "将开始菜单恢复为Windows 10样式";

            this.Switch.BackColor = System.Drawing.Color.Transparent;
            this.Switch.Checked = false;
            this.Switch.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.Switch.FalseTextColr = System.Drawing.Color.White;
            this.Switch.Location = new System.Drawing.Point(416, 97);
            this.Switch.Name = "Switch";
            this.Switch.Size = new System.Drawing.Size(46, 20);
            this.Switch.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.Switch.TabIndex = 1;
            this.Switch.Texts = null;
            this.Switch.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.Switch.TrueTextColr = System.Drawing.Color.White;
            this.Switch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Switch_MouseClick);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(540, 180);
            this.Controls.Add(this.Switch);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.Style = MetroFramework.MetroColorStyle.Pink;
            this.Text = "Win10样式开始菜单启用工具";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label label1;
        private UCSwitch Switch;
    }
}

