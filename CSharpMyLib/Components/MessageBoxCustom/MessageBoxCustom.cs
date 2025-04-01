using CSharpMyLib.Components.MessageBoxCustom;
using CSharpMyLib.Helpers;
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

namespace CSharpMyLib.Components.MessageBoxCustom
{
  
    public enum CustomMessageBoxType
    {
        Ok,
        YesNo
    }
    public enum CustomMessageBoxButtonResult
    {
        Ok,
        Yes,
        No,
    }
 
    public partial class MessageBoxCustom : Form
    {
        private MessageBoxInit _messageBoxInit;
        private string _initPath = "Data/MessageBoxInit.json";

        public DialogResult _dialogResult = new DialogResult();
        private static MessageBoxCustom _msgBox;

        private CustomMessageBoxType _customMessageBoxType;
        public string _title;
        public string _content;

        public MessageBoxCustom()
        {
            InitializeComponent();
            rtbStatus.SelectionProtected = true;
            rtbStatus.ReadOnly = true;
            rtbStatus.ShortcutsEnabled = false;
            this.StartPosition = FormStartPosition.Manual;
            _messageBoxInit = JsonHelper.GetInitObjectJsonTextD<MessageBoxInit>(_initPath);

            if (_messageBoxInit.Location.X == 0 && _messageBoxInit.Location.Y == 0)
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.Location = _messageBoxInit.Location;
            }
        }

        private void InitUi()
        {
            Text = _title;
            rtbStatus.Text = _content;
            switch (_customMessageBoxType)
            {
                case CustomMessageBoxType.Ok:
                    pnlOk.Location = new Point(241, 4);
                    pnlYesNo.Visible = false;
                    pnlOk.Visible = true;
                    break;
                case CustomMessageBoxType.YesNo:
                    pnlYesNo.Location = new Point(178, 4);
                    pnlOk.Visible = false;
                    pnlYesNo.Visible = true;
                    break;
            }
        }

        public static void Show(string message)
        {
            _msgBox = new MessageBoxCustom();
            _msgBox._content = message;
            _msgBox.InitUi();
            _msgBox.ShowDialog();
        }

        public static void Show(string message, string title)
        {
            _msgBox = new MessageBoxCustom();
            _msgBox._content = message;
            _msgBox._title = title;
            _msgBox.InitUi();
            _msgBox.Show();
        }

        public static DialogResult Show(string message, string title, CustomMessageBoxType customMessageBoxType)
        {
            _msgBox = new MessageBoxCustom();
            _msgBox._content = message;
            _msgBox._title = title;
            _msgBox._customMessageBoxType = customMessageBoxType;
            _msgBox.InitUi();
            _msgBox.ShowDialog();
            return _msgBox._dialogResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _dialogResult = DialogResult.OK;
            Close();
        }

        private void saveMessageBoxLocaltionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _messageBoxInit.Location = this.Location;
            JsonHelper.UpdateJsonText<MessageBoxInit>(_initPath, _messageBoxInit);
        }

        private void rtbStatus_Click(object sender, EventArgs e)
        {
            switch (_customMessageBoxType)
            {
                case CustomMessageBoxType.Ok:
                    btnOK.Focus();
                    break;
                case CustomMessageBoxType.YesNo:
                    btnYes.Focus();
                    break;
            }
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
    }
}
