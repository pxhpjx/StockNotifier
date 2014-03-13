using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Windows.Forms;

namespace StockNotifier
{
    public partial class StockNotifier : Form
    {
        System.Timers.Timer UpdateTimer = null;

        public StockNotifier(string[] args)
        {
            InitializeComponent();
            niNewData.Visible = true;
            this.SizeChanged += StockNotifier_MinimumSizeChanged;
            niNewData.MouseClick += niNewData_MouseClick;


            List<Stock> Configs = LogRecord.ReadSerXmlLog<List<Stock>>(System.Windows.Forms.Application.StartupPath + "\\Stocks.xml");
            if (Configs != null && Configs.Count > 0)
            {
                this.Height = 114 + Configs.Count * 23;
                dgvStocks.Visible = true;
                dgvStocks.Height = 20 + Configs.Count * 23;
                dgvStocks.DataSource = Configs;
            }
            else
            {
                this.Height = 80;
                dgvStocks.Visible = false;
            }

            UpdateTimer = new System.Timers.Timer(300);
            UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            UpdateTimer.Start();
            if (args != null && args.Contains("min"))
                UpdateTimer.Interval += 1;
        }

        void niNewData_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    contextMenuStrip1.TopLevel = true;
            //    contextMenuStrip1.Show(Control.MousePosition);
            //    contextMenuStrip1.Visible = true;
            //}
            if (e.Button == MouseButtons.Middle)
                this.Close();
        }

        void UpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (UpdateTimer.Interval != 300000)
            {
                if (UpdateTimer.Interval % 10 == 1)
                    this.Visible = false;
                UpdateTimer.Interval = 300000;
            }
            btnUpdate_Click(this, new EventArgs());
        }

        void StockNotifier_MinimumSizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.Visible = false;
        }

        private string GetRequest(string StockID)
        {
            string Url = string.Format("http://hqdigi2.eastmoney.com/EM_Quote2010NumericApplication/CompatiblePage.aspx?Type=fs&jsName=js&stk={0}&Reference=xml&rt=0.006132413089120159", StockID); ;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(new Uri(Url));
            webRequest.Method = "GET";
            webRequest.UserAgent = "PP's StockNotifier";

            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            return sr.ReadToEnd();
        }

        private string[] DecResponse(string Response)
        {
            if (string.IsNullOrWhiteSpace(Response) || !Response.Contains(','))
                return null;
            char[] Splitter = { ',' };
            string[] Paras = Response.Split(Splitter);
            if (Paras.Length < 10)
                return null;
            return Paras;
        }

        private Stock UpdateStock(Stock Old)
        {
            string[] Paras = DecResponse(GetRequest(Old.ID));
            if (Paras != null && Paras.Length > 0)
            {
                Stock New = FormatTools.SampleCopy(Old);
                New.Name = Paras[2];
                New.RealPrice = Paras[3];
                New.RealPrice += "/" + (string.IsNullOrWhiteSpace(New.MyAverageCost) ? "null" : (Math.Round(FormatTools.ParseDouble(New.RealPrice) / FormatTools.ParseDouble(New.MyAverageCost) * 100.0 - 100.0, 2)).ToString());
                New.ChangeAmount = Paras[4];
                New.ChangePercentage = Paras[5];
                return New;
            }
            return null;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<Stock> Stocks = dgvStocks.DataSource as List<Stock>;
            if (Stocks != null && Stocks.Count > 0)
            {
                List<Stock> list = new List<Stock>();
                niNewData.BalloonTipText = "";
                foreach (Stock s in Stocks)
                {
                    var r = UpdateStock(s);
                    if (r != null)
                    {
                        list.Add(r);
                        niNewData.BalloonTipText += string.Format("{3}{0}   {1}   {2}", r.Name, r.RealPrice, r.ChangePercentage, string.IsNullOrWhiteSpace(niNewData.BalloonTipText) ? "" : "\r\n");
                    }
                }
                if (list.Count > 0)
                {
                    BeginInvoke(new Action(() => dgvStocks.DataSource = list));
                    niNewData.ShowBalloonTip(5000);
                }
            }
        }

        private void niNewData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = !this.Visible;
            if (this.Visible)
                this.WindowState = FormWindowState.Normal;
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void QuitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string ID = ((List<Stock>)dgvStocks.DataSource)[e.RowIndex].ID;
                string Url = string.Format("http://quote.eastmoney.com/{0}{1}.html", (ID[ID.Length - 1] == '1' ? "sh" : "sz"), ID.Substring(0, ID.Length - 1));
                if (FormatTools.ParseString(Get("ClickUrl")) == Url)
                    Process.Start(@"D:\Mozilla Firefox\firefox.exe", Url);
                else
                    SetAbsolute("ClickUrl", Url, 22);
            }
        }

        public static void SetAbsolute(string key, object obj, double CacheSeconds, CacheItemPriority Level = CacheItemPriority.Normal)
        {
            HttpRuntime.Cache.Insert(key, obj, null, DateTime.UtcNow.AddSeconds(CacheSeconds), System.Web.Caching.Cache.NoSlidingExpiration, Level, null);
        }

        public static object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }
    }
}
