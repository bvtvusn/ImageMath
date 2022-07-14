namespace ImageMath
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxResult = new System.Windows.Forms.PictureBox();
            this.picInput = new System.Windows.Forms.PictureBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtError = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEditPolygon = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numGifFps = new System.Windows.Forms.NumericUpDown();
            this.numGifDuration = new System.Windows.Forms.NumericUpDown();
            this.numGifEnd = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numGifStart = new System.Windows.Forms.NumericUpDown();
            this.btnWriteGif = new System.Windows.Forms.Button();
            this.panError = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numOutputHeight = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.numOutputWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbExpression = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpInputImage = new System.Windows.Forms.GroupBox();
            this.grpOutputImage = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressBar2 = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGifFps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGifDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGifEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGifStart)).BeginInit();
            this.panError.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputWidth)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grpInputImage.SuspendLayout();
            this.grpOutputImage.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxResult
            // 
            this.pictureBoxResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxResult.Location = new System.Drawing.Point(3, 18);
            this.pictureBoxResult.Name = "pictureBoxResult";
            this.pictureBoxResult.Size = new System.Drawing.Size(610, 261);
            this.pictureBoxResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxResult.TabIndex = 0;
            this.pictureBoxResult.TabStop = false;
            // 
            // picInput
            // 
            this.picInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picInput.Location = new System.Drawing.Point(3, 18);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(615, 261);
            this.picInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picInput.TabIndex = 1;
            this.picInput.TabStop = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnCalculate.Location = new System.Drawing.Point(6, 89);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(706, 69);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtError
            // 
            this.txtError.Enabled = false;
            this.txtError.Location = new System.Drawing.Point(116, 3);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(243, 22);
            this.txtError.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.panError);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.cmbExpression);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCalculate);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1241, 164);
            this.panel1.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEditPolygon);
            this.groupBox3.Location = new System.Drawing.Point(715, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(175, 47);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Expmod";
            // 
            // btnEditPolygon
            // 
            this.btnEditPolygon.Location = new System.Drawing.Point(6, 18);
            this.btnEditPolygon.Name = "btnEditPolygon";
            this.btnEditPolygon.Size = new System.Drawing.Size(163, 23);
            this.btnEditPolygon.TabIndex = 11;
            this.btnEditPolygon.Text = "Edit Polygon";
            this.btnEditPolygon.UseVisualStyleBackColor = true;
            this.btnEditPolygon.Click += new System.EventHandler(this.btnEditPolygon_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.numGifFps);
            this.groupBox2.Controls.Add(this.numGifDuration);
            this.groupBox2.Controls.Add(this.numGifEnd);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.numGifStart);
            this.groupBox2.Controls.Add(this.btnWriteGif);
            this.groupBox2.Location = new System.Drawing.Point(896, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 126);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "GIF";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "Changes \"#\" for each frame";
            // 
            // numGifFps
            // 
            this.numGifFps.DecimalPlaces = 1;
            this.numGifFps.Location = new System.Drawing.Point(256, 69);
            this.numGifFps.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numGifFps.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numGifFps.Name = "numGifFps";
            this.numGifFps.Size = new System.Drawing.Size(77, 22);
            this.numGifFps.TabIndex = 28;
            this.numGifFps.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numGifDuration
            // 
            this.numGifDuration.DecimalPlaces = 1;
            this.numGifDuration.Location = new System.Drawing.Point(256, 46);
            this.numGifDuration.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numGifDuration.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numGifDuration.Name = "numGifDuration";
            this.numGifDuration.Size = new System.Drawing.Size(77, 22);
            this.numGifDuration.TabIndex = 28;
            this.numGifDuration.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numGifEnd
            // 
            this.numGifEnd.DecimalPlaces = 3;
            this.numGifEnd.Location = new System.Drawing.Point(92, 69);
            this.numGifEnd.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numGifEnd.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numGifEnd.Name = "numGifEnd";
            this.numGifEnd.Size = new System.Drawing.Size(77, 22);
            this.numGifEnd.TabIndex = 28;
            this.numGifEnd.Value = new decimal(new int[] {
            3142,
            0,
            0,
            196608});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "End Value:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 16);
            this.label6.TabIndex = 27;
            this.label6.Text = "Start Value:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "FPS:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Duration:";
            // 
            // numGifStart
            // 
            this.numGifStart.DecimalPlaces = 3;
            this.numGifStart.Location = new System.Drawing.Point(92, 46);
            this.numGifStart.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numGifStart.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.numGifStart.Name = "numGifStart";
            this.numGifStart.Size = new System.Drawing.Size(77, 22);
            this.numGifStart.TabIndex = 26;
            this.numGifStart.Value = new decimal(new int[] {
            31415,
            0,
            0,
            -2147221504});
            // 
            // btnWriteGif
            // 
            this.btnWriteGif.Location = new System.Drawing.Point(14, 97);
            this.btnWriteGif.Name = "btnWriteGif";
            this.btnWriteGif.Size = new System.Drawing.Size(319, 23);
            this.btnWriteGif.TabIndex = 25;
            this.btnWriteGif.Text = "Create GIF";
            this.btnWriteGif.UseVisualStyleBackColor = true;
            this.btnWriteGif.Click += new System.EventHandler(this.btnWriteGif_Click);
            // 
            // panError
            // 
            this.panError.Controls.Add(this.label2);
            this.panError.Controls.Add(this.txtError);
            this.panError.Location = new System.Drawing.Point(332, 12);
            this.panError.Name = "panError";
            this.panError.Size = new System.Drawing.Size(362, 28);
            this.panError.TabIndex = 23;
            this.panError.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "expression error:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numOutputHeight);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.numOutputWidth);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(715, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 72);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output image dimensions";
            // 
            // numOutputHeight
            // 
            this.numOutputHeight.Location = new System.Drawing.Point(6, 21);
            this.numOutputHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numOutputHeight.Name = "numOutputHeight";
            this.numOutputHeight.Size = new System.Drawing.Size(67, 22);
            this.numOutputHeight.TabIndex = 18;
            this.numOutputHeight.Value = new decimal(new int[] {
            576,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Use input size";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numOutputWidth
            // 
            this.numOutputWidth.Location = new System.Drawing.Point(93, 21);
            this.numOutputWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numOutputWidth.Name = "numOutputWidth";
            this.numOutputWidth.Size = new System.Drawing.Size(67, 22);
            this.numOutputWidth.TabIndex = 18;
            this.numOutputWidth.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "x";
            // 
            // cmbExpression
            // 
            this.cmbExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExpression.FormattingEnabled = true;
            this.cmbExpression.Items.AddRange(new object[] {
            "x*x",
            "expmod(skew(log(x)-10,1),1,1)",
            "expmod(skew(log(x)-11.8,2),1,1)",
            "exp(mod(log(x)+10,1))",
            "exp(mod(skew(log(x),1.1)+10,1.1))",
            "log(exp(x*x))",
            "expmod(log(x)-10,0.5,1.1)",
            "rotate(x,pi()/2)",
            "exp(mod(sin(log(x))+10,1))",
            "exp((mod(log(sin(x))+10,1)))",
            "rotate(log(x)*0.999,-pi()/2)",
            "rotate(exp(log(x)-1.2) *x,-pi()/2)",
            "x*im(1)+x",
            "real(x)+im(x)",
            "x + swap(0.05*sin(real(x)*10))",
            "x + swap(0.05*sin(real(x)*10)) +(0.05*sin(swap(im(x))*10))",
            "-abs(x)+im(x)",
            "sqrt(x*x)",
            "sqrt(sqrt(rotate(x,pi()/2)*rotate(x,pi()/2))*rotate(sqrt(x*x),pi()/2))",
            "sqrt(rotate(log(x),-pi()/2)*rotate(log(x),-pi()/2))",
            "rotate(sqrt(log(x)*log(x)),-pi()/2)",
            "rotate(sqrt(rotate(log(x)*log(x),pi()/2)),-pi()/2)",
            "rotate(2*log(sqrt(x*x)),-pi()/2)",
            "sqrt(real(x)*real(x))+im(x)",
            "rotate(2*log(sqrt(real(x)*real(x))+im(x)),-pi()/2)",
            "log(sin(x))",
            "sin(swap(log(swap(x))))",
            "sqrt(cos(x))",
            "sqrt(cos(x)+1)",
            "exp(mirror(log(x)))",
            "log(sin(-1+log(x)))",
            "rotate(log(x),pi()/2*3-0.015)*0.98",
            "mirror(x)+real(mirror(x))-pi()",
            "mod(x,2)*1.7",
            "mod(x+1000+#, pi()*2)-pi()",
            "abs(real(mod(100+#*2+x,6.28*2)-6.28))-3.14+im(x)",
            "mod(log(exp(pow(x+3.14,2))),6.28)-3.14",
            "mod(log(exp(pow(x,2)+#))+pi()*4,6.28)-pi()",
            "mod(sqrt(x*x)+3.14+#,6.28)-3.14",
            "mod(exp(mod(sin(log(x))+14,1))+6.28+#,6.28)-3.14"});
            this.cmbExpression.Location = new System.Drawing.Point(6, 51);
            this.cmbExpression.Name = "cmbExpression";
            this.cmbExpression.Size = new System.Drawing.Size(706, 37);
            this.cmbExpression.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Transform expression:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1241, 28);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Location = new System.Drawing.Point(3, 279);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(610, 28);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save image";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLoad.Location = new System.Drawing.Point(3, 279);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(615, 28);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load New Image";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 164);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grpInputImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpOutputImage);
            this.splitContainer1.Size = new System.Drawing.Size(1241, 310);
            this.splitContainer1.SplitterDistance = 621;
            this.splitContainer1.TabIndex = 9;
            // 
            // grpInputImage
            // 
            this.grpInputImage.Controls.Add(this.picInput);
            this.grpInputImage.Controls.Add(this.btnLoad);
            this.grpInputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInputImage.Location = new System.Drawing.Point(0, 0);
            this.grpInputImage.Name = "grpInputImage";
            this.grpInputImage.Size = new System.Drawing.Size(621, 310);
            this.grpInputImage.TabIndex = 2;
            this.grpInputImage.TabStop = false;
            this.grpInputImage.Text = "Input Image";
            // 
            // grpOutputImage
            // 
            this.grpOutputImage.Controls.Add(this.pictureBoxResult);
            this.grpOutputImage.Controls.Add(this.btnSave);
            this.grpOutputImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpOutputImage.Location = new System.Drawing.Point(0, 0);
            this.grpOutputImage.Name = "grpOutputImage";
            this.grpOutputImage.Size = new System.Drawing.Size(616, 310);
            this.grpOutputImage.TabIndex = 1;
            this.grpOutputImage.TabStop = false;
            this.grpOutputImage.Text = "Output Image";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripProgressBar2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 474);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1241, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 18);
            // 
            // toolStripProgressBar2
            // 
            this.toolStripProgressBar2.Name = "toolStripProgressBar2";
            this.toolStripProgressBar2.Size = new System.Drawing.Size(100, 18);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 500);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ImageMath";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGifFps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGifDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGifEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numGifStart)).EndInit();
            this.panError.ResumeLayout(false);
            this.panError.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOutputWidth)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grpInputImage.ResumeLayout(false);
            this.grpOutputImage.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxResult;
        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnEditPolygon;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbExpression;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.GroupBox grpInputImage;
        private System.Windows.Forms.GroupBox grpOutputImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numOutputHeight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numOutputWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panError;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Button btnWriteGif;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numGifFps;
        private System.Windows.Forms.NumericUpDown numGifDuration;
        private System.Windows.Forms.NumericUpDown numGifEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numGifStart;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar2;
    }
}

