
namespace lab9
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.radio = new System.Windows.Forms.Button();
            this.toggleStar = new System.Windows.Forms.Button();
            this.toggleBaubles = new System.Windows.Forms.Button();
            this.toggleLamps = new System.Windows.Forms.Button();
            this.toggleChains = new System.Windows.Forms.Button();
            this.toggleGifts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.Location = new System.Drawing.Point(13, 29);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(815, 984);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.CanvasPaint);
            // 
            // radio
            // 
            this.radio.Location = new System.Drawing.Point(13, 0);
            this.radio.Name = "radio";
            this.radio.Size = new System.Drawing.Size(133, 23);
            this.radio.TabIndex = 1;
            this.radio.Text = "Radio Turbo koledy";
            this.radio.UseVisualStyleBackColor = true;
            this.radio.Click += new System.EventHandler(this.radio_Click);
            // 
            // toggleStar
            // 
            this.toggleStar.Location = new System.Drawing.Point(153, 0);
            this.toggleStar.Name = "toggleStar";
            this.toggleStar.Size = new System.Drawing.Size(75, 23);
            this.toggleStar.TabIndex = 2;
            this.toggleStar.Text = "gwiazda";
            this.toggleStar.UseVisualStyleBackColor = true;
            this.toggleStar.Click += new System.EventHandler(this.toggleStar_Click);
            // 
            // toggleBaubles
            // 
            this.toggleBaubles.Location = new System.Drawing.Point(235, -1);
            this.toggleBaubles.Name = "toggleBaubles";
            this.toggleBaubles.Size = new System.Drawing.Size(75, 23);
            this.toggleBaubles.TabIndex = 3;
            this.toggleBaubles.Text = "bombki";
            this.toggleBaubles.UseVisualStyleBackColor = true;
            this.toggleBaubles.Click += new System.EventHandler(this.toggleBaubles_Click);
            // 
            // toggleLamps
            // 
            this.toggleLamps.Location = new System.Drawing.Point(317, 0);
            this.toggleLamps.Name = "toggleLamps";
            this.toggleLamps.Size = new System.Drawing.Size(75, 23);
            this.toggleLamps.TabIndex = 4;
            this.toggleLamps.Text = "światła";
            this.toggleLamps.UseVisualStyleBackColor = true;
            this.toggleLamps.Click += new System.EventHandler(this.toggleLamps_Click);
            // 
            // toggleChains
            // 
            this.toggleChains.Location = new System.Drawing.Point(398, 0);
            this.toggleChains.Name = "toggleChains";
            this.toggleChains.Size = new System.Drawing.Size(75, 23);
            this.toggleChains.TabIndex = 5;
            this.toggleChains.Text = "łańcuchy";
            this.toggleChains.UseVisualStyleBackColor = true;
            this.toggleChains.Click += new System.EventHandler(this.toggleChains_Click);
            // 
            // toggleGifts
            // 
            this.toggleGifts.Location = new System.Drawing.Point(479, 0);
            this.toggleGifts.Name = "toggleGifts";
            this.toggleGifts.Size = new System.Drawing.Size(75, 23);
            this.toggleGifts.TabIndex = 6;
            this.toggleGifts.Text = "prezenty";
            this.toggleGifts.UseVisualStyleBackColor = true;
            this.toggleGifts.Click += new System.EventHandler(this.toggleGifts_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 961);
            this.Controls.Add(this.toggleGifts);
            this.Controls.Add(this.toggleChains);
            this.Controls.Add(this.toggleLamps);
            this.Controls.Add(this.toggleBaubles);
            this.Controls.Add(this.toggleStar);
            this.Controls.Add(this.radio);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button radio;
        private System.Windows.Forms.Button toggleStar;
        private System.Windows.Forms.Button toggleBaubles;
        private System.Windows.Forms.Button toggleLamps;
        private System.Windows.Forms.Button toggleChains;
        private System.Windows.Forms.Button toggleGifts;
    }
}

