﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntDeployWinform.Models;

namespace AntDeployWinform.Winform
{
    public partial class FirstCreate : Form
    {
        private bool _level1;
        public FirstCreate(bool levle1)
        {
            InitializeComponent();


            Assembly assembly = typeof(Deploy).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("AntDeployWinform.Resources.Logo1.ico"))
            {
                if (stream != null) this.Icon = new Icon(stream);
            }

            _level1 = levle1;
            if (!levle1)
            {
                this.txt_iis_port.Visible = false;
                label15.Visible = false;
                label3.Visible = false;
            }
        }

        public IIsCreateParam IsCreateParam { get; set; }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            if (_level1)
            {
                var port = this.txt_iis_port.Text.Trim();
                if (string.IsNullOrEmpty(port))
                {
                    MessageBox.Show("Port Required!");
                    return;
                }

                if (!int.TryParse(port, out _))
                {
                    MessageBox.Show("Port Required!");
                    return;
                }
            }
            IsCreateParam = new IIsCreateParam
            {
                Port = this.txt_iis_port.Text.Trim(),
                PhysicalPath = this.txt_iis_PhysicalPath.Text.Trim(),
                PoolName = this.txt_pool_name.Text.Trim()
            };
            this.DialogResult = DialogResult.OK;
        }
    }
}
