using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facebook;

namespace SNM
{
    public partial class facebookLoginForm : Form
    {
        private readonly Uri _loginUrl;
        public FacebookOAuthResult FacebookOAuthResult { get; private set; }

        public facebookLoginForm(string appId, string extendedPermissions)
        {
            var oauthClient = new FacebookOAuthClient { AppId = appId };
            IDictionary<string, object> loginParameters = new Dictionary<string, object>();
            loginParameters["response_type"] = "token";
            loginParameters["display"] = "popup";
            loginParameters["scope"] = extendedPermissions;
            _loginUrl = oauthClient.GetLoginUrl(loginParameters);
            InitializeComponent();
        }

        private void facebookLoginForm_Load(object sender, EventArgs e)
        {
            wbFacebookLoginPopup.Navigate(_loginUrl.AbsoluteUri);
        }

        private void wbFacebookLoginPopup_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            FacebookOAuthResult oauthResult;
            if (FacebookOAuthResult.TryParse(e.Url, out oauthResult))
            {
                this.FacebookOAuthResult = oauthResult;
                this.Close();
            }
            else
            {
                this.FacebookOAuthResult = null;
            }
        }
    }
}
