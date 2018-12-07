namespace DNDAPI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.PanelOutput = new System.Windows.Forms.Panel();
            this.BoxOutput = new System.Windows.Forms.RichTextBox();
            this.PanelInput = new System.Windows.Forms.Panel();
            this.PanelInputOptions = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.BoxRestrictedTypes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BoxSameChance = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.CheckBoxCohesion = new System.Windows.Forms.CheckBox();
            this.MaskedTextBoxLevel = new System.Windows.Forms.MaskedTextBox();
            this.MaskedTextBoxNumber = new System.Windows.Forms.MaskedTextBox();
            this.RadioButtonDeadly = new System.Windows.Forms.RadioButton();
            this.RadioButtonHard = new System.Windows.Forms.RadioButton();
            this.RadioButtonMedium = new System.Windows.Forms.RadioButton();
            this.RadioButtonEasy = new System.Windows.Forms.RadioButton();
            this.ButtonOutput = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelOptions = new System.Windows.Forms.Label();
            this.CheckBoxCohesionSub = new System.Windows.Forms.CheckBox();
            this.PanelOutput.SuspendLayout();
            this.PanelInput.SuspendLayout();
            this.PanelInputOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelOutput
            // 
            this.PanelOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(40)))), ((int)(((byte)(24)))));
            this.PanelOutput.Controls.Add(this.BoxOutput);
            this.PanelOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.PanelOutput.Location = new System.Drawing.Point(282, 0);
            this.PanelOutput.Name = "PanelOutput";
            this.PanelOutput.Padding = new System.Windows.Forms.Padding(20);
            this.PanelOutput.Size = new System.Drawing.Size(565, 554);
            this.PanelOutput.TabIndex = 0;
            // 
            // BoxOutput
            // 
            this.BoxOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(211)))));
            this.BoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoxOutput.Font = new System.Drawing.Font("Noto Sans", 14F);
            this.BoxOutput.Location = new System.Drawing.Point(20, 20);
            this.BoxOutput.Name = "BoxOutput";
            this.BoxOutput.ReadOnly = true;
            this.BoxOutput.Size = new System.Drawing.Size(525, 514);
            this.BoxOutput.TabIndex = 0;
            this.BoxOutput.Text = resources.GetString("BoxOutput.Text");
            // 
            // PanelInput
            // 
            this.PanelInput.BackColor = System.Drawing.Color.Black;
            this.PanelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelInput.Controls.Add(this.PanelInputOptions);
            this.PanelInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelInput.Location = new System.Drawing.Point(0, 0);
            this.PanelInput.Name = "PanelInput";
            this.PanelInput.Padding = new System.Windows.Forms.Padding(20);
            this.PanelInput.Size = new System.Drawing.Size(282, 554);
            this.PanelInput.TabIndex = 2;
            // 
            // PanelInputOptions
            // 
            this.PanelInputOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(211)))));
            this.PanelInputOptions.Controls.Add(this.CheckBoxCohesionSub);
            this.PanelInputOptions.Controls.Add(this.label8);
            this.PanelInputOptions.Controls.Add(this.BoxRestrictedTypes);
            this.PanelInputOptions.Controls.Add(this.label7);
            this.PanelInputOptions.Controls.Add(this.BoxSameChance);
            this.PanelInputOptions.Controls.Add(this.label6);
            this.PanelInputOptions.Controls.Add(this.ButtonGenerate);
            this.PanelInputOptions.Controls.Add(this.CheckBoxCohesion);
            this.PanelInputOptions.Controls.Add(this.MaskedTextBoxLevel);
            this.PanelInputOptions.Controls.Add(this.MaskedTextBoxNumber);
            this.PanelInputOptions.Controls.Add(this.RadioButtonDeadly);
            this.PanelInputOptions.Controls.Add(this.RadioButtonHard);
            this.PanelInputOptions.Controls.Add(this.RadioButtonMedium);
            this.PanelInputOptions.Controls.Add(this.RadioButtonEasy);
            this.PanelInputOptions.Controls.Add(this.ButtonOutput);
            this.PanelInputOptions.Controls.Add(this.label4);
            this.PanelInputOptions.Controls.Add(this.label3);
            this.PanelInputOptions.Controls.Add(this.label2);
            this.PanelInputOptions.Controls.Add(this.label1);
            this.PanelInputOptions.Controls.Add(this.LabelOptions);
            this.PanelInputOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelInputOptions.Location = new System.Drawing.Point(20, 20);
            this.PanelInputOptions.Name = "PanelInputOptions";
            this.PanelInputOptions.Padding = new System.Windows.Forms.Padding(20);
            this.PanelInputOptions.Size = new System.Drawing.Size(240, 512);
            this.PanelInputOptions.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Noto Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(130, 355);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 32;
            this.label8.Text = "(type, type...)";
            // 
            // BoxRestrictedTypes
            // 
            this.BoxRestrictedTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.BoxRestrictedTypes.Location = new System.Drawing.Point(26, 353);
            this.BoxRestrictedTypes.Name = "BoxRestrictedTypes";
            this.BoxRestrictedTypes.Size = new System.Drawing.Size(100, 20);
            this.BoxRestrictedTypes.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Noto Sans", 8.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(24, 335);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "Prohibited Types";
            // 
            // BoxSameChance
            // 
            this.BoxSameChance.Location = new System.Drawing.Point(26, 312);
            this.BoxSameChance.Mask = "##";
            this.BoxSameChance.Name = "BoxSameChance";
            this.BoxSameChance.Size = new System.Drawing.Size(100, 20);
            this.BoxSameChance.TabIndex = 29;
            this.BoxSameChance.Click += new System.EventHandler(this.BoxSameChance_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Sans", 8.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(24, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "+ % Chance of Same Creature";
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.AutoSize = true;
            this.ButtonGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ButtonGenerate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonGenerate.Font = new System.Drawing.Font("Noto Sans", 8.25F);
            this.ButtonGenerate.Location = new System.Drawing.Point(20, 440);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(200, 26);
            this.ButtonGenerate.TabIndex = 27;
            this.ButtonGenerate.Text = "Generate!";
            this.ButtonGenerate.UseVisualStyleBackColor = false;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // CheckBoxCohesion
            // 
            this.CheckBoxCohesion.AutoSize = true;
            this.CheckBoxCohesion.Font = new System.Drawing.Font("Noto Sans", 8.25F, System.Drawing.FontStyle.Bold);
            this.CheckBoxCohesion.ForeColor = System.Drawing.Color.Black;
            this.CheckBoxCohesion.Location = new System.Drawing.Point(25, 385);
            this.CheckBoxCohesion.Name = "CheckBoxCohesion";
            this.CheckBoxCohesion.Size = new System.Drawing.Size(183, 19);
            this.CheckBoxCohesion.TabIndex = 26;
            this.CheckBoxCohesion.Text = "Limit creatures to one type?";
            this.CheckBoxCohesion.UseVisualStyleBackColor = true;
            // 
            // MaskedTextBoxLevel
            // 
            this.MaskedTextBoxLevel.Location = new System.Drawing.Point(26, 149);
            this.MaskedTextBoxLevel.Mask = "##";
            this.MaskedTextBoxLevel.Name = "MaskedTextBoxLevel";
            this.MaskedTextBoxLevel.Size = new System.Drawing.Size(100, 20);
            this.MaskedTextBoxLevel.TabIndex = 24;
            this.MaskedTextBoxLevel.Click += new System.EventHandler(this.MaskedTextBoxLevel_Click);
            // 
            // MaskedTextBoxNumber
            // 
            this.MaskedTextBoxNumber.Location = new System.Drawing.Point(25, 92);
            this.MaskedTextBoxNumber.Mask = "##";
            this.MaskedTextBoxNumber.Name = "MaskedTextBoxNumber";
            this.MaskedTextBoxNumber.Size = new System.Drawing.Size(100, 20);
            this.MaskedTextBoxNumber.TabIndex = 23;
            this.MaskedTextBoxNumber.Click += new System.EventHandler(this.MaskedTextBoxNumber_Click);
            // 
            // RadioButtonDeadly
            // 
            this.RadioButtonDeadly.AutoSize = true;
            this.RadioButtonDeadly.Font = new System.Drawing.Font("Noto Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RadioButtonDeadly.ForeColor = System.Drawing.Color.Black;
            this.RadioButtonDeadly.Location = new System.Drawing.Point(112, 227);
            this.RadioButtonDeadly.Name = "RadioButtonDeadly";
            this.RadioButtonDeadly.Size = new System.Drawing.Size(63, 19);
            this.RadioButtonDeadly.TabIndex = 16;
            this.RadioButtonDeadly.TabStop = true;
            this.RadioButtonDeadly.Text = "Deadly";
            this.RadioButtonDeadly.UseVisualStyleBackColor = true;
            // 
            // RadioButtonHard
            // 
            this.RadioButtonHard.AutoSize = true;
            this.RadioButtonHard.Font = new System.Drawing.Font("Noto Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RadioButtonHard.ForeColor = System.Drawing.Color.Black;
            this.RadioButtonHard.Location = new System.Drawing.Point(26, 227);
            this.RadioButtonHard.Name = "RadioButtonHard";
            this.RadioButtonHard.Size = new System.Drawing.Size(54, 19);
            this.RadioButtonHard.TabIndex = 15;
            this.RadioButtonHard.TabStop = true;
            this.RadioButtonHard.Text = "Hard";
            this.RadioButtonHard.UseVisualStyleBackColor = true;
            // 
            // RadioButtonMedium
            // 
            this.RadioButtonMedium.AutoSize = true;
            this.RadioButtonMedium.Font = new System.Drawing.Font("Noto Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RadioButtonMedium.ForeColor = System.Drawing.Color.Black;
            this.RadioButtonMedium.Location = new System.Drawing.Point(112, 204);
            this.RadioButtonMedium.Name = "RadioButtonMedium";
            this.RadioButtonMedium.Size = new System.Drawing.Size(70, 19);
            this.RadioButtonMedium.TabIndex = 14;
            this.RadioButtonMedium.TabStop = true;
            this.RadioButtonMedium.Text = "Medium";
            this.RadioButtonMedium.UseVisualStyleBackColor = true;
            // 
            // RadioButtonEasy
            // 
            this.RadioButtonEasy.AutoSize = true;
            this.RadioButtonEasy.Font = new System.Drawing.Font("Noto Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.RadioButtonEasy.ForeColor = System.Drawing.Color.Black;
            this.RadioButtonEasy.Location = new System.Drawing.Point(26, 204);
            this.RadioButtonEasy.Name = "RadioButtonEasy";
            this.RadioButtonEasy.Size = new System.Drawing.Size(50, 19);
            this.RadioButtonEasy.TabIndex = 13;
            this.RadioButtonEasy.TabStop = true;
            this.RadioButtonEasy.Text = "Easy";
            this.RadioButtonEasy.UseVisualStyleBackColor = true;
            // 
            // ButtonOutput
            // 
            this.ButtonOutput.AutoSize = true;
            this.ButtonOutput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonOutput.Font = new System.Drawing.Font("Noto Sans", 8.25F);
            this.ButtonOutput.Location = new System.Drawing.Point(20, 466);
            this.ButtonOutput.Name = "ButtonOutput";
            this.ButtonOutput.Size = new System.Drawing.Size(200, 26);
            this.ButtonOutput.TabIndex = 12;
            this.ButtonOutput.Text = "Output to File";
            this.ButtonOutput.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(40)))), ((int)(((byte)(24)))));
            this.label4.Location = new System.Drawing.Point(23, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Additional Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(40)))), ((int)(((byte)(24)))));
            this.label3.Location = new System.Drawing.Point(23, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Encounter Difficulty";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(40)))), ((int)(((byte)(24)))));
            this.label2.Location = new System.Drawing.Point(23, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Avg. Player Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Sans", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(40)))), ((int)(((byte)(24)))));
            this.label1.Location = new System.Drawing.Point(23, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of PCs";
            // 
            // LabelOptions
            // 
            this.LabelOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(242)))), ((int)(((byte)(211)))));
            this.LabelOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelOptions.Font = new System.Drawing.Font("Noto Sans", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.LabelOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(40)))), ((int)(((byte)(24)))));
            this.LabelOptions.Location = new System.Drawing.Point(20, 20);
            this.LabelOptions.Name = "LabelOptions";
            this.LabelOptions.Size = new System.Drawing.Size(200, 472);
            this.LabelOptions.TabIndex = 1;
            this.LabelOptions.Text = "Options";
            this.LabelOptions.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CheckBoxCohesionSub
            // 
            this.CheckBoxCohesionSub.AutoSize = true;
            this.CheckBoxCohesionSub.Font = new System.Drawing.Font("Noto Sans", 8.25F, System.Drawing.FontStyle.Bold);
            this.CheckBoxCohesionSub.ForeColor = System.Drawing.Color.Black;
            this.CheckBoxCohesionSub.Location = new System.Drawing.Point(79, 400);
            this.CheckBoxCohesionSub.Name = "CheckBoxCohesionSub";
            this.CheckBoxCohesionSub.Size = new System.Drawing.Size(129, 19);
            this.CheckBoxCohesionSub.TabIndex = 33;
            this.CheckBoxCohesionSub.Text = "Including subtype?";
            this.CheckBoxCohesionSub.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(25)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(847, 554);
            this.Controls.Add(this.PanelInput);
            this.Controls.Add(this.PanelOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMain";
            this.Text = "Encounter Generator";
            this.PanelOutput.ResumeLayout(false);
            this.PanelInput.ResumeLayout(false);
            this.PanelInputOptions.ResumeLayout(false);
            this.PanelInputOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelOutput;
        private System.Windows.Forms.Panel PanelInput;
        private System.Windows.Forms.Panel PanelInputOptions;
        private System.Windows.Forms.Button ButtonOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelOptions;
        private System.Windows.Forms.RadioButton RadioButtonDeadly;
        private System.Windows.Forms.RadioButton RadioButtonHard;
        private System.Windows.Forms.RadioButton RadioButtonMedium;
        private System.Windows.Forms.RadioButton RadioButtonEasy;
        private System.Windows.Forms.MaskedTextBox MaskedTextBoxNumber;
        private System.Windows.Forms.MaskedTextBox MaskedTextBoxLevel;
        private System.Windows.Forms.CheckBox CheckBoxCohesion;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.RichTextBox BoxOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox BoxSameChance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox BoxRestrictedTypes;
        private System.Windows.Forms.CheckBox CheckBoxCohesionSub;
    }
}

