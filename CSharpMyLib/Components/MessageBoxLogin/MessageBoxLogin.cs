using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetectEverything.CustomControls
{
    public partial class MessageBoxLogin : Form
    {
        public DialogResult _dialogResult = new DialogResult();
        private static MessageBoxLogin _msgBox;

        public string _title;
        public string _content;
        public MessageBoxLogin()
        {
            InitializeComponent();
        }
        private void InitUi()
        {
            Text = _title;
            pnlOk.Location = new Point(241, 4);
            pnlOk.Visible = true;

        }

        public static DialogResult Show(string message, string title)
        {
            _msgBox = new MessageBoxLogin();
            _msgBox._content = message;
            _msgBox._title = title;
            _msgBox.InitUi();
            _msgBox.ShowDialog();
            return _msgBox._dialogResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals("JEMS"))
            {
                _dialogResult = DialogResult.Yes;
            }
            else
            {
                _dialogResult = DialogResult.No;
            }

            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.Yes;
            Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.No;
            Close();
        }

        private void lbPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "JEMS";
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
