https://gemini.google.com/share/2fca00a5a45d

https://stackoverflow.com/questions/26676658/how-to-authenticate-user-password-proxy-in-c-sharp-selenium-chrome-driver

https://www.zenrows.com/blog/selenium-c-sharp-proxy#how-to-use-a-proxy-in-selenium-csharp

https://chatgpt.com/share/694ff8d1-46a8-8003-982d-d299c1bb9149


WinWaitActive("", "Chrome Legacy Window", "120")
If WinExists("", "Chrome Legacy Window") Then
    Send("username{TAB}")
    Send("password{Enter}")
EndIf
------------------------------------------

public class CameraProperty
{
    public bool AutoFocus { get; set; }
    public int Focus { get; set; }
    public double Brightness { get; set; }
    public double Contrast { get; set; }
    public double Saturation { get; set; }
    public double WhiteBalanceBlueU { get; set; }
    public double BackLight { get; set; }
    public double Gain { get; set; }
    public double Exposure { get; set; }
}

    public static void SetPropertyCamera(VideoCapture
      videoCapture)
    {
        CameraProperty cameraProperties = JsonHelper.GetInitObjectD<CameraProperty>(Constant.CAMERA_PROPERTY_PATH);

        videoCapture.AutoFocus = cameraProperties.AutoFocus;
        videoCapture.Focus = cameraProperties.Focus;
        videoCapture.Brightness = cameraProperties.Brightness;
        videoCapture.Contrast = cameraProperties.Contrast;
        videoCapture.Saturation = cameraProperties.Saturation;
        videoCapture.WhiteBalanceBlueU = cameraProperties.WhiteBalanceBlueU;
        videoCapture.BackLight = cameraProperties.BackLight;
        videoCapture.Gain = cameraProperties.Gain;
        videoCapture.Exposure = cameraProperties.Exposure;
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




-------------------------------------------
Hãy viết cho tôi chương trình C# dùng để test sản phẩm trong nhà máy với yêu cầu sau:
1. Sử dụng ClearScript, C#
2. C# là ứng dụng host bao gồm phần log thì sẽ sử dụng Richtextbox để in ra log
3. Phần nhập 進度管理番号, Serial No...
Phần nhập này sẽ được cấu hình như file như sau:
{
label:"進度管理番号",
name:"trackingNo"
require: true,
patternRegex:"...."
},
{
label:"Serial No",
name:"serialNo"
require: true,
patternRegex:"...."
}

mỗi khi đầu đọc barcode đọc hoàn thành một ô ví dụ 進度管理番号
thì sẽ gửi sang client clearscript để validate dữ liệu ngay lập tức

vaidate hết các nhập nhập thì sẽ đến bước chạy chương trình test.

4. trong chương trình test thì sẽ định nghĩa TestCase(id,name,=>{

đoạn script....

})

chương trình test có thể hỗ trợ các library  cả crud database, rs232....
các library này có thể cài đặt được giống như nuget ấy cho tiện lợi




-------------------------------------------

source code:
https://stone89son:7asJQcnlE1JsmdI9tUnGBkCIYqtRgRwFABqmYGGGGz3dszozEvUP4TsJQQJ99BIACAAAAAAAAAAAAASAZDO2Z1I@dev.azure.com/Allowtex/source-code/_git/source-code

watcher app:
https://stone89son:DHeQnknf2D4bm8Tu6Z7rfGdCEgIEP9Fs0zqALUDDDDsgncAfkCliitNJQQJ99BIACAAAAAAAAAAAAASAZDO4fkf@allowtex.visualstudio.com/WatcherApp/_git/WatcherApp

-------------------------------------------
-------------------------------------------
# code_view

new key : 2SSSVzPM6N9t62ViyCq6gH2ie8XE5JHOVSGnr786WMeOOOPtVCFh3NxdcNJQQJ99BFACAAAAAAAAAAAAASAZDO1iNNNbS


link: 	url = https://stone89son:@myprojectonazure.visualstudio.com/AssyCheckerWorkLog/_git/AssyCheckerWorkLog
----------------------------------------------
