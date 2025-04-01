
using WatcherApp.Repository;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using WatcherApp.Desktop.Forms;
using WatcherApp.Model;
using WatcherApp.Repository.Test;
using WatcherApp.Repository.MockData;
using WatcherApp.Desktop.DataCreators;

namespace WatcherApp.Desktop
{
    public partial class MainForm : Form
    {
        private ILog _log = LogManager.GetLogger(typeof(MainForm));
        private Form activeForm = null;

        public MainForm()
        {
            InitializeComponent();
            Init();
            btnJproExport.Visible = false;
            btnTotalView.Visible = false;
            btnSetting.Visible = false;
            button2.Visible = false;
            btnStorage.Visible = false;
            btnDataDelete.Visible = false;
           // btnKiShu.Visible = false;
            
            //Test();
            //DataCreators.TestResultDataCreator testResultDataCreator = new DataCreators.TestResultDataCreator();
            //testResultDataCreator.Create();

            //return;
            btnNGPercentage.Visible = false;
            btnTestConfig.Visible = false;
            // openChildForm(new fTestDataExtract());
            openChildForm(new fPhoneTesting());

            // sfDataGrid1.DataSource = _fileExtractData.GetTestResults("20200508");
        }

        private void Test()
        {
            // TestResultDataCreator.CreateTestData();
            TestResultRepository_Test testResultRepository_Test = new TestResultRepository_Test();
            //testResultRepository_Test.CheckKouteiJunban_Test_Case01();
            //testResultRepository_Test.AddOrUpdateTestedResult_Test();
        }
        private void Init()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // StartupFirewall.AllowDatabaseApp();
            // Log Init
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            btnViewLog.BackColor = SystemColors.GradientInactiveCaption;
        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            openChildForm(new fPhoneTesting());
            ActiveMenu(btnViewLog);
        }


        private void ActiveMenu(Button btnActive)
        {
            foreach (var control in pnlMenu.Controls)
            {
                Button btnMenu = (Button)control;
                if (btnMenu.Name == btnActive.Name)
                {
                    btnMenu.BackColor = SystemColors.GradientInactiveCaption;
                }
                else
                {
                    btnMenu.BackColor = SystemColors.Control;
                }
            }
        }
        private void btnNGPercentage_Click(object sender, EventArgs e)
        {
            openChildForm(new fExport());
            ActiveMenu(btnNGPercentage);
        }

        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.pnlMenu.ClientRectangle, Color.FromArgb(192, 0, 192), ButtonBorderStyle.Solid); ;
        }

        private void btnKiShu_Click(object sender, EventArgs e)
        {
            openChildForm(new fKishu());
            ActiveMenu(btnKiShu);
        }

        private void btnKotei_Click(object sender, EventArgs e)
        {
            openChildForm(new fKotei());
            ActiveMenu(btnKotei);
        }

        private void btnJproExport_Click(object sender, EventArgs e)
        {
            openChildForm(new fExportJpro());
            ActiveMenu(btnJproExport);
        }

        private void btnTotalView_Click(object sender, EventArgs e)
        {
            openChildForm(new fShuukei());
            ActiveMenu(btnTotalView);
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            openChildForm(new fWorkShift());
            ActiveMenu(btnSetting);
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new fCustomerImeiColor());
            ActiveMenu(button2);
        }

        private void btnStorage_Click(object sender, EventArgs e)
        {
            openChildForm(new fHoryuhin());
            ActiveMenu(btnStorage);
        }

        private void btnDataDelete_Click(object sender, EventArgs e)
        {
            openChildForm(new fDataDelete());
            ActiveMenu(btnDataDelete);

        }

        private void btnDeviceNg_Click(object sender, EventArgs e)
        {
            openChildForm(new fDefectiveProduct());
            ActiveMenu(btnDeviceNg);
        }
    }
}
