using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;

namespace favUtil
{

    public partial class Form1 : Form
    {
        const int REPORT_PAYLOAD_SIZE = 63;
        const byte REPORT_ID = 4;
        const byte QUEUE_READ = 1;
        const byte QUEUE_WRITE = 2;
        const byte QUEUE_DUMP = 3;

        const byte KEYBOARD_ATTRIBUTE_ALT = 0x4;
        const byte KEYBOARD_ATTRIBUTE_CTRL = 0x1;
        const byte KEYBOARD_ATTRIBUTE_SHIFT = 0x2;

        const byte MOUSE_BUTTON_LEFT = 0x1;
        const byte MOUSE_BUTTON_MIDDLE = 0x4;
        const byte MOUSE_BUTTON_RIGHT = 0x2;

        const byte MEDIA_PLAY = 0x8;
        const byte MEDIA_MUTE = 0x10;

        const byte REPORT_ID_KEYBOARD = 1;
        const byte REPORT_ID_MOUSE = 2;
        const byte REPORT_ID_MEDIA = 3;

        hidWrapper hid;
        hidReport report;

        ArrayList commandList = new ArrayList();

        class command
        {
            public byte length;
            public byte reportID;
            public byte[] data;
            public command()
            {
                length = 0;
                reportID = 0;
                data = new byte[8];
            }
        };

        private void disableDeviceRadio()
        {
            radioKeyboard.Enabled = false;
            radioMouse.Enabled = false;
            radioMedia.Enabled = false;
        }

        private void enableDeviceRadio()
        {
            radioKeyboard.Enabled = true;
            radioMouse.Enabled = true;
            radioMedia.Enabled = true;
        }

        private void disableControlKeyboard()
        {
            checkKeyboardAlt.Enabled = false;
            checkKeyboardCtrl.Enabled = false;
            checkKeyboardShift.Enabled = false;
            radioKeyboardChar.Enabled = false;
            radioKeyboardFunc.Enabled = false;
            radioKeyboardKeycode.Enabled = false;
            radioKeyboardEnter.Enabled = false;
            radioKeyboardTab.Enabled = false;
            radioKeyboardEsc.Enabled = false;
            textBoxKeyboardChar.Enabled = false;
            textBoxKeyboardFunc.Enabled = false;
            textBoxKeyboardKeycode.Enabled = false;
        }

        private void enableControlKeyboard()
        {
            checkKeyboardAlt.Enabled = true;
            checkKeyboardCtrl.Enabled = true;
            checkKeyboardShift.Enabled = true;
            radioKeyboardChar.Enabled = true;
            radioKeyboardFunc.Enabled = true;
            radioKeyboardKeycode.Enabled = true;
            radioKeyboardEnter.Enabled = true;
            radioKeyboardTab.Enabled = true;
            radioKeyboardEsc.Enabled = true;
            textBoxKeyboardChar.Enabled = true;
            textBoxKeyboardFunc.Enabled = true;
            textBoxKeyboardKeycode.Enabled = true;

            checkKeyboardAlt.Checked = false;
            checkKeyboardCtrl.Checked = false;
            checkKeyboardShift.Checked = false;
            radioKeyboardChar.Checked = true;
        }

        private void disableControlMouse()
        {
            checkMouseLeft.Enabled = false;
            checkMouseMiddle.Enabled = false;
            checkMouseRight.Enabled = false;
            textBoxMouseX.Enabled = false;
            textBoxMouseY.Enabled = false;
        }

        private void enableControlMouse()
        {
            checkMouseLeft.Enabled = true;
            checkMouseMiddle.Enabled = true;
            checkMouseRight.Enabled = true;
            textBoxMouseX.Enabled = true;
            textBoxMouseY.Enabled = true;

            checkMouseLeft.Checked = false;
            checkMouseMiddle.Checked = false;
            checkMouseRight.Checked = false;
            textBoxMouseX.Text = "0";
            textBoxMouseY.Text = "0";
        }

        private void disableControlMedia()
        {
            radioMediaPlay.Enabled = false;
            radioMediaMute.Enabled = false;
            radioMediaKeycode.Enabled = false;
        }

        private void enableControlMedia()
        {
            radioMediaPlay.Enabled = true;
            radioMediaMute.Enabled = true;
            radioMediaKeycode.Enabled = true;
            radioMediaPlay.Checked = true;
            textBoxMediaKeycode.Enabled = true;
        }

        private void disableControlAll()
        {
            radioKeyboard.Checked = false;
            radioMouse.Checked = false;
            radioMedia.Checked = false;
            disableControlKeyboard();
            disableControlMouse();
            disableControlMedia();
            textBoxMediaKeycode.Enabled = false;
        }


        private void refreshDeviceList()
        {
            if( hid != null )
            {
                hid.Dispose();
            }
            hid = new hidWrapper(0x1FC9, 0x80BA);

            comboBoxDevices.Items.Clear();
            listBoxDevices.Items.Clear();
            if(hid.length==0)
            {
                toolStripStatusLabel.Text = "ふぁぼボタンが見つかりません";
                buttonWrite.Enabled = false;
                return;
            }
            toolStripStatusLabel.Text = hid.length + "個のふぁぼボタンを検出しました";
            buttonWrite.Enabled = true;

            for(int i=0;i<hid.length;i++)
            {
                comboBoxDevices.Items.Add(i);
            }

            if (comboBoxDevices.Items.Count > 0)
            {
                comboBoxDevices.SelectedIndex = 0;
            }
        }

        private void refreshListBox()
        {
            int index = listBoxDevices.SelectedIndex;
            listBoxDevices.Items.Clear();
            for (int i = 0; i < commandList.Count; i++)
            {
                if (((command)commandList[i]).reportID == REPORT_ID_KEYBOARD)
                {
                    listBoxDevices.Items.Add(i + " Keyboard");
                }
                else if (((command)commandList[i]).reportID == REPORT_ID_MOUSE)
                {
                    listBoxDevices.Items.Add(i + " Mouse");
                }
                else if (((command)commandList[i]).reportID == REPORT_ID_MEDIA)
                {
                    listBoxDevices.Items.Add(i + " Media");
                }
            }
            listBoxDevices.Enabled = true;
            listBoxDevices.SelectedIndex = index;
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonRefreash_Click(object sender, EventArgs e)
        {
            refreshDeviceList();
            if(listBoxDevices.Items.Count>0)
            {
                listBoxDevices.SelectedIndex = 0;
            }
        }

        private void parseReport(hidReport report)
        {
            commandList.Clear();
            for(int i=1;i<REPORT_PAYLOAD_SIZE;i+=10)
            {
                command temp = new command();
                for (int j = 0; j < 10; j++)
                {
                    if (j==0)
                    {
                        temp.length = (byte)report.data[i+j];
                        if( temp.length== 0 )
                        {
                            return;
                        }
                    }
                    else if(j==1)
                    {
                        temp.reportID = (byte)report.data[i+j];
                    }
                    else
                    {
                        temp.data[j - 2] = (byte)report.data[i+j];
                    }
                }
                commandList.Add(temp);
            }
        }

        private void comboBoxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            report = new hidReport(REPORT_PAYLOAD_SIZE + 1);
            report.data[0] = REPORT_ID;
            report.data[1] = QUEUE_READ;
            uint size = hid.devices[comboBoxDevices.SelectedIndex].sendReport(report);
            if(size==0)
            {
                MessageBox.Show("データ取得要求の送信に失敗しました");
                return;
            }

            size = hid.devices[comboBoxDevices.SelectedIndex].getReport(ref report);
            if (size == 0)
            {
                MessageBox.Show("データ取得に失敗しました");
                return;
            }

            parseReport(report);
            refreshListBox();
            buttonAdd.Enabled = true;
        }

        private void listBoxDevices_SelectedValueChanged(object sender, EventArgs e)
        {
            if(listBoxDevices.Items.Count<1)
            {
                return;
            }
            if (listBoxDevices.SelectedIndex<0)
            {
                return;
            }
            disableControlAll();
            enableDeviceRadio();
            if(listBoxDevices.Items.Count<6)
            {
                buttonAdd.Enabled = true;
            }
            else
            {
                buttonAdd.Enabled = false;
            }
            if(listBoxDevices.Items.Count>1)
            {
                buttonDel.Enabled = true;
            }
            else
            {
                buttonDel.Enabled = false;
            }
            if( ((command)commandList[listBoxDevices.SelectedIndex]).reportID == REPORT_ID_KEYBOARD )
            {
                // Keyboard
                radioKeyboard.Checked = true;
                if ((((command)commandList[listBoxDevices.SelectedIndex]).data[0] & KEYBOARD_ATTRIBUTE_ALT) == KEYBOARD_ATTRIBUTE_ALT)
                {
                    checkKeyboardAlt.Checked = true;
                }
                else
                {
                    checkKeyboardAlt.Checked = false;
                }
                if ((((command)commandList[listBoxDevices.SelectedIndex]).data[0] & KEYBOARD_ATTRIBUTE_SHIFT) == KEYBOARD_ATTRIBUTE_SHIFT)
                {
                    checkKeyboardShift.Checked = true;
                }
                else
                {
                    checkKeyboardShift.Checked = false;
                }
                if ((((command)commandList[listBoxDevices.SelectedIndex]).data[0] & KEYBOARD_ATTRIBUTE_CTRL) == KEYBOARD_ATTRIBUTE_CTRL)
                {
                    checkKeyboardCtrl.Checked = true;
                }
                else
                {
                    checkKeyboardCtrl.Checked = false;
                }
                if( ((command)commandList[listBoxDevices.SelectedIndex]).data[2] >=4 && ((command)commandList[listBoxDevices.SelectedIndex]).data[2] <= 29 )
                {
                    // ascii
                    int temp = ((command)commandList[listBoxDevices.SelectedIndex]).data[2] - 4 + 'A';
                    textBoxKeyboardChar.Text = ((char)temp).ToString();
                    radioKeyboardChar.Checked = true;
                }
                else if (((command)commandList[listBoxDevices.SelectedIndex]).data[2] >= 58 && ((command)commandList[listBoxDevices.SelectedIndex]).data[2] <= 69)
                {
                    // func
                    int temp = ((command)commandList[listBoxDevices.SelectedIndex]).data[2] - 57;
                    textBoxKeyboardFunc.Text = "F" + temp.ToString();
                    radioKeyboardFunc.Checked = true;
                }
                else if (((command)commandList[listBoxDevices.SelectedIndex]).data[2] == 40)
                {
                    // Enter
                    radioKeyboardEnter.Checked = true;
                }
                else if (((command)commandList[listBoxDevices.SelectedIndex]).data[2] == 43)
                {
                    // Tab
                    radioKeyboardTab.Checked = true;
                }
                else if (((command)commandList[listBoxDevices.SelectedIndex]).data[2] == 41)
                {
                    // Esc
                    radioKeyboardEsc.Checked = true;
                }
                else
                {
                    // Keycode
                    textBoxKeyboardKeycode.Text = ((command)commandList[listBoxDevices.SelectedIndex]).data[2].ToString();
                    radioKeyboardKeycode.Checked = true;
                }
            }
            else if (((command)commandList[listBoxDevices.SelectedIndex]).reportID == REPORT_ID_MOUSE)
            {
                // Mouse
                radioMouse.Checked = true;
                if ((((command)commandList[listBoxDevices.SelectedIndex]).data[0] & MOUSE_BUTTON_LEFT) == MOUSE_BUTTON_LEFT)
                {
                    checkMouseLeft.Checked = true;
                }
                else
                {
                    checkMouseLeft.Checked = false;
                }
                if ((((command)commandList[listBoxDevices.SelectedIndex]).data[0] & MOUSE_BUTTON_MIDDLE) == MOUSE_BUTTON_MIDDLE)
                {
                    checkMouseMiddle.Checked = true;
                }
                else
                {
                    checkMouseMiddle.Checked = false;
                }
                if ((((command)commandList[listBoxDevices.SelectedIndex]).data[0] & MOUSE_BUTTON_RIGHT) == MOUSE_BUTTON_RIGHT)
                {
                    checkMouseRight.Checked = true;
                }
                else
                {
                    checkMouseRight.Checked = false;
                }
                textBoxMouseX.Text = ((sbyte)(((command)commandList[listBoxDevices.SelectedIndex]).data[1])).ToString();
                textBoxMouseY.Text = ((sbyte)(((command)commandList[listBoxDevices.SelectedIndex]).data[2])).ToString();
            }
            else if (((command)commandList[listBoxDevices.SelectedIndex]).reportID == REPORT_ID_MEDIA)
            {
                // Media control device
                radioMedia.Checked = true;
                if ((((command)commandList[listBoxDevices.SelectedIndex]).data[0] & MEDIA_PLAY) == MEDIA_PLAY)
                {
                    radioMediaPlay.Checked = true;
                }
                else if ((((command)commandList[listBoxDevices.SelectedIndex]).data[0] & MEDIA_MUTE) == MEDIA_MUTE)
                {
                    radioMediaMute.Checked = true;
                }
                else
                {
                    radioMediaKeycode.Checked = true;
                }
            }
        }

        private void radioKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (radioKeyboard.Checked == true)
            {
                enableControlKeyboard();
            }
            else
            {
                disableControlKeyboard();
            }
        }

        private void radioMouse_CheckedChanged(object sender, EventArgs e)
        {
            if(radioMouse.Checked == true)
            {
                enableControlMouse();
            }
            else
            {
                disableControlMouse();
            }
        }

        private void radioMedia_CheckedChanged(object sender, EventArgs e)
        {
            if(radioMedia.Checked == true)
            {
                enableControlMedia();
            }
            else
            {
                disableControlMedia();
            }
        }

        private void buttonApply(object sender, EventArgs e)
        {
            if(radioKeyboard.Checked == true)
            {
                ((command)commandList[listBoxDevices.SelectedIndex]).reportID = REPORT_ID_KEYBOARD;
                ((command)commandList[listBoxDevices.SelectedIndex]).length = 8;
                ((command)commandList[listBoxDevices.SelectedIndex]).data[0] = 0;
                if (checkKeyboardAlt.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[0] |= KEYBOARD_ATTRIBUTE_ALT;
                }
                if (checkKeyboardCtrl.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[0] |= KEYBOARD_ATTRIBUTE_CTRL;
                }
                if (checkKeyboardShift.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[0] |= KEYBOARD_ATTRIBUTE_SHIFT;
                }
                ((command)commandList[listBoxDevices.SelectedIndex]).data[1] = 0;
                if (radioKeyboardChar.Checked == true)
                {
                    char[] chararray = textBoxKeyboardChar.Text.ToUpper().ToCharArray();
                    textBoxKeyboardChar.Text = chararray[0].ToString();
                    int temp = chararray[0];
                    temp = temp - (byte)'A' + 4;
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[2] = (byte)temp;
                }
                else if (radioKeyboardFunc.Checked == true)
                {
                    int temp = 0;
                    char[] chararray = textBoxKeyboardFunc.Text.ToUpper().ToCharArray();
                    try
                    {
                        if (chararray[0] == 'F')
                        {
                            temp = int.Parse(textBoxKeyboardFunc.Text.Substring(1));
                        }
                        else
                        {
                            temp = int.Parse(textBoxKeyboardFunc.Text);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("ファンクションキーの入力が正しくありません");
                        return;
                    }
                    temp += 57;
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[2] = (byte)temp;
                }
                else if (radioKeyboardKeycode.Checked == true)
                {
                    int temp = 0;
                    try
                    {
                        temp = int.Parse(textBoxKeyboardKeycode.Text);
                    }
                    catch
                    {
                        MessageBox.Show("キーコードの入力が正しくありません");
                        return;
                    }
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[2] = (byte)temp;
                }
                else if (radioKeyboardEnter.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[2] = 40;
                }
                else if (radioKeyboardTab.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[2] = 43;
                }
                else if (radioKeyboardEsc.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[2] = 41;
                }
            }
            else if(radioMouse.Checked == true)
            {
                ((command)commandList[listBoxDevices.SelectedIndex]).reportID = REPORT_ID_MOUSE;
                ((command)commandList[listBoxDevices.SelectedIndex]).length = 4;
                ((command)commandList[listBoxDevices.SelectedIndex]).data[0] = 0;
                if (checkMouseLeft.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[0] |= MOUSE_BUTTON_LEFT;
                }
                if (checkMouseMiddle.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[0] |= MOUSE_BUTTON_MIDDLE;
                }
                if (checkMouseRight.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[0] |= MOUSE_BUTTON_RIGHT;
                }
                try
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[1] = (byte)sbyte.Parse(textBoxMouseX.Text);
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[2] = (byte)sbyte.Parse(textBoxMouseY.Text);
                }
                catch
                {
                    MessageBox.Show("移動量の値が正しくありません");
                    return;
                }
            }
            else if(radioMedia.Checked == true)
            {
                ((command)commandList[listBoxDevices.SelectedIndex]).reportID = REPORT_ID_MEDIA;
                ((command)commandList[listBoxDevices.SelectedIndex]).length = 2;
                if(radioMediaPlay.Checked==true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[0] = MEDIA_PLAY;
                }
                else if (radioMediaMute.Checked == true)
                {
                    ((command)commandList[listBoxDevices.SelectedIndex]).data[0] = MEDIA_MUTE;
                }
                else if (radioMediaKeycode.Checked == true)
                {
                    try
                    {
                        ((command)commandList[listBoxDevices.SelectedIndex]).data[0] = byte.Parse(textBoxMediaKeycode.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Keycodeの値が正しくありません");
                        return;
                    }
                }
            }

            refreshListBox();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            command temp = new command();
            temp.reportID = REPORT_ID_KEYBOARD;
            temp.length = 8;
            commandList.Add(temp);
            refreshListBox();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (listBoxDevices.SelectedIndex > 0)
            {
                listBoxDevices.SelectedIndex -= 1;
            }
            commandList.RemoveAt(listBoxDevices.SelectedIndex);
            refreshListBox();
        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            report = new hidReport(REPORT_PAYLOAD_SIZE + 1);
            report.data[0] = REPORT_ID;
            report.data[1] = QUEUE_WRITE;

            // 送信データの組み立て
            for(int i=0;i<commandList.Count;i++)
            {
                for(int j=0;j<10;j++)
                {
                    if(j==0)
                    {
                        report.data[i*10 + j+2] = ((command)commandList[i]).length;
                    }
                    else if (j == 1)
                    {
                        report.data[i*10 + j+2] = ((command)commandList[i]).reportID;
                    }
                    else
                    {
                        report.data[i*10 + j+2] = ((command)commandList[i]).data[j-2];
                    }
                }
            }

            uint size = hid.devices[comboBoxDevices.SelectedIndex].sendReport(report);
            if (size == 0)
            {
                MessageBox.Show("データ送信に失敗しました");
                return;
            }
            size = hid.devices[comboBoxDevices.SelectedIndex].getReport(ref report);
            if (size == 0)
            {
                MessageBox.Show("書込結果の受信に失敗しました");
                return;
            }
            if(report.data[1]==0)
            {
                MessageBox.Show("書き込みに成功しました");
            }
            else
            {
                MessageBox.Show("書き込みに失敗しました");
            }
        }
    }
}
