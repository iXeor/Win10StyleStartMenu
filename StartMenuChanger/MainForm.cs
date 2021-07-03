using System;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework.Forms;
using Microsoft.Win32;

namespace StartMenuChanger
{

    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void ExpRestart()
        {
            foreach (Process exp in Process.GetProcesses())
            {
                if(exp.ProcessName.Equals("explorer"))
                {
                    exp.Kill();
                    try
                    {
                        exp.Start();
                    }
                    catch (Exception)
                    {
                        // 忽略异常处理
                    }
                }
            }
        }

        private bool expCheck()
        {
            foreach (Process exp in Process.GetProcesses())
            {
                if(exp.ProcessName.Equals("explorer"))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsRegeditKeyExist()
        {
            string[] subkeyNames = new string[] { };
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey software = hkcu.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced");
            if (software != null) subkeyNames = software.GetValueNames();
            //取得该项下所有键值的名称的序列，并传递给预定的数组中
            foreach (string keyName in subkeyNames)
            {
                if (keyName == "Start_ShowClassicMode") //判断键值的名称
                {
                    hkcu.Close();
                    return true;
                }
            }
            hkcu.Close();
            return false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Switch.Checked = false;
            RegistryKey key = Registry.CurrentUser;
            RegistryKey software = key.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced",true);
            if (IsRegeditKeyExist())
            {
                if (software.GetValue("Start_ShowClassicMode").ToString() == "1")
                {
                    Switch.Checked = true;
                }
            }
        }

        private void Switch_MouseClick(object sender, MouseEventArgs e)
        {
            if (Switch.Checked)
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey software = key.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced",true);
                software.SetValue("Start_ShowClassicMode", "1", RegistryValueKind.DWord);
                DialogResult result = MessageBox.Show(@"是否现在重启资源管理器？",@"提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ExpRestart();
                    if (expCheck())
                    {
                        MessageBox.Show(@"修改成功！",@"提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                        if (result == DialogResult.OK)
                        {
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        Process.Start("explorer.exe");
                        MessageBox.Show(@"修改成功！",@"提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    }
                }
            }
            else if (Switch.Checked == false)
            {
                RegistryKey key = Registry.CurrentUser;
                RegistryKey software = key.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced",true);
                software.SetValue("Start_ShowClassicMode", "0", RegistryValueKind.DWord);
                DialogResult result = MessageBox.Show(@"是否现在重启资源管理器？",@"提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ExpRestart();
                    if (expCheck())
                    {
                        MessageBox.Show(@"修改成功！",@"提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        Process.Start("explorer.exe");
                        MessageBox.Show(@"修改成功！",@"提示",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    }
                }
            }
        }

    }
}
