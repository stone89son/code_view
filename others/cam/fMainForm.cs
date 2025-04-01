using CSharpMyLib;
using CSharpMyLib.Components;
using CSharpMyLib.Components.MessageBoxAdbCheck;
using CSharpMyLib.Components.MessageBoxCustom;
using CSharpMyLib.Constants;
using CSharpMyLib.Helpers;
using CSharpMyLib.Models;
using CSoftwareConfirmADB.Models;
using CustomerModeCam;
using CustomerModeCam.Forms;
using CustomerModeCam.Models;
using JemsDataService;
using JemsDataService.Models;
using JemsDataService.Repositories;
using Newtonsoft.Json;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using RakutenShare;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WatcherApp.Model;
using WatcherApp.Repository;
using Excel = Microsoft.Office.Interop.Excel;
using Point = OpenCvSharp.Point;
using RepositoryUtils = WatcherApp.Repository.Utils;

namespace CSoftwareConfirmADB
{
    public partial class fMainForm : Form
    {
        public List<TestItemImage> _testItems;
        public List<PhonePassModel> _phonePassModels;
        public InitModel _initModel;
        public RAKUTEN_LOGRepository _rAKUTEN_LOGRepository;
        public KSRDBJUCRepository _kSRDBJUCRepository;
        private const string _IMEI = "IMEI";
        private VideoCapture _capture;
        private static readonly Object objLock = new Object();
        private Mat _currentFrame;
        private const int ID_YOUKOSO = 705;
        private const int ID_COLOR = 710;
        private const int ID_POWERON = 715;
        private const int ID_POWEROFF = 720;
        private List<DeviceRangeColor> _lstDeviceRangeColor;
        private DeviceRangeColor _deviceRangeColor;
        public fMainForm()
        {
            InitializeComponent();
            Init();
            //OpenSessionEsimReset();
        }
        private void InitHistoryGird()
        {

            dgvPhonePass.Dock = DockStyle.Fill;
            dgvPhonePass.ShowRowHeader = true;
            dgvPhonePass.AllowResizingColumns = true;
            dgvPhonePass.AllowDraggingColumns = true;
            dgvPhonePass.ShowValidationErrorToolTip = true;
            dgvPhonePass.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;

            dgvPhonePass.Columns.Add(new GridTextColumn() { MappingName = "RepairNo", HeaderText = "修理NO" });
            dgvPhonePass.Columns.Add(new GridTextColumn() { MappingName = "PassedTime", HeaderText = "日時" });
            dgvPhonePass.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsPassed", HeaderText = "結果" });

            dgvPhonePass.Columns["RepairNo"].Width = 160;

            dgvPhonePass.Columns["PassedTime"].Width = 200;
            dgvPhonePass.Columns["IsPassed"].Width = 130;

            dgvPhonePass.Columns["PassedTime"].Format = "HH:mm:ss";

            dgvPhonePass.Style.RowHeaderStyle.SelectionMarkerThickness = 10;
            dgvPhonePass.Style.RowHeaderStyle.SelectionMarkerColor = Color.DarkViolet;
            dgvPhonePass.Style.RowHeaderStyle.SelectionBackColor = Color.White;

            _phonePassModels = new List<PhonePassModel>();
            dgvPhonePass.DataSource = _phonePassModels;
            dgvPhonePass.View.Refresh();
        }
        private void InitTestItemGrid()
        {
            sfDataGrid1.Dock = DockStyle.Fill;
            sfDataGrid1.ShowRowHeader = true;
            sfDataGrid1.AllowSorting = false;
            sfDataGrid1.AllowEditing = false;
            sfDataGrid1.AllowResizingColumns = true;
            sfDataGrid1.AllowDraggingColumns = true;
            sfDataGrid1.ShowValidationErrorToolTip = true;
            sfDataGrid1.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", HeaderText = "Id", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "IsTest", HeaderText = "IsTest", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "TestedDate", HeaderText = "TestedDate", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "KouteiCode", HeaderText = "KouteiCode", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "KouteiName", HeaderText = "KouteiName", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Unit", HeaderText = "Unit", Visible = false });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Memo", HeaderText = "Memo", Visible = false });

            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Name", Width = 140, HeaderText = "確認アイテム" });
            sfDataGrid1.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsAutoTest", Visible = false, Width = 70, HeaderText = "自動テスト" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "LowerLimit", Width = 160, HeaderText = "基準値" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "ConditionType", Width = 100, HeaderText = "コンディション" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "UpperLimit", Width = 160, Visible = false, HeaderText = "上限" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "TestedValue", Width = 150, HeaderText = "読み込み値" });
            sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "LogPathImage", Width = 150, Visible = false, HeaderText = "LogPathImage" });
            sfDataGrid1.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsPassed", Width = 85, HeaderText = "Passed" });

            sfDataGrid1.Style.RowHeaderStyle.SelectionMarkerThickness = 10;
            sfDataGrid1.Style.RowHeaderStyle.SelectionMarkerColor = Color.DarkViolet;
            sfDataGrid1.Style.RowHeaderStyle.SelectionBackColor = Color.White;

        }
        private void LoadTestItems()
        {
          
            _testItems =
                JsonHelper.GetInitObjectD<List<TestItemImage>>(FOLDERS_DEFAULT.TestItem);

            //_testItems = new List<TestItemImage>();
            //_testItems.Add(new TestItemImage() { Id = 700, Name = _IMEI });
            //_testItems.Add(new TestItemImage() { Id = 705, Name = "ようこそ" });
            //_testItems.Add(new TestItemImage() { Id = 710, Name = "電源切る" });
            //_testItems.Add(new TestItemImage() { Id = 715, Name = "色" });
            //JsonHelper.UpdateList<TestItemImage>(FOLDERS_DEFAULT.TestItem, _testItems);
            sfDataGrid1.DataSource = _testItems;
        }
        private void Init()
        {
            button1.Visible = false;
            _initModel = User.GetInitObjectD<InitModel>();
            _lstDeviceRangeColor = JsonHelper.GetInitObjectD<List<DeviceRangeColor>>(Constant.DEVICE_RANGE_COLOR_PATH);
            _kSRDBJUCRepository = new KSRDBJUCRepository();
            _rAKUTEN_LOGRepository = new RAKUTEN_LOGRepository();

            lbKiShu.Text = _initModel.KishuName;
            lbModel.Text = _initModel.KishuCode;
            lbKouteiName.Text = _initModel.KouteiName;
            
            InitTestItemGrid();
            InitHistoryGird();
            LoadTestItems();
            InitCamera();
            bgWorker.RunWorkerAsync();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
        }


        private void fMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //CloseOcrService();
        }

        private void fMainForm_Load(object sender, EventArgs e)
        {

        }

        private void fMainForm_Shown(object sender, EventArgs e)
        {
            ResetUI();
            //txtRepairNo.Text = "J2110111117";
            //txtImei.Text = "353240430029517";
        }

        private void dgvPhonePass_DrawCell(object sender, Syncfusion.WinForms.DataGrid.Events.DrawCellEventArgs e)
        {
            if (dgvPhonePass.ShowRowHeader && e.RowIndex != 0)
            {
                if (e.ColumnIndex == 0)
                {
                    PhonePassModel phonePassModel = (PhonePassModel)e.DataRow.RowData;
                    e.DisplayText = (_phonePassModels.Count - e.RowIndex + 1).ToString();
                }
            }
        }

        public void EndTest(bool totalPassed)
        {
            try
            {
                string repairNo = txtRepairNo.Text.Trim();
                if (!string.IsNullOrWhiteSpace(repairNo))
                {
                    List<TestItem> testItems = new List<TestItem>();
                    foreach (var item in _testItems)
                    {
                        testItems.Add(UtilsLib.FillObjectValue<TestItem>(item, new TestItem()));
                    }
                    //_isTesting = false;
                    bool isUpData = DBShare.DataUp(new ResultInfo()
                    {
                        RepairNo = repairNo,
                        IMEI=txtImei.Text.Trim(),
                        TestItems = testItems,
                        IsPassed = totalPassed,
                        PassedDate = DateTime.Now
                    });
                    if (isUpData == false)
                    {
                        totalPassed = false;
                        rtbStatus.Text = "データを更新できませんでした！";
                    }
                    string logPath = Path.Combine(_initModel.LogPath,
                        DateTime.Now.ToString("yyyyMMdd"),
                        $"{repairNo}_{DateTime.Now.ToString("HHmmss")}_{(totalPassed == true ? "OK" : "FAILED")}");
                    bool logImage = LogHelper.IsLogPath(logPath);
                    if (logImage == false)
                    {
                        totalPassed = false;
                        rtbStatus.Text = "LOG_PATH_IMAGEの写真のデータを保存できませんでした。！";
                    }
                    foreach (var item in _testItems)
                    {
                        if (!string.IsNullOrWhiteSpace(item.LogPathImage))
                        {
                            try
                            {
                                FileInfo fileInfo = new FileInfo(item.LogPathImage);
                                File.Copy(item.LogPathImage,
                                    Path.Combine(logPath, fileInfo.Name), true);
                                File.Delete(item.LogPathImage);
                            }
                            catch
                            {
                                totalPassed = false;
                                rtbStatus.Text = "写真のデータを保存できませんでした。！";
                            }
                        }
                    }
                }

                picResult.Image = totalPassed == true ? Image.FromFile(MyLibCommon.IMG_OK) : Image.FromFile(MyLibCommon.IMG_NG);
                _phonePassModels.Insert(0, new PhonePassModel()
                {
                    RepairNo = repairNo,
                    PassedTime = DateTime.Now,
                    IsPassed = totalPassed
                });

                dgvPhonePass.SelectedIndex = 0;
                dgvPhonePass.View.Refresh();
                sfDataGrid1.View.Refresh();
                if (totalPassed)
                {
                    rtbStatus.Text = string.Empty;
                }
                ResetUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                picResult.Image = Image.FromFile(MyLibCommon.IMG_NG);
                ResetUI();
            }
        }

        private void ResetUI()
        {
            //WriteStatus(string.Empty);
            txtRepairNo.Text = string.Empty;
            txtImei.Text = string.Empty;
            txtRepairNo.Enabled = true;
            txtImei.Enabled = false;
            txtRepairNo.Focus();
        }
        private void WriteStatus(string status)
        {
            rtbStatus.Text = status;
            Application.DoEvents();
        }
        private void sfDataGrid1_DrawCell(object sender, Syncfusion.WinForms.DataGrid.Events.DrawCellEventArgs e)
        {
            if (sfDataGrid1.ShowRowHeader && e.RowIndex != 0)
            {
                if (e.ColumnIndex == 0)
                {
                    e.DisplayText = (e.RowIndex).ToString();
                }
            }
        }

        [Obsolete]
        private void txtRepairNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtRepairNo.Text))
                {
                    try
                    {
                        rtbStatus.Text = string.Empty;
                        LoadTestItems();
                        picResult.Image = Image.FromFile(MyLibCommon.IMG_WAITING);
                        Application.DoEvents();
                        string repairNo = txtRepairNo.Text.Trim();
                        if (!VerifyHelper.VerifyRepairNo(repairNo))
                        {
                            ResetUI();
                            picResult.Image = Image.FromFile(MyLibCommon.IMG_NG);
                            return;
                        }

                        if (!DBShare.CheckOrderOrTested(repairNo))
                        {
                            ResetUI();
                            picResult.Image = Image.FromFile(MyLibCommon.IMG_NG);
                            return;
                        }
                        ResponseData responseData = _rAKUTEN_LOGRepository.Remove(repairNo);
                        if (responseData.Code != JemsDataConstants.ERROR_CODE_0 && responseData.Code != JemsDataConstants.ERROR_CODE_404)
                        {
                            ResetUI();
                            picResult.Image = Image.FromFile(MyLibCommon.IMG_NG);
                            rtbStatus.Text = $"Error Code:{responseData.Code} \n Content: {responseData.Content}";
                            return;
                        }

                        ResponseData<KSRDBJUC> responseDataKSRDBJUC = _kSRDBJUCRepository.GetBySyurino(repairNo);
                        if (responseDataKSRDBJUC.Code != JemsDataConstants.ERROR_CODE_0)
                        {
                            ResetUI();
                            picResult.Image = Image.FromFile(MyLibCommon.IMG_NG);
                            rtbStatus.Text = $"Error Code:{responseDataKSRDBJUC.Code} \n Content: {responseDataKSRDBJUC.Content}";
                            return;
                        }
                        ResponseData<DEVICE_COLOR> responseDataDEVICE_COLOR = _kSRDBJUCRepository.GetColor(repairNo);
                        if (responseDataDEVICE_COLOR.Code != JemsDataConstants.ERROR_CODE_0)
                        {
                            ResetUI();
                            picResult.Image = Image.FromFile(MyLibCommon.IMG_NG);
                            rtbStatus.Text = $"Error Code:{responseDataDEVICE_COLOR.Code} \n Content: {responseDataDEVICE_COLOR.Content}";
                            return;
                        }
                        responseDataDEVICE_COLOR.Data.COLOR = responseDataDEVICE_COLOR.Data.COLOR.Trim().ToUpper();
                        if (string.IsNullOrWhiteSpace(responseDataDEVICE_COLOR.Data.COLOR))
                        {
                            ResetUI();
                            picResult.Image = Image.FromFile(MyLibCommon.IMG_NG);
                            rtbStatus.Text = $"修理システムにCOLOR not found!";
                            return;
                        }

                        TestItem colorTestItem = _testItems.FirstOrDefault(p => p.Id == ID_COLOR);
                        colorTestItem.LowerLimit = responseDataDEVICE_COLOR.Data.COLOR;
                        colorTestItem.TestedDate = DateTime.Now;

                        _deviceRangeColor = _lstDeviceRangeColor.FirstOrDefault(
                           p => p.DeviceCode == _initModel.KishuCode &&
                            p.Color == colorTestItem.LowerLimit);
                        if (_deviceRangeColor == null)
                        {
                            ResetUI();
                            picResult.Image = Image.FromFile(MyLibCommon.IMG_NG);
                            rtbStatus.Text = $"{colorTestItem.LowerLimit}を設定してください。";
                            return;
                        }

                        KSRDBJUC kSRDBJUC = responseDataKSRDBJUC.Data;
                        TestItem imeiTestItem = _testItems.FirstOrDefault(p => p.Name == _IMEI);
                        imeiTestItem.LowerLimit = kSRDBJUC.KIKINO;
                        imeiTestItem.TestedDate = DateTime.Now;

                        //sfDataGrid1.DataSource = _testItems;
                        sfDataGrid1.View.Refresh();
                        txtRepairNo.Enabled = false;
                        txtImei.Enabled = true;
                        txtImei.Focus();
                    }
                    catch (Exception ex)
                    {
                        EndTest(false);
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private bool IsCustomerMode()
        {
            UtilsLib.Execute("USBDeview.exe", " /sxml \"export.xml\"");
            XmlDocument doc = new XmlDocument();
            doc.Load("export.xml");
            XmlNode notea = doc.SelectSingleNode("/usb_devices_list/item[friendly_name='P710']");
            foreach (XmlNode item in notea.ChildNodes)
            {
                if (item.InnerText.Contains("ATOLL-AB-IDP _SN:"))
                {
                    return true;
                }
            }
            return false;
        }

        private void txtIMEI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrWhiteSpace(txtRepairNo.Text))
                {
                    ImageProcess.SetPropertyCamera(_capture);
                    txtImei.Enabled = false;
                    string imei = txtImei.Text.Trim();

                    if (!VerifyHelper.VerifyIMEI(imei))
                    {

                        txtImei.Text = string.Empty;
                        txtImei.Focus();
                        txtImei.Enabled = true;
                        return;
                    }

                    TestItem imeiTestItem = _testItems.FirstOrDefault(p => p.Name == _IMEI);
                    imeiTestItem.TestedValue = imei;
                    imeiTestItem.TestedDate = DateTime.Now;

                    if (imeiTestItem.LowerLimit != imeiTestItem.TestedValue)
                    {
                        imeiTestItem.IsPassed = false;
                        EndTest(false);
                        return;
                    }
                    else
                    {
                        imeiTestItem.IsPassed = true;
                    }

                    sfDataGrid1.View.Refresh();
                    List<TestItemImage> lstTestItemImage =
                        _testItems.Where(p => p.Name != _IMEI).ToList();

                    //--------------------ようこそ-----------------
                    int brk = 0;
                    TestItemImage testItemYoukoso = lstTestItemImage.FirstOrDefault(p => p.Id == ID_YOUKOSO);
                    fAlertImage fAlertImageWelcome = new fAlertImage(
                       Path.Combine(FOLDERS_DEFAULT.ImagePath, "welcome_in.png"),
                       "ようこそ画面を入れてください。");
                    fAlertImageWelcome.ShowDialog();
                    double maxVal = Convert.ToDouble(testItemYoukoso.Memo);
                    while (brk < 5)
                    {
                        lock (objLock)
                        {
                            Rect rectCropAreaRecognize = new Rect(new Point(
                                testItemYoukoso.CutLocation.X,
                                testItemYoukoso.CutLocation.Y),
                            new OpenCvSharp.Size(testItemYoukoso.CutSize.Width, testItemYoukoso.CutSize.Height));
                            Mat croppedImageAreaRecognize = new Mat(_currentFrame, rectCropAreaRecognize);
                            string imagePath = $"{testItemYoukoso.Id}.jpg";
                            string imagePathRecongize = Path.Combine(FOLDERS_DEFAULT.ImagePath, imagePath);
                            croppedImageAreaRecognize.SaveImage(imagePathRecongize);
                            string welcome = ORCPyEngine.RecognizeTextHttp(imagePath);
                            File.Delete(imagePathRecongize);
                            testItemYoukoso.IsPassed = welcome == testItemYoukoso.LowerLimit ? true : false;

                            testItemYoukoso.LogPathImage = Path.Combine(FOLDERS_DEFAULT.ImagePath,
                                 $"{testItemYoukoso.Name}_{(testItemYoukoso.IsPassed == true ? "OK" : "FAILED")}.jpg");
                            _currentFrame.SaveImage(testItemYoukoso.LogPathImage);
                        }
                        testItemYoukoso.TestedDate = DateTime.Now;
                        if (testItemYoukoso.IsPassed)
                        {
                            testItemYoukoso.TestedValue = testItemYoukoso.LowerLimit;
                            break;
                        }
                        Thread.Sleep(300);
                        brk++;
                    }

                    if (!testItemYoukoso.IsPassed)
                    {
                        EndTest(false);
                        return;
                    }
                    sfDataGrid1.View.Refresh();
                    Application.DoEvents();
                    //--------------------色確認-----------------
                    TestItemImage colorTestItem = _testItems.FirstOrDefault(p => p.Id == ID_COLOR);
                    fAlertImage fAlertImageDeviceBack = new fAlertImage(
                      Path.Combine(FOLDERS_DEFAULT.ImagePath, $"{colorTestItem.LowerLimit}.png"),
                      "色確認、端末裏を入れてください。");
                    fAlertImageDeviceBack.ShowDialog();
                 
                    brk = 0;
                    while (brk < 5)
                    {
                        lock (objLock)
                        {
                            colorTestItem.IsPassed = ImageProcess.IsColor(_deviceRangeColor, _currentFrame);
                        
                        colorTestItem.LogPathImage = Path.Combine(FOLDERS_DEFAULT.ImagePath,
                            $"{colorTestItem.Name}_{(colorTestItem.IsPassed == true ? "OK" : "FAILED")}.jpg");
                        _currentFrame.SaveImage(colorTestItem.LogPathImage);
                        }
                        colorTestItem.TestedDate = DateTime.Now;
                        if (colorTestItem.IsPassed)
                        {
                            colorTestItem.TestedValue = _deviceRangeColor.Color;
                            break;
                        }
                        Thread.Sleep(300);
                        brk++;
                    }
                    if (!colorTestItem.IsPassed)
                    {
                        EndTest(false);
                        return;
                    }

                    sfDataGrid1.View.Refresh();
                    Application.DoEvents();
                    //--------------------POWER ON-----------------
                    fAlertImage fAlertImageUsb = new fAlertImage(
                       Path.Combine(FOLDERS_DEFAULT.ImagePath, "cable.png"),
                       "USBケーブルを差し込んでください。");
                    fAlertImageUsb.ShowDialog();
                    TestItem powerONTestItem = _testItems.FirstOrDefault(p => p.Id == ID_POWERON);
                    brk = 0;
                    while (brk < 5)
                    {
                        powerONTestItem.IsPassed = IsCustomerMode();
                        powerONTestItem.TestedDate = DateTime.Now;
                        if (powerONTestItem.IsPassed)
                        {
                            powerONTestItem.TestedValue = "ON";
                            break;
                        }
                        Thread.Sleep(1000);
                        brk++;
                    }
                    if (!powerONTestItem.IsPassed)
                    {
                        EndTest(false);
                        return;
                    }
                    sfDataGrid1.View.Refresh();
                    Application.DoEvents();
                    //--------------------POWER OFF-----------------
                    fAlertImage fAlertImagePower = new fAlertImage(
                                       Path.Combine(FOLDERS_DEFAULT.ImagePath, "power_button.png"),
                                       $@"①電源ボタンを長押しする
②「電源を切る」ボタンを押して、端末の電源をOFF（電源を切る）する。
                        ");
                    fAlertImagePower.ShowDialog();
                    TestItem powerOffTestItem = _testItems.FirstOrDefault(p => p.Id == ID_POWEROFF);
                    bool isPowerOff = false;
                    while (!isPowerOff)
                    {

                        powerOffTestItem.IsPassed = !IsCustomerMode();
                        isPowerOff = powerOffTestItem.IsPassed;
                        powerOffTestItem.TestedValue = "ON";
                        powerOffTestItem.TestedDate = DateTime.Now;
                        Thread.Sleep(200);
                    }
                    powerOffTestItem.IsPassed = true;
                    powerOffTestItem.TestedValue = "OFF";
                    powerOffTestItem.TestedDate = DateTime.Now;
                    List<TestItem> testItems = new List<TestItem>();
                    foreach (var item in _testItems)
                    {
                        testItems.Add(UtilsLib.FillObjectValue<TestItem>(item, new TestItem()));
                    }
                    sfDataGrid1.View.Refresh();
                    Application.DoEvents();
                    bool isTotalPassed = TestItemHelper.IsTotalPassed(testItems);
                    EndTest(true);
                }
            }
        }
        //private bool IsExistWelcome(Mat image, double maxValStand)
        //{
        //  ORCPyEngine
        //var image = new Mat("Image.png");
        //var template = new Mat(Path.Combine(FOLDERS_DEFAULT.DataPath, $"welcome_template.jpg"));

        //double minVal, maxVal;
        //Point minLoc, maxLoc;
        //var result = image.MatchTemplate(template, TemplateMatchModes.CCoeffNormed);
        //result.MinMaxLoc(out minVal, out maxVal, out minLoc, out maxLoc);
        ////Debug.WriteLine("maxLoc: {0}, maxVal: {1}", maxLoc, maxVal);
        //if (maxVal >= maxValStand)
        //{
        //    return true;
        //}
        //return false;

        //  }
        private void button1_Click(object sender, EventArgs e)
        {
            //DoEsimReset();
        }
        private void InitCamera()
        {
            //Init Camera
            _capture = new VideoCapture();

            //if (int.TryParse(_initModel.CameraConnectString, out _))
            //{
            //    int camIndex = Convert.ToInt32(_initModel.CameraConnectString);
            //    _capture.Open(camIndex, VideoCaptureAPIs.ANY);
            //}
            //else
            //{
            //    _capture.Open(_initModel.CameraConnectString);
            //}
            _capture.Open(0);
            ImageProcess.SetPropertyCamera(_capture);
            if (!_capture.IsOpened())
            {
                MessageBox.Show("Please insert Camera");
            }
        }
        private void ReconectCamera()
        {
            //Init Camera
            _capture = new VideoCapture();

            //if (int.TryParse(_initModel.CameraConnectString, out _))
            //{
            //    int camIndex = Convert.ToInt32(_initModel.CameraConnectString);
            //    _capture.Open(camIndex, VideoCaptureAPIs.ANY);
            //}
            //else
            //{
            //    _capture.Open(_initModel.CameraConnectString);
            //}
            _capture.Open(0);
            ImageProcess.SetPropertyCamera(_capture);
            if (!_capture.IsOpened())
            {
                ReconectCamera();
                Thread.Sleep(200);
            }
            else
            {
                rtbStatus.Text = "";
            }
        }
        private int counter;
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (_capture.IsOpened())
                {
                    var bgWorkerDowork = (BackgroundWorker)sender;

                    while (!bgWorkerDowork.CancellationPending)
                    {

                        if (_capture.Grab())
                        {
                            using (var frameMat = _capture.RetrieveMat())
                            {
                                while (++counter > 0)
                                {

                                    _capture.Read(frameMat);
                                    if (!frameMat.Empty())
                                    {
                                        lock (objLock)
                                        {
                                            Mat currentFrame = frameMat.Clone();
                                            Mat dst = new Mat(480, 640, currentFrame.Type());
                                            currentFrame = currentFrame.Resize(dst.Size(), 0, 0, InterpolationFlags.Lanczos4);
                                            Cv2.Rotate(currentFrame, currentFrame, RotateFlags.Rotate180);
                                            _currentFrame = currentFrame;
                                            //IsExist(_currentFrame);
                                            // Get rotation matrix for rotating the image around its center in pixel coordinates
                                            //Point2f center = new Point2f((currentFrame.Cols - 1) / 2, (currentFrame.Rows - 1) / 2);
                                            // Determine bounding rectangle, center not relevant
                                            // 640,480
                                            var frameHsv = BitmapConverter.ToBitmap(currentFrame);
                                            bgWorkerDowork.ReportProgress(0, frameHsv);

                                        }
                                        if (counter == 120)
                                        {
                                            counter = 0;
                                            GC.Collect();
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //Reconnect
                            this.Invoke((MethodInvoker)delegate ()
                            {
                                rtbStatus.Text = "Reconnecting to camera";
                                Application.DoEvents();
                                ReconectCamera();
                            });
                        }
                    }
                }
                else
                {
                    MessageBox.Show("カメラをコンピュータに取り付けてください。");
                }
            }
            catch (Exception ex)
            {
                //_log.Error(ex.ToString());
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                lock (objLock)
                {
                    Bitmap frameBitmap = (Bitmap)e.UserState;
                    //ptbCamera.Image?.Dispose();
                    //ptbCamera.Image = frameBitmap;
                    Image clonedImg = new Bitmap(frameBitmap.Width, frameBitmap.Height,
                        PixelFormat.Format32bppArgb);
                    using (var copy = Graphics.FromImage(clonedImg))
                    {
                        copy.DrawImage(frameBitmap, 0, 0);
                    }
                    ptbCamera.Image?.Dispose();
                    ptbCamera.InitialImage = null;
                    ptbCamera.Image = clonedImg;

                }
            }
            catch (Exception ex)
            {
                //_log.Error(ex);
            }
        }

        private void Reload()
        {
            LoadTestItems();
            InitCamera();
            bgWorker.RunWorkerAsync();
        }
        private void cAM確認位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bgWorker.CancelAsync();
            _capture.Dispose();
            fPositionConfig fPositionConfig = new fPositionConfig();
            fPositionConfig.ShowDialog();
            Reload();
        }
        private void 色確認位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdjustment fAdjustment = new fAdjustment();
            fAdjustment.ShowDialog();
        }

        private void 中断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRepairNo.Text.Trim())) {
                EndTest(false);
            }
        }
    }
}
