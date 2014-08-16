namespace favUtil
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
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
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
            this.comboBoxDevices = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxDevices = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusError = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonRefreash = new System.Windows.Forms.Button();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxMediaKeycode = new System.Windows.Forms.TextBox();
            this.radioMediaKeycode = new System.Windows.Forms.RadioButton();
            this.radioMediaMute = new System.Windows.Forms.RadioButton();
            this.radioMediaPlay = new System.Windows.Forms.RadioButton();
            this.textBoxMouseY = new System.Windows.Forms.TextBox();
            this.textBoxMouseX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkKeyboardCtrl = new System.Windows.Forms.CheckBox();
            this.checkMouseRight = new System.Windows.Forms.CheckBox();
            this.checkKeyboardShift = new System.Windows.Forms.CheckBox();
            this.checkMouseMiddle = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkMouseLeft = new System.Windows.Forms.CheckBox();
            this.checkKeyboardAlt = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxKeyboardKeycode = new System.Windows.Forms.TextBox();
            this.radioKeyboardEsc = new System.Windows.Forms.RadioButton();
            this.radioKeyboardTab = new System.Windows.Forms.RadioButton();
            this.textBoxKeyboardFunc = new System.Windows.Forms.TextBox();
            this.textBoxKeyboardChar = new System.Windows.Forms.TextBox();
            this.radioKeyboardKeycode = new System.Windows.Forms.RadioButton();
            this.radioKeyboardEnter = new System.Windows.Forms.RadioButton();
            this.radioKeyboardFunc = new System.Windows.Forms.RadioButton();
            this.radioKeyboardChar = new System.Windows.Forms.RadioButton();
            this.radioMedia = new System.Windows.Forms.RadioButton();
            this.radioMouse = new System.Windows.Forms.RadioButton();
            this.radioKeyboard = new System.Windows.Forms.RadioButton();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxDevices
            // 
            this.comboBoxDevices.FormattingEnabled = true;
            this.comboBoxDevices.Location = new System.Drawing.Point(83, 39);
            this.comboBoxDevices.Name = "comboBoxDevices";
            this.comboBoxDevices.Size = new System.Drawing.Size(56, 20);
            this.comboBoxDevices.TabIndex = 0;
            this.comboBoxDevices.SelectedIndexChanged += new System.EventHandler(this.comboBoxDevices_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "デバイス選択";
            // 
            // listBoxDevices
            // 
            this.listBoxDevices.Enabled = false;
            this.listBoxDevices.FormattingEnabled = true;
            this.listBoxDevices.ItemHeight = 12;
            this.listBoxDevices.Location = new System.Drawing.Point(12, 81);
            this.listBoxDevices.Name = "listBoxDevices";
            this.listBoxDevices.Size = new System.Drawing.Size(127, 88);
            this.listBoxDevices.TabIndex = 2;
            this.listBoxDevices.SelectedValueChanged += new System.EventHandler(this.listBoxDevices_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "送信コマンド(最大6)";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusError});
            this.statusStrip1.Location = new System.Drawing.Point(0, 269);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(493, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(140, 17);
            this.toolStripStatusLabel.Text = "ふぁぼボタンが見つかりません";
            // 
            // toolStripStatusError
            // 
            this.toolStripStatusError.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusError.Name = "toolStripStatusError";
            this.toolStripStatusError.Size = new System.Drawing.Size(0, 17);
            // 
            // buttonRefreash
            // 
            this.buttonRefreash.Location = new System.Drawing.Point(12, 12);
            this.buttonRefreash.Name = "buttonRefreash";
            this.buttonRefreash.Size = new System.Drawing.Size(127, 23);
            this.buttonRefreash.TabIndex = 5;
            this.buttonRefreash.Text = "デバイス一覧更新";
            this.buttonRefreash.UseVisualStyleBackColor = true;
            this.buttonRefreash.Click += new System.EventHandler(this.buttonRefreash_Click);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Enabled = false;
            this.buttonWrite.Location = new System.Drawing.Point(12, 242);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(127, 23);
            this.buttonWrite.TabIndex = 6;
            this.buttonWrite.Text = "設定書き込み";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.textBoxMouseY);
            this.groupBox1.Controls.Add(this.textBoxMouseX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkKeyboardCtrl);
            this.groupBox1.Controls.Add(this.checkMouseRight);
            this.groupBox1.Controls.Add(this.checkKeyboardShift);
            this.groupBox1.Controls.Add(this.checkMouseMiddle);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkMouseLeft);
            this.groupBox1.Controls.Add(this.checkKeyboardAlt);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.radioMedia);
            this.groupBox1.Controls.Add(this.radioMouse);
            this.groupBox1.Controls.Add(this.radioKeyboard);
            this.groupBox1.Location = new System.Drawing.Point(146, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 253);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "コマンド";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxMediaKeycode);
            this.groupBox3.Controls.Add(this.radioMediaKeycode);
            this.groupBox3.Controls.Add(this.radioMediaMute);
            this.groupBox3.Controls.Add(this.radioMediaPlay);
            this.groupBox3.Location = new System.Drawing.Point(7, 203);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(326, 45);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "入力キー";
            // 
            // textBoxMediaKeycode
            // 
            this.textBoxMediaKeycode.Enabled = false;
            this.textBoxMediaKeycode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxMediaKeycode.Location = new System.Drawing.Point(220, 18);
            this.textBoxMediaKeycode.MaxLength = 3;
            this.textBoxMediaKeycode.Name = "textBoxMediaKeycode";
            this.textBoxMediaKeycode.Size = new System.Drawing.Size(63, 19);
            this.textBoxMediaKeycode.TabIndex = 3;
            // 
            // radioMediaKeycode
            // 
            this.radioMediaKeycode.AutoSize = true;
            this.radioMediaKeycode.Enabled = false;
            this.radioMediaKeycode.Location = new System.Drawing.Point(144, 19);
            this.radioMediaKeycode.Name = "radioMediaKeycode";
            this.radioMediaKeycode.Size = new System.Drawing.Size(70, 16);
            this.radioMediaKeycode.TabIndex = 2;
            this.radioMediaKeycode.TabStop = true;
            this.radioMediaKeycode.Text = "キーコード";
            this.radioMediaKeycode.UseVisualStyleBackColor = true;
            // 
            // radioMediaMute
            // 
            this.radioMediaMute.AutoSize = true;
            this.radioMediaMute.Enabled = false;
            this.radioMediaMute.Location = new System.Drawing.Point(87, 19);
            this.radioMediaMute.Name = "radioMediaMute";
            this.radioMediaMute.Size = new System.Drawing.Size(56, 16);
            this.radioMediaMute.TabIndex = 1;
            this.radioMediaMute.TabStop = true;
            this.radioMediaMute.Text = "ミュート";
            this.radioMediaMute.UseVisualStyleBackColor = true;
            // 
            // radioMediaPlay
            // 
            this.radioMediaPlay.AutoSize = true;
            this.radioMediaPlay.Enabled = false;
            this.radioMediaPlay.Location = new System.Drawing.Point(7, 19);
            this.radioMediaPlay.Name = "radioMediaPlay";
            this.radioMediaPlay.Size = new System.Drawing.Size(77, 16);
            this.radioMediaPlay.TabIndex = 0;
            this.radioMediaPlay.TabStop = true;
            this.radioMediaPlay.Text = "再生/停止";
            this.radioMediaPlay.UseVisualStyleBackColor = true;
            // 
            // textBoxMouseY
            // 
            this.textBoxMouseY.Enabled = false;
            this.textBoxMouseY.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxMouseY.Location = new System.Drawing.Point(288, 154);
            this.textBoxMouseY.MaxLength = 4;
            this.textBoxMouseY.Name = "textBoxMouseY";
            this.textBoxMouseY.Size = new System.Drawing.Size(32, 19);
            this.textBoxMouseY.TabIndex = 10;
            // 
            // textBoxMouseX
            // 
            this.textBoxMouseX.Enabled = false;
            this.textBoxMouseX.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxMouseX.Location = new System.Drawing.Point(134, 154);
            this.textBoxMouseX.MaxLength = 4;
            this.textBoxMouseX.Name = "textBoxMouseX";
            this.textBoxMouseX.Size = new System.Drawing.Size(32, 19);
            this.textBoxMouseX.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(172, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Y移動量(-127～127)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "X移動量(-127～127)";
            // 
            // checkKeyboardCtrl
            // 
            this.checkKeyboardCtrl.AutoSize = true;
            this.checkKeyboardCtrl.Enabled = false;
            this.checkKeyboardCtrl.Location = new System.Drawing.Point(289, 20);
            this.checkKeyboardCtrl.Name = "checkKeyboardCtrl";
            this.checkKeyboardCtrl.Size = new System.Drawing.Size(43, 16);
            this.checkKeyboardCtrl.TabIndex = 8;
            this.checkKeyboardCtrl.Text = "Ctrl";
            this.checkKeyboardCtrl.UseVisualStyleBackColor = true;
            // 
            // checkMouseRight
            // 
            this.checkMouseRight.AutoSize = true;
            this.checkMouseRight.Enabled = false;
            this.checkMouseRight.Location = new System.Drawing.Point(201, 135);
            this.checkMouseRight.Name = "checkMouseRight";
            this.checkMouseRight.Size = new System.Drawing.Size(63, 16);
            this.checkMouseRight.TabIndex = 6;
            this.checkMouseRight.Text = "右ボタン";
            this.checkMouseRight.UseVisualStyleBackColor = true;
            // 
            // checkKeyboardShift
            // 
            this.checkKeyboardShift.AutoSize = true;
            this.checkKeyboardShift.Enabled = false;
            this.checkKeyboardShift.Location = new System.Drawing.Point(236, 20);
            this.checkKeyboardShift.Name = "checkKeyboardShift";
            this.checkKeyboardShift.Size = new System.Drawing.Size(48, 16);
            this.checkKeyboardShift.TabIndex = 7;
            this.checkKeyboardShift.Text = "Shift";
            this.checkKeyboardShift.UseVisualStyleBackColor = true;
            // 
            // checkMouseMiddle
            // 
            this.checkMouseMiddle.AutoSize = true;
            this.checkMouseMiddle.Enabled = false;
            this.checkMouseMiddle.Location = new System.Drawing.Point(132, 135);
            this.checkMouseMiddle.Name = "checkMouseMiddle";
            this.checkMouseMiddle.Size = new System.Drawing.Size(63, 16);
            this.checkMouseMiddle.TabIndex = 5;
            this.checkMouseMiddle.Text = "中ボタン";
            this.checkMouseMiddle.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "キー修飾";
            // 
            // checkMouseLeft
            // 
            this.checkMouseLeft.AutoSize = true;
            this.checkMouseLeft.Enabled = false;
            this.checkMouseLeft.Location = new System.Drawing.Point(63, 135);
            this.checkMouseLeft.Name = "checkMouseLeft";
            this.checkMouseLeft.Size = new System.Drawing.Size(63, 16);
            this.checkMouseLeft.TabIndex = 4;
            this.checkMouseLeft.Text = "左ボタン";
            this.checkMouseLeft.UseVisualStyleBackColor = true;
            // 
            // checkKeyboardAlt
            // 
            this.checkKeyboardAlt.AutoSize = true;
            this.checkKeyboardAlt.Enabled = false;
            this.checkKeyboardAlt.Location = new System.Drawing.Point(191, 20);
            this.checkKeyboardAlt.Name = "checkKeyboardAlt";
            this.checkKeyboardAlt.Size = new System.Drawing.Size(39, 16);
            this.checkKeyboardAlt.TabIndex = 4;
            this.checkKeyboardAlt.Text = "Alt";
            this.checkKeyboardAlt.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxKeyboardKeycode);
            this.groupBox2.Controls.Add(this.radioKeyboardEsc);
            this.groupBox2.Controls.Add(this.radioKeyboardTab);
            this.groupBox2.Controls.Add(this.textBoxKeyboardFunc);
            this.groupBox2.Controls.Add(this.textBoxKeyboardChar);
            this.groupBox2.Controls.Add(this.radioKeyboardKeycode);
            this.groupBox2.Controls.Add(this.radioKeyboardEnter);
            this.groupBox2.Controls.Add(this.radioKeyboardFunc);
            this.groupBox2.Controls.Add(this.radioKeyboardChar);
            this.groupBox2.Location = new System.Drawing.Point(7, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 92);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "入力キー";
            // 
            // textBoxKeyboardKeycode
            // 
            this.textBoxKeyboardKeycode.Enabled = false;
            this.textBoxKeyboardKeycode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxKeyboardKeycode.Location = new System.Drawing.Point(127, 63);
            this.textBoxKeyboardKeycode.MaxLength = 3;
            this.textBoxKeyboardKeycode.Name = "textBoxKeyboardKeycode";
            this.textBoxKeyboardKeycode.Size = new System.Drawing.Size(32, 19);
            this.textBoxKeyboardKeycode.TabIndex = 13;
            // 
            // radioKeyboardEsc
            // 
            this.radioKeyboardEsc.AutoSize = true;
            this.radioKeyboardEsc.Enabled = false;
            this.radioKeyboardEsc.Location = new System.Drawing.Point(190, 64);
            this.radioKeyboardEsc.Name = "radioKeyboardEsc";
            this.radioKeyboardEsc.Size = new System.Drawing.Size(42, 16);
            this.radioKeyboardEsc.TabIndex = 12;
            this.radioKeyboardEsc.TabStop = true;
            this.radioKeyboardEsc.Text = "Esc";
            this.radioKeyboardEsc.UseVisualStyleBackColor = true;
            // 
            // radioKeyboardTab
            // 
            this.radioKeyboardTab.AutoSize = true;
            this.radioKeyboardTab.Enabled = false;
            this.radioKeyboardTab.Location = new System.Drawing.Point(190, 42);
            this.radioKeyboardTab.Name = "radioKeyboardTab";
            this.radioKeyboardTab.Size = new System.Drawing.Size(42, 16);
            this.radioKeyboardTab.TabIndex = 11;
            this.radioKeyboardTab.TabStop = true;
            this.radioKeyboardTab.Text = "Tab";
            this.radioKeyboardTab.UseVisualStyleBackColor = true;
            // 
            // textBoxKeyboardFunc
            // 
            this.textBoxKeyboardFunc.Enabled = false;
            this.textBoxKeyboardFunc.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxKeyboardFunc.Location = new System.Drawing.Point(156, 41);
            this.textBoxKeyboardFunc.MaxLength = 3;
            this.textBoxKeyboardFunc.Name = "textBoxKeyboardFunc";
            this.textBoxKeyboardFunc.Size = new System.Drawing.Size(28, 19);
            this.textBoxKeyboardFunc.TabIndex = 10;
            // 
            // textBoxKeyboardChar
            // 
            this.textBoxKeyboardChar.Enabled = false;
            this.textBoxKeyboardChar.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.textBoxKeyboardChar.Location = new System.Drawing.Point(144, 18);
            this.textBoxKeyboardChar.MaxLength = 1;
            this.textBoxKeyboardChar.Name = "textBoxKeyboardChar";
            this.textBoxKeyboardChar.Size = new System.Drawing.Size(28, 19);
            this.textBoxKeyboardChar.TabIndex = 9;
            // 
            // radioKeyboardKeycode
            // 
            this.radioKeyboardKeycode.AutoSize = true;
            this.radioKeyboardKeycode.Enabled = false;
            this.radioKeyboardKeycode.Location = new System.Drawing.Point(7, 64);
            this.radioKeyboardKeycode.Name = "radioKeyboardKeycode";
            this.radioKeyboardKeycode.Size = new System.Drawing.Size(114, 16);
            this.radioKeyboardKeycode.TabIndex = 6;
            this.radioKeyboardKeycode.TabStop = true;
            this.radioKeyboardKeycode.Text = "キーコード(0～255)";
            this.radioKeyboardKeycode.UseVisualStyleBackColor = true;
            // 
            // radioKeyboardEnter
            // 
            this.radioKeyboardEnter.AutoSize = true;
            this.radioKeyboardEnter.Enabled = false;
            this.radioKeyboardEnter.Location = new System.Drawing.Point(190, 19);
            this.radioKeyboardEnter.Name = "radioKeyboardEnter";
            this.radioKeyboardEnter.Size = new System.Drawing.Size(50, 16);
            this.radioKeyboardEnter.TabIndex = 2;
            this.radioKeyboardEnter.TabStop = true;
            this.radioKeyboardEnter.Text = "Enter";
            this.radioKeyboardEnter.UseVisualStyleBackColor = true;
            // 
            // radioKeyboardFunc
            // 
            this.radioKeyboardFunc.AutoSize = true;
            this.radioKeyboardFunc.Enabled = false;
            this.radioKeyboardFunc.Location = new System.Drawing.Point(7, 42);
            this.radioKeyboardFunc.Name = "radioKeyboardFunc";
            this.radioKeyboardFunc.Size = new System.Drawing.Size(152, 16);
            this.radioKeyboardFunc.TabIndex = 1;
            this.radioKeyboardFunc.TabStop = true;
            this.radioKeyboardFunc.Text = "ファンクションキー(F1～F12)";
            this.radioKeyboardFunc.UseVisualStyleBackColor = true;
            // 
            // radioKeyboardChar
            // 
            this.radioKeyboardChar.AutoSize = true;
            this.radioKeyboardChar.Enabled = false;
            this.radioKeyboardChar.Location = new System.Drawing.Point(7, 19);
            this.radioKeyboardChar.Name = "radioKeyboardChar";
            this.radioKeyboardChar.Size = new System.Drawing.Size(136, 16);
            this.radioKeyboardChar.TabIndex = 0;
            this.radioKeyboardChar.TabStop = true;
            this.radioKeyboardChar.Text = "文字入力(A～Z, 0～9)";
            this.radioKeyboardChar.UseVisualStyleBackColor = true;
            // 
            // radioMedia
            // 
            this.radioMedia.AutoSize = true;
            this.radioMedia.Enabled = false;
            this.radioMedia.Location = new System.Drawing.Point(7, 180);
            this.radioMedia.Name = "radioMedia";
            this.radioMedia.Size = new System.Drawing.Size(109, 16);
            this.radioMedia.TabIndex = 2;
            this.radioMedia.TabStop = true;
            this.radioMedia.Text = "メディアコントローラ";
            this.radioMedia.UseVisualStyleBackColor = true;
            this.radioMedia.CheckedChanged += new System.EventHandler(this.radioMedia_CheckedChanged);
            // 
            // radioMouse
            // 
            this.radioMouse.AutoSize = true;
            this.radioMouse.Enabled = false;
            this.radioMouse.Location = new System.Drawing.Point(7, 134);
            this.radioMouse.Name = "radioMouse";
            this.radioMouse.Size = new System.Drawing.Size(50, 16);
            this.radioMouse.TabIndex = 1;
            this.radioMouse.TabStop = true;
            this.radioMouse.Text = "マウス";
            this.radioMouse.UseVisualStyleBackColor = true;
            this.radioMouse.CheckedChanged += new System.EventHandler(this.radioMouse_CheckedChanged);
            // 
            // radioKeyboard
            // 
            this.radioKeyboard.AutoSize = true;
            this.radioKeyboard.Enabled = false;
            this.radioKeyboard.Location = new System.Drawing.Point(7, 19);
            this.radioKeyboard.Name = "radioKeyboard";
            this.radioKeyboard.Size = new System.Drawing.Size(72, 16);
            this.radioKeyboard.TabIndex = 0;
            this.radioKeyboard.TabStop = true;
            this.radioKeyboard.Text = "キーボード";
            this.radioKeyboard.UseVisualStyleBackColor = true;
            this.radioKeyboard.CheckedChanged += new System.EventHandler(this.radioKeyboard_CheckedChanged);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Enabled = false;
            this.buttonAdd.Location = new System.Drawing.Point(12, 204);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(60, 23);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "追加";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDel
            // 
            this.buttonDel.Enabled = false;
            this.buttonDel.Location = new System.Drawing.Point(79, 204);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(60, 23);
            this.buttonDel.TabIndex = 9;
            this.buttonDel.Text = "削除";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.buttonDel_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(12, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "適用";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonApply);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 291);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDel);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.buttonRefreash);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxDevices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxDevices);
            this.MaximumSize = new System.Drawing.Size(509, 330);
            this.MinimumSize = new System.Drawing.Size(509, 330);
            this.Name = "Form1";
            this.Text = "ふぁぼボタンを設定するやつ";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxDevices;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxDevices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.Button buttonRefreash;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioMedia;
        private System.Windows.Forms.RadioButton radioMouse;
        private System.Windows.Forms.RadioButton radioKeyboard;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkKeyboardCtrl;
        private System.Windows.Forms.CheckBox checkKeyboardShift;
        private System.Windows.Forms.RadioButton radioKeyboardKeycode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkKeyboardAlt;
        private System.Windows.Forms.RadioButton radioKeyboardEnter;
        private System.Windows.Forms.RadioButton radioKeyboardFunc;
        private System.Windows.Forms.RadioButton radioKeyboardChar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxMediaKeycode;
        private System.Windows.Forms.RadioButton radioMediaKeycode;
        private System.Windows.Forms.RadioButton radioMediaMute;
        private System.Windows.Forms.RadioButton radioMediaPlay;
        private System.Windows.Forms.TextBox textBoxMouseY;
        private System.Windows.Forms.TextBox textBoxMouseX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkMouseRight;
        private System.Windows.Forms.CheckBox checkMouseMiddle;
        private System.Windows.Forms.CheckBox checkMouseLeft;
        private System.Windows.Forms.TextBox textBoxKeyboardKeycode;
        private System.Windows.Forms.RadioButton radioKeyboardEsc;
        private System.Windows.Forms.RadioButton radioKeyboardTab;
        private System.Windows.Forms.TextBox textBoxKeyboardFunc;
        private System.Windows.Forms.TextBox textBoxKeyboardChar;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusError;
        private System.Windows.Forms.Button button1;
    }
}

