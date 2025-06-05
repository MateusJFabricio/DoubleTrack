using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RangeSlider
{
    public partial class MVRangeSlider : UserControl
    {
        private const int border = 10;
        private string text;
        public string Label
        {
            get => text;
            set { text = value; Invalidate(); }
        }
            
        private bool innerRange = true;
        public bool InnerRange 
        { 
            get => innerRange;
            set
            {
                innerRange = value;
                Invalidate();
            }
        }
        private double min = 0;
        public double Min
        {
            get => min;
            set
            {
                if (min != value)
                {
                    min = Math.Round(value, 1);
                    Invalidate();
                }
            }
        }
        private double max = 100;
        public double Max
        {
            get => max;
            set
            {
                if (max != value)
                {
                    max = Math.Round(value, 1);
                    Invalidate();
                }
            }
        }
        private double valueStart = 20;
        public double ValueStart 
        { 
            get => valueStart;
            set
            {
                valueStart = Math.Round(value, 1);
                Invalidate();
            }
        }
        private double valueEnd = 20;
        public double ValueEnd 
        { 
            get => valueEnd; 
            set
            {
                valueEnd = Math.Round(value, 1);
                Invalidate();
            }
        }

        private bool draggingStart = false;
        private bool draggingEnd = false;

        public MVRangeSlider()
        {
            DoubleBuffered = true;
            InitializeComponent();
            this.MouseDown += MVRangeSlider_MouseDown;
            this.MouseMove += MVRangeSlider_MouseMove;
            this.MouseUp += MVRangeSlider_MouseUp;

            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            int width = this.Width - (border * 2);
            int height = this.Height;
            float startX = (float)((ValueStart - Min) / (Max - Min) * width) + border;
            float endX = (float)((ValueEnd - Min) / (Max - Min) * width) + border;

            // background bar
            g.FillRectangle(InnerRange ? Brushes.Gray : Brushes.Blue, border, height / 2 - 5, width, 10);

            // range selection
            g.FillRectangle(InnerRange ? Brushes.Blue : Brushes.Gray, startX, height / 2 - 5, endX - startX, 10);

            // thumbs
            g.FillEllipse(Brushes.Black, startX - 5, height / 2 - 10, 10, 20);
            g.FillEllipse(Brushes.Black, endX - 5, height / 2 - 10, 10, 20);

            //Values
            var startPoint = new Point((int)startX - (GetStringLenght(ValueStart.ToString()) / 2), (height / 2) - Font.Height - 10);
            var endPoint = new Point((int)endX - (GetStringLenght(ValueEnd.ToString()) / 2), (height / 2) - Font.Height - 10);
            var minPoint = new Point(border, (height / 2) + 10);
            var maxPoint = new Point(Width - border - GetStringLenght(Max.ToString()), (height / 2) + 10);

            g.DrawString(ValueStart.ToString(), Font, new SolidBrush(ForeColor), startPoint);
            g.DrawString(ValueEnd.ToString(), Font, new SolidBrush(ForeColor), endPoint);
            g.DrawString(Min.ToString(), Font, new SolidBrush(ForeColor), minPoint);
            g.DrawString(Max.ToString(), Font, new SolidBrush(ForeColor), maxPoint);

            //Label
            var labelPoint = new Point((Width / 2) - ((Label.Length * (int)Font.Size) / 2), Height / 2 + 10);
            g.DrawString(Label, Font, new SolidBrush(ForeColor), labelPoint);
        }
        private int GetStringLenght(string str)
        {
            return (int)(str.Length * Font.Size);
        }

        private void MVRangeSlider_MouseDown(object sender, MouseEventArgs e)
        {
            float width = this.Width - (border * 2);
            float startX = (float)((ValueStart - Min) / (Max - Min) * width) + border;
            float endX = (float)((ValueEnd - Min) / (Max - Min) * width) + border;
            float height = this.Height / 2;

            //In the bar
            if (Math.Abs(e.Y - height) < 7)
            {
                if (Math.Abs(e.X - startX) < 10) //Circle Start
                    draggingStart = true;
                else if (Math.Abs(e.X - endX) < 10) //Circle End
                    draggingEnd = true;
                else
                {
                    InnerRange = !InnerRange;
                    this.Invalidate();
                }
            }
        }

        private void MVRangeSlider_MouseMove(object sender, MouseEventArgs e)
        {
            if (!draggingStart && !draggingEnd) return;

            double newValue = Min + (e.X / (double)this.Width) * (Max - Min);
            newValue = Math.Max(Min, Math.Min(Max, newValue));

            if (draggingStart && newValue <= ValueEnd)
                ValueStart = newValue;
            else if (draggingEnd && newValue >= ValueStart)
                ValueEnd = newValue;

            this.Invalidate();
        }

        private void MVRangeSlider_MouseUp(object sender, MouseEventArgs e)
        {
            draggingStart = false;
            draggingEnd = false;
        }
    }

}
