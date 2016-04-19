using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Twitterizer;
using Facebook;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Extensions.MediaRss;
using Google.GData.YouTube;
using Google.YouTube;
using System.Windows.Threading;

namespace SNM
{
    /// <summary>
    /// Lógica de interacción para multiManager.xaml
    /// </summary>
    public partial class multiManager : UserControl
    {
        //twitter
        private bool twitterActivated = false;
        private OAuthTokens twitterTokens;
        public OAuthTokens TwitterTokens { private get { return twitterTokens; } set { twitterTokens = value; } }
        private TwitterUser homeUser;
        public TwitterUser HomeUser { private get { return homeUser; } set { homeUser = value; } }
        private bool firstLoad = true;
        private decimal topId;
        private DispatcherTimer twitterTimer;
        //twitter

        //youtube
        private bool youtubeActivated = false;
        private YouTubeRequest youtubeRequest;
        public YouTubeRequest YoutubeRequest { private get { return youtubeRequest; } set { youtubeRequest = value; } }
        private DispatcherTimer youtubeTimer;
        private string feedUrl = "http://gdata.youtube.com/feeds/api/users/default/newsubscriptionvideos?&max-results=50";
        //youtube

        //facebook
        private bool facebookActivated = false;
        private string accessToken = "";
        public string AccessToken { private get { return accessToken; } set { accessToken = value; } }
        private DispatcherTimer facebookTimer;
        //facebook


        public multiManager(bool facebookActivated, bool twitterActivated, bool youtubeActivated)
        {
            this.facebookActivated = facebookActivated;
            this.twitterActivated = twitterActivated;
            this.youtubeActivated = youtubeActivated;
            InitializeComponent();
            if (!this.facebookActivated)
            {
                tabPestañas.Items.Remove(tabWall);
            }
            if (!this.twitterActivated)
            {
                tabPestañas.Items.Remove(tabTimeline);
            }
            if (!this.youtubeActivated)
            {
                tabPestañas.Items.Remove(tabYoutube);
            }
        }

        public void initializeMultiManager()
        {
            if (facebookActivated)
            {
                lstMuroFill();
                facebookTimer = new DispatcherTimer(DispatcherPriority.Normal);
                facebookTimer.Interval = TimeSpan.FromMinutes(5);
                facebookTimer.Tick += new EventHandler(facebookTimer_Tick);
                facebookTimer.Start();
            }
            if (twitterActivated)
            {
                lstTimelineFill();
                twitterTimer = new DispatcherTimer(DispatcherPriority.Normal);
                twitterTimer.Interval = TimeSpan.FromSeconds(15);
                twitterTimer.Tick += new EventHandler(twitterTimer_Tick);
                twitterTimer.Start();
            }
            if (youtubeActivated)
            {
                lstSubscripcionesFill();
                youtubeTimer = new DispatcherTimer(DispatcherPriority.Normal);
                youtubeTimer.Interval = TimeSpan.FromMinutes(10);
                youtubeTimer.Tick += new EventHandler(youtubeTimer_Tick);
                youtubeTimer.Start();
            }
        }

        private void twitterTimer_Tick(object sender, EventArgs e)
        {
            lstTimelineFill();
        }

        private void youtubeTimer_Tick(object sender, EventArgs e)
        {
            lstSubscripcionesFill();
        }

        void facebookTimer_Tick(object sender, EventArgs e)
        {
            lstMuroFill();
        }

        private void lstMuroFill()
        {
            var fb = new FacebookClient(accessToken);
            dynamic result = fb.Get("me/feed");
            lstWall.Items.Clear();
            foreach (dynamic post in result.data)
            {
                lstWall.Items.Add(new facebookGenericPost(post, accessToken));
            }
        }

        private void lstSubscripcionesFill()
        {
            lstSubscripciones.Items.Clear();
            Feed<Video> subsFeed = youtubeRequest.Get<Video>(new Uri(feedUrl));
            foreach (Video sub in subsFeed.Entries)
            {
                lstSubscripciones.Items.Add(new userControlYoutubeVideoEntry(sub));
            }
        }

        private void lstTimelineFill()
        {
            TimelineOptions opciones = new TimelineOptions();
            opciones.Count = 20;

            if (firstLoad)
            {
                TwitterResponse<TwitterStatusCollection> respuestaColeccion = TwitterTimeline.HomeTimeline(twitterTokens, opciones);
                if (respuestaColeccion.Result == RequestResult.Success)
                {
                    bool firstTweet = true;
                    TwitterStatusCollection coleccion = respuestaColeccion.ResponseObject;
                    foreach (TwitterStatus tweet in coleccion)
                    {
                        try
                        {
                            if (firstTweet)
                            {
                                topId = tweet.Id;
                                lstTimeline.Items.Add(new gridTweet(tweet, twitterTokens, homeUser));
                                firstTweet = false;
                            }
                            else
                            {
                                lstTimeline.Items.Add(new gridTweet(tweet, twitterTokens, homeUser));
                            }
                        }
                        catch (Exception e)
                        {
                            new Warning("Hubo un error al intentar mostrar el timeline:\n" + e.Message).ShowDialog();
                            return;
                        }
                    }
                    firstLoad = false;
                    firstTweet = true;
                }
                else
                {
                    new Warning("Error al intentar recolectar el timeline: \n\n" + respuestaColeccion.Result.ToString()).ShowDialog();
                }
            }
            else
            {
                opciones.SinceStatusId = topId;
                TwitterResponse<TwitterStatusCollection> respuestaColeccion = TwitterTimeline.HomeTimeline(twitterTokens, opciones);
                if (respuestaColeccion.Result == RequestResult.Success)
                {
                    TwitterStatusCollection coleccion = respuestaColeccion.ResponseObject;
                    int inversor = 0;
                    foreach (TwitterStatus tweet in coleccion)
                    {
                        try
                        {
                            if (inversor == 0)
                            {
                                topId = tweet.Id;
                            }
                            lstTimeline.Items.Insert(inversor, new gridTweet(tweet, twitterTokens, homeUser));
                            inversor++;
                        }
                        catch (Exception e)
                        {
                            new Warning("Hubo un error al intentar mostrar el timeline:\n" + e.Message).ShowDialog();
                            return;
                        }
                    }
                }
                else
                {
                    new Warning("Error al intentar recolectar el timeline: \n\n" + respuestaColeccion.Result.ToString()).ShowDialog();
                }
                
            }
        }

        private void gridMultiManager_MouseUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void tabTimeline_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Space)
            {
                new Update(twitterTokens, homeUser).ShowDialog();
            }
        }

        private void tabWall_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Space)
            {
                new facebookGenericUpdate(accessToken).ShowDialog();
            }
        }

        private void tabYoutube_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.Key == Key.Space)
            {
                new youtubeUploader(youtubeRequest).ShowDialog();
            }
            else if (e.Key == Key.B)
            {
                new youtubeSearch(youtubeRequest).ShowDialog();
            }
        }
    }
}
