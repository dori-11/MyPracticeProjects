namespace ImageViewer
{
    partial class label1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.btnFlip = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.tkBrightness = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tkContrast = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tkSaturation = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRotateR = new System.Windows.Forms.Button();
            this.btnRotateL = new System.Windows.Forms.Button();
            this.bthFlip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkContrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkSaturation)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(113, 53);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(480, 374);
            this.picCanvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(830, 100);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(80, 80);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "이미지 열기\r\n";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(298, 444);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(97, 12);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "선택된 파일 없음";
            // 
            // btnGrayscale
            // 
            this.btnGrayscale.Location = new System.Drawing.Point(830, 190);
            this.btnGrayscale.Name = "btnGrayscale";
            this.btnGrayscale.Size = new System.Drawing.Size(80, 80);
            this.btnGrayscale.TabIndex = 3;
            this.btnGrayscale.Text = "흑백전환";
            this.btnGrayscale.UseVisualStyleBackColor = true;
            this.btnGrayscale.Click += new System.EventHandler(this.btnGrayscale_Click);
            // 
            // btnFlip
            // 
            this.btnFlip.Location = new System.Drawing.Point(920, 190);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(80, 80);
            this.btnFlip.TabIndex = 5;
            this.btnFlip.Text = "좌우 대칭";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(830, 467);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(170, 80);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(920, 100);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(80, 80);
            this.btnInvert.TabIndex = 7;
            this.btnInvert.Text = "색상 반전";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // tkBrightness
            // 
            this.tkBrightness.Location = new System.Drawing.Point(113, 468);
            this.tkBrightness.Maximum = 100;
            this.tkBrightness.Minimum = -100;
            this.tkBrightness.Name = "tkBrightness";
            this.tkBrightness.Size = new System.Drawing.Size(480, 45);
            this.tkBrightness.TabIndex = 8;
            this.tkBrightness.Scroll += new System.EventHandler(this.tkBrightness_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 479);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "밝기 조절";
            // 
            // tkContrast
            // 
            this.tkContrast.Location = new System.Drawing.Point(113, 494);
            this.tkContrast.Maximum = 100;
            this.tkContrast.Minimum = -100;
            this.tkContrast.Name = "tkContrast";
            this.tkContrast.Size = new System.Drawing.Size(480, 45);
            this.tkContrast.TabIndex = 10;
            this.tkContrast.Scroll += new System.EventHandler(this.tkContrast_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "대비 조절";
            // 
            // tkSaturation
            // 
            this.tkSaturation.Location = new System.Drawing.Point(113, 519);
            this.tkSaturation.Maximum = 200;
            this.tkSaturation.Name = "tkSaturation";
            this.tkSaturation.Size = new System.Drawing.Size(480, 45);
            this.tkSaturation.TabIndex = 12;
            this.tkSaturation.Value = 100;
            this.tkSaturation.Scroll += new System.EventHandler(this.tkSaturation_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 527);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "채도 조절";
            // 
            // btnRotateR
            // 
            this.btnRotateR.Location = new System.Drawing.Point(920, 280);
            this.btnRotateR.Name = "btnRotateR";
            this.btnRotateR.Size = new System.Drawing.Size(80, 80);
            this.btnRotateR.TabIndex = 14;
            this.btnRotateR.Text = "90도 우회전";
            this.btnRotateR.UseVisualStyleBackColor = true;
            this.btnRotateR.Click += new System.EventHandler(this.btnRotateR_Click);
            // 
            // btnRotateL
            // 
            this.btnRotateL.Location = new System.Drawing.Point(830, 280);
            this.btnRotateL.Name = "btnRotateL";
            this.btnRotateL.Size = new System.Drawing.Size(80, 80);
            this.btnRotateL.TabIndex = 15;
            this.btnRotateL.Text = "90도 좌회전";
            this.btnRotateL.UseVisualStyleBackColor = true;
            this.btnRotateL.Click += new System.EventHandler(this.btnRotateL_Click);
            // 
            // bthFlip
            // 
            this.bthFlip.Location = new System.Drawing.Point(830, 370);
            this.bthFlip.Name = "bthFlip";
            this.bthFlip.Size = new System.Drawing.Size(80, 80);
            this.bthFlip.TabIndex = 16;
            this.bthFlip.Text = "좌우 반전";
            this.bthFlip.UseVisualStyleBackColor = true;
            this.bthFlip.Click += new System.EventHandler(this.bthFlip_Click);
            // 
            // label1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.bthFlip);
            this.Controls.Add(this.btnRotateL);
            this.Controls.Add(this.btnRotateR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tkSaturation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tkContrast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tkBrightness);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFlip);
            this.Controls.Add(this.btnGrayscale);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.picCanvas);
            this.Name = "label1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkContrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tkSaturation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnGrayscale;
        private System.Windows.Forms.Button btnFlip;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.TrackBar tkBrightness;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar tkContrast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tkSaturation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRotateR;
        private System.Windows.Forms.Button btnRotateL;
        private System.Windows.Forms.Button bthFlip;
    }
}

