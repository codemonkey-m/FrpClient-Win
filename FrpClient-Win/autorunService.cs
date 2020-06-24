using System;
using System.Diagnostics;
using System.ServiceProcess;
using System.Windows.Forms;

namespace FrpClient_Win {
    partial class autorunService:ServiceBase {
        public autorunService() {
            InitializeComponent();
        }
        Process frp_process = null;

        protected override void OnStart(string[] args) {
            // TODO: 在此处添加代码以启动服务。
            System.IO.Directory.SetCurrentDirectory(Application.StartupPath);
            //using(System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath+"\\autoService.log", true)) {
            //    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
            //}
            startFrp();
        }

        protected override void OnStop() {
            // TODO: 在此处添加代码以执行停止服务所需的关闭操作。
            //using(System.IO.StreamWriter sw = new System.IO.StreamWriter(Application.StartupPath + "\\autoService.log", true)) {
            //    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Stop.");
            //}
            CloseFrp();
        }

        private void startFrp(Object sender = null, EventArgs e = null) {
            frp_process = new Process();
            frp_process.StartInfo.FileName = "frpc.exe";
            frp_process.StartInfo.Arguments = " -c " + DB.strFileName;
            frp_process.StartInfo.CreateNoWindow = true;
            frp_process.StartInfo.UseShellExecute = false;
            frp_process.StartInfo.RedirectStandardOutput = true;
            frp_process.Exited += new EventHandler(startFrp);
            frp_process.Start();
        }

        private void CloseFrp() {
            if(null == frp_process)
                return;
            frp_process.Kill();
            frp_process.Close();
            frp_process = null;
        }
    }
}
