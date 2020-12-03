namespace OurGame
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.time_cloud = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.LeftMove = new System.Windows.Forms.Timer(this.components);
            this.RightMove = new System.Windows.Forms.Timer(this.components);
            this.UpMove = new System.Windows.Forms.Timer(this.components);
            this.DownMove = new System.Windows.Forms.Timer(this.components);
            this.MoveBulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.tEnemy = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // time_cloud
            // 
            this.time_cloud.Enabled = true;
            this.time_cloud.Interval = 10;
            this.time_cloud.Tick += new System.EventHandler(this.time_cloud_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = global::OurGame.Properties.Resources.stay1;
            this.Player.Location = new System.Drawing.Point(497, 434);
            this.Player.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(125, 121);
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // LeftMove
            // 
            this.LeftMove.Interval = 10;
            this.LeftMove.Tick += new System.EventHandler(this.LeftMove_Tick);
            // 
            // RightMove
            // 
            this.RightMove.Interval = 10;
            this.RightMove.Tick += new System.EventHandler(this.RightMove_Tick);
            // 
            // UpMove
            // 
            this.UpMove.Interval = 10;
            this.UpMove.Tick += new System.EventHandler(this.UpMove_Tick);
            // 
            // DownMove
            // 
            this.DownMove.Interval = 10;
            this.DownMove.Tick += new System.EventHandler(this.DownMove_Tick);
            // 
            // MoveBulletsTimer
            // 
            this.MoveBulletsTimer.Enabled = true;
            this.MoveBulletsTimer.Interval = 10;
            this.MoveBulletsTimer.Tick += new System.EventHandler(this.MoveBulletsTimer_Tick);
            // 
            // tEnemy
            // 
            this.tEnemy.Enabled = true;
            this.tEnemy.Interval = 10;
            this.tEnemy.Tick += new System.EventHandler(this.tEnemy_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(743, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 113);
            this.label1.TabIndex = 2;
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(1025, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 66);
            this.label2.TabIndex = 3;
            this.label2.Text = "Score";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 27.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(1177, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 66);
            this.label3.TabIndex = 4;
            this.label3.Text = "00";
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(497, 314);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(125, 52);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Visible = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::OurGame.Properties.Resources.background_01;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1285, 729);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Player);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1285, 729);
            this.MinimumSize = new System.Drawing.Size(1285, 729);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer time_cloud;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer LeftMove;
        private System.Windows.Forms.Timer RightMove;
        private System.Windows.Forms.Timer UpMove;
        private System.Windows.Forms.Timer DownMove;
        private System.Windows.Forms.Timer MoveBulletsTimer;
        private System.Windows.Forms.Timer tEnemy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ExitButton;
    }
}

