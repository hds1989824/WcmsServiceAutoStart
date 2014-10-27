using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.Common;
using System.Diagnostics;
using System.Data;
using System.ServiceProcess;

namespace WcmsServiceAutoStart
{
    public partial class Form1 : Form
    {
        public Thread t1, t2, t3;
        ServiceController sc = new ServiceController();
        
        public Form1()
        {
            InitializeComponent();
        }
   
        public void GetStatus1()
        {
          //  for (int i = 0; i < 100;i++ )
           while(true)
            {
                string status1 = ShowSelectStutus("WCMSRest");
                if (status1 == "Stopped")
                {
                    try
                    {
                        sc.Start();
                    Debug.WriteLine("---LZ---" + "正在启动WCMSRest   " + status1);
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                    status1 = ShowSelectStutus("WCMSRest");
                    label7.Text = status1;
                    CommonFunction.WriteLog("WCMSRest 已经被启动");
                    Debug.WriteLine("---LZ---" + "WCMSRest 已经被启动   " + status1);
                    }
                    catch(Exception ex)
                    {
                        CommonFunction.WriteLog(ex.ToString());
                    }
                    
                }
                Thread.Sleep(5000);
            }
        }
        public void GetStatus2()
        {
            //  for (int i = 0; i < 100;i++ )
            while (true)
            {
                string status2 = ShowSelectStutus("WCMSStorages");
                if (status2 == "Stopped")
                {
                    try
                    {
                        sc.Start();
                        Debug.WriteLine("---LZ---" + "正在启动WCMSStorages   " + status2);
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                        status2 = ShowSelectStutus("WCMSStorages");
                        label8.Text = status2;
                        CommonFunction.WriteLog("WCMSStorages 已经被启动");
                        Debug.WriteLine("---LZ---" + "正在启动WCMSStorages  " + status2);
                    }
                    catch (Exception ex) {
                        CommonFunction.WriteLog(ex.ToString());
                    }
                   
                }
                Thread.Sleep(5000);
            }
        }
        public void GetStatus3()
        {
          //  for (int i = 0; i < 100;i++ )
           while(true)
            {
                 string status3 = ShowSelectStutus("WCMSTransmitors");
                if (status3 == "Stopped")
                {

                    try
                    { 
                        sc.Start();
                    Debug.WriteLine("---LZ---" + "正在启动WCMSTransmitors   " + status3);
                    sc.WaitForStatus(ServiceControllerStatus.Running);
                    status3 = ShowSelectStutus("WCMSTransmitors");
                    label9.Text = status3;
                    CommonFunction.WriteLog("WCMSTransmitors 已经被启动");
                    Debug.WriteLine("---LZ---" + "WCMSTransmitors 已经被启动   " + status3);
                    }
                    catch(Exception ex)
                    {
                        CommonFunction.WriteLog(ex.ToString());
                    }
                   
                }
                Thread.Sleep(5000);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
             Debug.WriteLine("---LZ---" + "开始监控WCMSRest");
             t1 = new Thread(new ThreadStart(GetStatus1));
             t1.IsBackground = true; ///如果主窗口关闭 结束进程
             t1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("---LZ---" + "开始监控WCMSStorages");
             t2 = new Thread(new ThreadStart(GetStatus2));
             t2.IsBackground = true;    
             t2.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("---LZ---" + "开始监控WCMSTransmitors");
             t3 = new Thread(new ThreadStart(GetStatus3));
             t3.IsBackground = true;
             t3.Start();
 
        }
        public string ShowSelectStutus(string servicename)
        {
            string serviceStutus = string.Empty;
            try
            {
                sc = new ServiceController(servicename);
                serviceStutus = sc.Status.ToString();
            }
            catch (Exception err)
            {
                serviceStutus = err.Message;
            }
            return serviceStutus;
        }
 
       
    }
}
