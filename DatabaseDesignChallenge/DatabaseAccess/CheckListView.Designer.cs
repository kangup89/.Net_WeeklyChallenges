namespace DatabaseAccess
{
    partial class CheckListView
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
            this.presentButton = new System.Windows.Forms.Button();
            this.peopleLabel = new System.Windows.Forms.Label();
            this.leftPeopleLabel = new System.Windows.Forms.Label();
            this.presentsLabel = new System.Windows.Forms.Label();
            this.peopleList = new System.Windows.Forms.ListBox();
            this.leftPeopleList = new System.Windows.Forms.ListBox();
            this.presentsList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // presentButton
            // 
            this.presentButton.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.presentButton.Location = new System.Drawing.Point(586, 276);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(75, 42);
            this.presentButton.TabIndex = 0;
            this.presentButton.Text = "Give Present";
            this.presentButton.UseVisualStyleBackColor = true;
            this.presentButton.Click += new System.EventHandler(this.presentButton_Click);
            // 
            // peopleLabel
            // 
            this.peopleLabel.AutoSize = true;
            this.peopleLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.peopleLabel.Location = new System.Drawing.Point(185, 36);
            this.peopleLabel.Name = "peopleLabel";
            this.peopleLabel.Size = new System.Drawing.Size(70, 19);
            this.peopleLabel.TabIndex = 2;
            this.peopleLabel.Text = "People";
            // 
            // leftPeopleLabel
            // 
            this.leftPeopleLabel.AutoSize = true;
            this.leftPeopleLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.leftPeopleLabel.Location = new System.Drawing.Point(565, 36);
            this.leftPeopleLabel.Name = "leftPeopleLabel";
            this.leftPeopleLabel.Size = new System.Drawing.Size(110, 19);
            this.leftPeopleLabel.TabIndex = 4;
            this.leftPeopleLabel.Text = "Left People";
            // 
            // presentsLabel
            // 
            this.presentsLabel.AutoSize = true;
            this.presentsLabel.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.presentsLabel.Location = new System.Drawing.Point(403, 376);
            this.presentsLabel.Name = "presentsLabel";
            this.presentsLabel.Size = new System.Drawing.Size(89, 19);
            this.presentsLabel.TabIndex = 6;
            this.presentsLabel.Text = "Presents";
            // 
            // peopleList
            // 
            this.peopleList.FormattingEnabled = true;
            this.peopleList.ItemHeight = 12;
            this.peopleList.Location = new System.Drawing.Point(49, 72);
            this.peopleList.Name = "peopleList";
            this.peopleList.Size = new System.Drawing.Size(348, 364);
            this.peopleList.TabIndex = 7;
            // 
            // leftPeopleList
            // 
            this.leftPeopleList.FormattingEnabled = true;
            this.leftPeopleList.ItemHeight = 12;
            this.leftPeopleList.Location = new System.Drawing.Point(459, 72);
            this.leftPeopleList.Name = "leftPeopleList";
            this.leftPeopleList.Size = new System.Drawing.Size(315, 184);
            this.leftPeopleList.TabIndex = 8;
            // 
            // presentsList
            // 
            this.presentsList.FormattingEnabled = true;
            this.presentsList.ItemHeight = 12;
            this.presentsList.Location = new System.Drawing.Point(498, 326);
            this.presentsList.Name = "presentsList";
            this.presentsList.Size = new System.Drawing.Size(276, 112);
            this.presentsList.TabIndex = 9;
            // 
            // CheckListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.presentsList);
            this.Controls.Add(this.leftPeopleList);
            this.Controls.Add(this.peopleList);
            this.Controls.Add(this.presentsLabel);
            this.Controls.Add(this.leftPeopleLabel);
            this.Controls.Add(this.peopleLabel);
            this.Controls.Add(this.presentButton);
            this.Name = "CheckListView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button presentButton;
        private System.Windows.Forms.Label peopleLabel;
        private System.Windows.Forms.Label leftPeopleLabel;
        private System.Windows.Forms.Label presentsLabel;
        private System.Windows.Forms.ListBox peopleList;
        private System.Windows.Forms.ListBox leftPeopleList;
        private System.Windows.Forms.ListBox presentsList;
    }
}

