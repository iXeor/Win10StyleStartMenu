
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using HZH_Controls.Controls;
using MetroFramework;
using MetroFramework.Forms;

namespace StartMenuChanger
{
    partial class MainForm
    {
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

