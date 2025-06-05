namespace RangeSlider
{
    partial class FormTestDoubleSlider
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mvRangeSlider1 = new MVRangeSlider();
            SuspendLayout();
            // 
            // mvRangeSlider1
            // 
            mvRangeSlider1.BorderStyle = BorderStyle.FixedSingle;
            mvRangeSlider1.Font = new Font("Segoe UI", 9F);
            mvRangeSlider1.InnerRange = true;
            mvRangeSlider1.Label = "Componentee";
            mvRangeSlider1.Location = new Point(30, 33);
            mvRangeSlider1.Max = 100D;
            mvRangeSlider1.Min = 0D;
            mvRangeSlider1.Name = "mvRangeSlider1";
            mvRangeSlider1.Padding = new Padding(10);
            mvRangeSlider1.Size = new Size(344, 80);
            mvRangeSlider1.TabIndex = 0;
            mvRangeSlider1.ValueEnd = 40D;
            mvRangeSlider1.ValueStart = 20D;
            // 
            // FormTestDoubleSlider
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(633, 294);
            Controls.Add(mvRangeSlider1);
            Name = "FormTestDoubleSlider";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private MVRangeSlider mvRangeSlider1;
    }
}
