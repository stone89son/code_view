using WatcherApp.Model;
using WatcherApp.Repository;
using Syncfusion.Data;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.ListView.Enums;
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
using System.IO;
using Syncfusion.XlsIO;
using Syncfusion.WinForms.DataGridConverter;
using WatcherApp.Desktop.ViewModels;
using CSharpMyLib.Components;
using DetectEverything.CustomControls;

namespace WatcherApp.Desktop.Forms
{
    public partial class fPhoneTesting : Form
    {
        private KishuRepository _kiShuRepository;
        private TestResultRepository _testResultRepository;
        private TestResultDeletedRepository _testResultDeletedRepository;

        private List<Kishu> _lstKishu;
        List<TestResultView> _testResultViews;
        private List<string> _lstGirdHiddenCols;

        public fPhoneTesting()
        {
            InitializeComponent();
            Init();
        }
        private void MenuColorRender()
        {
            if (isPassedView)
            {
                btnKanryoSu.BackColor = Color.FromArgb(255, 128, 0);
                btnShikenChu.BackColor = Color.FromArgb(0, 140, 186);
            }
            else
            {
                btnKanryoSu.BackColor = Color.FromArgb(76, 175, 80);
                btnShikenChu.BackColor = Color.FromArgb(255, 128, 0);
            }
        }

        private void Init()
        {
            isPassedView = true;
            MenuColorRender();
            btnLive.Text = "Live Off";
            _isLive = false;

            _kiShuRepository = new KishuRepository();
            _testResultDeletedRepository = new TestResultDeletedRepository();
            _lstKishu = _kiShuRepository.GetAll();
            cbbListKishu.DataSource = _lstKishu;
            cbbListKishu.ValueMember = "Code";
            cbbListKishu.DisplayMember = "Name";

            cbbListKishu.DropDownStyle = DropDownStyle.DropDown;
            cbbListKishu.AutoCompleteMode = AutoCompleteMode.Suggest;
            if (_lstKishu?.Count > 0)
            {
                cbbListKishu.SelectedValue = User.GetByKey("KishuCode");
            }

            _testResultRepository = new TestResultRepository();

            grvData.AllowEditing = true;
            grvData.ShowRowHeader = true;
            grvData.AllowResizingColumns = true;
            grvData.AllowDraggingColumns = true;
            grvData.ShowValidationErrorToolTip = true;
            grvData.SearchController.SearchColor = Color.LightGreen;

            grvData.AutoSizeColumnsMode = AutoSizeColumnsMode.AllCells;
            grvData.Style.RowHeaderStyle.SelectionMarkerThickness = 10;
            grvData.Style.RowHeaderStyle.SelectionMarkerColor = Color.DarkViolet;
            grvData.Style.RowHeaderStyle.SelectionBackColor = Color.White;

            List<CellButton> buttons = new List<CellButton>();
            buttons.Add(new CellButton() { Text = "詳細", Size = new Size(65, 25) });
            List<CellButton> btnsDelete = new List<CellButton>();
            btnsDelete.Add(new CellButton() { Text = "削除", Size = new Size(65, 25) });
            grvData.Columns.Add(new GridButtonColumn() { MappingName = "BtnDetails", Buttons = buttons, HeaderText = "詳細" });

            grvData.Columns.Add(new GridCheckBoxColumn() { MappingName = "IsPassedAll", HeaderText = "試験済" });

            grvData.Columns.Add(new GridTextColumn() { MappingName = "Id", HeaderText = "Id" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "Line", Visible = false, HeaderText = "ライン" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "RepairNo", HeaderText = "修理No" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "IMEI", HeaderText = "IMEI" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "OSVersion", HeaderText = "OSバージョン" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "RegulatoryLabel", HeaderText = "技適番号" });

            grvData.Columns.Add(new GridTextColumn() { MappingName = "KishuCode", HeaderText = "コード" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "KishuName", HeaderText = "機種名" });

            grvData.Columns.Add(new GridTextColumn() { MappingName = "PassedAllDate", HeaderText = "完了日時" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "DateModified", HeaderText = "Last active" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "LastTestedKouteiName", HeaderText = "現在工程" });
            grvData.Columns.Add(new GridCheckBoxColumn() { MappingName = "LastTestedIsPassed", HeaderText = "現在結果" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "Author", HeaderText = "Author" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "Remark", HeaderText = "備考" });

            grvData.Columns.Add(new GridTextColumn() { MappingName = "DateCreated", HeaderText = "DateCreated" });
            //grvData.Columns.Add(new GridTextColumn() { MappingName = "Author", HeaderText = "Author" });
            grvData.Columns.Add(new GridTextColumn() { MappingName = "IsEnable", HeaderText = "IsEnable" });
            grvData.Columns.Add(new GridButtonColumn() { MappingName = "BtnDelete", Buttons = btnsDelete, HeaderText = "削除" });

            grvData.Columns["BtnDetails"].Width = 70;
            grvData.Columns["BtnDelete"].Width = 60;
            grvData.Columns["IMEI"].Width = 120;
            grvData.Columns["OSVersion"].Width = 130;
            grvData.Columns["RegulatoryLabel"].Width = 130;
            //grvData.Columns["KishuCode"].Width = 80;
            //grvData.Columns["KishuName"].Width = 80;
            grvData.Columns["LastTestedKouteiName"].Width = 100;
            grvData.Columns["LastTestedIsPassed"].Width = 100;

            grvData.Columns["PassedAllDate"].Width = 130;
            grvData.Columns["DateModified"].Width = 130;

            _lstGirdHiddenCols = new List<string>();
            _lstGirdHiddenCols.Add("Id");
            _lstGirdHiddenCols.Add("DateCreated");
            _lstGirdHiddenCols.Add("Author");
            _lstGirdHiddenCols.Add("IsEnable");
            _lstGirdHiddenCols.Add("KishuCode");
            _lstGirdHiddenCols.Add("KishuName");
            Utils.GridviewHideColumn(grvData, _lstGirdHiddenCols);

            grvData.SearchController.AllowFiltering = true;
            // Enable the UI filtering for the SfDataGrid.
            grvData.AllowFiltering = true;

            LoadSummaryInfo();
            LoadTestResult();

            bgwLiveData.RunWorkerAsync();
        }

        private bool isPassedView;
        private List<TestResultView> GetTestResultData()
        {
            List<TestResult> testResults = new List<TestResult>();
            if (isPassedView)
            {
                testResults = _testResultRepository.GetTestedByKishu(((Kishu)cbbListKishu.SelectedItem).Code, dteDate.Value.Value);
                lbShikenKanryo.Text = testResults.Count.ToString();
            }
            else
            {
                testResults = _testResultRepository.GetTestingByKishu(((Kishu)cbbListKishu.SelectedItem).Code);
            }

            List<TestResultView> testResultViews = ToTestResultView(testResults);
            return testResultViews;
        }
        private List<TestResultView> ToTestResultView(List<TestResult> testResults)
        {
            List<TestResultView> testResultViews = new List<TestResultView>();
            foreach (TestResult item in testResults)
            {
                TestResultView testResultView = new TestResultView();
                Utils.MoveObjectValue(item, testResultView);
                ResultInfo lstTestResultInfo = testResultView.ResultInfos.LastOrDefault();
                if (lstTestResultInfo != null)
                {
                    testResultView.LastTestedKouteiName = lstTestResultInfo.KouteiName;
                    testResultView.LastTestedIsPassed = lstTestResultInfo.IsPassed;
                }
                testResultViews.Add(testResultView);
            }
            return testResultViews;
        }

        private void LoadSummaryInfo()
        {
            SummaryInfo summaryInfo = _testResultRepository.GetSummaryInfo(cbbListKishu.SelectedValue.ToString(), dteDate.Value.Value);
            lbShikenChu.Text = summaryInfo.CountTesting.ToString();
            lbShikenKanryo.Text = summaryInfo.CountPassed.ToString();
        }
        private void LoadTestResult()
        {
            _testResultViews = GetTestResultData();
            grvData.DataSource = _testResultViews;
        }

        private void grvData_CellButtonClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellButtonClickEventArgs e)
        {
            CellButton btn = ((CellButton)sender);
            TestResult testResult = (TestResult)grvData.SelectedItem;

            switch (btn.Text)
            {
                case "削除":
                    DialogResult dialogResult = MessageBoxLogin.Show("リーダーのパスワードを入力してください。", "リーダー権限");
                    if (dialogResult == DialogResult.Yes)
                    {

                        TestResultDeleted testResultDeleted = new TestResultDeleted();
                        testResultDeleted = Utils.MovePropertiesValue<TestResultDeleted>(testResult, testResultDeleted);
                        _testResultDeletedRepository.InsertOneForDeleted(testResultDeleted);

                        _testResultRepository.DeleteOne(g => g.IMEI == testResult.IMEI);
                        LoadSummaryInfo();
                        LoadTestResult();
                    }
                    break;
                case "詳細":
                    fPhoneTestingDetailsView phoneTestingDetailsView = new fPhoneTestingDetailsView(testResult);
                    phoneTestingDetailsView.Show();
                    break;
            }

        }

        private void cbbListKishu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grvData.View != null)
            {
                LoadSummaryInfo();
                LoadTestResult();
                grvData.View.Refresh();
            }
        }

        private void grvData_DrawCell(object sender, Syncfusion.WinForms.DataGrid.Events.DrawCellEventArgs e)
        {
            if (grvData.ShowRowHeader && e.RowIndex != 0)
            {
                if (e.ColumnIndex == 0)
                {
                    TestResultView testResult = (TestResultView)e.DataRow.RowData;
                    e.DisplayText = (_testResultViews.Count - _testResultViews.IndexOf(testResult)).ToString();
                }
            }
        }

        private void dteDate_ValueChanged(object sender, Syncfusion.WinForms.Input.Events.DateTimeValueChangedEventArgs e)
        {
            LoadSummaryInfo();
            LoadTestResult();
        }

        private bool _isLive;
        private void btnLive_Click(object sender, EventArgs e)
        {
            if (_isLive)
            {
                btnLive.Text = "Live Off";
                _isLive = false;

            }
            else
            {
                btnLive.Text = "Live On";
                _isLive = true;
            }
        }

        private void bgwLiveData_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var bgWorkerDowork = (BackgroundWorker)sender;

            while (!bgWorkerDowork.CancellationPending)
            {
                if (_isLive)
                {
                    List<TestResultView> testResultViews = GetTestResultData();
                    SummaryInfo summaryInfo = _testResultRepository.GetSummaryInfo(((Kishu)cbbListKishu.SelectedItem).Code, dteDate.Value.Value);

                    LiveDataViewModel liveDataViewModel = new LiveDataViewModel();
                    liveDataViewModel.TestResultViews = testResultViews;
                    liveDataViewModel.SummaryInfo = summaryInfo;

                    bgWorkerDowork.ReportProgress(0, liveDataViewModel);
                }
                Thread.Sleep(3000);
            }
        }

        private void bgwLiveData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            LiveDataViewModel liveDataViewModel = (LiveDataViewModel)e.UserState;
            _testResultViews = liveDataViewModel.TestResultViews;
            SummaryInfo summaryInfo = liveDataViewModel.SummaryInfo;

            lbShikenChu.Text = summaryInfo.CountTesting.ToString();
            lbShikenKanryo.Text = summaryInfo.CountPassed.ToString();

            grvData.DataSource = _testResultViews;
        }

        private void btnShikenChu_Click(object sender, EventArgs e)
        {
            isPassedView = false;
            MenuColorRender();
            LoadTestResult();
        }

        private void btnKanryoSu_Click(object sender, EventArgs e)
        {
            isPassedView = true;
            MenuColorRender();
            LoadTestResult();
        }

        private void txtImeiSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtRepairNo.Text))
            {
                List<TestResult> lstTestResult = _testResultRepository.SearchByRepairNo(((Kishu)cbbListKishu.SelectedItem).Code,
                    txtRepairNo.Text);
                grvData.DataSource = ToTestResultView(lstTestResult);
                grvData.SearchController.SearchText = txtRepairNo.Text;
            }
        }
        private void txtImeiSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRepairNo.Text))
            {
                LoadTestResult();
                LoadSummaryInfo();
                grvData.SearchController.SearchText = string.Empty;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var options = new ExcelExportingOptions();
            Columns cols = grvData.Columns;
            foreach (var item in cols)
            {
                if (_lstGirdHiddenCols.Exists(p => p.Equals(item.MappingName)))
                {
                    options.ExcludeColumns.Add(item.MappingName);
                }
            }

            options.ExportMode = ExportMode.Text;
            var excelEngine = grvData.ExportToExcel(grvData.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];
            var workSheet = workBook.Worksheets[0];
            workSheet.AutoFilters.FilterRange = workSheet.UsedRange;
            workSheet.Range["A1:I1"].CellStyle.Color = System.Drawing.Color.LightSlateGray;
            workSheet.Range["A1:I1"].CellStyle.Font.Color = ExcelKnownColors.White;
            workSheet.Range["A1:I1"].CellStyle.Font.Size = 15;

            SaveFileDialog saveFilterDialog = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };

            if (saveFilterDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (Stream stream = saveFilterDialog.OpenFile())
                {
                    if (saveFilterDialog.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;
                    else if (saveFilterDialog.FilterIndex == 2)
                        workBook.Version = ExcelVersion.Excel2010;
                    else
                        workBook.Version = ExcelVersion.Excel2013;
                    workBook.SaveAs(stream);
                }

                //Message box confirmation to view the created workbook.
                if (MessageBox.Show(this.grvData, "ワークブックを表示したいですか？", "ワークブックが作成されました.",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process.Start(saveFilterDialog.FileName);
                }
            }
        }
    }
}