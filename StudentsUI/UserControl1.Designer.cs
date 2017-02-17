namespace StudentsUI
{
    partial class UserControl1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labSubjectName = new System.Windows.Forms.Label();
            this.txtExamination = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labSubjectName
            // 
            this.labSubjectName.AutoSize = true;
            this.labSubjectName.Location = new System.Drawing.Point(13, 15);
            this.labSubjectName.Name = "labSubjectName";
            this.labSubjectName.Size = new System.Drawing.Size(41, 12);
            this.labSubjectName.TabIndex = 0;
            this.labSubjectName.Text = "学科：";
            // 
            // txtExamination
            // 
            this.txtExamination.Location = new System.Drawing.Point(60, 12);
            this.txtExamination.Name = "txtExamination";
            this.txtExamination.Size = new System.Drawing.Size(121, 21);
            this.txtExamination.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(201, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "修改";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txtExamination);
            this.Controls.Add(this.labSubjectName);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(265, 42);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        public System.Windows.Forms.Label labSubjectName;
        public System.Windows.Forms.TextBox txtExamination;
    }
}
