namespace Gamming
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
            this.Encode = new System.Windows.Forms.Button();
            this.decoded = new System.Windows.Forms.TextBox();
            this.encoded = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Encode
            // 
            this.Encode.Location = new System.Drawing.Point(270, 167);
            this.Encode.Name = "Encode";
            this.Encode.Size = new System.Drawing.Size(138, 23);
            this.Encode.TabIndex = 0;
            this.Encode.Text = "Encode /  Decode";
            this.Encode.UseVisualStyleBackColor = true;
            this.decoded.TextChanged += new System.EventHandler(this.Encode_TextChanged);
            // 
            // decoded
            // 
            this.decoded.Location = new System.Drawing.Point(12, 41);
            this.decoded.Multiline = true;
            this.decoded.Name = "decoded";
            this.decoded.Size = new System.Drawing.Size(333, 120);
            this.decoded.TabIndex = 2;
            // 
            // encoded
            // 
            this.encoded.Location = new System.Drawing.Point(351, 41);
            this.encoded.Multiline = true;
            this.encoded.Name = "encoded";
            this.encoded.Size = new System.Drawing.Size(342, 120);
            this.encoded.TabIndex = 3;
            this.encoded.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(466, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Encoded text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(104, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Source text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 296);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.encoded);
            this.Controls.Add(this.decoded);
            this.Controls.Add(this.Encode);
            this.Name = "Form1";
            this.Text = "Гаммирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Encode;
        private System.Windows.Forms.TextBox decoded;
        private System.Windows.Forms.TextBox encoded;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

