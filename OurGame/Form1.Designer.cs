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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.Player.Image = global::OurGame.Properties.Resources.cowboy;
            this.Player.InitialImage = global::OurGame.Properties.Resources.cowboy;
            resources.ApplyResources(this.Player, "Player");
            this.Player.Name = "Player";
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
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Name = "label3";
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.ExitButton.ForeColor = System.Drawing.Color.Red;
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::OurGame.Properties.Resources.mFYke_Xstl0;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Player);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
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

