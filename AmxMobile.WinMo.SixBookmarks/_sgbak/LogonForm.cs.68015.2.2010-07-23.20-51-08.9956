using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace AmxMobile.WinMo.SixBookmarks
{
    public partial class LogonForm : Form
    {
        private const string UsernameKey = "Username";
        private const string PasswordKey = "Password";

        public LogonForm()
        {
            InitializeComponent();
        }

        private void menuLogon_Click(object sender, EventArgs e)
        {
            this.DoLogon();
        }

        private void DoLogon()
        {
            // validate...
            ErrorBucket bucket = new ErrorBucket();
            string username = this.textUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
                bucket.Add("Username is required.");
            string password = this.textPassword.Text.Trim();
            if (string.IsNullOrEmpty(password))
                bucket.Add("Password is required.");

            // error?
            if (bucket.HasErrors)
            {
                Alert.Show(bucket.GetAllErrorsSeparatedByCrLf());
                return;
            }

            // clear the credentials...
            this.ClearCredentials();

            // logon...
            UsersService users = new UsersService();
            users.Logon(username, password, delegate(LogonResponse response)
            {
                // we managed to get a response...
                if (response.Result == LogonResult.LogonOk)
                {
                    // we did it...
                    this.LogonOk();
                }
                else
                    Alert.Show(response.Message);

            }, Alert.GetFailedHandler());
        }

        private void LogonOk()
        {
            // flip?
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.LogonOk));
                return;
            }

            // save...
            string username = this.textUsername.Text.Trim();
            if (this.checkRememberMe.Checked)
            {
                SimpleXmlPropertyBag settings = SixBookmarksRuntime.Current.Settings;
                settings[UsernameKey] = username;
                settings[PasswordKey] = this.textPassword.Text.Trim();
                settings.Save();
            }
            else
                this.ClearCredentials();

            // logon...
            SixBookmarksRuntime.Current.Logon(username);

            // do sync will come here...
            Sync sync = new Sync();
            sync.DoSync(delegate()
            {
                using(NavigatorForm form = new NavigatorForm())
                    form.ShowDialog();

            }, Alert.GetFailedHandler());
        }

        private void ClearCredentials()
        {
            // set...
            SimpleXmlPropertyBag settings = SixBookmarksRuntime.Current.Settings;
            if (settings.ContainsKey(UsernameKey))
                settings.Remove(UsernameKey);
            if (settings.ContainsKey(PasswordKey))
                settings.Remove(PasswordKey);

            // save...
            settings.Save();
        }

        private void LogonForm_Load(object sender, EventArgs e)
        {
            // load the settings...
            SimpleXmlPropertyBag settings = SixBookmarksRuntime.Current.Settings;
            if (settings.ContainsKey(UsernameKey) && settings.ContainsKey(PasswordKey))
            {
                this.textUsername.Text = settings[UsernameKey];
                this.textPassword.Text = settings[PasswordKey];

                // ok...
                this.DoLogon();
            }
        }
    }
}