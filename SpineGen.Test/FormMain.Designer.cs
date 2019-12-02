namespace SpineGen.Test
{
    partial class FormMain
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
            this.spineTemplate = new System.Windows.Forms.PictureBox();
            this.spineOutput = new System.Windows.Forms.PictureBox();
            this.clearLogo = new System.Windows.Forms.PictureBox();
            this.templateSelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.spineTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spineOutput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // spineTemplate
            // 
            this.spineTemplate.Location = new System.Drawing.Point(13, 40);
            this.spineTemplate.Name = "spineTemplate";
            this.spineTemplate.Size = new System.Drawing.Size(56, 428);
            this.spineTemplate.TabIndex = 0;
            this.spineTemplate.TabStop = false;
            // 
            // spineOutput
            // 
            this.spineOutput.Location = new System.Drawing.Point(733, 40);
            this.spineOutput.Name = "spineOutput";
            this.spineOutput.Size = new System.Drawing.Size(56, 428);
            this.spineOutput.TabIndex = 0;
            this.spineOutput.TabStop = false;
            // 
            // clearLogo
            // 
            this.clearLogo.Location = new System.Drawing.Point(75, 40);
            this.clearLogo.Name = "clearLogo";
            this.clearLogo.Size = new System.Drawing.Size(652, 428);
            this.clearLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.clearLogo.TabIndex = 1;
            this.clearLogo.TabStop = false;
            // 
            // templateSelector
            // 
            this.templateSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateSelector.FormattingEnabled = true;
            this.templateSelector.Location = new System.Drawing.Point(13, 13);
            this.templateSelector.Name = "templateSelector";
            this.templateSelector.Size = new System.Drawing.Size(258, 21);
            this.templateSelector.TabIndex = 2;
            this.templateSelector.SelectedIndexChanged += new System.EventHandler(this.TemplateSelector_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.templateSelector);
            this.Controls.Add(this.clearLogo);
            this.Controls.Add(this.spineOutput);
            this.Controls.Add(this.spineTemplate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.spineTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spineOutput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clearLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox spineTemplate;
        private System.Windows.Forms.PictureBox spineOutput;
        private System.Windows.Forms.PictureBox clearLogo;
        private System.Windows.Forms.ComboBox templateSelector;
    }
}

