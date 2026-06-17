namespace CalculatorApp;

public partial class Form1 : Form
{
    TextBox display;

    double firstNumber = 0;
    string operation = "";

    public Form1()
    {
        InitializeComponent();

        Text = "DotNET Calculator";
        Width = 300;
        Height = 450;

        display = new TextBox();
        display.Width = 250;
        display.Top = 20;
        display.Left = 10;
        display.Font = new System.Drawing.Font("Arial", 20);
        Controls.Add(display);

        string[] buttons =
        {
            "7", "8", "9", "/",
            "4", "5", "6", "*",
            "1", "2", "3", "-",
            "0", ".", "=", "+"
        };

        int x = 10, y = 70;
        foreach (var text in buttons)
        {
            Button b = new Button();
            b.Text = text;
            b.Width = 55;
            b.Height = 55;
            b.Left = x;
            b.Top = y;

            b.Font = new System.Drawing.Font("Arial", 16);
            b.Click += ButtonClick;
            Controls.Add(b);

            x += 60;
            if (x > 200)
            {
                x = 10;
                y += 60;
            }
        }

        Button clearButton = new Button();
        clearButton.Text = "Clear";
        clearButton.Width = 115;
        clearButton.Height = 55;
        clearButton.Left = 10;
        clearButton.Top = y;

        clearButton.Font = new System.Drawing.Font("Arial", 16);
        clearButton.Click += ClearButtonClick;
        Controls.Add(clearButton);
    } // end-constructor

    void ButtonClick(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        string value = b.Text;

        if (double.TryParse(value, out _)
            || value == ".")
        {
            display.Text += value;
            return;
        }

        if (value == "=")
        {
            Calculate();
            return;
        }
        
        firstNumber = double.Parse(display.Text);
        operation = value;
        display.Clear();
    } // end-ButtonClick


    void ClearButtonClick(object sender, EventArgs e)
    {
        display.Clear();
        firstNumber = 0;
        operation = "";
    }


    void Calculate()
    {
        double second = double.Parse(display.Text);
        double result = operation switch
        {
            "+" => firstNumber + second,
            "-" => firstNumber - second,
            "*" => firstNumber * second,
            "/" => firstNumber / second,
            _ => 0
        };

        display.Text = result.ToString();
    } // end-Calculate

} // end-class