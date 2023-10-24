using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;
using System.Drawing.Printing;

namespace webexp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public System.Windows.Forms.WebBrowser web = new WebBrowser();

        public List<string> file = new List<string>();
        public string a = Application.ExecutablePath;
        public int current = 0;
        public int webcontrolnumber = 0;
        public string x = "";
        public bool addFilele()
        {
            file.Add("1280px-romania_regiuni_dezvoltare.svg__0.png");
            file.Add("2000px-romania_counties_1930-2008-svg.png");

            file.Add("23560.svg");

            file.Add("78714559l.jpg");

            file.Add("Coat_of_arms_of_Romania.svg");

            file.Add("Greater_Romania_ES.svg");

            file.Add("ro15instante-768x513.jpg");

            file.Add("Romania, _administrative_divisions_-_XY.svg");

            file.Add("Romania_historic_regions.svg");

            file.Add("Romania_location_map.svg");

            file.Add("Romania_Municipalities_Map.svg");

            file.Add("Romania_Regions_map.svg");

            file.Add("Romania_Towns_Map.svg");


            return true;
        }

        public bool navTo()
        {
            web.Dispose();
            web = new WebBrowser();


            int cnr = this.Controls.Count;

            webcontrolnumber = cnr;

            this.Controls.Add(web);
            web.Show();

            web.ScrollBarsEnabled = true;


            web.Left = 0;
            web.Top = 0;
            web.Width = 52800;
            web.Height = 3600;


            web.Navigate("imagini\\emtpy.html");

            Text = ":" + a + "imagini\\" + file[current].ToString();

            if (areSVGs(file[current].ToString()) == true)
            {
                web.Navigate(a + "imagini\\" + file[current].ToString());
                return true;
            }
            else
            {
               
                web.Navigate("imagini\\imaginile.html");

                 x = "<html style = 'height: 100%;' >";
                x += "<head >";
                x +=  "<title > fila </title >";
                x += "</head >";
                x += "<body style = 'margin: 0px; height: 100%; background-color: rgb(14, 14, 14);' >";
                x += "<img name = 'imgx' id = 'imgx' src ='" + a + "imagini\\" + file[current].ToString() + "' width = '942' height = '628' >";
                x += "</body >";
                x += "</html >";
                web.DocumentCompleted +=  new WebBrowserDocumentCompletedEventHandler(writetohtml);

                
               

                return true;
            }
            
        }

        public void writetohtml(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (areSVGs(file[current].ToString()) == true)
            {
                web.Navigate(a + "imagini\\" + file[current].ToString());

            }
            else
            {
               
                web.Document.Write(x);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;



            

            addFilele();


            Text = a;

            a = a.Substring(0, a.Length - (10)); //10 is webexp.exe lenght of this string who is the name of the app

           

            navTo();
            
            




        }


        public bool areSVGs(string s )
        {

            if (s.Substring(s.Length - 3, 3) == "SVG" || s.Substring(s.Length - 3, 3) == "svg")
            {
                return true;
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls[webcontrolnumber].Top -= 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls[webcontrolnumber].Top += 10;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (current != 0) { current -= 1; }
           


            navTo();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (current != file.Count) { current += 1; }
            

            navTo();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Controls[webcontrolnumber].Left -= 10;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Controls[webcontrolnumber].Left += 10;
        }
    }
}