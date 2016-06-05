﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace PowerPOS
{
    public partial class FmLogin : DevExpress.XtraEditors.XtraForm
    {
        public FmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var dt = Util.SqlCeQuery(string.Format(@"
                SELECT employeeId, employeeType 
                FROM Employee
                WHERE LOWER(username) = '{0}'
                    AND password = '{1}'
            ", txtUsername.Text.ToLower(), Util.MD5String(txtPassword.Text)));

            if(dt.Rows.Count > 0)
            {
                Param.EmployeeId = dt.Rows[0]["employeeId"].ToString();
                Param.EmployeeType = dt.Rows[0]["employeeType"].ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("ไม่สามารถเข้าสู่ระบบได้\nเนื่องจากชื่อผู้ใช้ หรือรหัสผ่านไม่ถูกต้อง", "มีข้อผิดพลาดเกิดขึ้น", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}