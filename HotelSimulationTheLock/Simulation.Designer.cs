﻿namespace HotelSimulationTheLock
{
    partial class Simulation
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
            this._roomsStatus = new System.Windows.Forms.RichTextBox();
            this._maidStatus = new System.Windows.Forms.RichTextBox();
            this._guestStatus = new System.Windows.Forms.RichTextBox();
            this._restaurantStatus = new System.Windows.Forms.RichTextBox();
            this._fitnessStatus = new System.Windows.Forms.RichTextBox();
            this._poolStatus = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // _roomsStatus
            // 
            this._roomsStatus.Location = new System.Drawing.Point(1023, 98);
            this._roomsStatus.Name = "_roomsStatus";
            this._roomsStatus.Size = new System.Drawing.Size(159, 399);
            this._roomsStatus.TabIndex = 0;
            this._roomsStatus.Text = "";
            // 
            // _maidStatus
            // 
            this._maidStatus.Location = new System.Drawing.Point(1207, 98);
            this._maidStatus.Name = "_maidStatus";
            this._maidStatus.Size = new System.Drawing.Size(94, 260);
            this._maidStatus.TabIndex = 1;
            this._maidStatus.Text = "";
            // 
            // _guestStatus
            // 
            this._guestStatus.Location = new System.Drawing.Point(1324, 98);
            this._guestStatus.Name = "_guestStatus";
            this._guestStatus.Size = new System.Drawing.Size(185, 260);
            this._guestStatus.TabIndex = 2;
            this._guestStatus.Text = "";
            // 
            // _restaurantStatus
            // 
            this._restaurantStatus.Location = new System.Drawing.Point(1023, 523);
            this._restaurantStatus.Name = "_restaurantStatus";
            this._restaurantStatus.Size = new System.Drawing.Size(159, 260);
            this._restaurantStatus.TabIndex = 3;
            this._restaurantStatus.Text = "";
            // 
            // _fitnessStatus
            // 
            this._fitnessStatus.Location = new System.Drawing.Point(1207, 523);
            this._fitnessStatus.Name = "_fitnessStatus";
            this._fitnessStatus.Size = new System.Drawing.Size(139, 260);
            this._fitnessStatus.TabIndex = 4;
            this._fitnessStatus.Text = "";
            // 
            // _poolStatus
            // 
            this._poolStatus.Location = new System.Drawing.Point(1372, 523);
            this._poolStatus.Name = "_poolStatus";
            this._poolStatus.Size = new System.Drawing.Size(137, 260);
            this._poolStatus.TabIndex = 5;
            this._poolStatus.Text = "";
            // 
            // Simulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 845);
            this.Controls.Add(this._poolStatus);
            this.Controls.Add(this._fitnessStatus);
            this.Controls.Add(this._restaurantStatus);
            this.Controls.Add(this._guestStatus);
            this.Controls.Add(this._maidStatus);
            this.Controls.Add(this._roomsStatus);
            this.Name = "Simulation";
            this.Text = "Simulation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _roomsStatus;
        private System.Windows.Forms.RichTextBox _maidStatus;
        private System.Windows.Forms.RichTextBox _guestStatus;
        private System.Windows.Forms.RichTextBox _restaurantStatus;
        private System.Windows.Forms.RichTextBox _fitnessStatus;
        private System.Windows.Forms.RichTextBox _poolStatus;
    }
}