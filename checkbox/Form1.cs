namespace checkbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            string[] lines = File.ReadAllLines("checkboxes.txt");

            int yPosition = 10; 

          
            int HjärnKraft = 0;

            foreach (string line in lines)
            {
              
                string[] data = line.Split(':');

           
                if (data.Length >= 2)
                {
                 
                    CheckBox checkBox = new CheckBox();

               
                    checkBox.Text = data[0]; 

                    checkBox.Checked = (data[1] == "1"); 

                   
                    checkBox.Location = new System.Drawing.Point(10, yPosition);

                   
                    checkBox.Width = TextRenderer.MeasureText(checkBox.Text, checkBox.Font).Width + 20;

                    yPosition += checkBox.Height + 5;

                
                    checkBox.CheckedChanged += (s, ev) =>
                    {
                       
                        if (checkBox.Checked)
                        {
                           
                            HjärnKraft += int.Parse(data[1]);
                        }
                        else
                        {

                            HjärnKraft -= int.Parse(data[1]);
                        }

                       
                        label1.Text = "HjärnCeller: " + HjärnKraft;
                    };

                    this.Controls.Add(checkBox);
                }
            }
        }
    }
}
