namespace CreateXML
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
            this.btnCreateXML = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateXML
            // 
            this.btnCreateXML.Location = new System.Drawing.Point(128, 93);
            this.btnCreateXML.Name = "btnCreateXML";
            this.btnCreateXML.Size = new System.Drawing.Size(75, 23);
            this.btnCreateXML.TabIndex = 0;
            this.btnCreateXML.Text = "Create XML";
            this.btnCreateXML.UseVisualStyleBackColor = true;
            this.btnCreateXML.Click += new System.EventHandler(this.btnCreateXML_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(128, 122);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 23);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "Post XML";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 229);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnCreateXML);
            this.Name = "Form1";
            this.Text = "Retrieve XML";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateXML;
        private System.Windows.Forms.Button btnPost;
    }
}

