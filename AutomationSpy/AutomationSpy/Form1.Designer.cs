namespace AutomationSpy
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.locationLabel = new System.Windows.Forms.Label();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.automationElementRadioButton = new System.Windows.Forms.RadioButton();
            this.windowHandleRadioButton = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bottomPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.startButton);
            this.bottomPanel.Controls.Add(this.stopButton);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(6, 305);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(372, 50);
            this.bottomPanel.TabIndex = 3;
            // 
            // startButton
            // 
            this.startButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.startButton.Location = new System.Drawing.Point(72, 0);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(150, 50);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "開始";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.stopButton.Location = new System.Drawing.Point(222, 0);
            this.stopButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(150, 50);
            this.stopButton.TabIndex = 0;
            this.stopButton.Text = "停止";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.locationLabel.Location = new System.Drawing.Point(6, 271);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(372, 34);
            this.locationLabel.TabIndex = 4;
            this.locationLabel.Text = "Cousor Location = {x, y}";
            this.locationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // propertyGrid
            // 
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(6, 58);
            this.propertyGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(372, 213);
            this.propertyGrid.TabIndex = 5;
            this.propertyGrid.ToolbarVisible = false;
            // 
            // automationElementRadioButton
            // 
            this.automationElementRadioButton.Checked = true;
            this.automationElementRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.automationElementRadioButton.Location = new System.Drawing.Point(6, 6);
            this.automationElementRadioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.automationElementRadioButton.Name = "automationElementRadioButton";
            this.automationElementRadioButton.Size = new System.Drawing.Size(174, 40);
            this.automationElementRadioButton.TabIndex = 0;
            this.automationElementRadioButton.TabStop = true;
            this.automationElementRadioButton.Text = "Automation Element";
            this.automationElementRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.automationElementRadioButton.UseVisualStyleBackColor = true;
            this.automationElementRadioButton.CheckedChanged += new System.EventHandler(this.automationElementRadioButton_CheckedChanged);
            // 
            // windowHandleRadioButton
            // 
            this.windowHandleRadioButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.windowHandleRadioButton.Location = new System.Drawing.Point(192, 6);
            this.windowHandleRadioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.windowHandleRadioButton.Name = "windowHandleRadioButton";
            this.windowHandleRadioButton.Size = new System.Drawing.Size(174, 40);
            this.windowHandleRadioButton.TabIndex = 1;
            this.windowHandleRadioButton.TabStop = true;
            this.windowHandleRadioButton.Text = "Window Handle";
            this.windowHandleRadioButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.windowHandleRadioButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.windowHandleRadioButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.automationElementRadioButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 52);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.propertyGrid);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.locationLabel);
            this.Controls.Add(this.bottomPanel);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Text = "AutomationSpy";
            this.bottomPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.RadioButton windowHandleRadioButton;
        private System.Windows.Forms.RadioButton automationElementRadioButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

